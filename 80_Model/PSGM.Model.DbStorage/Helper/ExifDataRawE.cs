namespace PSGM.Model.DbStorage
{
    public enum Compression : int
    {
        None = 0,

        Uncompressed = 1,
        CCITT1D = 2,
        T4_Group3Fax = 3,
        T6_Group4Fax = 4,
        LZW = 5,
        JPEGold_style = 6,
        JPEG = 7,
        AdobeDeflate = 8,
        JBIGBandW = 9,
        JBIGColor = 10,
        //JPEG = 99,
        Kodak262 = 262,
        Next = 32766,
        SonyARWCompressed = 32767,
        PackedRAW = 32769,
        SamsungSRWCompressed = 32770,
        CCIRLEW = 32771,
        SamsungSRWCompressed2 = 32772,
        PackBits = 32773,
        Thunderscan = 32809,
        KodakKDCCompressed = 32867,
        IT8CTPAD = 32895,
        IT8LW = 32896,
        IT8MP = 32897,
        IT8BL = 32898,
        PixarFilm = 32908,
        PixarLog = 32909,
        Deflate = 32946,
        DCS = 32947,
        AperioJPEG2000YCbCr = 33003,
        AperioJPEG2000RGB = 33005,
        JBIG = 34661,
        SGILog = 34676,
        SGILog24 = 34677,
        JPEG2000 = 34712,
        NikonNEFCompressed = 34713,
        JBIG2TIFFFX = 34715,
        MicrosoftDocumentImagingMDIBinaryLevelCodec = 34718,
        MicrosoftDocumentImagingMDIProgressiveTransformCodec = 34719,
        MicrosoftDocumentImagingMDIVector = 34720,
        ESRILerc = 34887,
        LossyJPEG = 34892,
        LZMA2 = 34925,
        Zstd = 34926,
        WebP = 34927,
        PNG = 34933,
        JPEGXR = 34934,
        JPEGXL = 52546,
        KodakDCRCompressed = 65000,
        PentaxPEFCompressed = 65535,
    }

    public enum ExposureProgram : uint
    {
        NotDefined = 0,

        Manual = 1,
        ProgramAE = 2,
        AperturePriorityAE = 3,
        ShutterSpeedPriorityAE = 4,
        CreativeSlowSpeed = 8,
        ActionHighSpeed = 6,
        Portrait = 7,
        Landscape = 8,
        Bulb = 9,
    }

    public enum ExposureMode : uint
    {
        Auto = 0,

        Manual = 1,
        AutoBracket = 2,
    }       

    public enum LightSource : uint
    {
        Unknown = 0,

        Daylight = 1,
        Fluorescent = 2,
        TungstenIncandescent = 3,
        Flash = 4,
        FineWeather = 9,
        Cloudy = 10,
        Shade = 11,
        DaylightFluorescent = 12,
        DayWhiteFluorescent = 13,
        CoolWhiteFluorescent = 14,
        WhiteFluorescent = 15,
        WarmWhiteFluorescent = 16,
        StandardLightA = 17,
        StandardLightB = 18,
        StandardLightC = 19,
        D55 = 20,
        D65 = 21,
        D75 = 22,
        D50 = 23,
        ISOStudioTungsten = 24,
        Other = 255
    }

    public enum Flash : uint
    {
        NoFlash = 0,

        Fired = 1,
        //0x5	= Fired, Return not detected
        //0x7	= Fired, Return detected
        //0x8	= On, Did not fire
        //0x9	= On, Fired
        //0xd	= On, Return not detected
        //0xf	= On, Return detected
        //0x10	= Off, Did not fire
        //0x14	= Off, Did not fire, Return not detected
        //0x18	= Auto, Did not fire
        //0x19	= Auto, Fired
        //0x1d	= Auto, Fired, Return not detected
        //0x1f	= Auto, Fired, Return detected
        //0x20	= No flash function
        //0x30	= Off, No flash function
        //0x41	= Fired, Red-eye reduction
        //0x45	= Fired, Red-eye reduction, Return not detected
        //0x47	= Fired, Red-eye reduction, Return detected
        //0x49	= On, Red-eye reduction
        //0x4d	= On, Red-eye reduction, Return not detected
        //0x4f	= On, Red-eye reduction, Return detected
        //0x50	= Off, Red-eye reduction
        //0x58	= Auto, Did not fire, Red-eye reduction
        //0x59	= Auto, Fired, Red-eye reduction
        //0x5d	= Auto, Fired, Red-eye reduction, Return not detected
        //0x5f	= Auto, Fired, Red-eye reduction, Return detected
    }

    public enum ColorSpace : uint
    {
        Unknown = 0,

        sRGB = 1,
        AdobeRGB = 2,
        WideGamutRGB = 65533,
        ICCProfile = 65534,
        Uncalibrated = 65535
    }

    public enum ResolutionUnit : uint
    {
        None = 1,

        Inch = 2,
        Centimeter = 3
    }
}
