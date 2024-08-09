using RC.Model;
using Serilog;

namespace RC.Robot.Doosan.Sample
{
    public partial class App_Config
    {
        public static void AppConfiCreate()
        {
            Log.Information("Create Device -\"Robot Right\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "Robot Right",
                ApplicationDeviceLocation = "Machine",

                DeviceName = "M0906A",
                DeviceDescription = "Doosan",
                DeviceType = DeviceTypes.Robot,
                DeviceManufacturer = DeviceManufacturers.Doosan,
                DeviceSerialnumber = "???",
                DeviceConfiguration = string.Empty,

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new Interface_Ethernet()
                {
                    Id = new System.Guid(),

                    IpAddress = "10.31.230.50",
                    Port = 12345,
                    Timeout = 1000
                },
                Interfaces_Serial = null
            });

            Log.Information("Create Device -\"Robot Left\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "Robot Left",
                ApplicationDeviceLocation = "Machine",

                DeviceName = "M0906A",
                DeviceDescription = "Doosan",
                DeviceType = DeviceTypes.Robot,
                DeviceManufacturer = DeviceManufacturers.Doosan,
                DeviceSerialnumber = "???",
                DeviceConfiguration = string.Empty,

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new Interface_Ethernet()
                {
                    Id = new System.Guid(),

                    IpAddress = "10.31.230.51",
                    Port = 12345,
                    Timeout = 1000
                },
                Interfaces_Serial = null
            });
        }
    }
}
