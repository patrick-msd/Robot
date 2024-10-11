using OpenCvSharp;
using System.Drawing;

namespace PSGM.Helper
{
    public static partial class Vision2D
    {
        public static Bitmap ResizeImage(Bitmap image, int width, int height)
        {
            Bitmap resizedImage;

            int widthThumbnail = 0;
            int heightThumbnail = 0;

            if (width == 0 && height > 0)
            {
                heightThumbnail = height;
                widthThumbnail = (int)((double)image.Width / image.Height * heightThumbnail);
            }
            else if (height == 0 && width > 0)
            {
                widthThumbnail = width;
                heightThumbnail = (int)((double)image.Height / image.Width * widthThumbnail);
            }
            else if (height > 0 && width > 0)
            {
                widthThumbnail = width;
                heightThumbnail = height;
            }
            else
            {
                throw new Exception("Thumbnail configuration not allowed!");
            }

            resizedImage = new Bitmap(widthThumbnail, heightThumbnail);

            using (Graphics graphics = Graphics.FromImage(resizedImage))
            {
                graphics.DrawImage(image, 0, 0, widthThumbnail, heightThumbnail);
            }

            return resizedImage;
        }

        public static Mat ResizeImage(Mat image, int width, int height)
        {
            OpenCvSharp.Size size;
            Mat resizedImage = new Mat();

            int widthThumbnail = 0;
            int heightThumbnail = 0;

            if (width == 0 && height > 0)
            {
                heightThumbnail = height;
                widthThumbnail = (int)((double)image.Width / image.Height * heightThumbnail);

                size = new OpenCvSharp.Size(widthThumbnail, heightThumbnail);
            }
            else if (height == 0 && width > 0)
            {
                widthThumbnail = width;
                heightThumbnail = (int)((double)image.Height / image.Width * widthThumbnail);

                size = new OpenCvSharp.Size(widthThumbnail, heightThumbnail);
            }
            else if (height > 0 && width > 0)
            {
                size = new OpenCvSharp.Size(width, height);
            }
            else
            {
                throw new Exception("Thumbnail configuration not allowed!");
            }

            Cv2.Resize(image, resizedImage, size, 0, 0, InterpolationFlags.Linear);

            return resizedImage;
        }
    }
}
