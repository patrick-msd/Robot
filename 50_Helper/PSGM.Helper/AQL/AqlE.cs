namespace PSGM.Helper
{
    public enum AqlQuantity : int
    {
        None = -1,

        PerOrder = 10000,
        PerScanUnit = 20000,
    }

    public enum AqlInspectionLevel : int
    {
        None = -1,

        I = 0,
        II = 1,
        III = 2,

        S1 = 3,
        S2 = 4,
        S3 = 5,
        S4 = 6,
    }

    public enum SampleSizeLetter : int
    {
        None = -1,

        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7,
        I = 8,
        J = 9,
        K = 10,
        L = 11,
        M = 12,
        N = 13,
        O = 14,
        P = 15,
        Q = 16,
        R = 17,
        S = 18,
        T = 19,
        U = 20,
        V = 21,
        W = 22,
        X = 23,
        Y = 24,
        Z = 25,
    }

    public enum AcceptableQualityLevel : int
    {
        None = -1,

        ZeroPointZeroSixtyFive = 0,
        ZeroPointTen = 1,
        ZeroPointFifteen = 2,
        ZeroPointTwentyFive = 3,
        ZeroPointForty = 4,
        ZeroPointSixtyFive = 5,
        OnePointZero = 6,
        OnePointFive = 7,
        TwoPointFive = 8,
        FourPointZero = 9,
        SixPointFive = 10
    }

    public enum AqlState : int
    {
        None = -1,

        InProgress = 10000,

        FinishedWithErrors = 20000,
        FinishedWithWarnings = 20001,
        FinishedWithSuccess = 20002,
    }
}
