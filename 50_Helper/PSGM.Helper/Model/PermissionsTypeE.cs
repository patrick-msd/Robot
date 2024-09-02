namespace PSGM.Helper
{
    public enum PermissionType : int
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
}
