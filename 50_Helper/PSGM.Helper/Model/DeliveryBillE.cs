namespace PSGM.Helper
{
    public enum DeliverySlipType : uint
    {
        Undefined = 0,

        Created = 10000,

        Started = 20000,
        InProgress = 20001,
        Stopped = 20002,
        Paused = 20003,
        Finished = 20004,
    }
}
