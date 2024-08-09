using RC.Model;
using Serilog;

namespace RC.Control.RobotElectronics.Sample
{
    public partial class App_config
    {
        public static void AppConfiCreate()
        {
            Log.Information("Create Device -\"Controller 001\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "Controller 001",
                ApplicationDeviceLocation = "Sheet Cradle",

                DeviceName = "dS2408",
                DeviceDescription = "SVS-Vistek",
                DeviceType = DeviceTypes.Controller,
                DeviceManufacturer = DeviceManufacturers.RobotElectronics,
                DeviceSerialnumber = "107948",

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = false,
                ConnectAtSplashscreen = false,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new Interface_Ethernet()
                {
                    Id = new System.Guid(),

                    IpAddress = "10.31.230.100",
                    Port = 17123,
                    Timeout = 1000
                },
                Interfaces_Serial = null
            });

            Log.Information("Create Device -\"Controller 002\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "Controller 002",
                ApplicationDeviceLocation = "Cabine",

                DeviceName = "dS2408",
                DeviceDescription = "SVS-Vistek",
                DeviceType = DeviceTypes.Controller,
                DeviceManufacturer = DeviceManufacturers.RobotElectronics,
                DeviceSerialnumber = "107944",

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = false,
                ConnectAtSplashscreen = false,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new Interface_Ethernet()
                {
                    Id = new System.Guid(),

                    IpAddress = "10.31.230.101",
                    Port = 17123,
                    Timeout = 1000
                },
                Interfaces_Serial = null
            });
        }
    }
}
