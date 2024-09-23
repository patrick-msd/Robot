namespace PSGM.Helper
{
    public enum ProjectStatus : int
    {
        Undefined = 0,

        Created = 20000,
        Updated = 20001,
        Deleted = 20002,

        Started = 30000,
        InProgress = 30001,
        Hold = 30002,
        Stopped = 30003,
        Finished = 30004,
    }
    public enum ProjectPermissions : int
    {
        Undefined = 0,

        Private = 20000,
        Public = 20001,
    }

}
