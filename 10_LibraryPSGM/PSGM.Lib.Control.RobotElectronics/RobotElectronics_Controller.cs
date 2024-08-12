using System.Net;
using System.Net.Sockets;

namespace RC.Lib.Control.RobotElectronics
{
    public partial class RobotElectronics_Controller
    {
        #region Global variables
        // DB link
        private Guid? _IdDb = null;
        public Guid? IdDb { get { return _IdDb; } set { _IdDb = value; } }

        // TCP connection
        private TcpClient? _tcpClient;

        private string? _ipAddress;
        public string IpAddress { get { return _ipAddress; } }

        private int _port;
        public int Port { get { return _port; } }

        private bool _connected;
        public bool Connected { get { return _connected; } }

        private int _connectionTimeout;
        public int ConnectionTimeout { get { return _connectionTimeout; } }

        private byte[]? receiveData;
        private byte[]? sendData;

        private bool debug = false;

        private bool udpFlag = false;

        public delegate void ReceiveDataChangedHandler(object sender);
        public event ReceiveDataChangedHandler? ReceiveDataChanged;

        public delegate void SendDataChangedHandler(object sender);
        public event SendDataChangedHandler? SendDataChanged;

        public delegate void ConnectedChangedHandler(object sender);
        public event ConnectedChangedHandler? ConnectedChanged;

        NetworkStream? stream;

        private System.Timers.Timer? _timer;
        public event Action<MonitoringObject>? Monitoring;
        #endregion 

        public RobotElectronics_Controller(string ipAddress = "172.0.0.1, ", int port = 0, int connectionTimeout = 1000, int interval = 500)
        {
            _ipAddress = ipAddress;
            _port = port;

            _connectionTimeout = connectionTimeout;


            // Get Modbus address
            //ModusAddress = GetModbusAddress();

            // Create a timer with a one second interval
            if (interval >= 500)
            {
                _timer = new System.Timers.Timer(interval);
            }
            else
            {
                _timer = new System.Timers.Timer(2500);
            }

            // Hook up the Elapsed event for the timer
            _timer.Elapsed += OnTimedEvent;
            _timer.AutoReset = true;
            _timer.Enabled = true;
        }


        /// <summary>
        /// Establish connection to Master device in case of Modbus TCP.
        /// </summary>
        public void Connect()
        {
            if (!udpFlag)
            {
                //if (debug) StoreLogData.Instance.Store("Open TCP-Socket, IP-Address: " + ipAddress + ", Port: " + port, System.DateTime.UtcNow);
                _tcpClient = new TcpClient();
                var result = _tcpClient.BeginConnect(_ipAddress, _port, null, null);
                var success = result.AsyncWaitHandle.WaitOne(_connectionTimeout);
                if (!success)
                {
                    //throw new EasyModbus.Exceptions.ConnectionException("connection timed out");
                }
                _tcpClient.EndConnect(result);

                //tcpClient = new TcpClient(ipAddress, port);
                stream = _tcpClient.GetStream();
                stream.ReadTimeout = _connectionTimeout;
                _connected = true;
            }
            else
            {
                _tcpClient = new TcpClient();
                _connected = true;
            }

            if (ConnectedChanged != null)
            {
                ConnectedChanged(this);
            }
        }

        /// <summary>
        /// Establish connection to Master device in case of Modbus TCP.
        /// </summary>
        public void Disconnect()
        {
            if (_connected)
            {
                if (!udpFlag)
                {
                    stream.Close();
                    _tcpClient.Close();

                    _connected = false;
                }
                else
                {
                    _tcpClient.Close();

                    _connected = false;
                }

                if (ConnectedChanged != null)
                {
                    ConnectedChanged(this);
                }
            }
        }






