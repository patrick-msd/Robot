using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Address Generate_Machine1_Address()
        {
            DbMachine_Address addressUIBK = new DbMachine_Address()
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
                Location = null,
                LocationId = null
            };

            return addressUIBK;
        }
    }
}
