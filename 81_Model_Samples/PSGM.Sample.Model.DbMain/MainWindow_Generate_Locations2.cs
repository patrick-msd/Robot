using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Location> Generate_Locations2(int count, List<DbMain_Address> addresses)
        {
            Random random = new Random();

            List<DbMain_Location> tmp = new List<DbMain_Location>();

            for (int i = 0; i < count; i++)
            {
                DbMain_Location address = new DbMain_Location()
                {
                    Id = new Guid(),

                    Name = Common.RandomString(random.Next(10, 100)),
                    AddressLink = new DbMain_Location_Address_Link()
                    {
                        Id = new Guid(),

                        // Fk
                        Address = addresses[random.Next(addresses.Count)],
                        //AddressId = Guid.Empty,

                        Location = null,
                        LocationId = null,
                    },

                    Description = Common.RandomString(random.Next(10, 100)),

                    OrganizationLocationLink = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,  
                };

                tmp.Add(address);
            }

            return tmp;
        }
    }
}
