using PSGM.Model.DbMachine;

namespace PSGM.Sample.Model.DbMachine
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbMachine_Project Generate_Project1(Guid projectId)
        {
            Random random = new Random();

            DbMachine_Project element = new DbMachine_Project()
            {
                Id = projectId,

                ProjectId_Ext = projectId,

                Machines = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };

            //_dbStorage_Data_Context.RootDirectories.Add(element);
            //_dbStorage_Data_Context.SaveChanges();

            return element;
        }
    }
}
