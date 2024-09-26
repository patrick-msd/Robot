using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Device Generate_Machine1_DeviceGroupe2_Controller()
        {
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

                SerialNumber = "???",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,

                InitializeAtSplashScreen = true,
                ConnectAtSplashScreen = true,
                AutoStartAtSplashScreen = true,
                HomingAtSplashScreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new DbMachine_Interface_Ethernet()
                {
                    Id = new Guid(),

                    IpAddress = "10.31.230.101",
                    Port = 17123,
                    Timeout = 1000,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    Device = null,
                    DeviceId = null
                },
                Interfaces_Serial = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                DeviceGroup = null,
                DeviceGroupId = null
            };

            return device;
        }
    }
}
