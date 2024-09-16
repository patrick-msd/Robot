using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_RootDirectory> Create_RootDirectories(int count, List<Authorization_User> users, List<Authorization_UserGroup> userGroups, List<Notification_User> notificationUsers, List<Notification_UserGroup> notificationUserGroups, List<DbStorage_RootDirectoryMetadata> directoryMetadata)
        {
            Random random = new Random();

            List<DbStorage_RootDirectoryMetadataLink> dbStorage_RootDirectoryMetadataLink;

            List<DbStorage_RootDirectory> tmp = new List<DbStorage_RootDirectory>();

            for (int i = 0; i < count; i++)
            {
                dbStorage_RootDirectoryMetadataLink = new List<DbStorage_RootDirectoryMetadataLink>();

                for (int j = 0; j < random.Next(0, directoryMetadata.Count()); j++)
                {
                    dbStorage_RootDirectoryMetadataLink.Add(new DbStorage_RootDirectoryMetadataLink()
                    {
                        Id = Guid.NewGuid(),

                        //RootDirectory = null,
                        //RootDirectoryId = Guid.Empty,
                        
                        RootDirectoryMetadata = directoryMetadata[random.Next(0, directoryMetadata.Count())],
                        //RootDirectoryMetadataId = Guid.Empty,
                    });
                }

                tmp.Add(new DbStorage_RootDirectory()
                {
                    Id = Guid.NewGuid(),

                    Suffix = i.ToString(),
                    Name = "RootDirectory " + i.ToString(),
                    Prefix = i.ToString(),

                    Description = "RootDirectory Description " + i.ToString(),

                    RootDirectoryMetadataLinks = dbStorage_RootDirectoryMetadataLink,
                    
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

                    DirectoryObjectsAutofill = 0,
                    DirectorySizeAutofill = 0,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                });
            }

            return tmp;
        }
    }
}
