using PSGM.Helper;
using PSGM.Model.DbMachine;
using System.Diagnostics;

namespace PSGM.MultiTestApp1
{
    public partial class MainWindow
    {
        public static DbMachine_Device PowerSupply_001()
        {
            Debug.Write("Create Device -\"Camera Right\" ...");

            DbMachine_Device device = new DbMachine_Device()
            {
                Id = new Guid(),

                DeviceName = "DcDcConverter 001",
                DeviceDescription = "240W Universal, Isolated DC/DC",

                DeviceLocation = DeviceLocation.ControlCabinet,

                DeviceCategory = DeviceCategory.PowerSupply,
                DeviceManufacturer = DeviceManufacturer.Nextys,
                DeviceType = DeviceType.NDW240,
                DeviceUrl = "https://www.emea.lambda.tdk.com/nextys/dc-dc-converters.html",

                Serialnumber = "1915.510.03.00656.NNXB2",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,

                InitializeAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                AutoStartAtSplashscreen = true,
                HomingAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = null,
                Interfaces_Serial = new DbMachine_Interface_Serial()
                {
                    Id = new Guid(),

                    BaudRate = 9600,
                    Parity = (byte)System.IO.Ports.Parity.None,
                    StopBits = (byte)System.IO.Ports.StopBits.One,
                    Handshake = (byte)System.IO.Ports.Handshake.None,
                    ReadTimeout = 1000,
                    WriteTimeout = 1000,
                    PortName = "COM100",
                    MonitoringInterval = 1000,
                    SerialPortRetrySending = 3,

                    // FK
                    //Device = device null,
                },

                // FK
                //DeviceGroup = null
            };

            return device;
        }

        public static DbMachine_Device PowerSupply_002()
        {
            Debug.Write("Create Device -\"Camera Left\" ...");

            DbMachine_Device device = new DbMachine_Device()
            {
                Id = new Guid(),

                DeviceName = "DcDcConverter 002",
                DeviceDescription = "240W Universal, Isolated DC/DC",

                DeviceLocation = DeviceLocation.ControlCabinet,

                DeviceCategory = DeviceCategory.PowerSupply,
                DeviceManufacturer = DeviceManufacturer.Nextys,
                DeviceType = DeviceType.NDW240,
                DeviceUrl = "https://www.emea.lambda.tdk.com/nextys/dc-dc-converters.html",

                Serialnumber = "1915.510.03.00654.NNXB2",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,

                InitializeAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                AutoStartAtSplashscreen = true,
                HomingAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = null,
                Interfaces_Serial = new DbMachine_Interface_Serial()
                {
                    Id = new Guid(),

                    BaudRate = 9600,
                    Parity = (byte)System.IO.Ports.Parity.None,
                    StopBits = (byte)System.IO.Ports.StopBits.One,
                    Handshake = (byte)System.IO.Ports.Handshake.None,
                    ReadTimeout = 1000,
                    WriteTimeout = 1000,
                    PortName = "COM101",
                    MonitoringInterval = 1000,
                    SerialPortRetrySending = 3,

                    // FK
                    //Device = device null,
                },

                // FK
                //DeviceGroup = null
            };

            return device;
        }
    }
}
