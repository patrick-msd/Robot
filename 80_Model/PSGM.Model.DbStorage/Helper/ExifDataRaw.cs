using PSGM.Lib.ExifData;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [NotMapped]
    public partial class ExifDataRaw
    {
        /// <summary>
        /// Bild-Ausrichtung Hochformat / Querformat --> https://exiftool.org/TagNames/EXIF.html
        /// </summary>
        public ImageType ImageType { get; set; } = ImageType.Unknown;

        /// <summary>
        /// Compression -->  https://exiftool.org/TagNames/EXIF.html#Compression
        /// </summary>
        public Orientation Orientation { get; set; } = Orientation.Unknown;

        /// <summary>
        /// 
        /// </summary>
        public string Software { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string ProcessingSoftware { get; set; } = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Artist { get; set; } = string.Empty;

        /// <summary>
        /// Urheberrechts-Information
        /// </summary>
        public string Copyright { get; set; } = string.Empty;

        public int GpsAltitude { get; set; } = 0;

        public decimal GpsLatitudeDegree { get; set; } = 0.000m;

        public decimal GpsLatitudeMinute { get; set; } = 0.000m;

        public decimal GpsLatitudeSecond { get; set; } = 0.000m;

        public char GpsLatitudeCardinalPoint { get; set; } = char.MinValue;

        public decimal GpsLongitudeDegree { get; set; } = 0.000m;

        public decimal GpsLongitudeMinute { get; set; } = 0.000m;

        public decimal GpsLongitudeSecond { get; set; } = 0.000m;

        public char GpsLongitudeCardinalPoint { get; set; } = char.MinValue;

        /// <summary>
        /// X resolution
        /// </summary>
        public int XResolution { get; set; } = 0;

        /// <summary>
        /// Y resolution
        /// </summary>
        public int YResolution { get; set; } = 0;

        // https://exiftool.org/TagNames/EXIF.html
        /// <summary>
        ///  Name des Kameraherstellers eg. Sony
        /// </summary>
        public string Make { get; set; } = string.Empty;

        /// <summary>
        /// Name des Kamera-Modells eg. Sony Alpha 380
        /// </summary>
        public string Model { get; set; } = string.Empty;

        public string LensMake { get; set; } = string.Empty;

        public string LensModel { get; set; } = string.Empty;

        /// <summary>
        /// Blendenzahl
        /// </summary>
        public int FNumber { get; set; } = 0;

        /// <summary>
        /// Belichtungszeit
        /// </summary>
        public int ExposureTime { get; set; } = 0;

        /// <summary>
        /// Belichtungsprogramm
        /// </summary>
        public ExposureProgram ExposureProgram { get; set; } = ExposureProgram.NotDefined;

        public ExposureMode ExposureMode { get; set; } = ExposureMode.Manual;

        /// <summary>
        /// Empfindlichkeit des Bildsensors
        /// </summary>
        public int ISOSpeed { get; set; } = 0;

        public int FocalLength { get; set; } = 0;

        /// <summary>
        /// https://exiftool.org/TagNames/EXIF.html#Flash
        /// </summary>
        public Flash Flash { get; set; } = Flash.NoFlash;

        /// <summary>
        /// https://exiftool.org/TagNames/EXIF.html#LightSource
        /// </summary>
        public LightSource LightSource { get; set; } = LightSource.Unknown;

        /// <summary>
        ///     
        /// </summary>
        public ResolutionUnit ResolutionUnit { get; set; } = ResolutionUnit.None;

        /// <summary>
        /// 
        /// </summary>
        public ColorSpace ColorSpace { get; set; } = ColorSpace.Unknown;

        /// <summary>
        /// Datum und Uhrzeit der Aufgenommen
        /// </summary>
        public DateTime DateTimeOriginal { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Datum und Uhrzeit der Digitalisierung
        /// </summary>
        public DateTime CreateDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// atum und Uhrzeit der modifizierung
        /// </summary>
        public DateTime ModifyDate { get; set; } = DateTime.MinValue;

        /// <summary>
        /// Allgemeiner Kommentar oder Bildbeschreibung.Unicode-fähig
        /// </summary>
        public string UserComment { get; set; } = string.Empty;

        /// <summary>
        /// Titel des Bildes und kurze Bildbeschreibung
        /// </summary>
        public string ImageDescription { get; set; } = string.Empty;
    }
}
