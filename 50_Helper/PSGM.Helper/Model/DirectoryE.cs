namespace PSGM.Helper
{
    public enum DirectoryState : uint
    {
        Undefined = 0,

        DeliveryBillCreated = 10000,
        InPreparation = 10001,

        WaitingForScanning = 20001,
        Scanning = 20002,
    }
}
