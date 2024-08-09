using RC.Model;
using Serilog;

namespace RC.PowerSupply.Nextys.Sample
{
    public partial class App_config
    {
        public static void AppConfiCreate()
        {
            Log.Information("Create Device -\"Camera Right\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "DcDcConverter 001",
                ApplicationDeviceLocation = "Control cabinet",

                DeviceName = "NDW240",
                DeviceDescription = "Nextys DcDcConverter",
                DeviceType = DeviceTypes.PowerSupply,
                DeviceManufacturer = DeviceManufacturers.Nextys,
                DeviceSerialnumber = "1915.510.03.00656.NNXB2",

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = true,
                ConnectAtSplashscreen = false,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = null,
                Interfaces_Serial = new Interface_Serial()
                {
                    Id = new System.Guid(),

                    BaudRate = 9600,
                    Parity = (byte)System.IO.Ports.Parity.None,
                    StopBits = (byte)System.IO.Ports.StopBits.One,
                    Handshake = (byte)System.IO.Ports.Handshake.None,
                    ReadTimeout = 1000,
                    WriteTimeout = 1000,
                    PortName = "COM100"
                }
            });

            Log.Information("Create Device -\"Camera Left\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "DcDcConverter 002",
                ApplicationDeviceLocation = "Control cabinet",

                DeviceName = "NDW240",
                DeviceDescription = "Nextys DcDcConverter",
                DeviceType = DeviceTypes.PowerSupply,
                DeviceManufacturer = DeviceManufacturers.Nextys,
                DeviceSerialnumber = "1915.510.03.00654.NNXB2",

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = true,
                ConnectAtSplashscreen = false,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = null,
                Interfaces_Serial = new Interface_Serial()
                {
                    Id = new System.Guid(),

                    BaudRate = 9600,
                    Parity = (byte)System.IO.Ports.Parity.None,
                    StopBits = (byte)System.IO.Ports.StopBits.One,
                    Handshake = (byte)System.IO.Ports.Handshake.None,
                    ReadTimeout = 1000,
                    WriteTimeout = 1000,
                    PortName = "COM101"
                }
            });
        }
    }
}
