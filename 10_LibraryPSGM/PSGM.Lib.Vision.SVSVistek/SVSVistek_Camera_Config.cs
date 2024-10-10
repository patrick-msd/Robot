using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace PSGM.Lib.Vision.SVSVistek
{
    public partial class SVSVistek_Camera_Config
    {
        [JsonProperty("DevieControl")]
        public DevieControl DevieControl { get; set; }

        [JsonProperty("ImageFormatControl")]
        public ImageFormatControl ImageFormatControl { get; set; }

        [JsonProperty("AcquisitionControl")]
        public AcquisitionControl AcquisitionControl { get; set; }

        [JsonProperty("AnalogControl")]
        public AnalogControl AnalogControl { get; set; }

        [JsonProperty("LUTControl")]
        public LUTControl LUTControl { get; set; }
    }

    public class DevieControl
    {
        [JsonProperty("DeviceUserID")]
        public string DeviceUserID { get; set; } = "Robot";

        [JsonProperty("DeviceLinkThroughputLimitMode")]
        public DeviceLinkThroughputLimitMode DeviceLinkThroughputLimitMode { get; set; } = SVSVistek.DeviceLinkThroughputLimitMode.Off;

        [JsonProperty("DeviceLinkThroughputLimit")]
        public int DeviceLinkThroughputLimit { get; set; } = 1000000000;

        [JsonProperty("Maximum Packets Resend")]
        public int MaximumPacketsResend { get; set; } = 4095;

        [JsonProperty("LEDIntensity")]
        public int LEDIntensity { get; set; } = 64;

        [JsonProperty("FanControl")]
        public FanControl FanControl { get; set; } = FanControl.Auto;

        [JsonProperty("FanControlThreshold")]
        public double FanControlThreshold { get; set; } = 70.000d;
    }

    public class ImageFormatControl
    {
        [JsonProperty("XOffset")]
        public int XOffset { get; set; } = 0;

        [JsonProperty("YOffset")]
        public int YOffset { get; set; } = 0;

        [JsonProperty("Width")]
        public int Width { get; set; } = 9568;

        [JsonProperty("Height")]
        public int Height { get; set; } = 9380;

        [JsonProperty("SensorPixelSize")]
        public SensorPixelSize SensorPixelSize { get; set; } = SensorPixelSize.SensorBppAuto;

        [JsonProperty("PixelFormat")]
        public PixelFormat PixelFormat { get; set; } = PixelFormat.BayerGB8;

        [JsonProperty("BinningHorizontal")]
        public BinningHorizontal BinningHorizontal { get; set; } = BinningHorizontal.Off;

        [JsonProperty("BinningVertical")]
        public BinningVertical BinningVertical { get; set; } = BinningVertical.Off;

        [JsonProperty("ReverseX")]
        public ReverseX ReverseX { get; set; } = ReverseX.Off;

        [JsonProperty("ReverseY")]
        public ReverseY ReverseY { get; set; } = ReverseY.Off;
    }

    public class AcquisitionControl
    {
        [JsonProperty("AcquisitionMode")]
        public AcquisitionMode AcquisitionMode { get; set; } = AcquisitionMode.Continuous;

        [JsonProperty("TriggerSelector")]
        public TriggerSelector TriggerSelector { get; set; } = TriggerSelector.AcquisitionStart;

        [JsonProperty("TriggerMode")]
        public TriggerMode TriggerMode { get; set; } = TriggerMode.Off;

        [JsonProperty("TriggerSource")]
        public TriggerSource TriggerSource { get; set; } = TriggerSource.Software;

        [JsonProperty("TriggerActivation")]
        public TriggerActivation TriggerActivation { get; set; } = TriggerActivation.RisingEdge;

        [JsonProperty("TriggerDelay")]
        public double TriggerDelay { get; set; } = 0;

        [JsonProperty("SensorTriggerMode")]
        public SensorTriggerMode SensorTriggerMode { get; set; } = SensorTriggerMode.Freerunning;

        [JsonProperty("ExposureMode")]
        public ExposureMode ExposureMode { get; set; } = ExposureMode.Timed;

        [JsonProperty("ExposureTime")]
        public double ExposureTime { get; set; } = 55000.000d;

        [JsonProperty("ExposureAuto")]
        public ExposureAuto ExposureAuto { get; set; } = ExposureAuto.Off;

        [JsonProperty("ExposureFirst")]
        public ExposureFirst ExposureFirst { get; set; } = ExposureFirst.On;

        [JsonProperty("ExposureTimeMin")]
        public double ExposureTimeMin { get; set; } = 1000.000d;

        [JsonProperty("ExposureTimeMax")]
        public double ExposureTimeMax { get; set; } = 250000.000d;

        [JsonProperty("SensorShutterMode")]
        public SensorShutterMode SensorShutterMode { get; set; } = SensorShutterMode.Rolling;
    }

    public class AnalogControl
    {
        [JsonProperty("GainSelector")]
        public GainSelector GainSelector { get; set; } = GainSelector.All;

        [JsonProperty("Gain")]
        public double Gain { get; set; } = 0.000d;

        [JsonProperty("BlackLevelSelector")]
        public BlackLevelSelector BlackLevelSelector { get; set; } = BlackLevelSelector.All;

        [JsonProperty("BlackLevel")]
        public double BlackLevel { get; set; } = 0.000d;

        [JsonProperty("GainAuto")]
        public GainAuto GainAuto { get; set; } = GainAuto.Off;

        [JsonProperty("GainSpeed")]
        public GainSpeed GainSpeed { get; set; } = GainSpeed.Standard;

        [JsonProperty("GainAutoLevel")]
        public int GainAutoLevel { get; set; } = 100;

        [JsonProperty("GainAutoMin")]
        public double GainAutoMin { get; set; } = 0.000d;

        [JsonProperty("GainAutoMax")]
        public double GainAutoMax { get; set; } = 36.000d;

        [JsonProperty("BalanceWhiteRatioRed")]
        public double BalanceWhiteRatioRed { get; set; } = 1.000d;

        [JsonProperty("BalanceWhiteRatioGreen")]
        public double BalanceWhiteRatioGreen { get; set; } = 1.000d;

        [JsonProperty("BalanceWhiteRatioBlue")]
        public double BalanceWhiteRatioBlue { get; set; } = 1.000d;

        [JsonProperty("BalanceWhiteAuto")]
        public BalanceWhiteAuto BalanceWhiteAuto { get; set; } = BalanceWhiteAuto.Off;
    }

    public class LUTControl
    {
        [JsonProperty("LUTEnable")]
        public bool LUTEnable { get; set; } = false;

        [JsonProperty("Gamma")]
        public double Gamma { get; set; } = 1.000d;
    }

    public partial class SVSVistek_Camera_Config
    {
        public static SVSVistek_Camera_Config ToJson(string json) => JsonConvert.DeserializeObject<SVSVistek_Camera_Config>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToString(this SVSVistek_Camera_Config self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            }
        };
    }
}
