using PSGM.Model.DbWorkflow;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Storage_S3AndDatabase_Save_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            if (workflowItemLink.StorageClass == StorageClass.DataRaw)
            {
                Storage_S3AndDatabase_Save_DataRaw_V1_0_0(workflowItemLink);
            }

            else if (workflowItemLink.StorageClass == StorageClass.DataRawThumbnail)
            {
                Storage_S3AndDatabase_Save_DataRawThumbnail_V1_0_0(workflowItemLink);
            }

            else if (workflowItemLink.StorageClass == StorageClass.DataRawAndDataRawThumbnail)
            {
                Storage_S3AndDatabase_Save_DataRaw_V1_0_0(workflowItemLink);
                Storage_S3AndDatabase_Save_DataRawThumbnail_V1_0_0(workflowItemLink);
            }

            else if (workflowItemLink.StorageClass == StorageClass.Data)
            {
                Storage_S3AndDatabase_Save_Data_V1_0_0(workflowItemLink);

            }

            else if (workflowItemLink.StorageClass == StorageClass.DataThumbnail)
            {
                Storage_S3AndDatabase_Save_DataThumbnail_V1_0_0(workflowItemLink);
            }

            else if (workflowItemLink.StorageClass == StorageClass.DataAndDataThumbnail)
            {
                Storage_S3AndDatabase_Save_Data_V1_0_0(workflowItemLink);
                Storage_S3AndDatabase_Save_DataThumbnail_V1_0_0(workflowItemLink);
            }

            else
            {
                throw new Exception("Storage class not supported");
            }
        }
    }
}
