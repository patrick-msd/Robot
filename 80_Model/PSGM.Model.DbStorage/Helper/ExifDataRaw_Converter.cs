using PSGM.Lib.ExifData;

namespace PSGM.Model.DbStorage
{
    public partial class ExifDataRaw
    {
        public ExifData Convert2ExifData()
        {
            // https://www.codeproject.com/Articles/5251929/CompactExifLib-Access-to-EXIF-Tags-in-JPEG-TIFF-an
            // https://www.media.mit.edu/pia/Research/deepview/exif.html
            // https://exiftool.org/TagNames/EXIF.html

            ExifData exifData = ExifData.Empty();

            exifData.ImageType = ImageType;

            exifData.SetTagValue(ExifTag.Orientation, (int)Orientation, ExifTagType.UShort);

            exifData.SetTagValue(ExifTag.Software, Software, StringCoding.Utf8);

            exifData.SetTagValue(ExifTag.Artist, Artist, StringCoding.Utf8);

            exifData.SetTagValue(ExifTag.Copyright, Copyright, StringCoding.Utf8);

            // https://www.koordinaten-umrechner.de/decimal/47.264123,11.384191?karte=OpenStreetMap&zoom=18
            exifData.SetGpsAltitude(GpsAltitude);
            exifData.SetGpsLatitude(new GeoCoordinate() { Degree = GpsLatitudeDegree, Minute = GpsLatitudeMinute, Second = GpsLatitudeSecond, CardinalPoint = GpsLatitudeCardinalPoint });
            exifData.SetGpsLongitude(new GeoCoordinate() { Degree = GpsLongitudeDegree, Minute = GpsLongitudeMinute, Second = GpsLongitudeSecond, CardinalPoint = GpsLongitudeCardinalPoint });
            exifData.SetGpsDateTimeStamp(DateTime.UtcNow);

            exifData.SetTagValue(ExifTag.XResolution, XResolution, ExifTagType.URational);
            exifData.SetTagValue(ExifTag.YResolution, YResolution, ExifTagType.URational);

            exifData.SetTagValue(ExifTag.Make, Make, StringCoding.Utf8);
            exifData.SetTagValue(ExifTag.Model, Model, StringCoding.Utf8);
            exifData.SetTagValue(ExifTag.LensMake, LensMake, StringCoding.Utf8);
            exifData.SetTagValue(ExifTag.LensModel, LensModel, StringCoding.Utf8);

            exifData.SetTagValue(ExifTag.FNumber, FNumber, ExifTagType.URational);

            exifData.SetTagValue(ExifTag.ExposureTime, ExposureTime, ExifTagType.Undefined);
            exifData.SetTagValue(ExifTag.ExposureProgram, (int)ExposureProgram, ExifTagType.UShort);
            exifData.SetTagValue(ExifTag.ExposureMode, (int)ExposureMode, ExifTagType.UShort);

            exifData.SetTagValue(ExifTag.IsoSpeed, ISOSpeed, ExifTagType.UShort);

            exifData.SetTagValue(ExifTag.FocalLength, FocalLength, ExifTagType.URational);

            exifData.SetTagValue(ExifTag.Flash, 1, ExifTagType.UShort);
            exifData.SetTagValue(ExifTag.LightSource, 10, ExifTagType.UShort);

            exifData.SetTagValue(ExifTag.ResolutionUnit, (int)ResolutionUnit, ExifTagType.UShort);
            exifData.SetTagValue(ExifTag.ColorSpace, (int)ColorSpace, ExifTagType.UShort);

            return exifData;
        }
    }
}
