using PSGM.Model.DbBackend;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public DbBackend_Project Generate_Project1(Guid projectId)
        {
            Random random = new Random();

            DbBackend_Project element = new DbBackend_Project()
            {
                Id = projectId,

                ProjectId_Ext = projectId,

                Backends = null,
                
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
