using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public static partial class WorkflowType
    {
        public static DbMain_WorkflowType StorageAndDatabase_Save_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("58f638cb-d798-49c7-aef2-9fb995ae1976"),

                Name_EN = "Store and Database Save - V1.0.0",
                Description_EN = "Store and Database Save ...",
                Name_DE = "Speichern und Datenbank speichern - V1.0.0",
                Description_DE = "Speichern und Datenbank speichern ...",
                Name_FR = "Enregistrer et sauvegarder la base de données - V1.0.0",
                Description_FR = "Enregistrer et sauvegarder la base de données ...",
                Name_SP = "Guardar y guardar en la base de datos - V1.0.0",
                Description_SP = "Guardar y guardar en la base de datos ...",
                Name_IT = "Salva e salva nel database - V1.0.0",
                Description_IT = "Salva e salva nel database ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually, WorkflowExecutionLevel.ManuallyAndAutomatically },

                StorageType = new List<StorageType> { StorageType.S3, StorageType.Filesystem },
                StorageClass = new List<StorageClass> { StorageClass.DataMain, StorageClass.DataRaw, StorageClass.DataRawThumbnail, StorageClass.DataRawAndDataRawThumbnail, StorageClass.Data, StorageClass.DataThumbnail, StorageClass.DataAndDataThumbnail, StorageClass.DataTranscription, },

                WorkflowItems = null
            };
        }
    }
}
