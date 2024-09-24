using PSGM.Helper;
using PSGM.Model.DbBackend;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbBackend_Cluster> Generate_Structure2(int count, List<DbBackend_Project> projects)
        {
            Random random = new Random();

            List<DbBackend_Cluster> tmp = new List<DbBackend_Cluster>();

            Array values1 = Enum.GetValues(typeof(BackendType));
            Array values2 = Enum.GetValues(typeof(DatabaseType));
            Array values3 = Enum.GetValues(typeof(StorageType));
            Array values4 = Enum.GetValues(typeof(StorageClass));
            Array values5 = Enum.GetValues(typeof(StorageTier));

            //for (int i = 0; i < count; i++)
            //{
            //    DbBackend_Structure element = new DbBackend_Structure()
            //    {
            //        Id = Guid.NewGuid(),

            //        Name = "Name_" + i.ToString(),
            //        Description = "Description_" + i.ToString(),

            //        Stars = random.Next(0, 5),
            //        Order = i,

            //        BackendType = (BackendType)values1.GetValue(random.Next(values1.Length)),

            //        DatabaseType = (DatabaseType)values2.GetValue(random.Next(values2.Length)),
            //        DatabaseFilePath = "DatabaseFilePath_" + i.ToString(),
            //        DatabaseConnectionString = "DatabaseConnectionString_" + i.ToString(),

            //        StorageType = (StorageType)values3.GetValue(random.Next(values3.Length)),
            //        StorageClass = (StorageClass)values4.GetValue(random.Next(values4.Length)),
            //        StorageTier = (StorageTier)values5.GetValue(random.Next(values5.Length)),
            //        StorageFilePath = "StorageFilePath_" + i.ToString(),
            //        StorageS3Endpoint = "StorageS3Endpoint_" + i.ToString(),
            //        StorageS3AccessKey = "StorageS3AccessKey_" + i.ToString(),
            //        StorageS3SecretKey = "StorageS3SecretKey_" + i.ToString(),
            //        StorageS3Secure = random.Next(100) <= 50 ? true : false,
            //        StorageS3Region = "StorageS3Region_" + i.ToString(),

            //        ReadOnlyMode = random.Next(100) <= 50 ? true : false,
            //        Locked = random.Next(100) <= 50 ? true : false,

            //        Url = "Url_" + i.ToString(),
            //        UrlPublic = "UrlPublic_" + i.ToString(),

            //        Project = projects[random.Next(0, projects.Count)],
            //        //ProjectId = null,

            //        //CreatedByUserIdExtAutoFill = Guid.Empty,
            //        //CreatedDateTimeAutoFill = DateTime.Now,
            //        //ModifiedByUserIdExtAutoFill = Guid.Empty,
            //        //ModifiedDateTimeAutoFill = DateTime.Now,
            //    };

            //    //_dbStorage_Data_Context.RootDirectories.Add(element);
            //    //_dbStorage_Data_Context.SaveChanges();

            //    tmp.Add(element);
            //}

            return tmp;
        }
    }
}
