using OpenCvSharp;
using PSGM.Model.DbWorkflow;
using Serilog;
using System.Diagnostics;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Image_Rotate_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            Configuration_RotateV1_0_0? configuration = null;
            List<Configuration_RotateV1_0_0> configurations = workflowItemLink.GetRotateV1_0_0Configuration();

            configuration = configurations.Where(p => p.CameraId == _image_Data.CameraDeviceId).FirstOrDefault();

            if (configuration != null)
            {
                Cv2.Rotate(_image_Data.Image, _image_Data.Image, configuration.Rotate);
                //Cv2.ImShow($"Image", _imageData.Image);
            }
            else
            {
                Log.Debug("Crop V1.0.0 configuration not found ...");
            }
        }

        public void Image_Rotate_V2_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            Configuration_RotateV2_0_0? configuration = null;
            List<Configuration_RotateV2_0_0> configurations = workflowItemLink.GetRotateV2_0_0Configuration();

            configuration = configurations.Where(p => p.CameraId == _image_Data.CameraDeviceId).FirstOrDefault();

            if (configuration != null)
            {
                // ToDo: Must be tested and optimized
                //  https://www.projectpro.io/recipes/rotate-image-opencv
                //Mat M = Cv2.GetRotationMatrix2D(new Point2f(_imageData.Image.Width / 2, _imageData.Image.Height / 2), configuration.angle, 1);
                //Cv2.WarpAffine(_imageData.Image, _imageData.Image, M, new OpenCvSharp.Size(_imageData.Image.Height, _imageData.Image.Width), InterpolationFlags.Linear, BorderTypes.Constant, Scalar.All(0));
                //Cv2.ImShow($"Image", M);
            }
            else
            {
                Log.Debug("Crop V1.0.0 configuration not found ...");
            }
        }
    }
}
