using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Device Generate_Machine1_DeviceGroupe1_PowerSupply2()
        {
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

                SerialNumber = "1915.510.03.00654.NNXB2",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,

                InitializeAtSplashScreen = true,
                ConnectAtSplashScreen = true,
                AutoStartAtSplashScreen = true,
                HomingAtSplashScreen = true,

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

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    Device = null,
                    DeviceId = null
                },

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                DeviceGroup = null,
                DeviceGroupId = null
            };
            device.SetConfigurationControlRobotElectronicsV1_0_0(new Configuration_Control_RobotElectronicsV1_0_0() { MinValue = 0.000f, MaxValue = 24000.000f, DefaultValue = 4500.000f });

            return device;
        }
    }
}
