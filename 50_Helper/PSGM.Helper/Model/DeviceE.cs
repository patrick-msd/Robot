namespace PSGM.Helper
{
    public enum DeviceGroupeType : int
    {
        Undefined = 0,

        MainFrame = 10000,

        BookCradle = 20000,

        SheetCradle = 30000,
    }

    public enum DeviceLocation : int
    {
        Undefined = 0,

        ControlCabinet = 10000,

        MainFrame = 20000,

        SheetCradle = 30000,
        SheetCradleLeft = 30001,
        SheetCradleRight = 30002,

        BookCradle = 40000,
        BookCradleLeft = 40001,
        BookCradleRight = 40002,


        Magazine = 90000,
    }

    public enum DeviceCategory : int
    {
        Undefined = 0,

        Controller = 10000,

        Motion = 20000,

        PowerSupply = 30000,

        Robot = 40000,

        Vision = 50000,
    }

    public enum DeviceManufacturer : int
    {
        Undefined = 0,

        //Controller
        RobotElectronics = 10000,

        // Motion
        Nanotec = 20000,

        // Power Supply
        Nextys = 30000,

        // Robot
        Doosan = 40000,

        // Vision
        Intel = 50000,
        SVSVistek = 50001,
        OptoEngineering = 50002,


        // Interfaces
        IXXAT = 90000,
    }

    public enum DeviceType : int
    {
        Undefined = 0,

        // Controller
        DS2408 = 10000,

        // Motion
        PD2_C4118L1804_E_08 = 20000,
        CL3_E_1_0F_AND_SC3518M1204 = 20001,
        LGA421L18_B_UKGI_064 = 20002,

        // PowerSupply
        NDW240 = 30000,

        // Robot
        M0609 = 40000,

        // Vision
        HR455CXGE = 50000,

        // Interfaces
        HW630322 = 90000,
        HW025152 = 90001,
    }
}
