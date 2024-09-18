using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_RootDirectory> Create_RootDirectories(DbStorage_Context contect, int count)
        {
            Random random = new Random();

            List<DbStorage_RootDirectory> tmp = new List<DbStorage_RootDirectory>();

            #region Create Data ...
            List<DbStorage_RootDirectoryAuthorization_User> authorization_Users = new List<DbStorage_RootDirectoryAuthorization_User>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_Users.Add(new DbStorage_RootDirectoryAuthorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    RootDirectoryAuthorization_UserLinks = null
                });
            }

            List<DbStorage_RootDirectoryAuthorization_UserGroup> authorization_UserGroups = new List<DbStorage_RootDirectoryAuthorization_UserGroup>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_UserGroups.Add(new DbStorage_RootDirectoryAuthorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    RootDirectoryAuthorization_UserGroupLinks = null
                });
            }

            List<DbStorage_RootDirectoryNotification_User> notification_Users = new List<DbStorage_RootDirectoryNotification_User>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_Users.Add(new DbStorage_RootDirectoryNotification_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Description = Common.RandomString(random.Next(10, 100)),

                    NotificationType = (NotificationType)values.GetValue(random.Next(values.Length)),

                    EMail = random.Next(100) <= 50 ? true : false,
                    Slack = random.Next(100) <= 50 ? true : false,
                    Teams = random.Next(100) <= 50 ? true : false,
                    SMS = random.Next(100) <= 50 ? true : false,
                    WhatsApp = random.Next(100) <= 50 ? true : false,
                    Telegram = random.Next(100) <= 50 ? true : false,
                    Gotify = random.Next(100) <= 50 ? true : false,

                    RootDirectoryNotification_UserLinks = null
                });
            }

            List<DbStorage_RootDirectoryNotification_UserGroup> notification_UserGroups = new List<DbStorage_RootDirectoryNotification_UserGroup>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_UserGroups.Add(new DbStorage_RootDirectoryNotification_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Description = Common.RandomString(random.Next(10, 100)),

                    NotificationType = (NotificationType)values.GetValue(random.Next(values.Length)),

                    EMail = random.Next(100) <= 50 ? true : false,
                    Slack = random.Next(100) <= 50 ? true : false,
                    Teams = random.Next(100) <= 50 ? true : false,
                    SMS = random.Next(100) <= 50 ? true : false,
                    WhatsApp = random.Next(100) <= 50 ? true : false,
                    Telegram = random.Next(100) <= 50 ? true : false,
                    Gotify = random.Next(100) <= 50 ? true : false,

                    RootDirectoryNotification_UserGroupLinks = null
                });
            }



            List<DbStorage_RootDirectoryMetadataAuthorization_User> metadataAuthorization_Users = new List<DbStorage_RootDirectoryMetadataAuthorization_User>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_Users.Add(new DbStorage_RootDirectoryMetadataAuthorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    RootDirectoryMetadataAuthorization_UserLinks = null
                });
            }

            List<DbStorage_RootDirectoryMetadataAuthorization_UserGroup> metadataAuthorization_UserGroups = new List<DbStorage_RootDirectoryMetadataAuthorization_UserGroup>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_UserGroups.Add(new DbStorage_RootDirectoryMetadataAuthorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    RootDirectoryMetadataAuthorization_UserGroupLinks = null
                });
            }

            List<DbStorage_RootDirectoryMetadata> rootDirectoryMetadata = new List<DbStorage_RootDirectoryMetadata>();
            for (int i = 0; i < 1000; i++)
            {
                List<DbStorage_RootDirectoryMetadataAuthorization_UserLink> authorization_UsersLoop = new List<DbStorage_RootDirectoryMetadataAuthorization_UserLink>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_RootDirectoryMetadataAuthorization_UserLink()
                    {
                        Id = Guid.NewGuid(),

                        RootDirectoryMetadataAuthorization_User = metadataAuthorization_Users[random.Next(0, metadataAuthorization_Users.Count())],
                        //RootDirectoryMetadataAuthorization_UserId = Guid.Empty,

                        RootDirectoryMetadata = null,
                        RootDirectoryMetadataId = null
                    });
                }

                List<DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink> authorization_UserGroupsLoop = new List<DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink()
                    {
                        Id = Guid.NewGuid(),

                        RootDirectoryMetadataAuthorization_UserGroup = metadataAuthorization_UserGroups[random.Next(0, metadataAuthorization_UserGroups.Count())],
                        //RootDirectoryMetadataAuthorization_UserGroupId = Guid.Empty,

                        RootDirectoryMetadata = null,
                        RootDirectoryMetadataId = null
                    });
                }

                rootDirectoryMetadata.Add(new DbStorage_RootDirectoryMetadata()
                {
                    Id = Guid.NewGuid(),

                    Key = Common.RandomString(random.Next(5, 50)),
                    Value = Common.RandomString(random.Next(10, 100)),

                    Description = Common.RandomString(random.Next(10, 200)),

                    Hidden = random.Next(100) <= 50 ? true : false,
                    EditAll = random.Next(100) <= 50 ? true : false,
                    ViewAll = random.Next(100) <= 50 ? true : false,

                    ApplicableForFiles = random.Next(100) <= 50 ? true : false,

                    RootDirectoryMetadataLinks = null,

                    Authorization_UserLinks = authorization_UsersLoop,
                    Authorization_UserGroupLinks = authorization_UserGroupsLoop,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            for (int i = 0; i < count; i++)
            {
                List<DbStorage_RootDirectoryMetadataLink> rootDirectoryMetadataLinkLoop = new List<DbStorage_RootDirectoryMetadataLink>();
                for (int j = 0; j < random.Next(0, rootDirectoryMetadata.Count()); j++)
                {
                    rootDirectoryMetadataLinkLoop.Add(new DbStorage_RootDirectoryMetadataLink()
                    {
                        Id = Guid.NewGuid(),

                        RootDirectory = null,
                        RootDirectoryId = null,

                        RootDirectoryMetadata = rootDirectoryMetadata[random.Next(0, rootDirectoryMetadata.Count())],
                        //RootDirectoryMetadataId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectoryAuthorization_UserLink> authorization_UsersLoop = new List<DbStorage_RootDirectoryAuthorization_UserLink>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_RootDirectoryAuthorization_UserLink()
                    {
                        Id = Guid.NewGuid(),

                        RootDirectory = null,
                        RootDirectoryId = null,

                        RootDirectoryAuthorization_User = authorization_Users[random.Next(0, authorization_Users.Count())],
                        //RootDirectoryAuthorization_UserId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectoryAuthorization_UserGroupLink> authorization_UserGroupsLoop = new List<DbStorage_RootDirectoryAuthorization_UserGroupLink>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_RootDirectoryAuthorization_UserGroupLink()
                    {
                        Id = Guid.NewGuid(),

                        RootDirectory = null,
                        RootDirectoryId = null,

                        RootDirectoryAuthorization_UserGroup = authorization_UserGroups[random.Next(0, authorization_UserGroups.Count())],
                        //RootDirectoryAuthorization_UserGroupId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectoryNotification_UserLink> notification_UsersLoop = new List<DbStorage_RootDirectoryNotification_UserLink>();
                for (int j = 0; j < random.Next(0, notification_Users.Count()); j++)
                {
                    notification_UsersLoop.Add(new DbStorage_RootDirectoryNotification_UserLink()
                    {
                        Id = Guid.NewGuid(),
                        
                        RootDirectory = null,
                        RootDirectoryId = null,

                        RootDirectoryNotification_User = notification_Users[random.Next(0, notification_Users.Count())],
                        //RootDirectoryNotification_UserId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectoryNotification_UserGroupLink> notification_UserGroupsLoop = new List<DbStorage_RootDirectoryNotification_UserGroupLink>();
                for (int j = 0; j < random.Next(0, notification_UserGroups.Count()); j++)
                {
                    notification_UserGroupsLoop.Add(new DbStorage_RootDirectoryNotification_UserGroupLink()
                    {
                        Id = Guid.NewGuid(),

                        RootDirectory = null,
                        RootDirectoryId = null,

                        RootDirectoryNotification_UserGroup = notification_UserGroups[random.Next(0, notification_UserGroups.Count())],
                        //RootDirectoryNotification_UserGroupId = Guid.Empty,
                    });
                }

                DbStorage_Quality quality;
                int qualityCount = random.Next(0, 3);
                if (qualityCount == 0)
                {
                    quality = new DbStorage_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckPassed,

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        File = null,
                        FileId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    };
                }
                else if (qualityCount == 1)
                {
                    quality = new DbStorage_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckNotPassed,

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        File = null,
                        FileId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    };
                }
                else if (qualityCount == 2)
                {
                    quality = new DbStorage_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.Unchecked,

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        File = null,
                        FileId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    };
                }
                else
                {
                    quality = null;
                }

                DbStorage_RootDirectory element = new DbStorage_RootDirectory()
                {
                    Id = Guid.NewGuid(),

                    Suffix = i.ToString(),
                    Name = "RootDirectory " + i.ToString(),
                    Prefix = i.ToString(),
                    Description = "RootDirectory Description " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                    SuffixProjectOwner = i.ToString(),
                    NameProjectOwner = "ProjectOwner " + i.ToString(),
                    PrefixProjectOwner = i.ToString(),
                    DescriptionProjectOwner = "ProjectOwner Description " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                    Stars = random.Next(0, 5),

                    Order = random.Next(0, 10000),

                    DirectoryState = DirectoryState.Undefined,

                    Quality = quality,

                    MetadataLinks = rootDirectoryMetadataLinkLoop,

                    DirectoryLocked = false,
                    
                    Authorization_UserLinks = authorization_UsersLoop,
                    Authorization_UserGroupLinks = authorization_UserGroupsLoop,

                    Notification_UserLinks = notification_UsersLoop,
                    Notification_UserGroupLinks = notification_UserGroupsLoop,

                    JobIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //JobIdsExtString = string.Empty,

                    WorkflowItemIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //WorkflowItemIdsExtString = string.Empty,

                    BackupIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //BackupIdsExtString = string.Empty,

                    SubDirectories = null,

                    Files = null,

                    DirectoryObjectsAutofill = 0,
                    DirectorySizeAutofill = 0,

                    QrCode = new DbStorage_QrCode()
                    {
                        Id = Guid.NewGuid(),

                        Name = "QrCode " + i.ToString(),
                        Description = "QrCode " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                        QrCodeType = QrCodeType.Undefined,

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        File = null,
                        FileId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    },

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
