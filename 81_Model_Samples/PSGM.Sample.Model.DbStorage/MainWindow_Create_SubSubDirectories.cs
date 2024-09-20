using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_SubDirectory> Create_SubSubDirectories(int count, List<DbStorage_RootDirectory> rootDirectories)
        {
            Random random = new Random();

            List<DbStorage_SubDirectory> tmp = new List<DbStorage_SubDirectory>();

            #region Create Data ...
            List<DbStorage_SubDirectory_Authorization_User> authorization_Users = new List<DbStorage_SubDirectory_Authorization_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_Users.Add(new DbStorage_SubDirectory_Authorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserLinks = null
                });
            }

            List<DbStorage_SubDirectory_Authorization_UserGroup> authorization_UserGroups = new List<DbStorage_SubDirectory_Authorization_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                authorization_UserGroups.Add(new DbStorage_SubDirectory_Authorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserGroupLinks = null
                });
            }

            List<DbStorage_SubDirectory_Notification_User> notification_Users = new List<DbStorage_SubDirectory_Notification_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_Users.Add(new DbStorage_SubDirectory_Notification_User()
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

            List<DbStorage_SubDirectory_Notification_UserGroup> notification_UserGroups = new List<DbStorage_SubDirectory_Notification_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(NotificationType));

                notification_UserGroups.Add(new DbStorage_SubDirectory_Notification_UserGroup()
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



            List<DbStorage_SubDirectory_Metadata_Authorization_User> metadataAuthorization_Users = new List<DbStorage_SubDirectory_Metadata_Authorization_User>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_Users.Add(new DbStorage_SubDirectory_Metadata_Authorization_User()
                {
                    Id = Guid.NewGuid(),

                    UserIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserLinks = null
                });
            }

            List<DbStorage_SubDirectory_Metadata_Authorization_UserGroup> metadataAuthorization_UserGroups = new List<DbStorage_SubDirectory_Metadata_Authorization_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));
                PermissionType randomPermissionType = (PermissionType)values.GetValue(random.Next(values.Length));

                metadataAuthorization_UserGroups.Add(new DbStorage_SubDirectory_Metadata_Authorization_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    UserGroupIdExt = Guid.NewGuid(),

                    Permissions = randomPermissionType,

                    Description = Common.RandomString(random.Next(10, 100)),

                    AuthorizationUserGroupLinks = null
                });
            }

            List<DbStorage_SubDirectory_Metadata> subDirectoryMetadata = new List<DbStorage_SubDirectory_Metadata>();
            for (int i = 0; i < 50; i++)
            {
                List<DbStorage_SubDirectory_Metadata_Authorization_User_Link> authorization_UsersLoop = new List<DbStorage_SubDirectory_Metadata_Authorization_User_Link>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_SubDirectory_Metadata_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        AuthorizationUser = metadataAuthorization_Users[random.Next(0, metadataAuthorization_Users.Count())],
                        //Authorization_UserId = Guid.Empty,

                        Metadata = null,
                        MetadataId = null
                    });
                }

                List<DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link> authorization_UserGroupsLoop = new List<DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        AuthorizationUserGroup = metadataAuthorization_UserGroups[random.Next(0, metadataAuthorization_UserGroups.Count())],
                        //AuthorizationUserGroupId = Guid.Empty,

                        Metadata = null,
                        MetadataId = null
                    });
                }

                subDirectoryMetadata.Add(new DbStorage_SubDirectory_Metadata()
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

                    AuthorizationUserLinks = authorization_UsersLoop,
                    AuthorizationUserGroupLinks = authorization_UserGroupsLoop,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            for (int i = 0; i <= count; i++)
            {
                List<DbStorage_SubDirectory_Metadata_Link> subDirectoryMetadataLinkLoop = new List<DbStorage_SubDirectory_Metadata_Link>();
                for (int j = 0; j < random.Next(0, subDirectoryMetadata.Count()); j++)
                {
                    subDirectoryMetadataLinkLoop.Add(new DbStorage_SubDirectory_Metadata_Link()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        Metadata = subDirectoryMetadata[random.Next(0, subDirectoryMetadata.Count())],
                        //SubDirectoryMetadataId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectory_Authorization_User_Link> authorization_UsersLoop = new List<DbStorage_SubDirectory_Authorization_User_Link>();
                for (int j = 0; j < random.Next(0, authorization_Users.Count()); j++)
                {
                    authorization_UsersLoop.Add(new DbStorage_SubDirectory_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        AuthorizationUser = authorization_Users[random.Next(0, authorization_Users.Count())],
                        //SubDirectoryAuthorization_UserId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectory_Authorization_UserGroup_Link> authorization_UserGroupsLoop = new List<DbStorage_SubDirectory_Authorization_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, authorization_UserGroups.Count()); j++)
                {
                    authorization_UserGroupsLoop.Add(new DbStorage_SubDirectory_Authorization_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        AuthorizationUserGroup = authorization_UserGroups[random.Next(0, authorization_UserGroups.Count())],
                        //AuthorizationUserGroupId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectory_Notification_User_Link> notification_UsersLoop = new List<DbStorage_SubDirectory_Notification_User_Link>();
                for (int j = 0; j < random.Next(0, notification_Users.Count()); j++)
                {
                    notification_UsersLoop.Add(new DbStorage_SubDirectory_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        NotificationUser = notification_Users[random.Next(0, notification_Users.Count())],
                        //Notification_UserId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectory_Notification_UserGroup_Link> notification_UserGroupsLoop = new List<DbStorage_SubDirectory_Notification_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, notification_UserGroups.Count()); j++)
                {
                    notification_UserGroupsLoop.Add(new DbStorage_SubDirectory_Notification_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        SubDirectory = null,
                        SubDirectoryId = null,

                        NotificationUserGroup = notification_UserGroups[random.Next(0, notification_UserGroups.Count())],
                        //Notification_UserGroupId = Guid.Empty,
                    });
                }

                DbStorage_SubDirectory_Quality quality;
                int qualityCount = random.Next(0, 3);
                if (qualityCount == 0)
                {
                    quality = new DbStorage_SubDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckPassed,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    };
                }
                else if (qualityCount == 1)
                {
                    quality = new DbStorage_SubDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckNotPassed,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    };
                }
                else if (qualityCount == 2)
                {
                    quality = new DbStorage_SubDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.Unchecked,

                        SubDirectory = null,
                        SubDirectoryId = null,

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

                DbStorage_SubDirectory element = new DbStorage_SubDirectory();

                if (i == 0)
                {
                    element = new DbStorage_SubDirectory()
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

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectories = null,

                        ParentSubDirectory = null,
                        ParentSubDirectoryId = null,

                        Files = null,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        QrCode = new DbStorage_SubDirectory_QrCode()
                        {
                            Id = Guid.NewGuid(),

                            Name = "QrCode " + i.ToString(),
                            Description = "QrCode " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                            QrCodeType = QrCodeType.Undefined,

                            SubDirectory = null,
                            SubDirectoryId = null,

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
                }
                else if (i > 0 && i < count)
                {
                    element = new DbStorage_SubDirectory()
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

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectories = null,

                        ParentSubDirectory = tmp.Last(),
                        //ParentSubDirectoryId = null,

                        Files = null,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        QrCode = new DbStorage_SubDirectory_QrCode()
                        {
                            Id = Guid.NewGuid(),

                            Name = "QrCode " + i.ToString(),
                            Description = "QrCode " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                            QrCodeType = QrCodeType.Undefined,

                            SubDirectory = null,
                            SubDirectoryId = null,

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
                }
                else if (i == count)
                {
                    element = new DbStorage_SubDirectory()
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

                        ParentSubDirectory = tmp.Last(),
                        //ParentSubDirectoryId = null,

                        Files = null,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        QrCode = new DbStorage_SubDirectory_QrCode()
                        {
                            Id = Guid.NewGuid(),

                            Name = "QrCode " + i.ToString(),
                            Description = "QrCode " + i.ToString() + " " + Common.RandomString(random.Next(10, 100)),

                            QrCodeType = QrCodeType.Undefined,

                            SubDirectory = null,
                            SubDirectoryId = null,

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
                }

                //_dbStorage_Data_Context.SubDirectories.Add(element);
                //_dbStorage_Data_Context.SaveChanges();

                tmp.Add(element);
            }

            return tmp;
        }
    }
}
