using RC.Lib.Vision.SVSVistek;
using RC.Model;
using Serilog;

namespace RC.Vision.SVSVistek.Sample
{
    public partial class App_Config
    {
        public static void AppConfiCreate()
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
                    BalanceWhiteRatioRed = 1.29688d,
                    BalanceWhiteRatioGreen = 1.000d,
                    BalanceWhiteRatioBlue = 1.85547d,
                    BalanceWhiteAuto = BalanceWhiteAuto.Off

                },

                LUTControl = new LUTControl()
                {
                    LUTEnable = false,
                    Gamma = 1.000d
                }
            };

            Log.Information("Create Device -\"Camera Right\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "Camera Right",
                ApplicationDeviceLocation = "Machine",

                DeviceName = "HR455CXGE",
                DeviceDescription = "SVS-Vistek",
                DeviceType = DeviceTypes.Vision,
                DeviceManufacturer = DeviceManufacturers.SVSVistek,
                DeviceSerialnumber = "107948",
                DeviceConfiguration = Serialize.ToString(cameraConfig),

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new Interface_Ethernet()
                {
                    Id = new System.Guid(),

                    IpAddress = "192.168.140.100",
                    Port = 0,
                    Timeout = 1000
                },
                Interfaces_Serial = null
            });

            Log.Information("Create Device -\"Camera Left\" ...");
            Globals.Context.Devices.Add(new Device()
            {
                Id = new System.Guid(),

                ApplicationDeviceName = "Camera Left",
                ApplicationDeviceLocation = "Machine",

                DeviceName = "HR455CXGE",
                DeviceDescription = "SVS-Vistek",
                DeviceType = DeviceTypes.Vision,
                DeviceManufacturer = DeviceManufacturers.SVSVistek,
                DeviceSerialnumber = "107944",
                DeviceConfiguration = Serialize.ToString(cameraConfig),

                InterfaceName = string.Empty,
                InterfaceDescription = string.Empty,
                InterfaceManufacturer = null,
                InterfaceSerialnumber = string.Empty,

                AutoStartAtSplashscreen = true,
                HomingDeviceAtSplashscreen = true,
                ConnectAtSplashscreen = true,
                InitialzeAtSplashscreen = true,

                Interfaces_Can = null,
                Interfaces_Ethernet = new Interface_Ethernet()
                {
                    Id = new System.Guid(),

                    IpAddress = "192.168.141.101",
                    Port = 0,
                    Timeout = 1000
                },
                Interfaces_Serial = null
            });
        }
    }
}
