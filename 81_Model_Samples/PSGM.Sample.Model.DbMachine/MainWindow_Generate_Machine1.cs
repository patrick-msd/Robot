using PSGM.Helper;
using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Machine Generate_Machine1(DbMachine_Project projects)
        {
            Random random = new Random();

            DbMachine_Computer computer = Generate_Machine1_Computer(ComputerInfo.GetComputerUUID());

            DbMachine_Address addressUIBK = Generate_Machine1_Address();

            DbMachine_Location locationUIBK = Generate_Machine1_Location(addressUIBK);

            DbMachine_DeviceGroup deviceGroup_mainFrame = Generate_Machine1_DeviceGroupe1();

            DbMachine_DeviceGroup deviceGroup_sheetCradle = Generate_Machine1_DeviceGroupe2();

            DbMachine_Machine machine = new DbMachine_Machine()
            {
                Id = _machineId,

                Name = "Heja",
                Description = "Sheet scanning robot ...",

                ApplicationName = "Heja Scanning Software",

                InitializeAtSplashScreen = true,
                ConnectAtSplashScreen = true,
                AutoStartAtSplashScreen = true,
                HomingAtSplashScreen = true,

                LocationLinks = new List<DbMachine_Machine_Location_Link>()
                {
                    new DbMachine_Machine_Location_Link()
                    {
                        Id = Guid.NewGuid(),

                        Machine = null,
                        MachineId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Location = locationUIBK,
                        //LocationId = null,
                    }
                },

                DeviceGroups = new List<DbMachine_DeviceGroup>()
                {
                    deviceGroup_mainFrame,
                    deviceGroup_sheetCradle
                },

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Computer = new List<DbMachine_Computer>() { computer },
                //ComputerId = null,

                Project = projects,
                //ProjectId = null
            };

            return machine;
        }
    }
}
