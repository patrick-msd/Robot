using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Address> Generate_Addresses1()
        {      
            DbMain_Address addressUIBK = new DbMain_Address()
            {
                Id = Guid.NewGuid(),
                
                Line1 = "Innrain 52d",
                Line2 = "Stock 3",

                City = "Innsbruck",
                State = "Tirol",
                CountryCode = "AT",
                CountryName = "Austria",
                PostalCode = "6020",
                RegionCode = string.Empty,
                RegionName = string.Empty,

                GpsAltitude = 574,
                GpsLatitudeDegree = 47,
                GpsLatitudeMinute = 15,
                GpsLatitudeSecond = 50.8428m,
                GpsLatitudeCardinalPoint = 'N',
                GpsLongitudeDegree = 11,
                GpsLongitudeMinute = 23,
                GpsLongitudeSecond = 3.0876m,
                GpsLongitudeCardinalPoint = 'E',

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                AddressLink = null,
                AddressLinkId = null,   
            };

            DbMain_Address addressTLA = new DbMain_Address()
            {
                Id = Guid.NewGuid(),
                
                Line1 = "Michael-Gaismair-Straße 1",
                Line2 = string.Empty,
                
                City = "Innsbruck",
                State = "Tirol",
                CountryCode = "AT",
                CountryName = "Austria",
                PostalCode = "6020",
                RegionCode = string.Empty,
                RegionName = string.Empty,

                GpsAltitude = 574,
                GpsLatitudeDegree = 47,
                GpsLatitudeMinute = 15,
                GpsLatitudeSecond = 35.1684m,
                GpsLatitudeCardinalPoint = 'N',
                GpsLongitudeDegree = 11,
                GpsLongitudeMinute = 23,
                GpsLongitudeSecond = 40.5024m,
                GpsLongitudeCardinalPoint = 'E',

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                AddressLink = null,
                AddressLinkId = null
            };

            List<DbMain_Address> tmp = new List<DbMain_Address>()
            {
                addressUIBK,
                addressTLA
            };

            return tmp;
        }
    }
}
