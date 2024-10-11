using OpenCvSharp;
using System.Drawing;
using System.Drawing.Imaging;

namespace PSGM.Helper
{
    public static partial class Vision2D
    {
        public static void SaveBitmapAsJpeg(Bitmap bitmap, string filePath, long quality)
        {
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, quality);

            ImageCodecInfo jpegCodec = GetEncoderInfo(ImageFormat.Jpeg);

            bitmap.Save(filePath, jpegCodec, encoderParameters);
        }

        public static ImageCodecInfo GetEncoderInfo(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }
    }
}
