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

            #region Create Data User ...         
            List<DbStorage_RootDirectory_User> users = new List<DbStorage_RootDirectory_User>();
            for (int i = 0; i < 250; i++)
            {
                List<DbStorage_RootDirectory_User_Permission> userPermissions = new List<DbStorage_RootDirectory_User_Permission>();
                for (int j = 0; j < 250; j++)
                {
                    Array values = Enum.GetValues(typeof(PermissionType));

                    userPermissions.Add(new DbStorage_RootDirectory_User_Permission()
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

                List<DbStorage_RootDirectory_User_Notification> userNotifications = new List<DbStorage_RootDirectory_User_Notification>();
                for (int j = 0; j < 250; j++)
                {
                    userNotifications.Add(new DbStorage_RootDirectory_User_Notification()
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

                users.Add(new DbStorage_RootDirectory_User()
                {
                    Id = Guid.NewGuid(),

                    UserId_Ext = Guid.NewGuid(),

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

            #region Create Data UserGroup ...
            List<DbStorage_RootDirectory_UserGroup> userGroups = new List<DbStorage_RootDirectory_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                List<DbStorage_RootDirectory_UserGroup_Permission> userGroupPermissions = new List<DbStorage_RootDirectory_UserGroup_Permission>();
                for (int j = 0; j < 250; j++)
                {
                    Array values = Enum.GetValues(typeof(PermissionType));

                    userGroupPermissions.Add(new DbStorage_RootDirectory_UserGroup_Permission()
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

                List<DbStorage_RootDirectory_UserGroup_Notification> userGroupNotifications = new List<DbStorage_RootDirectory_UserGroup_Notification>();
                for (int j = 0; j < 250; j++)
                {
                    userGroupNotifications.Add(new DbStorage_RootDirectory_UserGroup_Notification()
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

                List<DbStorage_RootDirectory_UserGroup_User> userGroup_User = new List<DbStorage_RootDirectory_UserGroup_User>();
                for (int j = 0; j < 250; j++)
                {
                    userGroup_User.Add(new DbStorage_RootDirectory_UserGroup_User()
                    {
                        Id = Guid.NewGuid(),
                        
                        UserId_Ext = Guid.NewGuid(),

                        UserLinks = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    });
                }

                List<DbStorage_RootDirectory_UserGroup_User_Link> usersLoop = new List<DbStorage_RootDirectory_UserGroup_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    usersLoop.Add(new DbStorage_RootDirectory_UserGroup_User_Link()
                    {
                        Id = Guid.NewGuid(),
                        
                        // FK
                        User = userGroup_User[random.Next(0, userGroup_User.Count())],
                        //UserId = null,

                        UserGroup = null,
                        UserGroupId = null,
                    });
                }

                userGroups.Add(new DbStorage_RootDirectory_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    Permissions = userGroupPermissions[random.Next(0, userGroupPermissions.Count())],
                    Notifications = userGroupNotifications.GetRange(0, random.Next(0, userGroupNotifications.Count())),

                    UserLinks = usersLoop,
                    UserGroupLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            #region Create Metadata Key User ...
            List<DbStorage_MetadataKey_User> usersMetadataKey = new List<DbStorage_MetadataKey_User>();
            for (int i = 0; i < 250; i++)
            {
                List<DbStorage_MetadataKey_User_Permission> userPermissions = new List<DbStorage_MetadataKey_User_Permission>();
                for (int j = 0; j < 250; j++)
                {
                    Array values = Enum.GetValues(typeof(PermissionType));

                    userPermissions.Add(new DbStorage_MetadataKey_User_Permission()
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

                List<DbStorage_MetadataKey_User_Notification> userNotifications = new List<DbStorage_MetadataKey_User_Notification>();
                for (int j = 0; j < 250; j++)
                {
                    userNotifications.Add(new DbStorage_MetadataKey_User_Notification()
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

                usersMetadataKey.Add(new DbStorage_MetadataKey_User()
                {
                    Id = Guid.NewGuid(),

                    UserId_Ext = Guid.NewGuid(),

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

            #region Create Metadata Key UserGroup ...
            List<DbStorage_MetadataKey_UserGroup> userGroupsMetadataKey = new List<DbStorage_MetadataKey_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                List<DbStorage_MetadataKey_UserGroup_Permission> userGroupPermissions = new List<DbStorage_MetadataKey_UserGroup_Permission>();
                for (int j = 0; j < 250; j++)
                {
                    Array values = Enum.GetValues(typeof(PermissionType));

                    userGroupPermissions.Add(new DbStorage_MetadataKey_UserGroup_Permission()
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

                List<DbStorage_MetadataKey_UserGroup_Notification> userGroupNotifications = new List<DbStorage_MetadataKey_UserGroup_Notification>();
                for (int j = 0; j < 250; j++)
                {
                    userGroupNotifications.Add(new DbStorage_MetadataKey_UserGroup_Notification()
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

                List<DbStorage_MetadataKey_UserGroup_User> userGroup_User = new List<DbStorage_MetadataKey_UserGroup_User>();
                for (int j = 0; j < 250; j++)
                {
                    userGroup_User.Add(new DbStorage_MetadataKey_UserGroup_User()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = Guid.NewGuid(),

                        UserLinks = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    });
                }

                List<DbStorage_MetadataKey_UserGroup_User_Link> usersLoop = new List<DbStorage_MetadataKey_UserGroup_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    usersLoop.Add(new DbStorage_MetadataKey_UserGroup_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        User = userGroup_User[random.Next(0, userGroup_User.Count())],
                        //UserId = null,

                        UserGroup = null,
                        UserGroupId = null,
                    });
                }

                userGroupsMetadataKey.Add(new DbStorage_MetadataKey_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    Permissions = userGroupPermissions[random.Next(0, userGroupPermissions.Count())],
                    Notifications = userGroupNotifications.GetRange(0, random.Next(0, userGroupNotifications.Count())),

                    UserLinks = usersLoop,
                    UserGroupLinks = null,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            #region Create Metadata Key ...
            List<DbStorage_MetadataKey> metadataKey = new List<DbStorage_MetadataKey>();
            for (int i = 0; i < 250; i++)
            {
                List<DbStorage_MetadataKey_User_Link> usersLoop = new List<DbStorage_MetadataKey_User_Link>();
                for (int j = 0; j < random.Next(0, usersMetadataKey.Count()); j++)
                {
                    usersLoop.Add(new DbStorage_MetadataKey_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        User = usersMetadataKey[random.Next(0, usersMetadataKey.Count())],
                        //UserId = null,

                        MetadataKey = null,
                        MetadataKeyId = null,
                    });
                }

                List<DbStorage_MetadataKey_UserGroup_Link> userGroupsLoop = new List<DbStorage_MetadataKey_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, userGroupsMetadataKey.Count()); j++)
                {
                    userGroupsLoop.Add(new DbStorage_MetadataKey_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        UserGroup = userGroupsMetadataKey[random.Next(0, userGroupsMetadataKey.Count())],
                        //GroupId = null,

                        MetadataKey = null,
                        MetadataKeyId = null,
                    });
                }

                metadataKey.Add(new DbStorage_MetadataKey()
                {
                    Id = Guid.NewGuid(),

                    Name = Common.RandomString(random.Next(5, 50)),
                    Description = Common.RandomString(random.Next(10, 200)),

                    RootDirectoryMetadata = null,
                    SubDirectoryMetadata = null,
                    FileMetadata = null,

                    UserLinks = usersLoop,
                    UserGroupLinks = userGroupsLoop,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }
            #endregion

            #region Metadata ...
            List<DbStorage_RootDirectory_Metadata> rootDirectoryMetadata = new List<DbStorage_RootDirectory_Metadata>();
            for (int i = 1; i <= 50; i++)
            {
                Array values1 = Enum.GetValues(typeof(MetadataSource));
                Array values2 = Enum.GetValues(typeof(EmployeeType));

                rootDirectoryMetadata.Add(new DbStorage_RootDirectory_Metadata()
                {
                    Id = Guid.NewGuid(),

                    //Key = Common.RandomString(random.Next(5, 50)),
                    Value = Common.RandomString(random.Next(10, 100)),

                    Description = Common.RandomString(random.Next(10, 200)),

                    MetadataSource = (MetadataSource)values1.GetValue(random.Next(values1.Length)),
                    MetadataPermissions = (MetadataPermissions)values2.GetValue(random.Next(values2.Length)),

                    ApplicableForFiles = random.Next(100) <= 50 ? true : false,

                    MetadataLinks = null,

                    Stars = random.Next(0, 5),

                    Order = random.Next(0, 10000),

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,

                    // FK
                    Key = metadataKey[random.Next(0, metadataKey.Count())],
                    KeyId = null,
                });
            }
            #endregion

            #region Create Virtual Unit User ...         
            List<DbStorage_RootDirectory_VirtualUnit_User> usersVirtualUnit = new List<DbStorage_RootDirectory_VirtualUnit_User>();
            for (int i = 0; i < 250; i++)
            {
                List<DbStorage_RootDirectory_VirtualUnit_User_Permission> userPermissions = new List<DbStorage_RootDirectory_VirtualUnit_User_Permission>();
                for (int j = 0; j < 250; j++)
                {
                    Array values = Enum.GetValues(typeof(PermissionType));

                    userPermissions.Add(new DbStorage_RootDirectory_VirtualUnit_User_Permission()
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

                List<DbStorage_RootDirectory_VirtualUnit_User_Notification> userNotifications = new List<DbStorage_RootDirectory_VirtualUnit_User_Notification>();
                for (int j = 0; j < 250; j++)
                {
                    userNotifications.Add(new DbStorage_RootDirectory_VirtualUnit_User_Notification()
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

                usersVirtualUnit.Add(new DbStorage_RootDirectory_VirtualUnit_User()
                {
                    Id = Guid.NewGuid(),

                    UserId_Ext = Guid.NewGuid(),

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

            #region Create Virtual Unit UserGroup ...
            List<DbStorage_RootDirectory_VirtualUnit_UserGroup> userGroupsVirtualUnit = new List<DbStorage_RootDirectory_VirtualUnit_UserGroup>();
            for (int i = 0; i < 250; i++)
            {
                List<DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission> userGroupPermissions = new List<DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission>();
                for (int j = 0; j < 250; j++)
                {
                    Array values = Enum.GetValues(typeof(PermissionType));

                    userGroupPermissions.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission()
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

                List<DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification> userGroupNotifications = new List<DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification>();
                for (int j = 0; j < 250; j++)
                {
                    userGroupNotifications.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification()
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

                List<DbStorage_RootDirectory_VirtualUnit_UserGroup_User> userGroup_User = new List<DbStorage_RootDirectory_VirtualUnit_UserGroup_User>();
                for (int j = 0; j < 250; j++)
                {
                    userGroup_User.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_User()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = Guid.NewGuid(),

                        UserLinks = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    });
                }

                List<DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link> usersLoop = new List<DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    usersLoop.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        User = userGroup_User[random.Next(0, userGroup_User.Count())],
                        //UserId = null,

                        UserGroup = null,
                        UserGroupId = null,
                    });
                }

                userGroupsVirtualUnit.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup()
                {
                    Id = Guid.NewGuid(),

                    Permissions = userGroupPermissions[random.Next(0, userGroupPermissions.Count())],
                    Notifications = userGroupNotifications.GetRange(0, random.Next(0, userGroupNotifications.Count())),

                    UserLinks = usersLoop,
                    UserGroupLinks = null,

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

                List<DbStorage_RootDirectory_User_Link> usersLoop = new List<DbStorage_RootDirectory_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    usersLoop.Add(new DbStorage_RootDirectory_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        User = users[random.Next(0, users.Count())],
                        //UserId = null,

                        RootDirectory = null,
                        RootDirectoryId = null,
                    });
                }

                List<DbStorage_RootDirectory_UserGroup_Link> userGroupsLoop = new List<DbStorage_RootDirectory_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, userGroups.Count()); j++)
                {
                    userGroupsLoop.Add(new DbStorage_RootDirectory_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        UserGroup = userGroups[random.Next(0, userGroups.Count())],
                        //GroupId = null,

                        RootDirectory = null,
                        RootDirectoryId = null,
                    });
                }

                List<DbStorage_RootDirectory_VirtualUnit_User_Link> virtualUnitUsersLoop = new List<DbStorage_RootDirectory_VirtualUnit_User_Link>();
                for (int j = 0; j < random.Next(0, users.Count()); j++)
                {
                    virtualUnitUsersLoop.Add(new DbStorage_RootDirectory_VirtualUnit_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        VirtualUnit = null,

                        FileId = null,

                        // FK
                        User = usersVirtualUnit[random.Next(0, usersVirtualUnit.Count())],
                        //UserId = null,
                    });
                }

                List<DbStorage_RootDirectory_VirtualUnit_UserGroup_Link> virtualUnitUserGroupsLoop = new List<DbStorage_RootDirectory_VirtualUnit_UserGroup_Link>();
                for (int j = 0; j < random.Next(0, userGroups.Count()); j++)
                {
                    virtualUnitUserGroupsLoop.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_Link()
                    {
                        Id = Guid.NewGuid(),
   
                        // FK
                        VirtualUnit = null,
                        VirtualUnitId = null,   
                      
                        UserGroup = userGroupsVirtualUnit[random.Next(0, userGroupsVirtualUnit.Count())],
                        //UserGroup = null,
                    });
                }

                List<DbStorage_RootDirectory_VirtualUnit> virtualRootUnits = new List<DbStorage_RootDirectory_VirtualUnit>();
                for (int j = 0; j < random.Next(25, 250); j++)
                {
                    virtualRootUnits.Add(new DbStorage_RootDirectory_VirtualUnit()
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
                        RootDirectory = null,
                        RootDirectoryId = null,
                    });
                }

                Array values = Enum.GetValues(typeof(QualityState));
                QualityState qualityStateType = (QualityState)values.GetValue(random.Next(values.Length));

                #region Random quality ...
                DbStorage_RootDirectory_Quality? quality;
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
                #endregion

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

                    Locked = false,

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

                    VirtualUnits = virtualRootUnits,

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
