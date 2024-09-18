using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_SubDirectory> Create_SubDirectories(int count, List<DbStorage_RootDirectory> rootDirectories)
        {
            Random random = new Random();

            List<DbStorage_SubDirectory> tmp = new List<DbStorage_SubDirectory>();

            #region Create Data ...
            List<DbStorage_SubDirectoryAuthorization_User> authorization_Users = new List<DbStorage_SubDirectoryAuthorization_User>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_Users.Add(new DbStorage_SubDirectoryAuthorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    SubDirectoryAuthorization_UserLinks = null
                });
            }

            List<DbStorage_SubDirectoryAuthorization_UserGroup> authorization_UserGroups = new List<DbStorage_SubDirectoryAuthorization_UserGroup>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_UserGroups.Add(new DbStorage_SubDirectoryAuthorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    SubDirectoryAuthorization_UserGroupLinks = null
                });
            }

            List<DbStorage_SubDirectoryNotification_User> notification_Users = new List<DbStorage_SubDirectoryNotification_User>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_Users.Add(new DbStorage_SubDirectoryNotification_User()
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

                    SubDirectoryNotification_UserLinks = null
                });
            }

            List<DbStorage_SubDirectoryNotification_UserGroup> notification_UserGroups = new List<DbStorage_SubDirectoryNotification_UserGroup>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_UserGroups.Add(new DbStorage_SubDirectoryNotification_UserGroup()
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

                    SubDirectoryNotification_UserGroupLinks = null
                });
            }



            List<DbStorage_SubDirectoryMetadataAuthorization_User> metadataAuthorization_Users = new List<DbStorage_SubDirectoryMetadataAuthorization_User>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_Users.Add(new DbStorage_SubDirectoryMetadataAuthorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    SubDirectoryMetadataAuthorization_UserLinks = null
                });
            }

            List<DbStorage_SubDirectoryMetadataAuthorization_UserGroup> metadataAuthorization_UserGroups = new List<DbStorage_SubDirectoryMetadataAuthorization_UserGroup>();
            for (int i = 0; i < 2500; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_UserGroups.Add(new DbStorage_SubDirectoryMetadataAuthorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    SubDirectoryMetadataAuthorization_UserGroupLinks = null
                });
            }

            List<DbStorage_SubDirectoryMetadata> subDirectoryMetadata = new List<DbStorage_SubDirectoryMetadata>();
            for (int i = 0; i < 1000; i++)
            {
                List<DbStorage_SubDirectoryMetadataAuthorization_UserLink> authorization_UsersLoop = new List<DbStorage_SubDirectoryMetadataAuthorization_UserLink>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_SubDirectoryMetadataAuthorization_UserLink()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectoryMetadataAuthorization_User = metadataAuthorization_Users[random.Next(0, metadataAuthorization_Users.Count())],
                        //SubDirectoryMetadataAuthorization_UserId = Guid.Empty,

                        SubDirectoryMetadata = null,
                        SubDirectoryMetadataId = null
                    });
                }

                List<DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink> authorization_UserGroupsLoop = new List<DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectoryMetadataAuthorization_UserGroup = metadataAuthorization_UserGroups[random.Next(0, metadataAuthorization_UserGroups.Count())],
                        //SubDirectoryMetadataAuthorization_UserGroupId = Guid.Empty,

                        SubDirectoryMetadata = null,
                        SubDirectoryMetadataId = null
                    });
                }

                subDirectoryMetadata.Add(new DbStorage_SubDirectoryMetadata()
                {
                    Id = Guid.NewGuid(),

                    Key = Common.RandomString(random.Next(5, 50)),
                    Value = Common.RandomString(random.Next(10, 100)),

                    Description = Common.RandomString(random.Next(10, 200)),

                    Hidden = random.Next(100) <= 50 ? true : false,
                    EditAll = random.Next(100) <= 50 ? true : false,
                    ViewAll = random.Next(100) <= 50 ? true : false,

                    ApplicableForFiles = random.Next(100) <= 50 ? true : false,

                    SubDirectoryMetadataLinks = null,

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
                List<DbStorage_SubDirectoryMetadataLink> subDirectoryMetadataLinkLoop = new List<DbStorage_SubDirectoryMetadataLink>();
                for (int j = 0; j < random.Next(0, subDirectoryMetadata.Count()); j++)
                {
                    subDirectoryMetadataLinkLoop.Add(new DbStorage_SubDirectoryMetadataLink()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        SubDirectoryMetadata = subDirectoryMetadata[random.Next(0, subDirectoryMetadata.Count())],
                        //SubDirectoryMetadataId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectoryAuthorization_UserLink> authorization_UsersLoop = new List<DbStorage_SubDirectoryAuthorization_UserLink>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_SubDirectoryAuthorization_UserLink()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        SubDirectoryAuthorization_User = authorization_Users[random.Next(0, authorization_Users.Count())],
                        //SubDirectoryAuthorization_UserId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectoryAuthorization_UserGroupLink> authorization_UserGroupsLoop = new List<DbStorage_SubDirectoryAuthorization_UserGroupLink>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_SubDirectoryAuthorization_UserGroupLink()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        SubDirectoryAuthorization_UserGroup = authorization_UserGroups[random.Next(0, authorization_UserGroups.Count())],
                        //SubDirectoryAuthorization_UserGroupId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectoryNotification_UserLink> notification_UsersLoop = new List<DbStorage_SubDirectoryNotification_UserLink>();
                for (int j = 0; j < random.Next(0, notification_Users.Count()); j++)
                {
                    notification_UsersLoop.Add(new DbStorage_SubDirectoryNotification_UserLink()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        SubDirectoryNotification_User = notification_Users[random.Next(0, notification_Users.Count())],
                        //SubDirectoryNotification_UserId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectoryNotification_UserGroupLink> notification_UserGroupsLoop = new List<DbStorage_SubDirectoryNotification_UserGroupLink>();
                for (int j = 0; j < random.Next(0, notification_UserGroups.Count()); j++)
                {
                    notification_UserGroupsLoop.Add(new DbStorage_SubDirectoryNotification_UserGroupLink()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        SubDirectoryNotification_UserGroup = notification_UserGroups[random.Next(0, notification_UserGroups.Count())],
                        //SubDirectoryNotification_UserGroupId = Guid.Empty,
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

                DbStorage_SubDirectory element = new DbStorage_SubDirectory()
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
                    
                    MetadataLinks = subDirectoryMetadataLinkLoop,

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

                    RootDirectory = rootDirectories[random.Next(0, rootDirectories.Count())],
                    //RootDirectoryId = null,

                    SubDirectories = null,

                    ParentSubDirectory = null,
                    ParentSubDirectoryId = null,

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

                //_dbStorage_Data_Context.SubDirectories.Add(element);
                //_dbStorage_Data_Context.SaveChanges();

                tmp.Add(element);
            }

            return tmp;
        }
    }
}
