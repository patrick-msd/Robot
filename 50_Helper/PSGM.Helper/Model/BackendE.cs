namespace PSGM.Helper
{
    public enum BackendType : int
    {
        Undefined = 0,

        Main = 10000,

        DataRaw = 11000,
        Data = 11001,

        Archive  = 12000, 
        
        Job = 13000,

        Machine = 14000,

        Software = 15000,

        Workflow = 16000,



        User = 90000
    }
}
