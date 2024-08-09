using PSGM.Helper;
using PSGM.Model.DbMachine;
using System.Diagnostics;

namespace PSGM.MultiTestApp1
{
    public partial class MainWindow
    {
        public static DbMachine_Device Control_001()
        {
            Debug.Write("Create Device -\"Controller 001\" ...");

            DbMachine_Device device = new DbMachine_Device()
            {
                Id = new Guid(),

                DeviceName = "Controller 001",
                DeviceDescription = "8 Relays and 40 Opto Inputs",

                DeviceLocation = DeviceLocation.ControlCabinet,
                
                DeviceCategory = DeviceCategory.Controller,
                DeviceManufacturer = DeviceManufacturer.RobotElectronics,
                DeviceType = DeviceType.DS2408,
                DeviceUrl = "https://www.robot-electronics.co.uk/ds2408.html",

                Serialnumber = "???",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,
                
                InitializeAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                AutoStartAtSplashscreen = true,
                HomingAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new DbMachine_Interface_Ethernet()
                {
                    Id = new Guid(),
                    
                    IpAddress = "10.31.230.100",
                    Port = 17123,
                    Timeout = 1000,

                    // FK
                    //Device = device null,
                },
                Interfaces_Serial = null,
                
                // FK
                //DeviceGroup = null
            };

            return device;
        }

        public static DbMachine_Device Control_002()
        {
            Debug.Write("Create Device -\"Controller 002\" ...");

            DbMachine_Device device = new DbMachine_Device()
            {
                Id = new Guid(),

                DeviceName = "Controller 002",
                DeviceDescription = "8 Relays and 40 Opto Inputs",

                DeviceLocation = DeviceLocation.ControlCabinet,

                DeviceCategory = DeviceCategory.Controller,
                DeviceManufacturer = DeviceManufacturer.RobotElectronics,
                DeviceType = DeviceType.DS2408,
                DeviceUrl = "https://www.robot-electronics.co.uk/ds2408.html",

                Serialnumber = "???",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,

                InitializeAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                AutoStartAtSplashscreen = true,
                HomingAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new DbMachine_Interface_Ethernet()
                {
                    Id = new Guid(),    
                    
                    IpAddress = "10.31.230.101",
                    Port = 17123,
                    Timeout = 1000,

                    // FK
                    //Device = device null,
                },
                Interfaces_Serial = null,

                // FK
                //DeviceGroup = null
            };

            return device;
        }
    }
}
