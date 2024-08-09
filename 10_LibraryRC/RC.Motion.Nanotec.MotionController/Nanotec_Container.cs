using Nlc;
using Serilog;

namespace RC.Lib.Motion
{
    /// <summary>
    /// Callback class derived from Nlc.NlcScanBusCallback.
    /// </summary>
    public class ScanBusCallback : Nlc.NlcScanBusCallback // override
    {
        /// <summary>
        /// Callback used in bus scanning.
        /// </summary>
        /// <param name="info">Scan process state</param>
        /// <param name="devicesFound">Devices found so far</param>
        /// <param name="data">Optional data, meaning depends on info.</param>
        /// <returns></returns>
        public override Nlc.ResultVoid callback(Nlc.BusScanInfo info, Nlc.DeviceIdVector devicesFound, int data)
        {
            switch (info)
            {
                case Nlc.BusScanInfo.Start:
                    Console.WriteLine("Scan started.");
                    break;

                case Nlc.BusScanInfo.Progress:
                    if ((data & 1) == 0) // data holds scan progress
                    {
                        Console.Write(".");
                    }
                    break;

                case Nlc.BusScanInfo.Finished:
                    Console.WriteLine("");
                    Console.WriteLine("Scan finished.");
                    break;
            }

            return new Nlc.ResultVoid();
        }
    }

    public class NanolibException : Exception
    {
        public NanolibException(string message) : base(message)
        {
        }

        public NanolibException(string message, Exception inner) : base(message, inner)
        {
        }

        public NanolibException()
        {
        }
    }

    /// <summary>
    /// Helper class used just to wrap around Nanolib.
    /// Of course, Nanolib can be used directly in the code.
    /// </summary>
    public partial class Nanotec_Container
    {
        #region Global variables ...
        // DB link
        private Guid? _IdDb = null;
        public Guid? IdDb { get { return _IdDb; } set { _IdDb = value; } }

        // Nanotec libray accessor ...
        private Nlc.NanoLibAccessor _nanolibAccessor;

        // Bus hardware ...
        private BusHardwareId _busHardwareId;
        public BusHardwareId BusHardwareId { get { return _busHardwareId; } set { _busHardwareId = value; } }

        private Nlc.BusHardwareOptions _busHardwareOptions = new Nlc.BusHardwareOptions();
        public Nlc.BusHardwareOptions BusHardwareOptions { get { return _busHardwareOptions; } set { _busHardwareOptions = value; } }

        private Nlc.BusHWIdVector _busHardwareVector;
        public Nlc.BusHWIdVector BusHardwareVector { get { return _busHardwareVector; } set { _busHardwareVector = value; } }

        // Bus devices (CAN devices) ...
        private Nlc.DeviceIdVector _busDeviceVector;
        public Nlc.DeviceIdVector BusDeviceVector { get { return _busDeviceVector; } set { _busDeviceVector = value; } }

        // Nanotec motion controller
        private List<Nanotec_MotionController> _motionController;
        public List<Nanotec_MotionController> MotionController { get { return _motionController; } set { _motionController = value; } }
      #endregion

        public Nanotec_Container()
        {
            // Before accessing the nanolib, the pointer to the accessor class needs to be created and stored somewhere
            _nanolibAccessor = Nlc.Nanolib.getNanoLibAccessor();
        }  

        ~Nanotec_Container()
        {
            _motionController.Clear();

            _busHardwareId = null;
            _busHardwareId = null;
            _busHardwareVector = null;

            _busDeviceVector = null;

            _nanolibAccessor = null;
        }

        /// <summary>
        /// Get the hardware objects from given accessor
        /// </summary>
        /// <returns>Array of HardwareIds</returns>
        public Nlc.BusHWIdVector DiscoverBusHardwareDevices()
        {
            Nlc.ResultBusHwIds result = _nanolibAccessor.listAvailableBusHardware();

            if (result.hasError())
            {
                string errorMessage = string.Format("Error: listAvailableBusHardware() - {0}", result.getError());
                throw new NanolibException(errorMessage);
            }

            _busHardwareVector = result.getResult();

            return _busHardwareVector;
        }

