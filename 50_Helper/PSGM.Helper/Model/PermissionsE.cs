namespace PSGM.Helper
{
    public enum EmployeeType : int
    {
        None = 0,
        Inherited = 10,

        SuperAdmin = 10000,
        Admin = 10001,

        ProjectAdmin = 20000,
        ContributorAdmin = 20001,

        Owner = 50000,

        WorkflowAdmin = 60000,
        WorkflowContributor = 60001,

        Contributor = 70000,

        ServiceProviderScanning = 80000,
        ServiceProviderInfrastructure = 80001,
    }

    public enum PermissionType : int
    {
        None = 0,

        Inherited = 1,

        Create = 10000,
        Read = 10001,
        Update = 10002,
        Delete = 10003,

        CreateRead = 20000,
        ReadUpdate = 20001,
        CreateReadUpdate = 20002,
        ReadUpdateDelete = 20003,

        CreateReadUpdateDelete = 30000
    }
}
