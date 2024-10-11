using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_DeviceGroup Generate_Machine1_DeviceGroupe2()
        {
            DbMachine_DeviceGroup deviceGroup = new DbMachine_DeviceGroup()
            {
                Id = new Guid(),

                Name = "Main Frame",
                Description = "",

                Location = string.Empty,

                DeviceGroupeType = DeviceGroupeType.MainFrame,
                ConfigurationString = string.Empty,

                Devices = new List<DbMachine_Device>()
                {
                    Generate_Machine1_DeviceGroupe2_Controller(),
                },

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Machine = null,
                MachineId = null
            };

            return deviceGroup;
        }
    }
}
