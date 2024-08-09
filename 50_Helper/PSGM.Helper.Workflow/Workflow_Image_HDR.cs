using OpenCvSharp;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public void Image_HDR_V1_0_0()
        {
            Mat image = new Mat();
            Mat[] images = new Mat[_images_DataRaw.Count];

            double exposureTime = 0.000;
            double[] exposureTimes = new double[_images_DataRaw.Count];

            for (int i = 0; i < _images_DataRaw.Count; i++)
            {
                images[i] = _images_DataRaw[i].Image;

                exposureTimes[i] = _images_DataRaw[i].ExposureTime;

                exposureTime += exposureTimes[i];

                //Cv2.ImShow($"Image {i}", images[i]);
            }

            exposureTime = exposureTime / _images_DataRaw.Count;

            MergeMertens mergeMertens = MergeMertens.Create();
            mergeMertens.Process(images, image);
            //Cv2.ImShow($"Image HDR", image);

            List<Guid> fileRawIds = new List<Guid>();

            foreach (var imageDataRaw in _images_DataRaw)
            {
                fileRawIds.Add(imageDataRaw.FileId);
            }

            _image_Data.FileId = Guid.NewGuid();
            _image_Data.FileRawIds = fileRawIds;
            _image_Data.Image = image.ConvertScaleAbs(255.0);
            _image_Data.ExposureTime = exposureTime;
            _image_Data.DateDigitized = _images_DataRaw[0].DateDigitized;
            _image_Data.CameraDeviceId = _images_DataRaw[0].CameraDeviceId;
        }
    }
}
