namespace PSGM.Helper
{
    public enum PermissionsType : int
    {
        None = 0,
        Inherited = 1,

        Owner = 10000,

        SuperAdmin = 20000,
        Admin = 20001,

        ReadWrite = 30000,
        ReadWriteDelete = 30001,



        ServiceProviderScanning = 80000,
        ServiceProviderInfrastructure = 80001,

        Viewer = 90000
    }
}
