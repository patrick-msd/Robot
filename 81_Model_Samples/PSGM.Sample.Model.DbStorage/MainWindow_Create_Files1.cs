using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        //public List<DbStorage_File> Create_Files1(int count, List<Authorization_User> users, List<Authorization_UserGroup> userGroups, List<Notification_User> notificationUsers, List<Notification_UserGroup> notificationUserGroups, List<DbStorage_SubDirectory> subDirectories, List<DbStorage_RootDirectory> rootDirectories, List<DbStorage_FileMetadata> dbStorage_FileMetadata)
        public List<DbStorage_File> Create_Files1(int count, List<DbStorage_RootDirectory> rootDirectories, List<DbStorage_SubDirectory> subDirectories)
        {
            Random random = new Random();
            List<DbStorage_File> tmp = new List<DbStorage_File>();

            #region Create Data ...
            List<DbStorage_File_Authorization_User> authorization_Users = new List<DbStorage_File_Authorization_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_Users.Add(new DbStorage_File_Authorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserLinks = null
                });
            }

            List<DbStorage_File_Authorization_UserGroup> authorization_UserGroups = new List<DbStorage_File_Authorization_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_UserGroups.Add(new DbStorage_File_Authorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserGroupLinks = null
                });
            }

            List<DbStorage_File_Notification_User> notification_Users = new List<DbStorage_File_Notification_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_Users.Add(new DbStorage_File_Notification_User()
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

                    NotificationUserLinks = null,
                });
            }

            List<DbStorage_File_Notification_UserGroup> notification_UserGroups = new List<DbStorage_File_Notification_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_UserGroups.Add(new DbStorage_File_Notification_UserGroup()
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


            List<DbStorage_File_Metadata_Authorization_User> metadataAuthorization_Users = new List<DbStorage_File_Metadata_Authorization_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_Users.Add(new DbStorage_File_Metadata_Authorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserLinks = null
                });
            }

            List<DbStorage_File_Metadata_Authorization_UserGroup> metadataAuthorization_UserGroups = new List<DbStorage_File_Metadata_Authorization_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_UserGroups.Add(new DbStorage_File_Metadata_Authorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserGroupLinks = null
                });
            }

            List<DbStorage_File_Metadata> fileMetadata = new List<DbStorage_File_Metadata>();
            for (int i = 0; i < 50; i++)
            {
                List<DbStorage_File_Metadata_Authorization_User_Link> authorization_UsersLoop = new List<DbStorage_File_Metadata_Authorization_User_Link>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_File_Metadata_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        AuthorizationUser = metadataAuthorization_Users[random.Next(0, metadataAuthorization_Users.Count())],
                        //AuthorizationUserId = Guid.Empty,

                        Metadata = null,
                        MetadataId = null
                    });
                }

                List<DbStorage_File_Metadata_Authorization_UserGroup_Link> authorization_UserGroupsLoop = new List<DbStorage_File_Metadata_Authorization_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_File_Metadata_Authorization_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        AuthorizationUserGroup = metadataAuthorization_UserGroups[random.Next(0, metadataAuthorization_UserGroups.Count())],
                        //AuthorizationUserGroupId = Guid.Empty,

                        Metadata = null,
                        MetadataId = null
                    });
                }

                fileMetadata.Add(new DbStorage_File_Metadata()
                {
                    Id = Guid.NewGuid(),

                    Key = Common.RandomString(random.Next(5, 50)),
                    Value = Common.RandomString(random.Next(10, 100)),

                    Description = Common.RandomString(random.Next(10, 200)),

                    Hidden = random.Next(100) <= 50 ? true : false,
                    EditAll = random.Next(100) <= 50 ? true : false,
                    ViewAll = random.Next(100) <= 50 ? true : false,

                    MetadataLinks = null,

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
                List<DbStorage_File_Metadata_Link> fileMetadataLinkLoop = new List<DbStorage_File_Metadata_Link>();
                for (int j = 0; j < random.Next(0, fileMetadata.Count()); j++)
                {
                    fileMetadataLinkLoop.Add(new DbStorage_File_Metadata_Link()
                    {
                        Id = Guid.NewGuid(),

                        //File = null,
                        //FileId = Guid.Empty,

                        Metadata = fileMetadata[random.Next(0, fileMetadata.Count())],
                        //MetadataId = Guid.Empty,
                    });
                }

                List<DbStorage_File_Authorization_User_Link> authorization_UsersLoop = new List<DbStorage_File_Authorization_User_Link>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_File_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),
                        AuthorizationUser = authorization_Users[random.Next(0, authorization_Users.Count())],
                        //AuthorizationUserId = Guid.Empty,

                        File = null,
                        FileId = null
                    });
                }

                List<DbStorage_File_Authorization_UserGroup_Link> authorization_UserGroupsLoop = new List<DbStorage_File_Authorization_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_File_Authorization_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        AuthorizationUserGroup = authorization_UserGroups[random.Next(0, authorization_UserGroups.Count())],
                        //AuthorizationUserGroupId = Guid.Empty,

                        File = null,
                        FileId = null
                    });
                }

                List<DbStorage_File_Notification_User_Link> notification_UsersLoop = new List<DbStorage_File_Notification_User_Link>();
                for (int j = 0; j < random.Next(0, notification_Users.Count()); j++)
                {
                    notification_UsersLoop.Add(new DbStorage_File_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),
                        NotificationUser = notification_Users[random.Next(0, notification_Users.Count())],
                        //NotificationUserId = Guid.Empty,

                        File = null,
                        FileId = null
                    });
                }

                List<DbStorage_File_Notification_UserGroup_Link> notification_UserGroupsLoop = new List<DbStorage_File_Notification_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, notification_UserGroups.Count()); j++)
                {
                    notification_UserGroupsLoop.Add(new DbStorage_File_Notification_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUserGroup = notification_UserGroups[random.Next(0, notification_UserGroups.Count())],
                        //NotificationUserGroupId = Guid.Empty,

                        File = null,
                        FileId = null
                    });
                }

                DbStorage_File_Quality quality;
                int qualityCount = random.Next(0, 3);
                if (qualityCount == 0)
                {
                    quality = new DbStorage_File_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckPassed,

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
                    quality = new DbStorage_File_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckNotPassed,

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
                    quality = new DbStorage_File_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.Unchecked,

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

                DbStorage_File element = new DbStorage_File()
                {
                    Id = Guid.NewGuid(),

                    RawFileIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //RawFileIdsString = string.Empty,

                    Suffix = i.ToString(),
                    Name = "File " + i.ToString(),
                    Prefix = i.ToString(),
                    Description = "FileDescription " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                    SuffixProjectOwner = i.ToString(),
                    NameProjectOwner = "ProjectOwner " + i.ToString(),
                    PrefixProjectOwner = i.ToString(),
                    DescriptionProjectOwner = "ProjectOwnerDescription " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                    Stars = random.Next(0, 5),

                    Order = random.Next(0, 10000),

                    Quality = quality,

                    MetadataLinks = fileMetadataLinkLoop,

                    MachineIdExt = Guid.NewGuid(),
                    DeviceIdExt = Guid.NewGuid(),
                    SoftwareIdExt = Guid.NewGuid(),

                    ObjectExtension = FileExtension.JSON,

                    ObjectSize = 34235,

                    StorageObjectName = Common.RandomString(random.Next(10, 100)),
                    StorageObjectVersion = random.Next(0, 100),
                    StorageObjectUrl = Common.RandomString(random.Next(10, 200)),
                    StorageObjectUrlPublic = Common.RandomString(random.Next(10, 200)),

                    ExtId1 = Guid.NewGuid().ToString(),
                    ExtId2 = Guid.NewGuid().ToString(),
                    ExtId3 = Guid.NewGuid().ToString(),
                    ExtId4 = Guid.NewGuid().ToString(),
                    ExtId5 = Guid.NewGuid().ToString(),
                    ExtId6 = Guid.NewGuid().ToString(),
                    ExtId7 = Guid.NewGuid().ToString(),
                    ExtId8 = Guid.NewGuid().ToString(),
                    ExtId9 = Guid.NewGuid().ToString(),
                    ExtId10 = Guid.NewGuid().ToString(),

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

                    QrCode = new DbStorage_File_QrCode()
                    {
                        Id = Guid.NewGuid(),

                        Name = "QrCode " + i.ToString(),
                        Description = "QrCode " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                        File = null,
                        FileId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    },

                    RootDirectory = null,
                    RootDirectoryId = null,

                    SubDirectory = subDirectories[random.Next(0, subDirectories.Count())],
                    SubDirectoryId = Guid.Empty,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                };

                //_dbStorage_Data_Context.Files.Add(element);
                //_dbStorage_Data_Context.SaveChanges();

                tmp.Add(element);
            }

            return tmp;
        }
    }
}
