using PSGM.Model.DbBackendStructure;

namespace PSGM.Sample.Model.DbBackendStructure
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbBackendStructure_Project> Generate_Project(int count)
        {
            Random random = new Random();

            List<DbBackendStructure_Project> tmp = new List<DbBackendStructure_Project>();

            for (int i = 0; i < count; i++)
            {
                DbBackendStructure_Project element = new DbBackendStructure_Project()
                {
                    Id = Guid.NewGuid(),

                    ProjectId_Ext = Guid.NewGuid(),

                    Structures = null,
                    
                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                };

                //_dbStorage_Data_Context.RootDirectories.Add(element);
                //_dbStorage_Data_Context.SaveChanges();

                tmp.Add(element);
            }

            return tmp;
        }
    }
}
