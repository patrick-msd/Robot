namespace PSGM.Helper
{
    public enum DirectoryState : int
    {
        Undefined = 0,

        DeliverSlipCreated = 10000,
        InPreparation = 10001,

        WaitingForScanning = 20001,
        Scanning = 20002,
    }
}
