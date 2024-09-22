namespace PSGM.Helper
{
    public enum EmployeeType : int
    {
        None = 0,
        Inherited = 1,

        SuperAdmin = 10000,
        Admin = 10001,

        Owner = 20000,

        Read = 30000,
        ReadWrite = 30000,
        ReadWriteDelete = 30001,

        WorkflowAdmin = 80000,
        WorkflowContributor = 80001,

        ServiceProviderScanning = 90000,
        ServiceProviderInfrastructure = 90001,
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
