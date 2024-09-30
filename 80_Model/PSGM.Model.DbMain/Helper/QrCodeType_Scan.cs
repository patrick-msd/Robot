namespace PSGM.Model.DbMain
{
    public static partial class QrCodeType
    {
        public static DbMain_QrCodeType IgnoreDoublePageSensor_V1_0_0()
        {
            return new DbMain_QrCodeType
            {
                Id = new Guid("0c9491a2-81f1-4c68-9f80-9b9ea39ae481"),

                Name_EN = "Ignore double page sensor - V1.0.0",
                Description_EN = "Ignore double page sensor ...",
                Name_DE = "Doppelseitensensor ignorieren - V1.0.0",
                Description_DE = "Doppelseitensensor ignorieren ...",
                Name_FR = "Ignorer le capteur de double page - V1.0.0",
                Description_FR = "Ignorer le capteur de double page ...",
                Name_SP = "Ignorar el sensor de doble página - V1.0.0",
                Description_SP = "Ignorar el sensor de doble página ...",
                Name_IT = "Ignora il sensore di doppia pagina - V1.0.0",
                Description_IT = "Ignora il sensore di doppia pagina ...",

                // FK
                QrCodes = null
            };
        }

        public static DbMain_QrCodeType ReplaceImage_V1_0_0()
        {
            return new DbMain_QrCodeType
            {
                Id = new Guid("599b9687-add1-4b1d-a91b-37581b626231"),

                Name_EN = "Replace image - V1.0.0",
                Description_EN = "Replace image ...",
                Name_DE = "Bild ersetzen - V1.0.0",
                Description_DE = "Bild ersetzen ...",
                Name_FR = "Remplacer l'image - V1.0.0",
                Description_FR = "Remplacer l'image ...",
                Name_SP = "Reemplazar imagen - V1.0.0",
                Description_SP = "Reemplazar imagen ...",
                Name_IT = "Sostituisci immagine - V1.0.0",
                Description_IT = "Sostituisci immagine ...",

                // FK
                QrCodes = null
            };
        }
    }
}
