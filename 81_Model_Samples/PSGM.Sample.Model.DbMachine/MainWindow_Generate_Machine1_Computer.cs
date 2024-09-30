using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Computer Generate_Machine1_Computer(Guid computerId)
        {
            DbMachine_Computer addressUIBK = new DbMachine_Computer()
            {
                Id = Guid.NewGuid(),

                Name = "PC-001",
                Description = "ASRock computer ...",

                ComputerUUID = computerId,
                
                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Machine = null,
                MachineId = null
            };

            return addressUIBK;
        }
    }
}