        public Nlc.BusHardwareId SetBusHardwareDevice(string interfaceManufacturer, string interfaceSerialnumber)
        {
            // Just for better overview: print out available hardware
            uint lineNum = 0;
            foreach (Nlc.BusHardwareId adapter in _busHardwareVector)
            {
                if (string.Equals(adapter.getBusHardware(), interfaceManufacturer) && string.Equals(adapter.getHardwareSpecifier(), interfaceSerialnumber))
                {
                    Log.Information($"Selected bus device Nr. {lineNum} - Name: {adapter.getName()} --> Bus Hardware: {adapter.getBusHardware()} --> Protocol: {adapter.getProtocol()}");

                    // Create a copy of every object, which is returned in a vector, because when the vector goes out of scope, the contained objects will be destroyed.
                    // Or just copy the vector into an array.
                    _busHardwareId = _busHardwareVector.ToArray()[lineNum];
                }
                else
                {
                    Log.Debug($"Not selected bus device Nr. {lineNum} - Name: {adapter.getName()} --> Bus Hardware: {adapter.getBusHardware()} --> Protocol: {adapter.getProtocol()}");
                }

                lineNum++;
            }

            return _busHardwareId;
        }

        /// <summary>
        /// Create bus hardware options object from given bus hardware id
        /// </summary>
        /// <param name="busHwId">The id of the bus hardware taken from GetHardware()</param>
        /// <returns>A set of options for opening the bus hardware</returns>
        public Nlc.BusHardwareOptions CreateBusHardwareOptions()
        {
            // create new bus hardware options
            _busHardwareOptions = new Nlc.BusHardwareOptions();

            // now add all options necessary for opening the bus hardware
            // in case of CAN bus it is the baud rate
            Nlc.BusHwOptionsDefault busHwOptionsDefaults = new Nlc.BusHwOptionsDefault();

            // now add all options necessary for opening the bus hardware
            if (_busHardwareId.getProtocol() == Nlc.Nanolib.BUS_HARDWARE_ID_PROTOCOL_CANOPEN)
            {
                // in case of CAN bus it is the baud rate
                _busHardwareOptions.addOption(busHwOptionsDefaults.canBus.BAUD_RATE_OPTIONS_NAME, busHwOptionsDefaults.canBus.baudRate.BAUD_RATE_1000K);

                if (_busHardwareId.getBusHardware() == Nlc.Nanolib.BUS_HARDWARE_ID_IXXAT)
                {
                    // in case of HMS IXXAT we need also bus number
                    _busHardwareOptions.addOption(busHwOptionsDefaults.canBus.ixxat.ADAPTER_BUS_NUMBER_OPTIONS_NAME, busHwOptionsDefaults.canBus.ixxat.adapterBusNumber.BUS_NUMBER_0_DEFAULT);
                }
            }
            else if (_busHardwareId.getProtocol() == Nlc.Nanolib.BUS_HARDWARE_ID_PROTOCOL_MODBUS_RTU)
            {
                // in case of Modbus RTU it is the serial baud rate
                _busHardwareOptions.addOption(busHwOptionsDefaults.serial.BAUD_RATE_OPTIONS_NAME, busHwOptionsDefaults.serial.baudRate.BAUD_RATE_19200);
                // and serial parity
                _busHardwareOptions.addOption(busHwOptionsDefaults.serial.PARITY_OPTIONS_NAME, busHwOptionsDefaults.serial.parity.EVEN);
            }
            else
            {

            }

            return _busHardwareOptions;
        }

        /// <summary>
        /// Opens the bus hardware with given id and options
        /// </summary>
        /// <param name="busHwId">The id of the bus hardware taken from GetHardware()</param>
        /// <param name="busHwOptions">The hardware options taken from Create.....BusHardwareOptions()</param>
        public void OpenBusHardware()
        {
            Nlc.Result result = _nanolibAccessor.openBusHardwareWithProtocol(_busHardwareId, _busHardwareOptions);

            if (result.hasError())
            {
                string errorMsg = string.Format("Error: openBusHardwareWithProtocol() - {0}", result.getError());
                throw new NanolibException(errorMsg);
            }
        }

        public bool AddMotionController(uint canDeviceId, Guid idDb)
        {
            // Find Bus device 
            List<DeviceId> tmp = _busDeviceVector.Where(p => p.getDeviceId() == canDeviceId).ToList();

            if (tmp.Count == 1)
            {
                _motionController.Add(new Nanotec_MotionController()
                {
                    IdDb = idDb,

                    CanDeviceId = canDeviceId,
                    DeviceId = tmp[0],
                    DeviceHandle = CreateDevice(tmp[0])
                });

                return true;
            }
            else
            {
                Log.Error($"To many or to less devices for Id {canDeviceId} found!");

                return false;
            }
        }


