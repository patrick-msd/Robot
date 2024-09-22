namespace PSGM.Helper
{
    public enum QrCodeType : int
    {
        Undefined = 0,

        Batch = 10000,
        ScanUnit = 10001,

        // Scan Types
        IgnoreDoublePageSensor = 50000,
        ReplaceImage = 50001,

    }
}
