namespace PSGM.Helper
{
    public enum WorkflowApplyLevel : uint
    {
        Undefined = 0,

        File = 10000,

        RootDirectory = 20000,
        Subdirectory = 20001,

        Project = 30000,

        Organization = 40000,
    }

    public enum WorkflowExecutionLevel : uint
    {
        Undefined = 0,

        Automatically = 10000,

        Manually = 20000,

        ManuallyAndAutomatically = 90000,
    }
}
