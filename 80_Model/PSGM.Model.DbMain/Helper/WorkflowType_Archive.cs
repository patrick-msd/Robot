using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public static partial class WorkflowType
    {
        public static DbMain_WorkflowType Archive_V1_0_0()
        {
            return new DbMain_WorkflowType
            {
                Id = new Guid("e14ec448-ff6b-4387-b5c3-0e22d2bd5e47"),

                Name_EN = "Archive",
                Description_EN = "Archive files, sub folders, root folders, units, projects, ...",
                Name_DE = "Archiv",
                Description_DE = "Dateien, Unterordner, Stammordner, Einheiten, Projekte, ... archivieren",
                Name_FR = "Archiver",
                Description_FR = "Archiver des fichiers, des sous-dossiers, des dossiers racine, des unités, des projets, ...",
                Name_SP = "Archivo",
                Description_SP = "Archivar archivos, subcarpetas, carpetas raíz, unidades, proyectos, ...",
                Name_IT = "Archivio",
                Description_IT = "Archiviare file, sottocartelle, cartelle radice, unità, progetti, ...",


                ApplyLevel = new List<WorkflowApplyLevel> { WorkflowApplyLevel.File, WorkflowApplyLevel.Subdirectory, WorkflowApplyLevel.RootDirectory, WorkflowApplyLevel.Unit, WorkflowApplyLevel.Project },
                ExecutionLevel = new List<WorkflowExecutionLevel> { WorkflowExecutionLevel.Manually },

                StorageType = new List<StorageType> { StorageType.Tape },
                StorageClass = new List<StorageClass> { StorageClass.Undefined },

                WorkflowItems = null
            };
        }
    }
}
