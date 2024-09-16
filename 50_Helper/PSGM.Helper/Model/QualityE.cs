namespace PSGM.Helper
{
    public enum QualityState : uint
    {
        Undefined = 0,

        Unchecked = 10000,

        CheckPassed = 20000,
        CheckNotPassed = 20001,
    }
}
