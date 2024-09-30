namespace PSGM.Model.DbMain
{
    public static partial class QrCodeType
    {
        public static DbMain_QrCodeType Batch_V1_0_0()
        {
            return new DbMain_QrCodeType
            {
                Id = new Guid("242ff725-c58e-4927-9f74-7e7cf737bd17"),

                Name_EN = "Batch - V1.0.0",
                Description_EN = "Batch of documents ...",
                Name_DE = "Stapel - V1.0.0",
                Description_DE = "Stapel von Dokumenten ...",
                Name_FR = "Lot - V1.0.0",
                Description_FR = "Lot de documents ...",
                Name_SP = "Lote - V1.0.0",
                Description_SP = "Lote de documentos ...",
                Name_IT = "Batch - V1.0.0",
                Description_IT = "Batch di documenti ...",

                // FK
                QrCodes = null
            };
        }

        public static DbMain_QrCodeType ScanUnit_V1_0_0()
        {
            return new DbMain_QrCodeType
            {
                Id = new Guid("6156cbce-6f04-4beb-ac16-257ffe204564"),

                Name_EN = "Scan unit - V1.0.0",
                Description_EN = "Scan unit ...",
                Name_DE = "Scan-Einheit - V1.0.0",
                Description_DE = "Scan-Einheit ...",
                Name_FR = "Unité de numérisation - V1.0.0",
                Description_FR = "Unité de numérisation ...",
                Name_SP = "Unidad de escaneo - V1.0.0",
                Description_SP = "Unidad de escaneo ...",
                Name_IT = "Unità di scansione - V1.0.0",
                Description_IT = "Unità di scansione ...",

                // FK
                QrCodes = null
            };
        }
    }
}
