using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Location Generate_Machine1_Location(DbMachine_Address address)
        {
            DbMachine_Location locationUIBK = new DbMachine_Location()
            {
                Id = new Guid(),

                Name = "GEIWI Turm - 3. Stocker (DEA Büro)",
                Description = "",

                LocationType = LocationType.ScanningStation,

                AddressLink = new DbMachine_Location_Address_Link()
                {
                    Id = new Guid(),

                    // FK       
                    Address = address,
                    //AddressId = null,

                    Location = null,
                    LocationId = null,
                },

                MachineLocationLink = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };

            return locationUIBK;
        }
    }
}
