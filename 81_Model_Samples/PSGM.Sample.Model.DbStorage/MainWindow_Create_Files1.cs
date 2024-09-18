using PSGM.Helper;
using PSGM.Model.DbStorage;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbStorage_File> Create_Files1(int count, List<Authorization_User> users, List<Authorization_UserGroup> userGroups, List<Notification_User> notificationUsers, List<Notification_UserGroup> notificationUserGroups, List<DbStorage_SubDirectory> subDirectories, List<DbStorage_RootDirectory> rootDirectories, List<DbStorage_FileMetadata> dbStorage_FileMetadata)
        {
            Random random = new Random();

            DbStorage_Quality dbStorage_Quality;

            List<DbStorage_FileMetadataLink> dbStorage_FileMetadataLink;

            List<DbStorage_File> tmp = new List<DbStorage_File>();

            for (int i = 0; i < count; i++)
            {
                dbStorage_FileMetadataLink = new List<DbStorage_FileMetadataLink>();

                for (int j = 0; j < random.Next(0, dbStorage_FileMetadata.Count()); j++)
                {
                    dbStorage_FileMetadataLink.Add(new DbStorage_FileMetadataLink()
                    {
                        Id = Guid.NewGuid(),
                        
                        //File = null,
                        //FileId = Guid.Empty,

                        FileMetadata = dbStorage_FileMetadata[random.Next(0, dbStorage_FileMetadata.Count())],
                        //FileMetadataId = Guid.Empty,
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

                tmp.Add(new DbStorage_File()
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

                    Quality = dbStorage_Quality,

                    FileMetadataLinks = dbStorage_FileMetadataLink,

                    MachineIdExt = Guid.NewGuid(),
                    DeviceIdExt = Guid.NewGuid(),
                    SoftwareIdExt = Guid.NewGuid(),

                    ObjectExtension = FileExtension.JSON,

                    ObjectSize = 34235,

                    StorageObjectName = Common.RandomString(random.Next(10, 100)),
                    StorageObjectVersion = random.Next(0,100),
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

                    RootDirectory = null,
                    RootDirectoryId = null,

                    SubDirectory = subDirectories[random.Next(0, subDirectories.Count())],
                    SubDirectoryId = Guid.Empty,
                    
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
