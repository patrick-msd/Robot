using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public static partial class WorkflowType
    {
        public static DbMain_WorkflowType Image_SharpeningCheck_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("a5d15ef9-103e-4a30-8de6-b0b2fbd6d293"),

                Name_EN = "Check image sharpening - V1.0.0",
                Description_EN = "Check image sharpening according to the sidecar file ...",
                Name_DE = "Bildschärfe überprüfen - V1.0.0",
                Description_DE = "Bildschärfe überprüfen gemäß der Sidecar-Datei ...",
                Name_FR = "Vérifier l'affûtage de l'image - V1.0.0",
                Description_FR = "Vérifier l'affûtage de l'image selon le fichier sidecar ...",
                Name_SP = "Verificar el afilado de la imagen - V1.0.0",
                Description_SP = "Verificar el afilado de la imagen según el archivo sidecar ...",
                Name_IT = "Controlla la nitidezza dell'immagine - V1.0.0",
                Description_IT = "Controlla la nitidezza dell'immagine in base al file sidecar ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }

        public static DbMain_WorkflowType Image_ImageExposureCheck_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("e7d5bf8e-7f68-40c5-8df8-d669b9194807"),

                Name_EN = "Calculate darktable image - V1.0.0",
                Description_EN = "Calculate darktable image according to the sidecar file ...",
                Name_DE = "HDR-Bild berechnen - V1.0.0",
                Description_DE = "Calculate darktable image according to the sidecar file ...",
                Name_FR = "Calculer l'image darktable - V1.0.0",
                Description_FR = "Calculer l'image darktable selon le fichier sidecar ...",
                Name_SP = "Calcular imagen darktable - V1.0.0",
                Description_SP = "Calcular imagen darktable según el archivo sidecar ...",
                Name_IT = "Calcola l'immagine darktable - V1.0.0",
                Description_IT = "Calcola l'immagine darktable in base al file sidecar ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }
    }
}
