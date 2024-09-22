using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_RootDirectory> Generate_RootDirectories(int count)
        {
            Random random = new Random();

            List<DbStorage_RootDirectory> tmp = new List<DbStorage_RootDirectory>();

            #region Create Data ...
            List<DbStorage_RootDirectory_Authorization_User> authorization_Users = new List<DbStorage_RootDirectory_Authorization_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(EmployeeType));
                EmployeeType randomPermissionType = (EmployeeType)values.GetValue(random.Next(values.Length));

                authorization_Users.Add(new DbStorage_RootDirectory_Authorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),
                    
                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserLinks = null
                });
            }

            List<DbStorage_RootDirectory_Authorization_UserGroup> authorization_UserGroups = new List<DbStorage_RootDirectory_Authorization_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(EmployeeType));
                EmployeeType randomPermissionType = (EmployeeType)values.GetValue(random.Next(values.Length));

                authorization_UserGroups.Add(new DbStorage_RootDirectory_Authorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),
                    
                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserGroupLinks = null
                });
            }

            List<DbStorage_RootDirectory_Notification_User> notification_Users = new List<DbStorage_RootDirectory_Notification_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_Users.Add(new DbStorage_RootDirectory_Notification_User()
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

                    NotificationUserLinks = null
                });
            }

            List<DbStorage_RootDirectory_Notification_UserGroup> notification_UserGroups = new List<DbStorage_RootDirectory_Notification_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_UserGroups.Add(new DbStorage_RootDirectory_Notification_UserGroup()
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

                    NotificationUserGroupLinks = null
                });
            }



            List<DbStorage_RootDirectory_Metadata_Authorization_User> metadataAuthorization_Users = new List<DbStorage_RootDirectory_Metadata_Authorization_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(EmployeeType));
                EmployeeType randomPermissionType = (EmployeeType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_Users.Add(new DbStorage_RootDirectory_Metadata_Authorization_User()
                {
                    Id = Guid.NewGuid(),
                    
                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserLinks = null
                });
            }

            List<DbStorage_RootDirectory_Metadata_Authorization_UserGroup> metadataAuthorization_UserGroups = new List<DbStorage_RootDirectory_Metadata_Authorization_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(EmployeeType));
                EmployeeType randomPermissionType = (EmployeeType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_UserGroups.Add(new DbStorage_RootDirectory_Metadata_Authorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,
                    
                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserGroupLinks = null
                });
            }

            List<DbStorage_RootDirectory_Metadata> rootDirectoryMetadata = new List<DbStorage_RootDirectory_Metadata>();
            for (int i = 1; i <= 50; i++)
            {
                List<DbStorage_RootDirectory_Metadata_Authorization_User_Link> authorization_UsersLoop = new List<DbStorage_RootDirectory_Metadata_Authorization_User_Link>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_RootDirectory_Metadata_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),
                        
                        // FK
                        AuthorizationUser = metadataAuthorization_Users[random.Next(0, metadataAuthorization_Users.Count())],
                        //AuthorizationUserId = Guid.Empty,
                        
                        Metadata = null,
                        MetadataId = null
                    });
                }

                List<DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link> authorization_UserGroupsLoop = new List<DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        AuthorizationUserGroup = metadataAuthorization_UserGroups[random.Next(0, metadataAuthorization_UserGroups.Count())],
                        //AuthorizationUserGroupId = Guid.Empty,

                        Metadata = null,
                        MetadataId = null
                    });
                }

                rootDirectoryMetadata.Add(new DbStorage_RootDirectory_Metadata()
                {
                    Id = Guid.NewGuid(),

                    Key = Common.RandomString(random.Next(5, 50)),
                    Value = Common.RandomString(random.Next(10, 100)),

                    Description = Common.RandomString(random.Next(10, 200)),
                    
                    Hidden = random.Next(100) <= 50 ? true : false,
                    EditAll = random.Next(100) <= 50 ? true : false,
                    ViewAll = random.Next(100) <= 50 ? true : false,

                    ApplicableForFiles = random.Next(100) <= 50 ? true : false,

                    MetadataLinks = null,

                    MetadataType = MetadataType.Unknown,

                    Stars = random.Next(0, 5),

                    Order = random.Next(0, 10000),

                    AuthorizationUserLinks = authorization_UsersLoop,
                    AuthorizationUserGroupLinks = authorization_UserGroupsLoop,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            for (int i = 0; i < count; i++)
            {
                List<DbStorage_RootDirectory_Metadata_Link> rootDirectoryMetadataLinkLoop = new List<DbStorage_RootDirectory_Metadata_Link>();
                for (int j = 0; j < random.Next(0, rootDirectoryMetadata.Count()); j++)
                {
                    rootDirectoryMetadataLinkLoop.Add(new DbStorage_RootDirectory_Metadata_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,

                        Metadata = rootDirectoryMetadata[random.Next(0, rootDirectoryMetadata.Count())],
                        //MetadataId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectory_Authorization_User_Link> authorization_UsersLoop = new List<DbStorage_RootDirectory_Authorization_User_Link>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_RootDirectory_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,

                        AuthorizationUser = authorization_Users[random.Next(0, authorization_Users.Count())],
                        //AuthorizationUserId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectory_Authorization_UserGroup_Link> authorization_UserGroupsLoop = new List<DbStorage_RootDirectory_Authorization_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_RootDirectory_Authorization_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,

                        AuthorizationUserGroup = authorization_UserGroups[random.Next(0, authorization_UserGroups.Count())],
                        //AuthorizationUserGroupId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectory_Notification_User_Link> notification_UsersLoop = new List<DbStorage_RootDirectory_Notification_User_Link>();
                for (int j = 0; j < random.Next(0, notification_Users.Count()); j++)
                {
                    notification_UsersLoop.Add(new DbStorage_RootDirectory_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,

                        NotificationUser = notification_Users[random.Next(0, notification_Users.Count())],
                        //NotificationUserId = Guid.Empty,
                    });
                }

                List<DbStorage_RootDirectory_Notification_UserGroup_Link> notification_UserGroupsLoop = new List<DbStorage_RootDirectory_Notification_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, notification_UserGroups.Count()); j++)
                {
                    notification_UserGroupsLoop.Add(new DbStorage_RootDirectory_Notification_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,

                        NotificationUserGroup = notification_UserGroups[random.Next(0, notification_UserGroups.Count())],
                        //NotificationUserGroupId = Guid.Empty,
                    });
                }

                Array values = Enum.GetValues(typeof(QualityState));
                QualityState qualityStateType = (QualityState)values.GetValue(random.Next(values.Length));

                DbStorage_RootDirectory_Quality quality;
                int qualityCount = random.Next(0, 3);
                if (qualityCount == 0)
                {
                    quality = new DbStorage_RootDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,
                    };
                }
                else if (qualityCount == 1)
                {
                    quality = new DbStorage_RootDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,
                    };
                }
                else if (qualityCount == 2)
                {
                    quality = new DbStorage_RootDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,
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

                    AuthorizationUserLinks = authorization_UsersLoop,
                    AuthorizationUserGroupLinks = authorization_UserGroupsLoop,

                    NotificationUserLinks = notification_UsersLoop,
                    NotificationUserGroupLinks = notification_UserGroupsLoop,

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

                    QrCode = new DbStorage_RootDirectory_QrCode()
                    {
                        Id = Guid.NewGuid(),

                        Name = "QrCode " + i.ToString(),
                        Description = "QrCode " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                        QrCodeType = QrCodeType.Undefined,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,
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
