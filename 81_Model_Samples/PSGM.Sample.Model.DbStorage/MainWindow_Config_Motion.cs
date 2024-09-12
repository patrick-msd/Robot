using PSGM.Helper;
using PSGM.Model.DbMachine;
using System.Diagnostics;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow
    {
        public static DbMachine_Device Motion_001()
        {
            Debug.Write("Create Device -\"Motion\" ...");

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

                Serialnumber = "HW630322",
                ConfigurationString = string.Empty,
                AttachmentsString = string.Empty,

                InitializeAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                AutoStartAtSplashscreen = true,
                HomingAtSplashscreen = true,

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

                            Serialnumber = "B959903 22/23-0020",
                            Configuration = string.Empty,
                            Timeout = 1000,
                            
                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null    
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

                            Serialnumber = "B959903 22/23-0012",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
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

                            Serialnumber = "B959903 22/23-0019",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
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

                            Serialnumber = "B959903 22/23-0016",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
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

                            Serialnumber = "B956654 02/23-0115, ???",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
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

                            Serialnumber = "B956654 02/23-0076, ???",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
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

                            Serialnumber = "B956654 02/23-0150, ???",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
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

                            Serialnumber = "B956654 02/23-0081, ???",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
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

                            Serialnumber = "B956654 02/23-0079",
                            Configuration = string.Empty,
                            Timeout = 1000,

                            InitialzeAtSplashscreen = true,
                            ConnectAtSplashscreen = true,
                            AutoStartAtSplashscreen = true,
                            HomingAtSplashscreen = true,

                            // FK
                            //Interface_Can = null
                        }
                    }
                },
                Interfaces_Ethernet = null,
                Interfaces_Serial = null,

                // FK
                //DeviceGroup = null
            };

            return device;
        }
    }
}
