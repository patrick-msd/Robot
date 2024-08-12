namespace RC.Lib.PowerSupply
{
    public partial class Nextys_DcDcConverter
    {
        #region Global variables
        // DB link
        private Guid? _IdDb = null;
        public Guid? IdDb { get { return _IdDb; } set { _IdDb = value; } }

        // ....
        private NextysModbusClient _client;

        public bool IsConnected { get { return _client.IsOpen; } }

        private bool _serialPortBusy { get; set; }
        public int _serialPortRetrySending { get; set; }

        public int _maxOutputVoltage { get; set; }
        public int _minOutputVoltage { get; set; }

        public int _maxOutputCurrent { get; set; }
        public int _minOutputCurrent { get; set; }

        private System.Timers.Timer? _timer;
        public event Action<MonitoringObject> Monitoring;
        #endregion

        public Nextys_DcDcConverter(string portName = "COM1", int baudRate = 38400, System.IO.Ports.Parity parity = System.IO.Ports.Parity.Even, System.IO.Ports.StopBits stopBit = System.IO.Ports.StopBits.One, System.IO.Ports.Handshake handshake = System.IO.Ports.Handshake.None, int readTimeout = 1000, int writeTimeout = 1000, int interval = 10000, int serialPortRetrySending = 10)
        {
            _client = new NextysModbusClient(portName, baudRate, parity, stopBit, handshake, readTimeout, writeTimeout, 0x01, interval);

            _serialPortRetrySending = serialPortRetrySending;

            // Get Modbus address
            //ModusAddress = GetModbusAddress();

            // Create a timer with a one second interval
            if (interval >= 2500)
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
        /// Connect device
        /// </summary>
        public void Connect()
        {
            if (_client != null)
            {
                if (_client.Connected)
                {
                    _client.Disconnect();
                }

                _client.Connect();
            }
        }

        /// <summary>
        /// Disconnect device
        /// </summary>
        public void Disconnect()
        {
            try
            {
                if (_client != null)
                {
                    if (_client.Connected)
                    {
                        _client.Disconnect();
                    }
                }

                //_client = null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Enable Output
        /// </summary>
        public void OutputEnable()
        {
            SetOutput(NextysOutputEnable.Enable);
        }

        /// <summary>
        /// Disable Output
        /// </summary>
        public void OutputDisable()
        {
            SetOutput(NextysOutputEnable.Disable);
        }

        #region Settings
        /// <summary>
        /// Get modbus address
        /// </summary>
        /// <returns>Modbus address</returns>
        public ushort GetModbusAddress()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.ModbusAddress, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        return (ushort)(response[0] * 100);
                    }

                    Thread.Sleep(15);
                }

                return 0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set nominal output voltage [mV]
        /// </summary>
        /// <param name="voltage">Voltage [mV]</param>
        public bool SetNominalOutputVoltage(int voltage)
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        _client?.WriteSingleRegister((int)NextysModbusRegister.NominalOutputVoltage, Math.Clamp(voltage, _minOutputVoltage, _maxOutputVoltage) / 10);

                        _serialPortBusy = false;

                        return true;
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>a
        /// Get nominal output voltage [mV]
        /// </summary>
        /// <returns>Voltage [mV]</returns>
        public double GetNominalOutputVoltage()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.NominalOutputVoltage, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        return (double)(response[0] * 10);
                    }

                    Thread.Sleep(15);
                }

                return -1.0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set output maximal current [mA]
        /// </summary>
        /// <param name="current">Current [mA]</param>
        public bool SetMaximalOutputCurrent(int current)
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        _client?.WriteSingleRegister((int)NextysModbusRegister.MaximalOutputCurrent, Math.Clamp(current, _minOutputCurrent, _maxOutputCurrent) / 100);

                        _serialPortBusy = false;

                        return true;
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get output maximal current [mA]
        /// </summary>
        /// <returns>Current [mA]</returns>
        public double GetMaximalOutputCurrent()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.MaximalOutputCurrent, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        return (double)(response[0] * 100);
                    }

                    Thread.Sleep(15);
                }

                return -1.0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Set current limitation
        /// </summary>
        /// <param name="value">Hiccup, Constant current<</param>
        public bool SetOperatingMode(NextysOperationMode value)
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        _client?.WriteSingleRegister((int)NextysModbusRegister.OperatingMode, (int)value);

                        _serialPortBusy = false;

                        return true;
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        /// <summary>
        /// Get current limitation
        /// </summary>
        /// <returns>Hiccup, Constant current</returns>
        public NextysOperationMode GetOperatingMode()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.OperatingMode, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] > 0)
                        {
                            return NextysOperationMode.Single;
                        }
                        else
                        {
                            return NextysOperationMode.Parallel;
                        }
                    }

                    Thread.Sleep(15);
                }

                return NextysOperationMode.Single;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        /// <summary>
        /// Set current limitation
        /// </summary>
        /// <param name="value">Hiccup, Constant current<</param>
        public bool SetCurrentLimitation(NextysCurrentLimitation value)
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        _client?.WriteSingleRegister((int)NextysModbusRegister.CurrentLimitation, (int)value);

                        _serialPortBusy = false;

                        return true;
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get current limitation
        /// </summary>
        /// <returns>Hiccup, Constant current</returns>
        public NextysCurrentLimitation GetCurrentLimitation()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.CurrentLimitation, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] > 0)
                        {
                            return NextysCurrentLimitation.Hiccup;
                        }
                        else
                        {
                            return NextysCurrentLimitation.ConstantCurrent;
                        }

                    }

                    Thread.Sleep(15);
                }

                return NextysCurrentLimitation.ConstantCurrent;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set outut enable
        /// </summary>
        /// <param name="value">True / False</param>
        public bool SetOutput(NextysOutputEnable value)
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        _client?.WriteSingleRegister((int)NextysModbusRegister.OutputEnable, Convert.ToInt32(value));

                        _serialPortBusy = false;

                        return true;
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get outut enable
        /// </summary>
        /// <returns>True / False</returns>
        public NextysOutputEnable GetOutputEnable()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.OutputEnable, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == 0)
                        {
                            return NextysOutputEnable.Disable;
                        }
                        else
                        {
                            return NextysOutputEnable.Enable;
                        }
                    }

                    Thread.Sleep(15);
                }

                return NextysOutputEnable.Disable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Set lock settings
        /// </summary>
        /// <param name="value">True / False</param>
        public bool SetLockSettings(NextysLockSettings value)
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        _client?.WriteSingleRegister((int)NextysModbusRegister.LockSettings, Convert.ToUInt16(value));

                        _serialPortBusy = false;

                        return true;
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get lock settings
        /// </summary>
        /// <returns>True / False</returns>
        public NextysLockSettings GetLockSettings()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.LockSettings, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] > 0)
                        {
                            return NextysLockSettings.Enable;
                        }
                        else
                        {
                            return NextysLockSettings.Disable;
                        }
                    }

                    Thread.Sleep(15);
                }

                return NextysLockSettings.Disable;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Metering
        /// <summary>
        /// Get output voltage [mV]
        /// </summary>
        /// <returns>Voltage [mV]</returns>
        public double GetOutputVoltage()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.OutputVoltage, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        return (double)(response[0] * 100);
                    }

                    Thread.Sleep(15);
                }

                return -1.0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get output current [mA]
        /// </summary>
        /// <returns>Current [mA]</returns>
        public double GetOutputCurrent()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.OutputCurrent, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        return (double)(response[0] * 100);
                    }

                    Thread.Sleep(15);
                }

                return -1.0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Output Power [mW]
        /// </summary>
        /// <returns>Power [mW]</returns>
        public double GetOutputPower()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.OutputPower, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        return (double)(response[0] * 100);
                    }

                    Thread.Sleep(15);
                }

                return -1.0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get Input Voltage [mV]
        /// </summary>
        /// <returns>Voltage [mV]</returns>
        public double GetInputVoltage()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<int> response = _client.ReadInputRegisters((int)NextysModbusRegister.InputVoltage, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        return (double)(response[0] * 100);
                    }

                    Thread.Sleep(15);
                }

                return -1.0;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region State
        /// <summary>
        /// Get DC OK
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetDcOk()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.DcOk, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get output disable
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetOutputDisabled()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.OutputDisable, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get output short circuit
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetOutputShortCircuit()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.OutputShortCircuit, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get output overload
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetOutputOverload()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.OutputOverload, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get USB powered
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetUsbPowered()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.UsbPowered, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get over temperature warning
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetOverTemperatureWarning()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.OverTemperatureWarning, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get over temperature error
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetOverTemperatureError()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.OverTemperatureError, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Get output over voltage error
        /// </summary>
        /// <returns>True / False</returns>
        public bool GetOutputOverVoltageError()
        {
            try
            {
                for (int r = 0; r < _serialPortRetrySending; r++)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        _serialPortBusy = true;

                        Span<bool> response = _client.ReadCoils((int)NextysModbusRegister.OutputOverVoltageError, 1);
                        response.Reverse();

                        _serialPortBusy = false;

                        if (response[0] == true)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                    Thread.Sleep(15);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion

        #region Timed event
        private void OnTimedEvent(object source, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                if (Monitoring != null)
                {
                    if (_client != null && _serialPortBusy == false)
                    {
                        MonitoringObject tmp = new MonitoringObject();

                        //tmp.ModusAddress = GetModbusAddress();                            // Takes too long
                        tmp.MaximalOutputCurrent = GetMaximalOutputCurrent() / 1000;
                        tmp.NominalOutputVoltage = GetNominalOutputVoltage() / 1000;
                        tmp.OutputVoltage = GetOutputVoltage() / 1000;
                        tmp.OutputCurrent = GetOutputCurrent() / 1000;
                        tmp.OutputPower = GetOutputPower() / 1000;
                        tmp.InputVoltage = GetInputVoltage() / 1000;
                        tmp.DcOk = GetDcOk();
                        tmp.OutputDisabled = GetOutputDisabled();
                        tmp.OutputShortCircuit = GetOutputShortCircuit();
                        tmp.OutputOverload = GetOutputOverload();
                        tmp.UsbPowered = GetUsbPowered();
                        tmp.OverTemperatureWarning = GetOverTemperatureWarning();
                        tmp.OverTemperatureError = GetOverTemperatureError();
                        tmp.OutputOverVoltageError = GetOutputOverVoltageError();

                        // Raise event and pass data
                        Monitoring(tmp);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        #endregion
    }
}
