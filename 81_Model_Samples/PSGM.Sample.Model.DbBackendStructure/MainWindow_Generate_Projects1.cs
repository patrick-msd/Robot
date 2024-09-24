using PSGM.Model.DbBackendStructure;

namespace PSGM.Sample.Model.DbBackendStructure
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbBackendStructure_Project Generate_Project1(int count, Guid projectId)
        {
            Random random = new Random();

            DbBackendStructure_Project element = new DbBackendStructure_Project()
            {
                Id = Guid.NewGuid(),

                ProjectId_Ext = projectId,

                Structures = null,

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
