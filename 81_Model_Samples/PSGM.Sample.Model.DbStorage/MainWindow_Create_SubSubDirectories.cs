using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_SubDirectory> Create_SubSubDirectories(int count, List<Authorization_User> users, List<Authorization_UserGroup> userGroups, List<Notification_User> notificationUsers, List<Notification_UserGroup> notificationUserGroups, List<DbStorage_RootDirectory> rootDirectories, List<DbStorage_SubDirectoryMetadata> directoryMetadata)
        {
            Random random = new Random();

            List<DbStorage_SubDirectoryMetadataLink> dbStorage_SubDirectoryMetadataLink;

            List<DbStorage_SubDirectory> tmp = new List<DbStorage_SubDirectory>();

            for (int i = 0; i <= count; i++)
            {
                dbStorage_SubDirectoryMetadataLink = new List<DbStorage_SubDirectoryMetadataLink>();

                for (int j = 0; j < random.Next(0, directoryMetadata.Count()); j++)
                {
                    dbStorage_SubDirectoryMetadataLink.Add(new DbStorage_SubDirectoryMetadataLink()
                    {
                        Id = Guid.NewGuid(),

                        //SubDirectory = null,
                        //SubDirectoryId = Guid.Empty,

                        SubDirectoryMetadata = directoryMetadata[random.Next(0, directoryMetadata.Count())],
                        //SubDirectoryMetadataId = Guid.Empty,
                    });
                }

                if (i == 0)
                {
                    tmp.Add(new DbStorage_SubDirectory()
                    {
                        Id = Guid.NewGuid(),

                        Suffix = i.ToString(),
                        Name = "SubSubDirectory " + i.ToString(),
                        Prefix = i.ToString(),

                        Description = "SubSubDirectory Description " + i.ToString(),

                        SubDirectoryMetadataLinks = dbStorage_SubDirectoryMetadataLink,

                        DirectoryLocked = false,

                        AuthorizationUsersIdExt = users,
                        //AuthorizationUserIdsExtString = string.Empty,

                        AuthorizationUserGroupIdsExt = userGroups,
                        //AuthorizationUserGroupIdsExtString = string.Empty,

                        NotificationUserIdsExt = notificationUsers,
                        //NotificationUserIdsExtString = string.Empty,

                        NotificationUserGroupIdsExt = notificationUserGroups,
                        //NotificationUserGroupIdsExtString = string.Empty,

                        JobIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //JobIdsExtString = string.Empty,

                        WorkflowItemIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //WorkflowItemIdsExtString = string.Empty,

                        BackupIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //BackupIdsExtString = string.Empty,

                        Files = null,
                        SubDirectories = null,

                        //ParentSubDirectory = null,
                        //ParentSubDirectoryId = Guid.Empty,

                        RootDirectory = rootDirectories[random.Next(0, rootDirectories.Count())],
                        //RootDirectoryId = Guid.Empty,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    });
                }
                else if (i > 0 && i < count)
                {
                    tmp.Add(new DbStorage_SubDirectory()
                    {
                        Id = Guid.NewGuid(),

                        Suffix = i.ToString(),
                        Name = "RootDirectory " + i.ToString(),
                        Prefix = i.ToString(),

                        Description = "Description " + i.ToString(),

                        SubDirectoryMetadataLinks = dbStorage_SubDirectoryMetadataLink,

                        DirectoryLocked = false,

                        AuthorizationUsersIdExt = users,
                        //AuthorizationUserIdsExtString = string.Empty,

                        AuthorizationUserGroupIdsExt = userGroups,
                        //AuthorizationUserGroupIdsExtString = string.Empty,

                        NotificationUserIdsExt = notificationUsers,
                        //NotificationUserIdsExtString = string.Empty,

                        NotificationUserGroupIdsExt = notificationUserGroups,
                        //NotificationUserGroupIdsExtString = string.Empty,

                        JobIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //JobIdsExtString = string.Empty,

                        WorkflowItemIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //WorkflowItemIdsExtString = string.Empty,

                        BackupIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                        //BackupIdsExtString = string.Empty,

                        Files = null,
                        SubDirectories = null,

                        ParentSubDirectory = tmp.Last(),
                        //ParentSubDirectoryId = Guid.Empty,

                        //RootDirectory = null,
                        //RootDirectoryId = Guid.Empty,

                        DirectoryObjectsAutofill = 0,
                        DirectorySizeAutofill = 0,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    });
                }
            }

            return tmp;
        }
    }
}
