using PSGM.Helper;
using PSGM.Model.DbMachine;
using System.Diagnostics;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow
    {
        public static DbMachine_Device Robot_001()
        {
            Debug.Write("Create Device -\"Robot Right\" ...");

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

                    IpAddress = "10.31.230.50",
                    Port = 12345,
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
