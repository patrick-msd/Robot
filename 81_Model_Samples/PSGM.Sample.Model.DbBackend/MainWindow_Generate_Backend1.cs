using PSGM.Helper;
using PSGM.Model.DbBackend;

namespace PSGM.Sample.Model.DbBackend
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbBackend_Backend> Generate_Backend1(DbBackend_Project projects)
        {
            Random random = new Random();

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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
                        StorageS3AccessKey = "lXbKy82C7lIkNRRQXaoq",
                        StorageS3SecretKey = "iuVv7TMZA0Oaky7bgXE6mdejI9Xnu40KGMrFve",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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
                        StorageS3AccessKey = "Mq5A3CCxUMcUxW9xP0Nw",
                        StorageS3SecretKey = "YCVcvjFidGNneQVPTJ0LUhDM1Nxj9Y5fD5RMCh",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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
                        StorageS3AccessKey = "cIm3AkV6LpnR47v7vP68",
                        StorageS3SecretKey = "LcBxrCot4ekVhNXOQ5pF6cXakToEilbEmXpX3G",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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
                        StorageS3AccessKey = "iPM6Iklm5dcyJVq9z3Vr",
                        StorageS3SecretKey = "jgn0MHMHgMg9MtldqVVCPuNU2ahOVDdQpvm4g9",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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
                        StorageS3AccessKey = "vRq5oKX0jphGaCvGdGMz",
                        StorageS3SecretKey = "uimrR6RKkVgUL9QL4XcNRyucP4r0jeajzwxfwT",
                        StorageS3Secure = false,
                        StorageS3Region = "eu-central-1",

                        ReadOnlyMode = false,

                        Locked = false,
                        LockedDescription = string.Empty,

                        Url = string.Empty,
                        UrlPublic = string.Empty,

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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
                        Id = Guid.NewGuid(),

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

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,

                // FK
                Project = projects,
                //ProjectId = null,
            };



            List<DbBackend_Backend> tmp = new List<DbBackend_Backend>(new List<DbBackend_Backend>()
            {
                backendMain,

                backendStorageDataRaw,
                backendStorageDataRawThumbnail,

                backendStorageData,
                backendStorageDataThumbnail,

                backendTranscription,

                backendJob,

                backendMachine,

                backendSoftware
            });

            return tmp;
        }
    }
}
