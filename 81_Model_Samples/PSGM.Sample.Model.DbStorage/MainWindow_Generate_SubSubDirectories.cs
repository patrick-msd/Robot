using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_SubDirectory> Generate_SubSubDirectories(int count, List<DbStorage_RootDirectory> rootDirectories)
        {
            Random random = new Random();

            List<DbStorage_SubDirectory> tmp = new List<DbStorage_SubDirectory>();

            #region Create Data User ...
            List<DbStorage_SubDirectory_User_Permission> userPermissions = new List<DbStorage_SubDirectory_User_Permission>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));

                userPermissions.Add(new DbStorage_SubDirectory_User_Permission()
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

            List<DbStorage_SubDirectory_User_Notification> userNotifications = new List<DbStorage_SubDirectory_User_Notification>();
            for (int i = 0; i < 250; i++)
            {
                userNotifications.Add(new DbStorage_SubDirectory_User_Notification()
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

            List<DbStorage_SubDirectory_User> users = new List<DbStorage_SubDirectory_User>();
            for (int i = 0; i < 250; i++)
            {
                users.Add(new DbStorage_SubDirectory_User()
                {
                    Id = Guid.NewGuid(),

                    UserId_Ext = Guid.NewGuid(),

                    Acronym = Common.RandomString(random.Next(1, 32)),

                    EMail = Common.RandomString(random.Next(3, 511)),

                    DaytimePhoneNumber = Common.RandomString(random.Next(3, 100)),
                    EveningPhoneNumber = Common.RandomString(random.Next(3, 100)),

                    Permissions = userPermissions[random.Next(0, userPermissions.Count())],
                    Notifications = userNotifications.GetRange(0, random.Next(0, userNotifications.Count())),

                    UserLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            #region Create Data VirtualUnit User ...
            List<DbStorage_SubDirectory_VirtualUnit_User_Permission> virtualUnitUserPermissions = new List<DbStorage_SubDirectory_VirtualUnit_User_Permission>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));

                virtualUnitUserPermissions.Add(new DbStorage_SubDirectory_VirtualUnit_User_Permission()
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

            List<DbStorage_SubDirectory_VirtualUnit_User_Notification> virtualUnitUserNotifications = new List<DbStorage_SubDirectory_VirtualUnit_User_Notification>();
            for (int i = 0; i < 250; i++)
            {
                virtualUnitUserNotifications.Add(new DbStorage_SubDirectory_VirtualUnit_User_Notification()
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

            List<DbStorage_SubDirectory_VirtualUnit_User> virtualUnitUsers = new List<DbStorage_SubDirectory_VirtualUnit_User>();
            for (int i = 0; i < 250; i++)
            {
                virtualUnitUsers.Add(new DbStorage_SubDirectory_VirtualUnit_User()
                {
                    Id = Guid.NewGuid(),

                    UserId_Ext = Guid.NewGuid(),

                    Acronym = Common.RandomString(random.Next(1, 32)),

                    EMail = Common.RandomString(random.Next(3, 511)),

                    DaytimePhoneNumber = Common.RandomString(random.Next(3, 100)),
                    EveningPhoneNumber = Common.RandomString(random.Next(3, 100)),

                    Permissions = virtualUnitUserPermissions[random.Next(0, virtualUnitUserPermissions.Count())],
                    Notifications = virtualUnitUserNotifications.GetRange(0, random.Next(0, virtualUnitUserNotifications.Count())),

                    UserLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            #region Create Data UserGroup ...
            List<DbStorage_SubDirectory_UserGroup_Permission> userGroupPermissions = new List<DbStorage_SubDirectory_UserGroup_Permission>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));

                userGroupPermissions.Add(new DbStorage_SubDirectory_UserGroup_Permission()
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

            List<DbStorage_SubDirectory_UserGroup_Notification> userGroupNotifications = new List<DbStorage_SubDirectory_UserGroup_Notification>();
            for (int i = 0; i < 250; i++)
            {
                userGroupNotifications.Add(new DbStorage_SubDirectory_UserGroup_Notification()
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

            List<DbStorage_SubDirectory_UserGroup> userGroups = new List<DbStorage_SubDirectory_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                userGroups.Add(new DbStorage_SubDirectory_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    Permissions = userGroupPermissions[random.Next(0, userGroupPermissions.Count())],
                    Notifications = userGroupNotifications.GetRange(0, random.Next(0, userGroupNotifications.Count())),

                    UserGroupLinks = null,
                    UserLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            #region Create Data VirtualUnit UserGroup ...
            List<DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission> virtualUnitUserGroupPermissions = new List<DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission>();
            for (int i = 0; i < 250; i++)
            {
                Array values = Enum.GetValues(typeof(PermissionType));

                virtualUnitUserGroupPermissions.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission()
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

            List<DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification> virtualUnitUserGroupNotifications = new List<DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification>();
            for (int i = 0; i < 250; i++)
            {
                virtualUnitUserGroupNotifications.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification()
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

            List<DbStorage_SubDirectory_VirtualUnit_UserGroup> virtualUnitUserGroups = new List<DbStorage_SubDirectory_VirtualUnit_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                virtualUnitUserGroups.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    Permissions = virtualUnitUserGroupPermissions[random.Next(0, virtualUnitUserGroupPermissions.Count())],
                    Notifications = virtualUnitUserGroupNotifications.GetRange(0, random.Next(0, virtualUnitUserGroupNotifications.Count())),

                    UserGroupLinks = null,
                    UserLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            List<DbStorage_SubDirectory_Metadata> subDirectoryMetadata = new List<DbStorage_SubDirectory_Metadata>();
            for (int i = 1; i <= 50; i++)
            {
                Array values1 = Enum.GetValues(typeof(MetadataType));
                Array values2 = Enum.GetValues(typeof(EmployeeType));

                subDirectoryMetadata.Add(new DbStorage_SubDirectory_Metadata()
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
                List<DbStorage_SubDirectory_Metadata_Link> subDirectoryMetadataLinkLoop = new List<DbStorage_SubDirectory_Metadata_Link>();
                for (int j = 0; j < random.Next(0, subDirectoryMetadata.Count()); j++)
                {
                    subDirectoryMetadataLinkLoop.Add(new DbStorage_SubDirectory_Metadata_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        SubDirectory = null,
                        SubDirectoryId = null,

                        Metadata = subDirectoryMetadata[random.Next(0, subDirectoryMetadata.Count())],
                        //MetadataId = Guid.Empty,
                    });
                }

                List<DbStorage_SubDirectory_User_Link> usersLoop = new List<DbStorage_SubDirectory_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    usersLoop.Add(new DbStorage_SubDirectory_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        User = users[random.Next(0, users.Count())],
                        //UserId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,
                    });
                }

                List<DbStorage_SubDirectory_UserGroup_Link> userGroupsLoop = new List<DbStorage_SubDirectory_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, userGroups.Count()); j++)
                {
                    userGroupsLoop.Add(new DbStorage_SubDirectory_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        UserGroup = userGroups[random.Next(0, userGroups.Count())],
                        //GroupId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,
                    });
                }



                List<DbStorage_SubDirectory_VirtualUnit_User_Link> virtualUnitUsersLoop = new List<DbStorage_SubDirectory_VirtualUnit_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    virtualUnitUsersLoop.Add(new DbStorage_SubDirectory_VirtualUnit_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        VirtualUnit = null,

                        FileId = null,

                        // FK
                        User = virtualUnitUsers[random.Next(0, virtualUnitUsers.Count())],
                        //UserId = null,
                    });
                }

                List<DbStorage_SubDirectory_VirtualUnit_UserGroup_Link> virtualUnitUserGroupsLoop = new List<DbStorage_SubDirectory_VirtualUnit_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, userGroups.Count()); j++)
                {
                    virtualUnitUserGroupsLoop.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        VirtualUnit = null,

                        FileId = null,

                        // FK
                        UserGroup = virtualUnitUserGroups[random.Next(0, virtualUnitUserGroups.Count())],
                        //GroupId = null,
                    });
                }



                List<DbStorage_SubDirectory_VirtualUnit> virtualSubUnits = new List<DbStorage_SubDirectory_VirtualUnit>();
                for (int j = 0; j < random.Next(25, 250); j++)
                {
                    virtualSubUnits.Add(new DbStorage_SubDirectory_VirtualUnit()
                    {
                        Id = Guid.NewGuid(),

                        VirtualUnitId_Ext = Guid.NewGuid(),

                        UserLinks = virtualUnitUsersLoop,
                        UserGroupLinks = virtualUnitUserGroupsLoop,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        SubDirectory = null,
                        SubDirectoryId = null,
                    });
                }

                Array values = Enum.GetValues(typeof(QualityState));
                QualityState qualityStateType = (QualityState)values.GetValue(random.Next(values.Length));

                #region Random quality ...
                DbStorage_SubDirectory_Quality? quality;
                int qualityCount = random.Next(0, 3);
                if (qualityCount == 0)
                {
                    quality = new DbStorage_SubDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        SubDirectory = null,
                        SubDirectoryId = null,
                    };
                }
                else if (qualityCount == 1)
                {
                    quality = new DbStorage_SubDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        SubDirectory = null,
                        SubDirectoryId = null,
                    };
                }
                else if (qualityCount == 2)
                {
                    quality = new DbStorage_SubDirectory_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = qualityStateType,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        SubDirectory = null,
                        SubDirectoryId = null,
                    };
                }
                else
                {
                    quality = null;
                }
                #endregion

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

                        UserLinks = usersLoop,
                        UserGroupLinks = userGroupsLoop,

                        JobIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //JobIds_ExtString = string.Empty,

                        WorkflowItemIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //WorkflowItemIds_ExtString = string.Empty,

                        ArchiveIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //ArchiveIds_ExtString = string.Empty,

                        SubDirectories = null,

                        Files = null,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        QrCode = new DbStorage_SubDirectory_QrCode()
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
                            SubDirectory = null,
                            SubDirectoryId = null,
                        },

                        VirtualUnits = virtualSubUnits,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,

                        ParentSubDirectory = null,
                        ParentSubDirectoryId = null
                    };
                }
                else if (i > 1 && i < count)
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

                        UserLinks = usersLoop,
                        UserGroupLinks = userGroupsLoop,

                        JobIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //JobIds_ExtString = string.Empty,

                        WorkflowItemIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //WorkflowItemIds_ExtString = string.Empty,

                        ArchiveIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //ArchiveIds_ExtString = string.Empty,

                        SubDirectories = null,

                        Files = null,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        QrCode = new DbStorage_SubDirectory_QrCode()
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
                            SubDirectory = null,
                            SubDirectoryId = null,
                        },

                        VirtualUnits = virtualSubUnits,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        RootDirectory = null,
                        RootDirectoryId = null,

                        ParentSubDirectory = tmp.Last(),
                        //ParentSubDirectoryId = null,
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

                        UserLinks = usersLoop,
                        UserGroupLinks = userGroupsLoop,

                        JobIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //JobIds_ExtString = string.Empty,

                        WorkflowItemIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //WorkflowItemIds_ExtString = string.Empty,

                        ArchiveIds_Ext = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //ArchiveIds_ExtString = string.Empty,

                        SubDirectories = null,

                        Files = null,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        QrCode = new DbStorage_SubDirectory_QrCode()
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
                            SubDirectory = null,
                            SubDirectoryId = null,
                        },

                        VirtualUnits = virtualSubUnits,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        RootDirectory = rootDirectories[random.Next(0, rootDirectories.Count())],
                        //RootDirectoryId = null,

                        ParentSubDirectory = tmp.Last(),
                        //ParentSubDirectoryId = null,
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
