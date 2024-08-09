using PSGM.Model.DbWorkflow;

namespace PSGM.Helper.Workflow
{

    public partial class Workflow
    {
        public void StorageAndDatabase_Save_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            if (workflowItemLink.StorageType == StorageType.S3)
            {
                Storage_S3AndDatabase_Save_V1_0_0(workflowItemLink);
            }
            else if (workflowItemLink.StorageType == StorageType.Filesystem)
            {
                Storage_FilesystemAndDatabase_Save_V1_0_0(workflowItemLink);
            }
            else
            {
                throw new Exception("Storage type not supported");
            }
        }
    }
}
