namespace PSGM.Helper
{
    public static class QrCodeType_Id
    {
        public static Guid Batch_V1_0_0 { get; } = new Guid("242ff725-c58e-4927-9f74-7e7cf737bd17");

        public static Guid ScanUnit_V1_0_0 { get; } = new Guid("6156cbce-6f04-4beb-ac16-257ffe204564");

        #region Scan Types
        public static Guid IgnoreDoublePageSensor_V1_0_0 { get; } = new Guid("0c9491a2-81f1-4c68-9f80-9b9ea39ae481");

        public static Guid ReplaceImage_V1_0_0 { get; } = new Guid("599b9687-add1-4b1d-a91b-37581b626231");
        #endregion

    }
}
