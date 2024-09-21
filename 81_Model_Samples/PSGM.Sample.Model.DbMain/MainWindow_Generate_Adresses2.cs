using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
      public List<DbMain_Address> Generate_Addresses2(int count)
        {
            Random random = new Random();

            List<DbMain_Address> tmp = new List<DbMain_Address>();

            for (int i = 0; i < count; i++)
            {
                DbMain_Address address = new DbMain_Address()
                {
                    Id = Guid.NewGuid(),

                    Line1 = "Address " + i.ToString(),
                    Line2 = Common.RandomString(random.Next(10, 100)),

                    City = Common.RandomString(random.Next(10, 100)),
                    State = Common.RandomString(random.Next(10, 100)),
                    CountryCode = Common.RandomString(2),
                    CountryName = Common.RandomString(random.Next(10, 100)),
                    PostalCode = Common.RandomString(random.Next(10, 100)),
                    RegionCode = string.Empty,
                    RegionName = string.Empty,

                    GpsAltitude = random.Next(0, 100),
                    GpsLatitudeDegree = random.Next(0, 100),
                    GpsLatitudeMinute = random.Next(0, 100),
                    GpsLatitudeSecond = 35.1684m,
                    GpsLatitudeCardinalPoint = 'N',
                    GpsLongitudeDegree = random.Next(0, 100),
                    GpsLongitudeMinute = random.Next(0, 100),
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

                tmp.Add(address);
            }

            return tmp;
        }
    }
}
