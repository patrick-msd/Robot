using PSGM.Helper;
using PSGM.Model.DbBackend;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbBackend_Backend> Generate_Backend1(DbBackend_Project projects)
        {
            Random random = new Random();

            #region Databases
            // Main
            DbBackend_Backend backendMain = new DbBackend_Backend()
            {
                Id = new Guid("29000f47-e4dc-4101-965c-af8624d29495"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Main,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                        Id = new Guid("a9976223-8737-46e5-a2c8-e2a677551f49"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = new List<DbBackend_Storage_Cluster>()
                {
                    new DbBackend_Storage_Cluster()
                    {
                        Id = new Guid("c2ec198a-2d7f-4c2f-8073-46a196d2e0a4"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        StorageType = StorageType.S3,
                        StorageClass = StorageClass.DataMain,
                        StorageTier = StorageTier.Hot,

                        StorageFilePath = string.Empty,

                        StorageS3BucketName = string.Empty,                                 // BucketName is Project Id
                        StorageS3AccessKey = "xVnwqfNWGqblg1dmA33j",
                        StorageS3SecretKey = "1Xq3G7az3QC3R0wKTBbwNHPNawhA16j1cx0n0a",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        Internal = true,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        StorageServers = new List<DbBackend_Storage_Server>()
                        {
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 110,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 111,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 112,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };

            // Transcription
            DbBackend_Backend backendTranscription = new DbBackend_Backend()
            {
                Id = new Guid("20d16641-3d52-40ce-87ad-621d29d7245f"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Transcription,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                              Id = new Guid("b69ab40f-8c21-4916-b019-260a081e1a0f"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = new List<DbBackend_Storage_Cluster>()
                {
                    new DbBackend_Storage_Cluster()
                    {
                     Id = new Guid("968d6641-4119-4d4c-9bc0-2ced7beffd43"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        StorageType = StorageType.S3,
                        StorageClass = StorageClass.DataTranscription,
                        StorageTier = StorageTier.Hot,

                        StorageFilePath = string.Empty,

                        StorageS3BucketName = string.Empty,                                 // BucketName is Project Id
                        StorageS3AccessKey = "fAWtO1ZgyPt0GQZ2B4yO",
                        StorageS3SecretKey = "n2p9FmJM7o68t8jzHEMP1Z5RO5RnJxFFKxva0M",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        Internal = true,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        StorageServers = new List<DbBackend_Storage_Server>()
                        {
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 128,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 129,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 130,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };

            // Job
            DbBackend_Backend backendJob = new DbBackend_Backend()
            {
                Id = new Guid("ca878289-9b96-457f-a486-f53aed0da113"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Job,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                        Id = new Guid("216ea8ad-5e98-414f-9c7c-cdb3fb9dffdb"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = null,

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };

            // Machine
            DbBackend_Backend backendMachine = new DbBackend_Backend()
            {
                Id = new Guid("09c02b16-bb49-40ba-89b7-40504327565d"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Machine,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                           Id = new Guid("50c221c0-715a-4b62-b85e-fbff5ea22697"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = null,

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };

            // Software
            DbBackend_Backend backendSoftware = new DbBackend_Backend()
            {
                Id = new Guid("3f7c76da-0854-43c4-b85c-410b9b5d17fc"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Software,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                        Id = new Guid("b054b335-4f51-4e23-b6fa-454ca3ad7e10"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = null,

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };
            #endregion

            #region Storage
            // Storage Data
            DbBackend_Backend backendStorageData = new DbBackend_Backend()
            {
                Id = new Guid("8611b52b-b27f-4ccf-847b-a17eb590bbe9"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Storage,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                        Id = new Guid("baf4e09e-eb5f-4c62-817e-dfa1d9fe3266"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = new List<DbBackend_Storage_Cluster>()
                {
                    new DbBackend_Storage_Cluster()
                    {
                        Id = new Guid("d0e989bf-7e46-4064-903d-a5e27a276c4a"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        StorageType = StorageType.S3,
                        StorageClass = StorageClass.Data,
                        StorageTier = StorageTier.Hot,

                        StorageFilePath = string.Empty,

                        StorageS3BucketName = string.Empty,                                 // BucketName is Project Id
                        StorageS3AccessKey = "lXbKy82C7lIkNRRQXaoq",
                        StorageS3SecretKey = "iuVv7TMZA0Oaky7bgXE6mdejI9Xnu40KGMrFve",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        Internal = true,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        StorageServers = new List<DbBackend_Storage_Server>()
                        {
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 116,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 117,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 118,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };

            // Storage Data Thumbnail
            DbBackend_Backend backendStorageDataThumbnail = new DbBackend_Backend()
            {
                Id = new Guid("739570fa-ef7e-41bc-9b79-b4753dc04527"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Storage,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                        Id = new Guid("b63d6be2-4bbf-420d-b8d3-1e78a57a6bd1"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = new List<DbBackend_Storage_Cluster>()
                {
                    new DbBackend_Storage_Cluster()
                    {
                        Id = new Guid("8ba313b7-618d-41c4-98b7-968295299505"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        StorageType = StorageType.S3,
                        StorageClass = StorageClass.DataThumbnail,
                        StorageTier = StorageTier.Hot,

                        StorageFilePath = string.Empty,

                        StorageS3BucketName = string.Empty,                                 // BucketName is Project Id
                        StorageS3AccessKey = "Mq5A3CCxUMcUxW9xP0Nw",
                        StorageS3SecretKey = "YCVcvjFidGNneQVPTJ0LUhDM1Nxj9Y5fD5RMCh",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        Internal = true,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        StorageServers = new List<DbBackend_Storage_Server>()
                        {
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 119,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 120,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 121,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };

            // Storage Data Raw
            DbBackend_Backend backendStorageDataRaw = new DbBackend_Backend()
            {
                Id = new Guid("9e05de17-2d39-47fd-a1f2-f4c274b8f44c"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Storage,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                             Id = new Guid("50b7e775-1b84-41aa-b0b1-4280351c3b05"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = new List<DbBackend_Storage_Cluster>()
                {
                    new DbBackend_Storage_Cluster()
                    {
                         Id = new Guid("7a9bbb27-bad4-41bc-b281-e8410db84c4f"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        StorageType = StorageType.S3,
                        StorageClass = StorageClass.DataRaw,
                        StorageTier = StorageTier.Hot,

                        StorageFilePath = string.Empty,

                        StorageS3BucketName = string.Empty,                                 // BucketName is Project Id
                        StorageS3AccessKey = "cIm3AkV6LpnR47v7vP68",
                        StorageS3SecretKey = "LcBxrCot4ekVhNXOQ5pF6cXakToEilbEmXpX3G",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        Internal = true,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        StorageServers = new List<DbBackend_Storage_Server>()
                        {
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 122,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 123,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 124,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };

            // Storage Data Raw Thumbnail
            DbBackend_Backend backendStorageDataRawThumbnail = new DbBackend_Backend()
            {
                Id = new Guid("aedb88bc-c17d-49f1-879c-c595ad758aef"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Storage,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = new List<DbBackend_Database_Cluster>()
                {
                    new DbBackend_Database_Cluster()
                    {
                        Id = new Guid("afbd8a86-67a8-4b92-9ddb-9f4b8ef8be63"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        DatabaseType = DatabaseType.PostgreSQL,
                        DatabaseFilePath = string.Empty,
                        DatabasePort = 50001,
                        DatabaseUsername = "postgres",
                        DatabasePassword = "fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        DatabaseServers = new List<DbBackend_Database_Server>()
                        {
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Database_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                StorageClusters = new List<DbBackend_Storage_Cluster>()
                {
                    new DbBackend_Storage_Cluster()
                    {
                        Id = new Guid("a13006e1-2808-4620-b9bb-6a78193a3099"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        StorageType = StorageType.S3,
                        StorageClass = StorageClass.DataRawThumbnail,
                        StorageTier = StorageTier.Hot,

                        StorageFilePath = string.Empty,

                        StorageS3BucketName = string.Empty,                                 // BucketName is Project Id
                        StorageS3AccessKey = "iPM6Iklm5dcyJVq9z3Vr",
                        StorageS3SecretKey = "jgn0MHMHgMg9MtldqVVCPuNU2ahOVDdQpvm4g9",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        Internal = true,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,

                        StorageServers = new List<DbBackend_Storage_Server>()
                        {
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 125,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 126,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Storage_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 127,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                ServerClusters = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };
            #endregion

            #region Logging
            // Loki
            DbBackend_Backend backendLoki = new DbBackend_Backend()
            {
                Id = new Guid("4d7e0de8-53fc-496f-b58f-bf42c0248a2d"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Logging,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = null,

                StorageClusters = null,

                ServerClusters = new List<DbBackend_Server_Cluster>()
                {
                    new DbBackend_Server_Cluster()
                    {
                        Id = new Guid("a27b898d-5c5c-4426-a49d-696b6998f00c"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        ServerType = ServerType.Loki,

                        ServerPort = 3100,
                        ServerUsername = string.Empty,
                        ServerPassword = string.Empty,
                        ServerPublicKey = string.Empty,
                        ServerPrivateKey  = string.Empty,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = "[{Timestamp:dd.MM.yyyy - HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}",
                        //Configuration = "[{Timestamp:dd.MM.yyyy - HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";

                        ServerServers = new List<DbBackend_Server_Server>()
                        {
                            new DbBackend_Server_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Server_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Server_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };
            #endregion

            #region Authentication abd Authorization
            // Loki
            DbBackend_Backend backendKeycloak = new DbBackend_Backend()
            {
                Id = new Guid("9b37bc60-c96c-4c7e-9975-262803c72b65"),

                Name = string.Empty,
                Description = string.Empty,

                BackendType = BackendType.Authentication,

                ReadOnlyMode = false,

                Locked = false,
                LockedDescription = string.Empty,

                Url = string.Empty,
                UrlPublic = string.Empty,

                DatabaseClusters = null,

                StorageClusters = null,

                ServerClusters = new List<DbBackend_Server_Cluster>()
                {
                    new DbBackend_Server_Cluster()
                    {
                        Id = new Guid("a0b51811-f2c5-4308-b68c-7989f82d66ef"),

                        Name = string.Empty,
                        Description = string.Empty,

                        Stars = 0,
                        Order = 1,

                        BranchNumber = 31,
                        Domain = "psgm.at",

                        ServerType = ServerType.Keycloak,

                        ServerPort = 3100,
                        ServerUsername = string.Empty,
                        ServerPassword = string.Empty,
                        ServerPublicKey = string.Empty,
                        ServerPrivateKey  = string.Empty,

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

                        Configuration = string.Empty,   

                        ServerServers = new List<DbBackend_Server_Server>()
                        {
                            new DbBackend_Server_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = "",
                                Description = "",

                                Node = 1,

                                FirstIpSegment = 10,
                                LastIpSegment = 113,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Server_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 2,

                                FirstIpSegment = 10,
                                LastIpSegment = 114,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            },
                            new DbBackend_Server_Server()
                            {
                                Id = Guid.NewGuid(),

                                Name = string.Empty,
                                Description = string.Empty,

                                Node = 3,

                                FirstIpSegment = 10,
                                LastIpSegment = 115,
                                VLAN = 40,

                                ServerIP = string.Empty,
                                ServerDNS = string.Empty,

                                ReadOnlyMode = false,

                                Locked = false,
                                LockedDescription = string.Empty,

                                Configuration = string.Empty,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Cluster = null,
                                ClusterId = null,
                            }
                        },
                        
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        Backend = null,
                        BackendId = null
                    }
                },

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };
            #endregion

            List<DbBackend_Backend> tmp = new List<DbBackend_Backend>(new List<DbBackend_Backend>()
            {
                backendMain,

                backendStorageData,
                backendStorageDataThumbnail,

                backendStorageDataRaw,
                backendStorageDataRawThumbnail,

                backendTranscription,

                backendJob,

                backendMachine,

                backendSoftware,

                backendLoki,

                backendKeycloak,
            });

            return tmp;
        }
    }
}
