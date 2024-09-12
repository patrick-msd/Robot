using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_File> Create_Files2(int count, List<Authorization_User> users, List<Authorization_UserGroup> userGroups, List<Notification_User> notificationUsers, List<Notification_UserGroup> notificationUserGroups, List<DbStorage_SubDirectory> subDirectories, List<DbStorage_RootDirectory> rootDirectories)
        {
            Random random = new Random();

            List<DbStorage_File> tmp = new List<DbStorage_File>();

            for (int i = 0; i < count; i++)
            {
                tmp.Add(new DbStorage_File()
                {
                    Id = Guid.NewGuid(),

                    RawFileIds = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //RawFileIdsString = string.Empty,

                    Suffix = i.ToString(),
                    Name = "File " + i.ToString(),
                    Prefix = i.ToString(),

                    Description = "Description " + i.ToString(),

                    ObjectExtension = FileExtension.JSON,

                    ObjectSize = 34235,

                    StorageObjectName = string.Empty,
                    StorageObjectUrl = string.Empty,
                    StorageObjectUrlPublic = string.Empty,

                    AuthorizationUsersIdExt = users,
                    //AuthorizationUserIdsExtString = string.Empty,

                    AuthorizationUserGroupIdsExt = userGroups,
                    //AuthorizationUserGroupIdsExtString = string.Empty,

                    NotificationUserIdsExt = notificationUsers,
                    //NotificationUserIdsExtString = string.Empty,

                    NotificationUserGroupIdsExt = notificationUserGroups,
                    //NotificationUserGroupIdsExtString = string.Empty,

                    MachineIdExt = Guid.NewGuid(),
                    DeviceIdExt = Guid.NewGuid(),

                    JobIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //JobIdsExtString = string.Empty,

                    WorkflowItemIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //WorkflowItemIdsExtString = string.Empty,

                    BackupIdsExt = new List<Guid>() { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
                    //BackupIdsExtString = string.Empty,

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

                    //CreatedByUserIdExtAutoFill = Guid.Empty,
                    //CreatedDateTimeAutoFill = DateTime.Now,
                    //ModifiedByUserIdExtAutoFill = Guid.Empty,
                    //ModifiedDateTimeAutoFill = DateTime.Now,
                    //LastModificationChangesAutoFill = string.Empty,

                    //Metadata = new List<DbStorage_FileMetadata>()
                    //{
                    //    new DbStorage_FileMetadata()
                    //    {
                    //        Id = Guid.NewGuid(),

                    //        //Key = "Key " + i.ToString(),
                    //        //Value = "Value " + i.ToString(),
                    //    }
                    //},
                    //ObjectMetadataString = string.Empty,

                    QrCode = new DbStorage_QrCode()
                    {
                        Id = Guid.NewGuid(),

                        //QrCodeString = "QrCode " + i.ToString(),
                        //QrCodeImage = new byte[0],
                    },

                    //RootDirectory = Guid.Empty,
                    //RootDirectoryId = Guid.Empty,

                    SubDirectory = subDirectories.Last(),
                    //SubDirectoryId = Guid.Empty,
                });
            }

            return tmp;
        }
    }
}