        /// <summary>
        /// Closes the bus hardware (access no longer possible after that)
        /// Note: the call of the function is optional because the nanolib will cleanup the
        /// bus hardware itself on closing.
        /// </summary>
        /// <param name="busHwId">The bus hardware id to close</param>
        public void CloseBusHardware()
        {
            Nlc.Result result = _nanolibAccessor.closeBusHardware(_busHardwareId);

            if (result.hasError())
            {
                string errorMsg = string.Format("Error: closeBusHardware() - {0}", result.getError());
                throw new NanolibException(errorMsg);
            }
        }

        /// <summary>
        /// Scans bus and returns all found device ids.
        ///
        /// CAUTION: open bus hardware first with NanoLibHelper.OpenBusHardware()
        ///
        /// </summary>
        /// <param name="busHwId">The bus hardware to scan</param>
        /// <returns>Vector with found devices</returns>
        public Nlc.DeviceIdVector ScanBusForDevices()
        {
            ScanBusCallback scanCallback = new ScanBusCallback();

            Nlc.ResultDeviceIds result = _nanolibAccessor.scanDevices(_busHardwareId, scanCallback);

            if (result.hasError())
            {
                string errorMsg = string.Format("Error: scanDevices() - {0}", result.getError());
                throw new NanolibException(errorMsg);
            }

            _busDeviceVector = result.getResult();

            return _busDeviceVector;
        }

        /// <summary>
        /// Create a Device and return DeviceHandle
        /// </summary>
        /// <param name="deviceId">The device id</param>
        /// <returns>The DeviceHandle used to access all device related functions</returns>
        public Nlc.DeviceHandle CreateDevice(Nlc.DeviceId deviceId)
        {
            Nlc.ResultDeviceHandle result = _nanolibAccessor.addDevice(deviceId);

            if (result.hasError())
            {
                string errorMsg = string.Format("Error: CreateDevice() - {0}", result.getError());
                throw new NanolibException(errorMsg);
            }

            return result.getResult();
        }

        /// <summary>
        /// Connects to given DeviceHandle
        /// </summary>
        /// <param name="deviceHandle"></param>
        public void DeviceConnect(uint canDeviceId)
        {
            Nlc.ResultVoid result = _nanolibAccessor.connectDevice(GetBusDeviceById(canDeviceId));

            try
            {
                if (result.hasError())
                {
                    throw new NanolibException("Error: DeviceConnect() - " + result.getError());
                }
            }
            catch (Exception)
            {

                throw;
            }
        }



        public DeviceHandle GetBusDeviceById(uint canDeviceId)
        {
            return _motionController.Where(p => p.CanDeviceId == canDeviceId).First().DeviceHandle;
        }

        /// <summary>
        /// Disconnects given device
        ///
        /// Note: the call of the function is optional because the nanolib will cleanup the
        /// devices on bus itself on closing.
        /// </summary>
        /// <param name="deviceHandle">DeviceHandle of the device</param>
        public void DeviceDisconnect(Nlc.DeviceHandle deviceHandle)
        {
            Nlc.ResultVoid result = _nanolibAccessor.disconnectDevice(deviceHandle);

            if (result.hasError())
            {
                throw new NanolibException("Error: DeviceDisconnect() - " + result.getError());
            }
        }

        /// <summary>
        /// Reads out a number of given device
        /// </summary>
        /// <param name="deviceHandle">The handle of the device to read from</param>
        /// <param name="odIndex">The index and sub-index of the object dictionary to read from</param>
        /// <returns>A 64 bit number. The interpretation of the data type is up to the user. </returns>
        public long ReadNumber(Nlc.DeviceHandle deviceHandle, Nlc.OdIndex odIndex)
        {
            Nlc.ResultInt result = _nanolibAccessor.readNumber(deviceHandle, odIndex);

            if (result.hasError())
            {
                string errorMsg = CreateErrorMessage("Reading number", deviceHandle, odIndex, result.getError());
                throw new NanolibException(errorMsg);
            }
            return result.getResult();
        }

