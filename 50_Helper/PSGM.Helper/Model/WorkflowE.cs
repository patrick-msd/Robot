namespace PSGM.Helper
{
    public enum ApplyLevel : uint
    {
        Undefined = 0,

        File = 10000,

        RootDirectory = 20000,
        Subdirectory = 20001,

        Project = 30000,

        Organization = 40000,
    }
}
