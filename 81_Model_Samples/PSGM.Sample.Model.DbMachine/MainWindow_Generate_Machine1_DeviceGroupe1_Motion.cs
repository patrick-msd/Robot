using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Device Generate_Machine1_DeviceGroupe1_Motion()
        {


            //device.SetConfigurationControlRobotElectronicsV1_0_0(new Configuration_Control_RobotElectronicsV1_0_0() { MinValue = 0.000f, MaxValue = 24000.000f, DefaultValue = 4500.000f });




            DbMachine_Device device = new DbMachine_Device()
            {
                Id = new Guid(),

                DeviceName = "Motion Controller 001",
                DeviceDescription = "USB-to-CAN Converter for Nanotec motion coltroller",

                DeviceLocation = DeviceLocation.MainFrame,

                DeviceCategory = DeviceCategory.Motion,
                DeviceManufacturer = DeviceManufacturer.IXXAT,
                DeviceType = DeviceType.HW630322,
                DeviceUrl = "https://www.hms-networks.com/de/p/1-01-0281-12001-ixxat-usb-to-can-v2-compact",

                SerialNumber = "HW630322",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,

                InitializeAtSplashScreen = true,
                ConnectAtSplashScreen = true,
                AutoStartAtSplashScreen = true,
                HomingAtSplashScreen = true,

                Interfaces_Can = new DbMachine_Interface_Can()
                {
                    Interface_CanDevices = new List<DbMachine_Interface_CanDevice>()
                    {
                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 1,

                            DeviceName = "Cradle Right - 1",
                            DeviceDescription = "Stepper motor with integrated controller – NEMA 17",

                            DeviceLocation = DeviceLocation.SheetCradleRight,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.PD2_C4118L1804_E_08,
                            DeviceUrl = "https://www.nanotec.com/eu/de/produkte/1891-pd2-c4118l1804-e-08",

                            SerialNumber = "B959903 22/23-0020",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                            
                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 4,

                            DeviceName = "Cradle Right - 2",
                            DeviceDescription = "Stepper motor with integrated controller – NEMA 17",

                            DeviceLocation = DeviceLocation.SheetCradleRight,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.PD2_C4118L1804_E_08,
                            DeviceUrl = "https://www.nanotec.com/eu/de/produkte/1891-pd2-c4118l1804-e-08",

                            SerialNumber = "B959903 22/23-0012",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 2,

                            DeviceName = "Cradle Left - 1",
                            DeviceDescription = "Stepper motor with integrated controller – NEMA 17",

                            DeviceLocation = DeviceLocation.SheetCradleLeft,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.PD2_C4118L1804_E_08,
                            DeviceUrl = "https://www.nanotec.com/eu/de/produkte/1891-pd2-c4118l1804-e-08",

                            SerialNumber = "B959903 22/23-0019",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                            
                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 3,

                            DeviceName = "Cradle Left - 2",
                            DeviceDescription = "Stepper motor with integrated controller – NEMA 17",

                            DeviceLocation = DeviceLocation.SheetCradleLeft,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.PD2_C4118L1804_E_08,
                            DeviceUrl = "https://www.nanotec.com/eu/de/produkte/1891-pd2-c4118l1804-e-08",

                            SerialNumber = "B959903 22/23-0016",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 11,

                            DeviceName = "Sheet cradel Right - Downholder Right",
                            DeviceDescription = "Motor controller / drive, Stepper motor - NEMA 14",

                            DeviceLocation = DeviceLocation.SheetCradleRight,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.CL3_E_1_0F_AND_SC3518M1204,
                            DeviceUrl = "https://www.nanotec.com/eu/en/products/1758-cl3-e-1-0f, https://www.nanotec.com/eu/de/produkte/1857-sc3518m1204-b",

                            SerialNumber = "B956654 02/23-0115, ???",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 12,

                            DeviceName = "Sheet cradel Right - Downholder Left",
                            DeviceDescription = "Motor controller / drive, Stepper motor - NEMA 14",

                            DeviceLocation = DeviceLocation.SheetCradleRight,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.CL3_E_1_0F_AND_SC3518M1204,
                            DeviceUrl = "https://www.nanotec.com/eu/en/products/1758-cl3-e-1-0f, https://www.nanotec.com/eu/de/produkte/1857-sc3518m1204-b",

                            SerialNumber = "B956654 02/23-0076, ???",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                            
                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 13,

                            DeviceName = "Sheet cradel Left - Downholder Right",
                            DeviceDescription = "Motor controller / drive, Stepper motor - NEMA 14",

                            DeviceLocation = DeviceLocation.SheetCradleLeft,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.CL3_E_1_0F_AND_SC3518M1204,
                            DeviceUrl = "https://www.nanotec.com/eu/en/products/1758-cl3-e-1-0f, https://www.nanotec.com/eu/de/produkte/1857-sc3518m1204-b",

                            SerialNumber = "B956654 02/23-0150, ???",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 14,

                            DeviceName = "Sheet cradel Left - Downholder Left",
                            DeviceDescription = "Motor controller / drive, Stepper motor - NEMA 14",

                            DeviceLocation = DeviceLocation.SheetCradleLeft,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.CL3_E_1_0F_AND_SC3518M1204,
                            DeviceUrl = "https://www.nanotec.com/eu/en/products/1758-cl3-e-1-0f, https://www.nanotec.com/eu/de/produkte/1857-sc3518m1204-b",

                            SerialNumber = "B956654 02/23-0081, ???",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        },

                        new DbMachine_Interface_CanDevice()
                        {
                            Id = new Guid(),

                            CanDeviceId = 21,

                            DeviceName = "Double Page control 001",
                            DeviceDescription = "Captive linearaktuator – NEMA 17",

                            DeviceLocation = DeviceLocation.SheetCradleLeft,

                            DeviceCategory = DeviceCategory.Motion,
                            DeviceManufacturer = DeviceManufacturer.Nanotec,
                            DeviceType = DeviceType.LGA421L18_B_UKGI_064,
                            DeviceUrl = "https://www.nanotec.com/eu/de/produkte/2475-lga421l18-b-ukgi-064",

                            SerialNumber = "B956654 02/23-0079",
                            ConfigurationString = string.Empty,
                            Timeout = 1000,

                            InitializeAtSplashScreen = true,
                            ConnectAtSplashScreen = true,
                            AutoStartAtSplashScreen = true,
                            HomingAtSplashScreen = true,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Interface_Can = null,
                            Interface_CanId = null
                        }
                    }
                },
                Interfaces_Ethernet = null,
                Interfaces_Serial = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                DeviceGroup = null,
                DeviceGroupId = null,
            };

            Configuration_Motion_NanotecV1_0_0 config = new Configuration_Motion_NanotecV1_0_0()
            {
                MinPositionRange = 0.000f,
                MaxPositionRange = 0.000f,

                DefaultTargetPosition = 0.000f,

                MinPositionRangeLimit = 0.000f,
                MaxPositionRangeLimit = 0.000f,

                MinPositionLimit = 0.000f,
                MaxPositionLimit = 0.000f,

                HomeOffset = 0.000f,
                Polarity = 0.000f,

                MotorProfileType = 0.000f,

                ProfileVelocity = 0.000f,
                ProfileAcceleration = 0.000f,

                EndVelocity = 0.000f,

                ProfileDeceleration = 0.000f,

                QuickStopDeceleration = 0.000f,

                MaxAcceleration = 0.000f,
                MaxDeceleration = 0.000f,

                BeginAccelerationJerk = 0.000f,
                BeginDecelerationJerk = 0.000f,

                EndAccelerationJerk = 0.000f,
                EndDecelerationJerk = 0.000f,

                JerkLimit = 0.000f,

                PositionWindow = 0.000f,
                PositionWindowTime = 0.000f,

                FollowingErrorWindow = 0.000f,
                FollowingErrorTimeOut = 0.000f
            };

            device.Interfaces_Can.Interface_CanDevices.ToList()[0].SetConfigurationMotionNanotecV1_0_0(config);

            return device;
        }
    }
}
