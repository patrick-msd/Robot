using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public static partial class WorkflowType
    {
        public static DbMain_WorkflowType Vision2D_GrabImage_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("05328e02-daf4-4b1f-8883-f43063f2b2e5"),

                Name_EN = "Grab image - V1.0.0",
                Description_EN = "Grab image with specified camera ...",
                Name_DE = "Bild aufnehmen - V1.0.0",
                Description_DE = "Bild mit angegebener Kamera aufnehmen ...",
                Name_FR = "Prendre une photo - V1.0.0",
                Description_FR = "Prendre une photo avec l'appareil photo spécifié ...",
                Name_SP = "Tomar una foto - V1.0.0",
                Description_SP = "Tomar una foto con la cámara especificada ...",
                Name_IT  = "Scatta una foto - V1.0.0",
                Description_IT = "Scatta una foto con la fotocamera specificata ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }
    }
}
