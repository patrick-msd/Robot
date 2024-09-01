namespace PSGM.Helper
{
    public enum ProjectStatus : uint
    {
        Undefined = 0,

        Created = 10000,

        Started = 20000,

        InProgress = 30000,

        Hold = 70000,

        Stopped = 80000,
      
        Finished = 90000,
    }
}
