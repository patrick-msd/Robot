namespace PSGM.Lib.ExifData
{
    public enum ImageFileBlock
    {
        Unknown = 0,

        Exif = 1,
        Iptc = 2,
        Xmp = 3,
        JpegComment = 4,
        PngMetaData = 5,
        PngDateChanged = 6
    };

    public enum ImageType
    {
        Unknown = 0,

        Jpeg = 1,
        Tiff = 2,
        Png = 3
    };

    public enum Orientation
    {
        Unknown = 0,

        Horizontal = 1,
        MirrorHorizontal = 2,
        Rotate180 = 3,
        MirrorVertical = 4,
        MirrorHorizontalAndRotate270CW = 5,
        Rotate90CW = 6,
        MirrorHorizontalAndRotate90CW = 7,
        Rotate270CW = 8,
    };

    public enum StringCodingFormat
    {
        TypeAscii = 0x00000000,                 // Tag type is "ExifTagType.Ascii". A null terminating character is added when writing.
        TypeUndefined = 0x00010000,             // Tag type is "ExifTagType.Undefined". A null terminating character is not present.
        TypeByte = 0x00020000,                  // Tag type is "ExifTagType.Byte". A null terminating character is added when writing.
        TypeUndefinedWithIdCode = 0x00030000    // Tag type is "ExifTagType.Undefined" and an additional ID code is present. A null terminating character is not present.
    };

    // Strings coding constants. In the lower 16 bits the code page number (1 to 65535) is coded.
    // In the higher 16 bits the EXIF tag type and additional infos are coded.
    public enum StringCoding
    {
        Utf8 = StringCodingFormat.TypeAscii | 65001,                            // Default value for all tags of type "ExifTagType.Ascii". 
        UsAscii = StringCodingFormat.TypeAscii | 20127,
        WestEuropeanWin = StringCodingFormat.TypeAscii | 1252,
        UsAscii_Undef = StringCodingFormat.TypeUndefined | 20127,               // For the tags "ExifVersion", "FlashPixVersion" and others.			   
        Utf16Le_Byte = StringCodingFormat.TypeByte | 1200,                      // For the Microsoft tags "XpTitle", "XpComment", "XpAuthor", "XpKeywords" and "XpSubject".
        IdCode_Utf16 = StringCodingFormat.TypeUndefinedWithIdCode | 1200,       // Default value for the tag "UserComment".
        IdCode_UsAscii = StringCodingFormat.TypeUndefinedWithIdCode | 20127,
        IdCode_WestEu = StringCodingFormat.TypeUndefinedWithIdCode | 1252
    }

    public enum ExifDateFormat
    {
        DateAndTime = 0,
        DateOnly = 1
    }
}
