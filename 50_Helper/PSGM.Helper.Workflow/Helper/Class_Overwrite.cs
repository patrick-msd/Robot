using OpenCvSharp;
using PSGM.Lib.ExifData;
using PSGM.Model.DbStorage;
using System.Drawing;

namespace PSGM.Helper.Workflow
{
    public class ImageHelperBitmap_Workflow : ImageHelper
    {
        public Bitmap Image;
        public Bitmap Thumbnail;

        public ExifData ExifData;

        public DbStorage_File DatabaseEntity;
    }

    public class ImageHelperMat_Workflow : ImageHelper
    {
        public Mat Image;
        public Mat Thumbnail;

        public ExifData ExifData;

        public DbStorage_File DatabaseEntity;
    }
}
