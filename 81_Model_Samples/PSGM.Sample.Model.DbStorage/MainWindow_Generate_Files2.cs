using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_File> Generate_Files2(int count, List<DbStorage_RootDirectory> rootDirectories, List<DbStorage_SubDirectory> subDirectories)
        {
            Random random = new Random();

            List<DbStorage_File> tmp = new List<DbStorage_File>();

            #region Create Data User ...
            List<DbStorage_File_User_Permission> userPermissions = new List<DbStorage_File_User_Permission>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));

                userPermissions.Add(new DbStorage_File_User_Permission()
                {
                    Id = Guid.NewGuid(),

                    Description = string.Empty,

                    PermissionFile = (PermissionType)values.GetValue(random.Next(values.Length)),
                    PermissionMetadata = (PermissionType)values.GetValue(random.Next(values.Length)),

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    User = null,
                    UserId = null,
                });
            }

            List<DbStorage_File_User_Notification> userNotifications = new List<DbStorage_File_User_Notification>();
            for (int i = 0; i < 250; i++)
            {
                userNotifications.Add(new DbStorage_File_User_Notification()
                {
                    Id = Guid.NewGuid(),

                    Description = string.Empty,

                    TriggerType = NotificationTriggerType.WorkflowImage,
                    TriggerState = NotificationTriggerState.CreatedUpdatedDeleted,

                    EMail = random.Next(100) <= 50 ? true : false,
                    Slack = random.Next(100) <= 50 ? true : false,
                    Teams = random.Next(100) <= 50 ? true : false,
                    SMS = random.Next(100) <= 50 ? true : false,
                    WhatsApp = random.Next(100) <= 50 ? true : false,
                    Telegram = random.Next(100) <= 50 ? true : false,
                    Gotify = random.Next(100) <= 50 ? true : false,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    User = null,
                    UserId = null,
                });
            }

            List<DbStorage_File_User> users = new List<DbStorage_File_User>();
            for (int i = 0; i < 250; i++)
            {
                users.Add(new DbStorage_File_User()
                {
                    Id = Guid.NewGuid(),

                    UserId_Ext = Guid.NewGuid(),

                    Acronym = Common.RandomString(random.Next(1, 32)),

                    EMail = Common.RandomString(random.Next(3, 511)),

                    DaytimePhoneNumber = Common.RandomString(random.Next(3, 255)),
                    EveningPhoneNumber = Common.RandomString(random.Next(3, 255)),

                    Permissions = userPermissions[random.Next(0, userPermissions.Count())],
                    Notifications = userNotifications.GetRange(0, random.Next()),

                    UserLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            #region Create Data UserGroup ...
            List<DbStorage_File_UserGroup_Permission> userGroupPermissions = new List<DbStorage_File_UserGroup_Permission>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));

                userGroupPermissions.Add(new DbStorage_File_UserGroup_Permission()
                {
                    Id = Guid.NewGuid(),

                    Description = string.Empty,

                    PermissionFile = (PermissionType)values.GetValue(random.Next(values.Length)),
                    PermissionMetadata = (PermissionType)values.GetValue(random.Next(values.Length)),

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    UserGroup = null,
                    UserGroupId = null,
                });
            }

            List<DbStorage_File_UserGroup_Notification> userGroupNotifications = new List<DbStorage_File_UserGroup_Notification>();
            for (int i = 0; i < 250; i++)
            {
                userGroupNotifications.Add(new DbStorage_File_UserGroup_Notification()
                {
                    Id = Guid.NewGuid(),

                    Description = string.Empty,

                    TriggerType = NotificationTriggerType.WorkflowImage,
                    TriggerState = NotificationTriggerState.CreatedUpdatedDeleted,

                    EMail = random.Next(100) <= 50 ? true : false,
                    Slack = random.Next(100) <= 50 ? true : false,
                    Teams = random.Next(100) <= 50 ? true : false,
                    SMS = random.Next(100) <= 50 ? true : false,
                    WhatsApp = random.Next(100) <= 50 ? true : false,
                    Telegram = random.Next(100) <= 50 ? true : false,
                    Gotify = random.Next(100) <= 50 ? true : false,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    UserGroup = null,
                    UserGroupId = null,
                });
            }

            List<DbStorage_File_UserGroup> userGroups = new List<DbStorage_File_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                userGroups.Add(new DbStorage_File_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    Permissions = userGroupPermissions[random.Next(0, userGroupPermissions.Count())],
                    Notifications = userGroupNotifications.GetRange(0, random.Next()),

                    UserGroupLinks = null,
                    UserLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            List<DbStorage_File_Metadata> fileMetadata = new List<DbStorage_File_Metadata>();
            for (int i = 1; i <= 50; i++)
            {
                Array values1 = Enum.GetValues(typeof(MetadataType));
                Array values2 = Enum.GetValues(typeof(EmployeeType));

                fileMetadata.Add(new DbStorage_File_Metadata()
                {
                    Id = Guid.NewGuid(),

                    Key = Common.RandomString(random.Next(5, 50)),
                    Value = Common.RandomString(random.Next(10, 100)),

                    Description = Common.RandomString(random.Next(10, 200)),

                    MetadataType = (MetadataType)values1.GetValue(random.Next(values1.Length)),
                    MetadataPermissions = (MetadataPermissions)values2.GetValue(random.Next(values2.Length)),

                    ApplicableForFiles = random.Next(100) <= 50 ? true : false,

                    MetadataLinks = null,

                    Stars = random.Next(0, 5),

                    Order = random.Next(0, 10000),

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }

            for (int i = 1; i <= count; i++)
            {
                List<DbStorage_File_Metadata_Link> fileMetadataLinkLoop = new List<DbStorage_File_Metadata_Link>();
                for (int j = 0; j < random.Next(0, fileMetadata.Count()); j++)
                {
                    fileMetadataLinkLoop.Add(new DbStorage_File_Metadata_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        File = null,
                        FileId = null,

                        Metadata = fileMetadata[random.Next(0, fileMetadata.Count())],
                        //MetadataId = Guid.Empty,
                    });
                }

                List<DbStorage_File_User_Link> usersLoop = new List<DbStorage_File_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    usersLoop.Add(new DbStorage_File_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        User = users[random.Next(0, users.Count())],
                        //UserId = null,

                        File = null,
                        FileId = null,
                    });
                }

                List<DbStorage_File_UserGroup_Link> userGroupsLoop = new List<DbStorage_File_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, userGroups.Count()); j++)
                {
                    userGroupsLoop.Add(new DbStorage_File_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        UserGroup = userGroups[random.Next(0, userGroups.Count())],
                        //GroupId = null,

                        File = null,
                        FileId = null,
                    });
                }

                List<DbStorage_File_VirtualSubUnit> virtualSubUnits = new List<DbStorage_File_VirtualSubUnit>();
                for (int j = 0; j < random.Next(25, 250); j++)
                {
                    virtualSubUnits.Add(new DbStorage_File_VirtualSubUnit()
                    {
                        Id = Guid.NewGuid(),

                        VirtualSubUnitId_Ext = Guid.NewGuid(),

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        File = null,
                        FileId = null,
                    });
                }

                Array values = Enum.GetValues(typeof(QualityState));
                QualityState qualityStateType = (QualityState)values.GetValue(random.Next(values.Length));

                #region Random quality ...
                DbStorage_File_Quality? quality;
                int qualityCount = random.Next(0, 3);
                if (qualityCount == 0)
                {
                    quality = new DbStorage_File_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        File = null,
                        FileId = null,
                    };
                }
                else if (qualityCount == 1)
                {
                    quality = new DbStorage_File_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        File = null,
                        FileId = null,
                    };
                }
                else if (qualityCount == 2)
                {
                    quality = new DbStorage_File_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        File = null,
                        FileId = null,
                    };
                }
                else
                {
                    quality = null;
                }
                #endregion

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

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        File = null,
                        FileId = null,
                    },

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    RootDirectory = null,
                    RootDirectoryId = null,

                    SubDirectory = subDirectories[random.Next(0, subDirectories.Count())],
                    SubDirectoryId = Guid.Empty,
                };

                //_dbStorage_Data_Context.Files.Add(element);
                //_dbStorage_Data_Context.SaveChanges();

                tmp.Add(element);
            }

            return tmp;
        }
    }
}
