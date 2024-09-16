namespace PSGM.Helper
{
    public enum QrCodeType : uint
    {
        Undefined = 0,

        Batch = 10000,
        ScanUnit = 10001,

        // Scan Types
        IgnoreDoublepageSensor = 50000,
        ReplaceImage = 50001,

    }
}
