namespace PSGM.Helper
{
    public enum WorkflowApplyLevel : int
    {
        Undefined = 0,

        Project = 10000,

        Organization = 20000,
        Contributor = 20001,

        Unit = 30001,

        RootDirectory = 40000,
        Subdirectory = 40001,

        File = 50000,
    }

    public enum WorkflowExecutionLevel : int
    {
        Undefined = 0,

        Automatically = 10000,

        Manually = 20000,

        ManuallyAndAutomatically = 90000,
    }

    public enum WorkflowStatus : int
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
}
