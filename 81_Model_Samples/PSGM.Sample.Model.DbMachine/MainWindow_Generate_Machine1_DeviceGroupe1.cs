using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_DeviceGroup Generate_Machine1_DeviceGroupe1()
        {
            DbMachine_DeviceGroup deviceGroup = new DbMachine_DeviceGroup()
            {
                Id = new Guid(),

                Name = "Main Frame",
                Description = "",

                Location = string.Empty,

                DeviceGroupeType = DeviceGroupeType.MainFrame,
                Configuration = string.Empty,

                Devices = new List<DbMachine_Device>()
                {
                    Generate_Machine1_DeviceGroupe1_Controller(),

                    Generate_Machine1_DeviceGroupe1_PowerSupply1(),
                    Generate_Machine1_DeviceGroupe1_PowerSupply2(),

                    Generate_Machine1_DeviceGroupe1_Robot(),

                    Generate_Machine1_DeviceGroupe1_Vision2D1(),
                    Generate_Machine1_DeviceGroupe1_Vision2D2(),

                    Generate_Machine1_DeviceGroupe1_Motion()
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
