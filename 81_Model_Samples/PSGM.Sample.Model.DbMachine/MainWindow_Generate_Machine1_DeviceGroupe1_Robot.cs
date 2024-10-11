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

                DeviceName = "Robot",
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

            Configuration_Robot_DoosanV1_0_0 config = new Configuration_Robot_DoosanV1_0_0()
            {
                AnalogOutput1 = 0.000f,
                AnalogOutput2 = 0.000f,
                AnalogOutput3 = 0.000f,
                AnalogOutput4 = 0.000f,
                AnalogOutput5 = 0.000f,
                AnalogOutput6 = 0.000f,
                AnalogOutput7 = 0.000f,
                AnalogOutput8 = 0.000f,
                AnalogOutput9 = 0.000f,
                AnalogOutput10 = 0.000f,
                AnalogOutput11 = 0.000f,
                AnalogOutput12 = 0.000f,
                AnalogOutput13 = 0.000f,
                AnalogOutput14 = 0.000f,
                AnalogOutput15 = 0.000f,
                AnalogOutput16 = 0.000f,

                ToolAnalogOutput1 = 0.000f,
                ToolAnalogOutput2 = 0.000f,
                ToolAnalogOutput3 = 0.000f,
                ToolAnalogOutput4 = 0.000f,
                ToolAnalogOutput5 = 0.000f,
                ToolAnalogOutput6 = 0.000f,
                ToolAnalogOutput7 = 0.000f,
                ToolAnalogOutput8 = 0.000f,
                ToolAnalogOutput9 = 0.000f,
                ToolAnalogOutput10 = 0.000f,
                ToolAnalogOutput11 = 0.000f,
                ToolAnalogOutput12 = 0.000f,
                ToolAnalogOutput13 = 0.000f,
                ToolAnalogOutput14 = 0.000f,
                ToolAnalogOutput15 = 0.000f,
                ToolAnalogOutput16 = 0.000f,

                DigitalOutput1 = false,
                DigitalOutput2 = false,
                DigitalOutput3 = false,
                DigitalOutput4 = false,
                DigitalOutput5 = false,
                DigitalOutput6 = false,
                DigitalOutput7 = false,
                DigitalOutput8 = false,
                DigitalOutput9 = false,
                DigitalOutput10 = false,
                DigitalOutput11 = false,
                DigitalOutput12 = false,
                DigitalOutput13 = false,
                DigitalOutput14 = false,
                DigitalOutput15 = false,
                DigitalOutput16 = false,

                ToolDigitalOutput1 = false,
                ToolDigitalOutput2 = false,
                ToolDigitalOutput3 = false,
                ToolDigitalOutput4 = false,
                ToolDigitalOutput5 = false,
                ToolDigitalOutput6 = false,
                ToolDigitalOutput7 = false,
                ToolDigitalOutput8 = false,
                ToolDigitalOutput9 = false,
                ToolDigitalOutput10 = false,
                ToolDigitalOutput11 = false,
                ToolDigitalOutput12 = false,
                ToolDigitalOutput13 = false,
                ToolDigitalOutput14 = false,
                ToolDigitalOutput15 = false,
                ToolDigitalOutput16 = false,

                Tools = new List<Configuration_Robot_Doosan_ToolV1_0_0>()
                {
                    new Configuration_Robot_Doosan_ToolV1_0_0()
                    {
                         Name = string.Empty,

                        CenterPositionX = 0.000f,
                        CenterPositionY = 0.000f,
                        CenterPositionZ = 0.000f,
                        CenterPositionA = 90.000f,
                        CenterPositionB = 0.000f,
                        CenterPositionC = 0.000f,

                        Weight = 0.000f,

                        CenterOfGravityX = 0.000f,
                        CenterOfGravityY = 0.000f,
                        CenterOfGravityZ = 0.000f,

                        InertialValueX = 0.000f,
                        InertialValueY = 0.000f,
                        InertialValueZ = 0.000f,
                        InertialValueA = 0.000f,
                        InertialValueB = 0.000f,
                        InertialValueC = 0.000f
                    }
                },
            };
            device.SetConfigurationRobotDoosanV1_0_0(config);

            return device;
        }
    }
}