        public byte[] SendCommand(byte[] data)
        {
            if (_tcpClient == null & !udpFlag)
            {
                //if (debug) StoreLogData.Instance.Store("ConnectionException Throwed", System.DateTime.UtcNow);
                //throw new EasyModbus.Exceptions.ConnectionException("connection error");
            }

            byte[] response;

            if (udpFlag)
            {
                UdpClient udpClient = new UdpClient();
                IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(_ipAddress), _port);
                udpClient.Send(data, data.Length, endPoint);
                int portOut = ((IPEndPoint)udpClient.Client.LocalEndPoint).Port;
                udpClient.Client.ReceiveTimeout = 5000;
                endPoint = new IPEndPoint(IPAddress.Parse(_ipAddress), portOut);
                data = udpClient.Receive(ref endPoint);
            }
            else
            {
                stream.Write(data, 0, data.Length);
                if (debug)
                {
                    byte[] debugData = new byte[data.Length];
                    //Array.Copy(data, 0, debugData, 0, data.Length );
                    //if (debug) StoreLogData.Instance.Store("Send ModbusTCP-Data: " + BitConverter.ToString(debugData), System.DateTime.UtcNow);
                }
                if (SendDataChanged != null)
                {
                    sendData = new byte[data.Length];
                    Array.Copy(data, 0, sendData, 0, data.Length);
                    SendDataChanged(this);
                }
                data = new Byte[2100];
                int NumberOfBytes = stream.Read(data, 0, data.Length);
                if (ReceiveDataChanged != null)
                {
                    receiveData = new byte[NumberOfBytes];
                    Array.Copy(data, 0, receiveData, 0, NumberOfBytes);
                    //if (debug) StoreLogData.Instance.Store("Receive ModbusTCP-Data: " + BitConverter.ToString(receiveData), System.DateTime.UtcNow);
                    ReceiveDataChanged(this);
                }
            }

            //response = new bool[quantity];
            //for (int i = 0; i < quantity; i++)
            //{
            //    int intData = data[9 + i / 8];
            //    int mask = Convert.ToInt32(Math.Pow(2, (i % 8)));
            //    response[i] = Convert.ToBoolean((intData & mask) / mask);
            //}

            string result = System.Text.Encoding.UTF8.GetString(data);

            return data;
        }







        /// <summary>
        /// This command returns 8 bytes of status data:
        /// Module ID This will be 30 (0x1E) for the dS2408
        /// System Firmware Major 2 for example
        /// System Firmware Minor 18 for example
        /// Application Firmware Major 1 for example
        /// Application Firmware Minor 2 for example
        /// Volts Power supply volts x 10. Example 125 is 12.5v
        /// Internal Temperature(high byte) x 10
        /// Internal Temperature(low byte) combined to 16 bits, 267 = 26.7 degrees C
        /// </summary>
        /// <returns>System Status.</returns>
        public Status GetStatus()
        {
            // 0x30 (decimal 48) Get Status (1 byte command, returning 8 bytes)
            byte[] response = SendCommand(new byte[] { (byte)Commands.GetStatus });

            Status status = new Status()
            {
                ModuleID = response[0],
                SystemFirmwareMajo = response[1],
                SystemFirmwareMinor = response[2],
                ApplicationFirmwareMajor = response[3],
                ApplicationFirmwareMinor = response[4],
                PowerSupplyVolt = (double)(Convert.ToDouble(response[5]) / 10),
                InternalTemperature = (double)(ByteArrayToDouble(new byte[] { response[6], response[7] }) / 10)
            };

            return status;
        }

        /// <summary>
        /// This command turns a relay on or off or pulses it for a time period and returns an ACK/NACKbyte.
        /// ACK=0, NACK=non-zero(actually the unknown relay number).
        /// </summary>
        /// <param name="relay">Relay number.</param>
        /// <param name="state">Turn relay on or off.</param>
        /// <param name="pulsTime">When >100 this pulses relay on for that number of mS.</param>
        /// <returns></returns>
        public void SetRelay(Relay relay, bool state, UInt32 pulsTime = 0)
        {
            byte[] pulseTimeByte = new byte[] { 0x00, 0x00, 0x00, 0x00 };

            if (pulsTime >= 100)
            {
                pulseTimeByte = BitConverter.GetBytes(pulsTime);
                Array.Reverse(pulseTimeByte);
            }

            //0x31 0x02 0x01 0x00 0x00 0x00 0x00 Set Relay (7 byte command, returning 1 byte)
            SendCommand(new byte[] { (byte)Commands.SetRelay, (byte)relay, Convert.ToByte(state), pulseTimeByte[0], pulseTimeByte[1], pulseTimeByte[2], pulseTimeByte[3] });
        }

