using PSGM.Model.DbWorkflow;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Storage_FilesystemAndDatabase_Save_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            if (workflowItemLink.StorageClass == StorageClass.DataRaw)
            {
                // ToDo: ...
            }

            if (workflowItemLink.StorageClass == StorageClass.Data)
            {
                // ToDo: ...
            }

            if (workflowItemLink.StorageClass == StorageClass.DataThumbnail)
            {
                // ToDo: ...    
            }
        }
    }
}
