using PSGM.Model.DbWorkflow;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Storage_S3AndDatabase_Save_DataRawThumbnail_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            Configuration_SaveImageV1_0_0 configuration = workflowItemLink.GetSaveImageV1_0_0Configuration();

            // ToDo: ...
        }
    }
}
