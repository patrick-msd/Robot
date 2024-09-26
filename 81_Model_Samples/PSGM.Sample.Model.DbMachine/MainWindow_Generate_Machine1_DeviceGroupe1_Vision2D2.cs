using PSGM.Helper;
using PSGM.Model.DbMachine;
using RC.Lib.Vision.SVSVistek;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Device Generate_Machine1_DeviceGroupe1_Vision2D2()
        {
            SVSVistek_Camera_Config cameraConfig = new SVSVistek_Camera_Config()
            {
                DevieControl = new DevieControl()
                {
                    DeviceUserID = "???",
                    DeviceLinkThroughputLimitMode = DeviceLinkThroughputLimitMode.Off,
                    DeviceLinkThroughputLimit = 1000000000,
                    MaximumPacketsResend = 4095,
                    LEDIntensity = 64,
                    FanControl = FanControl.Auto,
                    FanControlThreshold = 70.000d,
                },

                ImageFormatControl = new ImageFormatControl()
                {
                    XOffset = 3550,
                    YOffset = 1700,
                    Width = 2400,
                    Height = 3000,
                    SensorPixelSize = SensorPixelSize.SensorBppAuto,
                    PixelFormat = PixelFormat.BayerBG16,
                    BinningHorizontal = BinningHorizontal.Off,
                    BinningVertical = BinningVertical.Off,
                    ReverseX = ReverseX.Off,
                    ReverseY = ReverseY.Off
                },

                AcquisitionControl = new AcquisitionControl()
                {
                    AcquisitionMode = AcquisitionMode.Continuous,
                    TriggerSelector = TriggerSelector.AcquisitionStart,
                    TriggerMode = TriggerMode.Off,
                    TriggerSource = TriggerSource.Software,
                    TriggerActivation = TriggerActivation.RisingEdge,
                    TriggerDelay = 0.000d,
                    SensorTriggerMode = SensorTriggerMode.Freerunning,
                    ExposureMode = ExposureMode.Timed,
                    ExposureTime = 15000.000d,
                    ExposureAuto = ExposureAuto.Off,
                    ExposureFirst = ExposureFirst.On,
                    ExposureTimeMin = 1000.000d,
                    ExposureTimeMax = 500000.000d,
                    SensorShutterMode = SensorShutterMode.Global
                },

                AnalogControl = new AnalogControl()
                {
                    GainSelector = GainSelector.All,
                    Gain = 3.000d,
                    BlackLevelSelector = BlackLevelSelector.All,
                    BlackLevel = 0.000d,
                    GainAuto = GainAuto.Off,
                    GainSpeed = GainSpeed.Standard,
                    GainAutoLevel = 100,
                    GainAutoMin = 0.000d,
                    GainAutoMax = 36.000d,
                    BalanceWhiteRatioRed = 1.30859d,
                    BalanceWhiteRatioGreen = 1.000d,
                    BalanceWhiteRatioBlue = 1.90234d,
                    BalanceWhiteAuto = BalanceWhiteAuto.Off
                },

                LUTControl = new LUTControl()
                {
                    LUTEnable = false,
                    Gamma = 1.000d
                }
            };

            DbMachine_Device device = new DbMachine_Device()
            {
                Id = new Guid(),

                DeviceName = "Vision 2D Right",
                DeviceDescription = "61MP industiral CMOS camera with 10GigE",

                DeviceLocation = DeviceLocation.MainFrame,

                DeviceCategory = DeviceCategory.Vision,
                DeviceManufacturer = DeviceManufacturer.SVSVistek,
                DeviceType = DeviceType.HR455CXGE,
                DeviceUrl = "https://www.svs-vistek.com/de/industriekameras/svs-kamera-detail.php?id=hr455CXGE",

                SerialNumber = "107944",
                ConfigurationString = Serialize.ToString(cameraConfig),
                AttachmentsString = string.Empty,
                
                InitializeAtSplashScreen = true,
                ConnectAtSplashScreen = true,
                AutoStartAtSplashScreen = true,
                HomingAtSplashScreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new DbMachine_Interface_Ethernet()
                {
                    Id = new Guid(),

                    IpAddress = "192.168.141.100",
                    Port = 0,
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
