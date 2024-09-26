using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Device Generate_Machine1_DeviceGroupe1_Robot()
        {
            DbMachine_Device device = new DbMachine_Device()
            {
                Id = new Guid(),

                DeviceName = "Robot Right",
                DeviceDescription = "Robot with 6 degrees of freedom",

                DeviceLocation = DeviceLocation.MainFrame,

                DeviceCategory = DeviceCategory.Robot,
                DeviceManufacturer = DeviceManufacturer.Doosan,
                DeviceType = DeviceType.M0609,
                DeviceUrl = "https://www.doosanrobotics.com/de/product/Products/Series/M0609",

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

                    IpAddress = "10.31.230.50",
                    Port = 12345,
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