        /// <summary>
        /// Reads out a number of given device via the assigned object dictionary
        /// </summary>
        /// <param name="objectDictionay">An assigned object dictionary</param>
        /// <param name="odIndex">The index and sub-index of the object dictionary to read from</param>
        /// <returns>A 64 bit number. The interpretation of the data type is up to the user. </returns>
        public long ReadNumber(Nlc.ObjectDictionary objectDictionay, Nlc.OdIndex odIndex)
        {
            Nlc.ResultInt result = GetObject(objectDictionay, odIndex).readNumber();

            if (result.hasError())
            {
                string errorMsg = CreateErrorMessage("Reading number", objectDictionay.getDeviceHandle().getResult(), odIndex, result.getError());
                throw new NanolibException(errorMsg);
            }
            return result.getResult();
        }

        /// <summary>
        /// Writes given number to the device
        /// </summary>
        /// <param name="deviceHandle">The id of the device to write to</param>
        /// <param name="value">The value to write to the device</param>
        /// <param name="odIndex">The index and sub-index of the object dictionary to write to</param>
        /// <param name="bitLength">The bit length of the object to write to, either 8, 16 or 32 (see manual for all the bit lengths of all objects)</param>
        public void WriteNumber(Nlc.DeviceHandle deviceHandle, long value, Nlc.OdIndex odIndex, uint bitLength)
        {
            Nlc.ResultVoid result = _nanolibAccessor.writeNumber(deviceHandle, value, odIndex, bitLength);

            try
            {
                if (result.hasError())
                {
                    string errorMsg = CreateErrorMessage("Writing number", deviceHandle, odIndex, result.getError());
                    throw new NanolibException(errorMsg);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Writes given number to the device via assigned object dictionary
        /// </summary>
        /// <param name="objectDictionay">An assigned object dictionary</param>
        /// <param name="value">The value to write to the device</param>
        /// <param name="odIndex">The index and sub-index of the object dictionary to write to</param>
        public void WriteNumber(Nlc.ObjectDictionary objectDictionay, long value, Nlc.OdIndex odIndex)
        {
            Nlc.ResultVoid result = GetObject(objectDictionay, odIndex).writeNumber(value);

            if (result.hasError())
            {
                string errorMsg = CreateErrorMessage("Writing number", objectDictionay.getDeviceHandle().getResult(), odIndex, result.getError());
                throw new NanolibException(errorMsg);
            }
        }

        /// <summary>
        /// Reads array object from a device
        /// </summary>
        /// <param name="deviceHandle">The handle of the device to read from</param>
        /// <param name="index">The index of the object</param>
        /// <returns>Vector (array) of numbers (the interpretation of the data type is up to the user).</returns>
        public Nlc.IntVector ReadArray(Nlc.DeviceHandle deviceHandle, ushort index)
        {
            var result = _nanolibAccessor.readNumberArray(deviceHandle, index);

            if (result.hasError())
            {
                string errorMsg = CreateErrorMessage("Reading array", deviceHandle, new Nlc.OdIndex(index, 0), result.getError());
                throw new NanolibException(errorMsg);
            }
            return result.getResult();
        }

        /// <summary>
        /// Reads a string object from a devicew
        /// </summary>
        /// <param name="deviceHandle"></param>
        /// <param name="odIndex">The index and sub-index of the object dictionary to read from</param>
        /// <returns>string</returns>
        public string ReadString(Nlc.DeviceHandle deviceHandle, Nlc.OdIndex odIndex)
        {
            Nlc.ResultString result = _nanolibAccessor.readString(deviceHandle, odIndex);

            if (result.hasError())
            {
                string errorMsg = CreateErrorMessage("Reading string", deviceHandle, odIndex, result.getError());
                throw new NanolibException(errorMsg);
            }
            return result.getResult();
        }

        /// <summary>
        /// Reads a string object from a given device via the assigned object dictionary
        /// </summary>
        /// <param name="deviceHandle"></param>
        /// <param name="odIndex">The index and sub-index of the object dictionary to read from</param>
        /// <returns>string</returns>
        public string ReadString(Nlc.ObjectDictionary objectDictionay, Nlc.OdIndex odIndex)
        {
            Nlc.ResultString result = GetObject(objectDictionay, odIndex).readString();
            if (result.hasError())
            {
                string errorMsg = CreateErrorMessage("Reading string", objectDictionay.getDeviceHandle().getResult(), odIndex, result.getError());
                throw new NanolibException(errorMsg);
            }
            return result.getResult();
        }

        /// <summary>
        /// Gets DeviceId of given DeviceHandle.
        /// </summary>
        /// <param name="deviceHandle">Nlc.DeviceHandle</param>
        /// <returns>Nlc.DeviceId</returns>
        public Nlc.DeviceId GetDeviceId(Nlc.DeviceHandle deviceHandle)
        {
            Nlc.ResultDeviceId result = _nanolibAccessor.getDeviceId(deviceHandle);
            if (result.hasError())
            {
                throw new NanolibException("Unable to get DeviceId");
            }

            return result.getResult();
        }

        /// <summary>
        /// Gets assigned object dictionary.
        /// </summary>
        /// <param name="deviceHandle">Nlc.DeviceHandle.</param>
        /// <returns>Assigned Nlc.ObjectDictionary.</returns>
        public Nlc.ObjectDictionary GetDeviceObjectDictionary(Nlc.DeviceHandle deviceHandle)
        {
            Nlc.ResultObjectDictionary result = _nanolibAccessor.getAssignedObjectDictionary(deviceHandle);
            if (result.hasError())
            {
                throw new NanolibException("Unable to get the assigned Object Dictionary");
            }

            return result.getResult();
        }

        /// <summary>
        /// Gets object dictionary entry.
        /// </summary>
        /// <param name="objectDictionary">Nlc.ObjectDictionary.</param>
        /// <param name="odIndex">Nlc.OdIndex.</param>
        /// <returns>Nlc.ObjectEntry.</returns>
        public Nlc.ObjectEntry GetObjectEntry(Nlc.ObjectDictionary objectDictionary, ushort index)
        {
            Nlc.ResultObjectEntry result = objectDictionary.getObjectEntry(index);
            if (result.hasError())
            {
                throw new NanolibException("Unable to get Object Dictionary entry");
            }

            return result.getResult();
        }

        /// <summary>
        /// Gets object dictionary sub entry.
        /// </summary>
        /// <param name="objectDictionary">Nlc.ObjectDictionary.</param>
        /// <param name="odIndex">Nlc.OdIndex.</param>
        /// <returns>Nlc.ObjectSubEntry.</returns>
        public Nlc.ObjectSubEntry GetObject(Nlc.ObjectDictionary objectDictionary, Nlc.OdIndex odIndex)
        {
            Nlc.ResultObjectSubEntry result = objectDictionary.getObject(odIndex);
            if (result.hasError())
            {
                throw new NanolibException("Unable to get Object Dictionary sub entry");
            }

            return result.getResult();
        }

        /// <summary>
        /// Gets Sampler Interface.
        /// </summary>
        /// <returns>Nlc.SamplerInterface</returns>
        public Nlc.SamplerInterface GetSamplerInterface()
        {
            return _nanolibAccessor.getSamplerInterface();
        }

        /// <summary>
        /// Gets ProfinetDCP Interface.
        /// </summary>
        /// <returns>Nlc.SamplerInterface</returns>
        public Nlc.ProfinetDCP GetProfinetDcpInterface()
        {
            return _nanolibAccessor.getProfinetDCP();
        }

        /// <summary>
        /// Set the logging level
        /// </summary>
        /// <param name="logLevel">Nanolib log Level</param>
        public void SetLoggingLevel(Nlc.LogLevel logLevel)
        {
            if (_nanolibAccessor == null)
            {
                throw new NanolibException("Error: NanolibHelper2021().setup() is required");
            }
            _nanolibAccessor.setLoggingLevel(logLevel);
        }

        /// <summary>
        /// Helper function for creating an error message from given objects
        /// </summary>
        /// <param name="function">The name of the function the error ocurred</param>
        /// <param name="deviceHandle">The handle of the device to read from</param>
        /// <param name="odIndex">The index and sub-index of the object dictionary</param>
        /// <param name="resultError">The error text of the result</param>
        /// <returns></returns>
        private string CreateErrorMessage(string function, Nlc.DeviceHandle deviceHandle, Nlc.OdIndex odIndex, string resultError)
        {
            string deviceIdstring;
            Nlc.ResultDeviceId resultDeviceId = _nanolibAccessor.getDeviceId(deviceHandle);
            if (resultDeviceId.hasError())
            {
                deviceIdstring = "invalid handle";
            }
            else
            {
                deviceIdstring = resultDeviceId.getResult().toString();
            }

            return string.Format("{0} of device {1} at od index {2} resulted in an error: {3}", function, deviceIdstring, odIndex.Index.ToString(), resultError);
        }
    }
}