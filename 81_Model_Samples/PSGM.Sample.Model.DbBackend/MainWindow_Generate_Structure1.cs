using PSGM.Helper;
using PSGM.Model.DbBackend;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbBackend_Cluster> Generate_Structure1(int count, DbBackend_Project projects)
        {
            Random random = new Random();

            // Main
            DbBackend_Cluster main = new DbBackend_Cluster()
            {
                Id = new Guid("29000f47-e4dc-4101-965c-af8624d29495"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Main,
                
                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataMain,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "xVnwqfNWGqblg1dmA33j",
                StorageS3SecretKey = "1Xq3G7az3QC3R0wKTBbwNHPNawhA16j1cx0n0a",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Server = new List<DbBackend_Server>()
                {
                    new DbBackend_Server()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Name",
                        Description = "Description",

                        //DNS = = string.Empty,
                        //IpAddress = "10.31.30.100",
                        FirstIpSegment = 10,
                        LastIpSegment = 100,
                        VLAN = 30,

                        Locked = false,
                        LockedDescription = string.Empty,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Cluster = null,
                        ClusterId = null,
                    },
                    new DbBackend_Server()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Name",
                        Description = "Description",

                        //DNS = = string.Empty,
                        //IpAddress = "10.31.30.100",
                        FirstIpSegment = 10,
                        LastIpSegment = 100,
                        VLAN = 30,

                        Locked = false,
                        LockedDescription = string.Empty,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Cluster = null,
                        ClusterId = null,
                    },
                    new DbBackend_Server()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Name",
                        Description = "Description",

                        //DNS = = string.Empty,
                        //IpAddress = "10.31.30.100",
                        FirstIpSegment = 10,
                        LastIpSegment = 100,
                        VLAN = 30,

                        Locked = false,
                        LockedDescription = string.Empty,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Cluster = null,
                        ClusterId = null,
                    }
                },

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };


            // Storage Data Raw
            DbBackend_Cluster dataRaw = new DbBackend_Cluster()
            {
                Id = new Guid("9e05de17-2d39-47fd-a1f2-f4c274b8f44c"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRaw,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "lXbKy82C7lIkNRRQXaoq",
                StorageS3SecretKey = "iuVv7TMZA0Oaky7bgXE6mdejI9Xnu40KGMrFve",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };

            // Storage Data Raw Thumbnail
            DbBackend_Cluster dataRawThumbnail = new DbBackend_Cluster()
            {
                Id = new Guid("aedb88bc-c17d-49f1-879c-c595ad758aef"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataRawThumbnail,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "Mq5A3CCxUMcUxW9xP0Nw",
                StorageS3SecretKey = "YCVcvjFidGNneQVPTJ0LUhDM1Nxj9Y5fD5RMCh",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };

            // Storage Data
            DbBackend_Cluster data = new DbBackend_Cluster()
            {
                Id = new Guid("8611b52b-b27f-4ccf-847b-a17eb590bbe9"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.Data,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "cIm3AkV6LpnR47v7vP68",
                StorageS3SecretKey = "LcBxrCot4ekVhNXOQ5pF6cXakToEilbEmXpX3G",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };

            // Storage Data Thumbnail
            DbBackend_Cluster dataThumbnail = new DbBackend_Cluster()
            {
                Id = new Guid("739570fa-ef7e-41bc-9b79-b4753dc04527"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Storage,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataThumbnail,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = "iPM6Iklm5dcyJVq9z3Vr",
                StorageS3SecretKey = "jgn0MHMHgMg9MtldqVVCPuNU2ahOVDdQpvm4g9",
                StorageS3Secure = false,
                StorageS3Region = "eu-central-1",

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };

            // Transcription
            DbBackend_Cluster transcription = new DbBackend_Cluster()
            {
                Id = new Guid("20d16641-3d52-40ce-87ad-621d29d7245f"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Transcription,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.S3,
                StorageClass = StorageClass.DataTranscription,
                StorageTier = StorageTier.Hot,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };


            // Job
            DbBackend_Cluster job = new DbBackend_Cluster()
            {
                Id = new Guid("ca878289-9b96-457f-a486-f53aed0da113"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Job,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.Unknown,
                StorageClass = StorageClass.Unknown,
                StorageTier = StorageTier.Unknown,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };


            // Machine
            DbBackend_Cluster machine = new DbBackend_Cluster()
            {
                Id = new Guid("09c02b16-bb49-40ba-89b7-40504327565d"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Machine,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.Unknown,
                StorageClass = StorageClass.Unknown,
                StorageTier = StorageTier.Unknown,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };


            // Software
            DbBackend_Cluster software = new DbBackend_Cluster()
            {
                Id = new Guid("3f7c76da-0854-43c4-b85c-410b9b5d17fc"),

                Name = "Name",
                Description = "Description",

                Stars = 0,
                Order = 1,

                BranchNumber = 31,
                Domain = "psgm.at",

                BackendType = BackendType.Software,

                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseFilePath = string.Empty,
                DatabasePort = 50001,
                DatabaseUsername = "postgres",
                DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                StorageType = StorageType.Unknown,
                StorageClass = StorageClass.Unknown,
                StorageTier = StorageTier.Unknown,

                StorageFilePath = string.Empty,

                StorageS3BucketName = string.Empty,                             // BucketName is Project Id
                StorageS3AccessKey = string.Empty,
                StorageS3SecretKey = string.Empty,
                StorageS3Secure = false,
                StorageS3Region = string.Empty,

                ReadOnlyMode = false,
                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                Project = projects,
                //ProjectId = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,
            };





            List<DbBackend_Cluster> tmp = new List<DbBackend_Cluster>(new List<DbBackend_Cluster>()
            {
                main,

                dataRaw,
                dataRawThumbnail,

                data,
                dataThumbnail,

                transcription,

                job,

                machine,

                software
            });

            return tmp;
        }
    }
}
