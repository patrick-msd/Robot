using OpenCvSharp;
using PSGM.Model.DbWorkflow;
using Serilog;
using System.Diagnostics;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Image_Sharpen_V1_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            ConfigurationSharpenV1_0_0? configuration = null;
            List<ConfigurationSharpenV1_0_0> configurations = workflowItemLink.GetSharpenV1_0_0Configuration();

            configuration = configurations.Where(p => p.CameraId == _image_Data.CameraDeviceId).FirstOrDefault();

            if (configuration != null)
            {
                // https://qiita.com/kaiyu_tech/items/a37fc929ac0f3328fea1
                // https://bleedaiacademy.com/designing-advanced-image-filters-in-opencv-creating-instagram-filters-pt-3%E2%81%843/
                // https://learnopencv.com/non-photorealistic-rendering-using-opencv-python-c/
                // https://learnopencv.com/image-filtering-using-convolution-in-opencv/
                // https://medium.com/dataseries/designing-image-filters-using-opencv-like-abode-photoshop-express-part-1-8765e3f4495b
                // https://en.wikipedia.org/wiki/Unsharp_masking

                //Cv2.ImShow("Original", _imageData.Image);
                Cv2.Filter2D(_image_Data.Image, _image_Data.Image, MatType.CV_8UC3, InputArray.Create(configuration.Filter));
                //Cv2.ImShow("Shaping", _imageData.Image);
            }
            else
            {
                Log.Debug("Crop V1.0.0 configuration not found ...");
            }
        }

        public void Image_Sharpen_V2_0_0(DbWorkflow_WorkflowItemLink workflowItemLink)
        {
            ConfigurationSharpenV2_0_0? configuration = null;
            List<ConfigurationSharpenV2_0_0> configurations = workflowItemLink.GetSharpenV2_0_0Configuration();

            configuration = configurations.Where(p => p.CameraId == _image_Data.CameraDeviceId).FirstOrDefault();

            if (configuration != null)
            {
                // https://qiita.com/kaiyu_tech/items/a37fc929ac0f3328fea1
                // https://bleedaiacademy.com/designing-advanced-image-filters-in-opencv-creating-instagram-filters-pt-3%E2%81%843/
                // https://learnopencv.com/non-photorealistic-rendering-using-opencv-python-c/
                // https://learnopencv.com/image-filtering-using-convolution-in-opencv/
                // https://medium.com/dataseries/designing-image-filters-using-opencv-like-abode-photoshop-express-part-1-8765e3f4495b
                // https://en.wikipedia.org/wiki/Unsharp_masking

                //Cv2.ImShow("Original", _imageData.Image);
                Cv2.DetailEnhance(_image_Data.Image, _image_Data.Image, configuration.SigmaS, configuration.SigmaR);
                //Cv2.ImShow("Original+", _imageData.Image);
            }
            else
            {
                Log.Debug("Crop V1.0.0 configuration not found ...");
            }
        }
    }
}
