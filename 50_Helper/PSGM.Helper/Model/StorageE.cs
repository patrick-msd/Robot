namespace PSGM.Helper
{
    public enum StorageType : int
    {
        Unknown = 0,

        Inherited = 10,

        Filesystem = 10000,

        S3 = 20000,
    }

    public enum StorageClass : int
    {
        Unknown = 0,

        DataMain = 10000,


        DataRaw = 20000,
        DataRawThumbnail = 20001,
        DataRawAndDataRawThumbnail = 20002,

        Data = 30000,
        DataThumbnail = 30001,
        DataAndDataThumbnail = 30002,

        DataTranscription = 40000,
    }

    public enum StorageTier : int
    {
        Unknown = 0,

        // https://learn.microsoft.com/en-us/azure/storage/blobs/access-tiers-overview
        // https://www.techtarget.com/searchstorage/definition/tiered-storage

        Hot = 10000,

        Cool = 20000,

        Cold = 30000,

        Archive = 40000,
    }
}
