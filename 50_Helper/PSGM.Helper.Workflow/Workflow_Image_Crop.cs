using PSGM.Model.DbWorkflow;
using Serilog;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Image_Crop_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            Configuration_CropV1_0_0? configuration = null;
            List<Configuration_CropV1_0_0> configurations = workflowItemLink.GetCropV1_0_0Configuration();

            configuration = configurations.Where(p => p.CameraId == _image_Data.CameraDeviceId).FirstOrDefault();

            if (configuration != null)
            {
                if (configuration.RowEnd <= 0)
                {
                    configuration.RowEnd = _image_Data.Image.Height;
                }

                if (configuration.ColumnEnd <= 0)
                {
                    configuration.ColumnEnd = _image_Data.Image.Width;
                }

                _image_Data.Image = _image_Data.Image[configuration.RowStart, configuration.RowEnd, configuration.ColumnStart, configuration.ColumnEnd];
                //Cv2.ImShow($"Image", _imageData.Image);
            }
            else
            {
                Log.Debug("Crop V1.0.0 configuration not found ...");
            }
        }
    }
}
