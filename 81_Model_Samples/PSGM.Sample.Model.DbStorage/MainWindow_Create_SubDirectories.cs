using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_SubDirectory> Create_SubDirectories(int count, List<Authorization_User> users, List<Authorization_UserGroup> userGroups, List<Notification_User> notificationUsers, List<Notification_UserGroup> notificationUserGroups, List<DbStorage_RootDirectory> rootDirectories)
        {
            Random random = new Random();

            List<DbStorage_SubDirectory> tmp = new List<DbStorage_SubDirectory>();

            for (int i = 0; i < count; i++)
            {
                tmp.Add(new DbStorage_SubDirectory()
                {
                    Id = Guid.NewGuid(),

                    Suffix = i.ToString(),
                    Name = "SubDirectory " + i.ToString(),
                    Prefix = i.ToString(),

                    Description = "SubDirectory Description " + i.ToString(),

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

                    ParentSubDirectory = null,
                    //ParentSubDirectoryId = Guid.Empty,

                    RootDirectory = rootDirectories[random.Next(0, rootDirectories.Count())],
                    //RootDirectoryId = Guid.Empty,

                    //ObjectsAutofill = 0,
                    //DirectorySizeAutofill = 0,

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                    //LastModificationChangesAutoFill = string.Empty,
                });
            }

            return tmp;
        }
    }
}
