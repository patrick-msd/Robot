using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Location> Generate_Locations1(List<DbMain_Address> addresses)
        {
            Random random = new Random();

            DbMain_Location locationUIBK = new DbMain_Location()
            {
                Id = new Guid(),

                Name = "Headquarter",
                AddressLink = new DbMain_Location_Address_Link()
                {
                    Id = new Guid(),

                    // FK
                    Address = addresses.Where(p => p.Line1.Contains("Innrain 52d")).First(),
                    //AddressId = Guid.Empty,

                    Location = null,
                    LocationId = null,
                },

                Description = string.Empty,

                OrganizationLocationLink = null,

                ProjectLocationLink = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,               
            };

            DbMain_Location locationTLA = new DbMain_Location()
            {
                Id = new Guid(),

                Name = "Headquarter",

                AddressLink = new DbMain_Location_Address_Link()
                {
                    Id = new Guid(),

                    // FK
                    Address = addresses.Where(p => p.Line1.Contains("Michael-Gaismair-Straße 1")).First(),
                    //AddressId = Guid.Empty,

                    Location = null,
                    LocationId = null,
                },

                Description = string.Empty,

                OrganizationLocationLink = null,

                ProjectLocationLink = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,   
            };

            List<DbMain_Location> tmp = new List<DbMain_Location>()
            {
                locationUIBK,
                locationTLA
            };

            return tmp;
        }
    }
}