        /// <summary>
        /// This command turns an output on or off and returns an ACK/NACK byte.
        /// ACK=0, NACK=nonzero(actually the unknown I/O port number).
        /// All I/O's which need to be inputs should have the output turned off.
        /// When turned on the NPN transistor can sink up to 100mA.
        /// </summary>
        /// <returns></returns>
        public void SetOutput(GPIO output, bool status)
        {
            //0x32 0x04 0x01 Set Output (3 byte command, returning 1 byte)
            SendCommand(new byte[] { (byte)Commands.SetOutput, (byte)output, Convert.ToByte(status) });
        }


        /// <summary>
        /// This command is used to get the states of the relays. The second byte is the relay number, relay 1 in this case.
        /// The first returned byte is the state of the requested relay, 0x00 (off) or 0x01 (on).
        /// The next four bytes pack the states of all 32 relays(virtual and actual relays).
        /// Bit 7 of byte 2 is relay 32 through to bit 0 of byte 5 which is relay 1.
        /// </summary>
        /// <param name="relay"#1>Relay number.</param>
        /// <returns></returns>
        public bool GetRelay(Relay relay)
        {
            // 0x33 0x01 Get Relay (2 byte command – returning 5 bytes)
            byte[] response = SendCommand(new byte[] { (byte)Commands.GetRelays, (byte)relay });

            return Convert.ToBoolean(response[0]);
        }

        /// <summary>
        /// This command is used to get the states of the relays. The second byte is the relay number, relay 1 in this case.
        /// The first returned byte is the state of the requested relay, 0x00 (off) or 0x01 (on).
        /// The next four bytes pack the states of all 32 relays(virtual and actual relays).
        /// Bit 7 of byte 2 is relay 32 through to bit 0 of byte 5 which is relay 1.
        /// </summary>
        /// <param name="relay"#1>Relay number.</param>
        /// <returns></returns>
        public bool[] GetAllRelays()
        {
            // 0x33 0x01 Get Relay (2 byte command – returning 5 bytes)
            byte[] response = SendCommand(new byte[] { (byte)Commands.GetRelays, 0x01 });

            return ConvertByteArrayToBoolArray(response.SubArray(1, 4));
        }

        /// <summary>
        /// This command is used to get the states of the inputs.The second byte is the input number, input 1 in this case.
        /// The first returned byte is the state of the requested input, 0x00 (inactive) or 0x01 (active)
        /// the 2nd to 6th bytes pack the states of all 40 inputs.If the bit is high the input is active.
        /// </summary>
        /// <param name="input">Input number.</param>
        /// <returns></returns>
        public bool GetInput(GPIO input)
        {
            // 0x34 0x01 Get Input (2 byte command – returning 6 bytes)
            byte[] response = SendCommand(new byte[] { (byte)Commands.GetInputs, (byte)input });

            return Convert.ToBoolean(response[0]);
        }

        /// <summary>
        /// This command is used to get the states of the inputs.The second byte is the input number, input 1 in this case.
        /// The first returned byte is the state of the requested input, 0x00 (inactive) or 0x01 (active)
        /// the 2nd to 6th bytes pack the states of all 40 inputs.If the bit is high the input is active.
        /// </summary>
        /// <returns></returns>
        public bool[] GetAllInput()
        {
            // 0x34 0x01 Get Input (2 byte command – returning 6 bytes)
            byte[] response = SendCommand(new byte[] { (byte)Commands.GetInputs, 0x01 });

            return ConvertByteArrayToBoolArray(response.SubArray(2, 4));
        }

