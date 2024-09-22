namespace PSGM.Helper
{
    public enum SoftwareType : int
    {
        Unknown = 0,

        SheetScanner = 10000,
    }

    public enum ReleaseChannel : int
    {
        Unknown = 0,

        Official = 10000,
        ReleaseCandidate = 20000,
        EarlyAccess = 30000,
        Beta = 40000,
        Alpha = 50000,
    }
}
