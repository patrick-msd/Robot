using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public static partial class WorkflowType
    {
        public static DbMain_WorkflowType Image_HDR_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("7394722e-1574-435a-b7c6-27e56e54c4d9"),

                Name_EN = "Calculate HDR image - V1.0.0",
                Description_EN = "Calculate HDR image with OpenCV (mergeMertens) ...",
                Name_DE = "HDR-Bild berechnen - V1.0.0",
                Description_DE = "HDR-Bild mit OpenCV (mergeMertens) berechnen ...",
                Name_FR = "Calculer l'image HDR - V1.0.0",
                Description_FR = "Calculer l'image HDR avec OpenCV (mergeMertens) ...",
                Name_SP = "Calcular imagen HDR - V1.0.0",
                Description_SP = "Calcular imagen HDR con OpenCV (mergeMertens) ...",
                Name_IT = "Calcola l'immagine HDR - V1.0.0",
                Description_IT = "Calcola l'immagine HDR con OpenCV (mergeMertens) ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },
                
                WorkflowItems = null
            };
        }

        public static DbMain_WorkflowType Image_Darktable_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("63b73409-2f96-42df-8c5d-54c06842bd75"),

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

        public static DbMain_WorkflowType Image_Resize_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("e58f3c8c-d574-40f9-8c0b-c930b7181c9f"),

                Name_EN = "Resize image - V1.0.0",
                Description_EN = "Resize image to specified size...",
                Name_DE = "Bildgröße ändern - V1.0.0",
                Description_DE = "Bildgröße auf angegebene Größe ändern ...",
                Name_FR = "Redimensionner l'image - V1.0.0",
                Description_FR = "Redimensionner l'image à la taille spécifiée ...",
                Name_SP = "Cambiar tamaño de la imagen - V1.0.0",
                Description_SP = "Cambiar tamaño de la imagen al tamaño especificado ...",
                Name_IT = "Ridimensiona l'immagine - V1.0.0",
                Description_IT = "Ridimensiona l'immagine alla dimensione specificata ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }

        public static DbMain_WorkflowType Image_Crop_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("b3f0ed21-eb46-44b0-baac-9f4f3c94b56a"),

                Name_EN = "Crop image - V1.0.0",
                Description_EN = "Crop image to specified size...",
                Name_DE = "Bild zuschneiden - V1.0.0",
                Description_DE = "Bild auf angegebene Größe zuschneiden ...",
                Name_FR = "Recadrer l'image - V1.0.0",
                Description_FR = "Recadrer l'image à la taille spécifiée ...",
                Name_SP = "Recortar imagen - V1.0.0",
                Description_SP = "Recortar imagen al tamaño especificado ...",
                Name_IT = "Ritaglia l'immagine - V1.0.0",
                Description_IT = "Ritaglia l'immagine alla dimensione specificata ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }

        public static DbMain_WorkflowType Image_Rotate_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("ada0860b-eabc-4051-b8ad-7b40d1bff3d1"),

                Name_EN = "Rotate image - V1.0.0",
                Description_EN = "Rotate image ...",
                Name_DE = "Bild drehen - V1.0.0",
                Description_DE = "Bild drehen ...",
                Name_FR = "Faire pivoter l'image - V1.0.0",
                Description_FR = "Faire pivoter l'image ...",
                Name_SP = "Girar imagen - V1.0.0",
                Description_SP = "Girar imagen ...",
                Name_IT = "Ruota l'immagine - V1.0.0",
                Description_IT = "Ruota l'immagine ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }

        public static DbMain_WorkflowType Image_Rotate_V2_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("7486c122-9c08-41dc-a24a-19c3a25582db"),

                Name_EN = "Rotate image - V2.0.0",
                Description_EN = "Rotate image ...",
                Name_DE = "Bild drehen - V2.0.0",
                Description_DE = "Bild drehen ...",
                Name_FR = "Faire pivoter l'image - V2.0.0",
                Description_FR = "Faire pivoter l'image ...",
                Name_SP = "Girar imagen - V2.0.0",
                Description_SP = "Girar imagen ...",
                Name_IT = "Ruota l'immagine - V2.0.0",
                Description_IT = "Ruota l'immagine ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }

        public static DbMain_WorkflowType Image_Sharpen_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("e4434561-0668-4d2b-8ec1-21152edd5226"),

                Name_EN = "Sharpen image - V1.0.0",
                Description_EN = "Sharpen image ...",
                Name_DE = "Bild schärfen - V1.0.0",
                Description_DE = "Bild schärfen ...",
                Name_FR = "Affûter l'image - V1.0.0",
                Description_FR = "Affûter l'image ...",
                Name_SP = "Afilar imagen - V1.0.0",
                Description_SP = "Afilar imagen ...",
                Name_IT = "Affilare l'immagine - V1.0.0",
                Description_IT = "Affilare l'immagine ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }

        public static DbMain_WorkflowType Image_Sharpen_V2_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("ac3f6348-ed27-4e6e-b387-2043c221865e"),

                Name_EN = "Sharpen image - V2.0.0",
                Description_EN = "Sharpen image ...",
                Name_DE = "Bild schärfen - V2.0.0",
                Description_DE = "Bild schärfen ...",
                Name_FR = "Affûter l'image - V2.0.0",
                Description_FR = "Affûter l'image ...",
                Name_SP = "Afilar imagen - V2.0.0",
                Description_SP = "Afilar imagen ...",
                Name_IT = "Affilare l'immagine - V2.0.0",
                Description_IT = "Affilare l'immagine ...",

                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Automatically, WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Undefined },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }
    }
}
