using PSGM.Model.DbWorkflow;
using Serilog;
using System.Diagnostics;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Image_Resize_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            ConfigurationResizeV1_0_0 configuration = workflowItemLink.GetResizeV1_0_0Configuration();

            if (configuration != null)
            {
                _image_Data.Image = Vision2D.ResizeImage(_image_Data.Image, configuration.Width, configuration.Height);
            }
            else
            {
                Log.Debug("Resize V1.0.0 configuration not found ...");
            }
        }
    }
}
