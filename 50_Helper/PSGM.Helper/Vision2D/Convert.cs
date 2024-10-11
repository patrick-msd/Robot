using OpenCvSharp;
using System.Drawing;

namespace PSGM.Helper
{
    public static partial class Vision2D
    {
        //private static Bitmap BitmapFromWriteableBitmap(WriteableBitmap writeableBmp)
        //{
        //    Bitmap bmp;

        //    using (MemoryStream outStream = new MemoryStream())
        //    {
        //        BitmapEncoder enc = new BmpBitmapEncoder();
        //        enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeableBmp));
        //        enc.Save(outStream);
        //        bmp = new Bitmap(outStream);
        //    }

        //    return bmp;
        //}

        private static Mat GetMatFromImage(Image image)
        {
            return OpenCvSharp.Extensions.BitmapConverter.ToMat(new Bitmap(image));
        }
    }
}
