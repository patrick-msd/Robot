namespace PSGM.Lib.PowerSupply
{
    public enum NextysOperationMode : ushort
    {
        Single = 0x0,
        Parallel = 0x1
    }

    public enum NextysCurrentLimitation : ushort
    {
        Hiccup = 0x0,
        ConstantCurrent = 0x1
    }

    public enum NextysOutputEnable : ushort
    {
        Disable = 0x0,
        Enable = 0x1
    }

    public enum NextysLockSettings : ushort
    {
        Disable = 0x0,
        Enable = 0x1
    }
}
