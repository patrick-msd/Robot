namespace RC.Lib.Vision.SVSVistek
{
    public enum DeviceLinkThroughputLimitMode : byte
    {
        Off = 0x00,
        On = 0x01
    }

    public enum FanControl : byte
    {
        Off = 0x00,
        On = 0x01,
        Auto = 0x02
    }
    public enum SensorPixelSize : byte
    {
        SensorBppAuto = 0x00,
        SensorBpp8 = 0x01,
        SensorBpp10 = 0x02,
        SensorBpp11 = 0x03,
        SensorBpp12 = 0x04,
        SensorBpp14 = 0x05,
        SensorBpp16 = 0x06
    }

    public enum PixelFormat : byte
    {
        Mono8 = 0x00,
        Mono12Packed = 0x01,
        Mono16 = 0x02,
        BayerGR8 = 0x03,
        BayerRG8 = 0x04,
        BayerGB8 = 0x05,
        BayerBG8 = 0x06,
        BayerGR12Packed = 0x07,
        BayerRG12Packed = 0x08,
        BayerGB12Packed = 0x09,
        BayerBG12Packed = 0x0A,
        BayerGR16 = 0x0B,
        BayerRG16 = 0x0C,
        BayerGB16 = 0x0D,
        BayerBG16 = 0x0E
    }

    public enum BinningHorizontal : byte
    {
        Off = 0x01,
        On = 0x02,
        X4 = 0x03
    }

    public enum BinningVertical : byte
    {
        Off = 0x01,
        On = 0x02,
        X4 = 0x03
    }

    public enum ReverseX : byte
    {
        Off = 0x00,
        On = 0x01
    }

    public enum ReverseY : byte
    {
        Off = 0x00,
        On = 0x01
    }

    public enum AcquisitionMode : byte
    {
        SingleFrame = 0x00,
        MultiFrame = 0x01,
        Continuous = 0x02
    }

    public enum TriggerSelector : byte
    {
        AcquisitionStart = 0x00,
        FrameStart = 0x01
    }

    public enum TriggerMode : byte
    {
        Off = 0x00,
        On = 0x01
    }

    public enum TriggerSource : byte
    {
        Software = 0x00,
        Line1 = 0x01
    }

    public enum TriggerActivation : byte
    {
        RisingEdge = 0x00,
        FallingEdge = 0x01,
        BothEdges = 0x02
    }

    public enum SensorTriggerMode : byte
    {
        Precise = 0x00,
        Fast = 0x01,
        Freerunning = 0x02,
        FixedFrequency = 0x03,
        Triggered = 0x04
    }

    public enum ExposureMode : byte
    {
        Timed = 0x00,
        TriggerWidth = 0x01
    }

    public enum ExposureAuto : byte
    {
        Off = 0x00,
        Once = 0x01,
        Continuous = 0x02
    }

    public enum ExposureFirst : byte
    {
        Off = 0x00,
        On = 0x01
    }

    public enum SensorShutterMode : byte
    {
        Global = 0x00,
        Rolling = 0x01,
        GlobalReset = 0x02
    }

    public enum SensorReadoutMode : byte
    {
        Global = 0x00,
        Rolling = 0x01,
        GlobalReset = 0x02
    }

    public enum GainSelector : byte
    {
        All = 0x00
    }

    public enum BlackLevelSelector : byte
    {
        All = 0x00
    }

    public enum GainAuto : byte
    {
        Off = 0x00,
        Once = 0x01,
        Continuous = 0x02
    }

    public enum GainSpeed : byte
    {
        Standard = 0x00,
        Fast = 0x01
    }

    public enum BalanceWhiteAuto : byte
    {
        Off = 0x00,
        Once = 0x01,
        Continuous = 0x02
    }

}
