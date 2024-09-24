using PSGM.Helper;
using PSGM.Model.DbBackendStructure;

namespace PSGM.Sample.Model.DbBackendStructure
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbBackendStructure_Structure> Generate_Structure1(int count, DbBackendStructure_Project projects)
        {
            Random random = new Random();

            List<DbBackendStructure_Structure> tmp = new List<DbBackendStructure_Structure>();

            // Main
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Main,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbMain;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataMain,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = "s3-clu001.branch31.psgm.at",
                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "xVnwqfNWGqblg1dmA33j",
                StorageS3SecretKey = "1Xq3G7az3QC3R0wKTBbwNHPNawhA16j1cx0n0a",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });


            // Storage Data Raw
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorageRaw;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRaw,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = "s3-clu100.branch31.psgm.at",
                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "lXbKy82C7lIkNRRQXaoq",
                StorageS3SecretKey = "iuVv7TMZA0Oaky7bgXE6mdejI9Xnu40KGMrFve",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });

            // Storage Data Raw Thumbnail
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorageRaw;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRawThumbnail,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = "s3-clu100.branch31.psgm.at",
                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "lXbKy82C7lIkNRRQXaoq",
                StorageS3SecretKey = "iuVv7TMZA0Oaky7bgXE6mdejI9Xnu40KGMrFve",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });

            // Storage Data
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorage;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = "s3-clu101.branch31.psgm.at",
                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "Mq5A3CCxUMcUxW9xP0Nw",
                StorageS3SecretKey = "YCVcvjFidGNneQVPTJ0LUhDM1Nxj9Y5fD5RMCh",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });

            // Storage Data Thumbnail
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorage;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataThumbnail,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = "s3-clu101.branch31.psgm.at",
                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "Mq5A3CCxUMcUxW9xP0Nw",
                StorageS3SecretKey = "YCVcvjFidGNneQVPTJ0LUhDM1Nxj9Y5fD5RMCh",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });

            // Storage Data Thumbnail
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorage;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataThumbnail,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = "s3-clu101.branch31.psgm.at",
                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "Mq5A3CCxUMcUxW9xP0Nw",
                StorageS3SecretKey = "YCVcvjFidGNneQVPTJ0LUhDM1Nxj9Y5fD5RMCh",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });


            // Job
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Job,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbJob;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.Unknown,
                StorageClass = StorageClass.Unknown,
                StorageTier = StorageTier.Unknown,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = string.Empty,
                StorageS3BucketName = string.Empty,
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });


            // Machine
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Machine,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbMachine;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.Unknown,
                StorageClass = StorageClass.Unknown,
                StorageTier = StorageTier.Unknown,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = string.Empty,
                StorageS3BucketName = string.Empty,
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });


            // Machine
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Software,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbSoftware;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.Unknown,
                StorageClass = StorageClass.Unknown,
                StorageTier = StorageTier.Unknown,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = string.Empty,
                StorageS3BucketName = string.Empty,
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });


            // Workflow
            tmp.Add(new DbBackendStructure_Structure()
            {
                Id = Guid.NewGuid(),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BackendType = BackendType.Workflow,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbWorkflow;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.Unknown,
                StorageClass = StorageClass.Unknown,
                StorageTier = StorageTier.Unknown,

                StorageFilePath = string.Empty,

                StorageS3Endpoint = string.Empty,
                StorageS3BucketName = string.Empty,
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            });
            return tmp;
        }
    }
}