        /// <summary>
        /// The dS2408 does not have analogue inputs.This command will return 4 values(8 bytes) which are meaningless.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public byte[] GetAnalogueInputs(Anaalog input)
        {
            // 0x35 Get Analogue inputs (1 byte command returning 8 bytes)
            byte[] response = SendCommand(new byte[] { (byte)Commands.GetAnalogue, (byte)input });

            return response;
        }

        /// <summary>
        /// This command is used to get the counters.The second byte is the counter number, counter 1 in this case.
        /// The first 4 bytes returned is the current counter value.This 32-bit (4 bytes) value is returned
        /// high byte first.The second group of 4 bytes returned is the capture register for this counter,
        /// also a 32-bit (4 byte) value returned high byte first.
        /// </summary>
        /// <returns></returns>
        public uint[] GetCounter()
        {
            // 0x36 0x01 Get Counters (2 byte command – returning 8 bytes)
            byte[] response = SendCommand(new byte[] { (byte)Commands.GetCounters });

            return ConvertByteArrayToCounter(response.SubArray(0, 8));
        }

        /// <summary>
        /// This command is used to update all relays with one command returning an ACK/NACK byte.
        /// ACK=0, NACK=non-zero.If a bit is high(1), the corresponding relay will be turned on.If a bit
        /// is low(0) the corresponding relay will be turned off.This command therefore affects all relays.
        /// The bit order is the same as the Get Relay command.
        /// </summary>
        /// <param name="value">Value to set the Relays.</param>
        /// <returns></returns>
        public byte[] UpdateAllRelays(bool[] value)
        {
            byte[] byteValues = ConvertBoolArrayToByteArray(value);

            // 0x37 0xnn 0xnn 0xnn 0xnn Update all relays(5 byte command returning 1 byte)
            byte[] response = SendCommand(new byte[] { (byte)Commands.UpdateAllRelays, byteValues[3], byteValues[2], byteValues[1], byteValues[0] });

            return response;
        }

        /// <summary>
        /// Set only those relays with a corresponding high in the bit pattern returning an ACK/NACK byte.
        /// ACK=0, NACK=non-zero.Same bit order as command 0x37 above.
        /// Relays with a corresponding low(0) are NOT affected and remain on/off as previously set.
        /// </summary>
        ///  <param name="value">Value to set the Relays.</param>
        /// <returns></returns>
        public byte[] SetSelectedRelays(bool[] value)
        {
            byte[] byteValues = ConvertBoolArrayToByteArray(value);

            // 0x38 0xnn 0xnn 0xnn 0xnn Set selected relays (5 byte command returning 1 byte)
            byte[] response = SendCommand(new byte[] { (byte)Commands.SetSelectedRelays, byteValues[3], byteValues[2], byteValues[1], byteValues[0] });

            return response;
        }

        /// <summary>
        /// Clears only those relays with a corresponding high in the bit pattern returning an ACK/NACK
        /// byte. ACK=0, NACK=non-zero.Same bit order as command 0x37 above.
        /// Relays with a corresponding low(0) are NOT affected and remain on/off as previously set.
        /// </summary>
        /// <param name="value">Value to set the Relays.</param>
        /// <returns></returns>
        public byte[] ClearSelectedRelays(bool[] value)
        {
            byte[] byteValues = ConvertBoolArrayToByteArray(value);

            // 0x39 0xnn 0xnn 0xnn 0xnn Clear selected relays (5 byte command returning 1 byte)
            byte[] response = SendCommand(new byte[] { (byte)Commands.ClearSelectedRelays, byteValues[3], byteValues[2], byteValues[1], byteValues[0] });

            return response;
        }











        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (Monitoring != null)
                {
                    MonitoringObject tmp = new MonitoringObject();

                    //tmp.DigitalOutput = GetMaximalOutputCurrent() / 1000;
                    //tmp.DigitalInput = GetNominalOutputVoltage() / 1000;
                    //tmp.AnalogOutput = GetOutputVoltage() / 1000;
                    //tmp.AnalogInput = GetOutputCurrent() / 1000;

                    // Raise event and pass data
                    Monitoring(tmp);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
