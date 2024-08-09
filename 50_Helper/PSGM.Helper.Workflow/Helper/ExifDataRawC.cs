using PSGM.Lib.ExifData;
using PSGM.Model.DbStorage;

namespace PSGM.Helper.Workflow
{
    public partial class Workflow
    {
        public ExifDataRaw CreateExifDataRaw()
        {
            // https://www.codeproject.com/Articles/5251929/CompactExifLib-Access-to-EXIF-Tags-in-JPEG-TIFF-an
            // https://www.media.mit.edu/pia/Research/deepview/exif.html
            // https://exiftool.org/TagNames/EXIF.html

            // ToDo: Read from database

            return new ExifDataRaw()
            {
                ImageType = ImageType.Jpeg,
                Orientation = Orientation.Unknown,

                Software = "Sheet Scanner - V0.0.0.0",
                ProcessingSoftware = "Sheet Scanner - V0.0.0.0",

                Artist = "Patrick Schoenegger",
                Copyright = "(C) Patrick Schoenegger (PSGM GmbH)",

                GpsAltitude = 574,
                GpsLatitudeDegree = 47,
                GpsLatitudeMinute = 15,
                GpsLatitudeSecond = 50.8428m,
                GpsLatitudeCardinalPoint = 'N',
                GpsLongitudeDegree = 11,
                GpsLongitudeMinute = 23,
                GpsLongitudeSecond = 3.0876m,
                GpsLongitudeCardinalPoint = 'E',

                XResolution = 300,
                YResolution = 300,

                Make = "SVSVistek",
                Model = "HR455CXGE",
                LensMake = "Myutron Objektiv",
                LensModel = "LSF2528-V58",
                FNumber = 8,

                ExposureTime = 200,
                ExposureProgram = ExposureProgram.CreativeSlowSpeed,
                ExposureMode = ExposureMode.Auto,
                ISOSpeed = 200,

                FocalLength = 70,

                Flash = Flash.Fired,
                LightSource = LightSource.Flash,

                ResolutionUnit = ResolutionUnit.Centimeter,
                ColorSpace = ColorSpace.sRGB,

                DateTimeOriginal = DateTime.MinValue,
                CreateDate = DateTime.MinValue,
                ModifyDate = DateTime.UtcNow,
                UserComment = string.Empty,
                ImageDescription = string.Empty,
            };
        }
    }
}
