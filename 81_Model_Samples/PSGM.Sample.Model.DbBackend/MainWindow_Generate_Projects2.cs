using PSGM.Model.DbBackend;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbBackend_Project> Generate_Project2(int count)
        {
            Random random = new Random();

            List<DbBackend_Project> tmp = new List<DbBackend_Project>();

            for (int i = 0; i < count; i++)
            {
                DbBackend_Project element = new DbBackend_Project()
                {
                    Id = Guid.NewGuid(),

                    ProjectId_Ext = Guid.NewGuid(),

                    Backends = null,
                    
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
