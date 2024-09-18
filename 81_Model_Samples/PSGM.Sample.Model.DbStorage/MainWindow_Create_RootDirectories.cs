using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_RootDirectory> Create_RootDirectories(int count, List<Authorization_User> users, List<Authorization_UserGroup> userGroups, List<Notification_User> notificationUsers, List<Notification_UserGroup> notificationUserGroups, List<DbStorage_RootDirectoryMetadata> directoryMetadata)
        {
            Random random = new Random();

            DbStorage_Quality dbStorage_Quality;

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

                        RootDirectory = null,
                        RootDirectoryId = null,

                        RootDirectoryMetadata = directoryMetadata[random.Next(0, directoryMetadata.Count())],
                        //RootDirectoryMetadataId = Guid.Empty,
                    });
                }

                int quality = random.Next(0, 3);
                if (quality == 0)
                {
                    dbStorage_Quality = new DbStorage_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckPassed,

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        File = null,
                        FileId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    };
                }
                else if (quality == 1)
                {
                    dbStorage_Quality = new DbStorage_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.CheckNotPassed,

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,

                        File = null,
                        FileId = null,

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                    };
                }
                else if (quality == 2)
                {
                    dbStorage_Quality = new DbStorage_Quality()
                    {
                        Id = Guid.NewGuid(),

                        Description = Common.RandomString(random.Next(10, 100)),

                        QualityState = QualityState.Unchecked,

                        RootDirectory = null,
                        RootDirectoryId = null,

                        SubDirectory = null,
                        SubDirectoryId = null,

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
                    dbStorage_Quality = null;
                }

                tmp.Add(new DbStorage_RootDirectory()
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

                    Quality = dbStorage_Quality,

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

                    SubDirectories = null,

                    Files = null,

                    DirectoryObjectsAutofill = 0,
                    DirectorySizeAutofill = 0,

                    QrCode = new DbStorage_QrCode()
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
