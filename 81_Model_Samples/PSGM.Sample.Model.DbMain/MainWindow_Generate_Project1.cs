using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Project> Generate_Project1(List<DbMain_Location> locations)
        {
            Random random = new Random();

            Array values1 = Enum.GetValues(typeof(NotificationType));

            // Root Directory (Bucket) --> ProjectId\\DirectoryIds{1...n}\\FileId ...
            DbMain_Project project = new DbMain_Project()
            {
                Id = Guid.NewGuid(),

                Name = "Meldezettel",
                Description = "Digitalisierung der Meldezettel von ...",

                Organization = dbMain_organizationTLA,
                Contributors = new List<DbMain_Contributors>()
                {
                    new  DbMain_Contributors()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Scanning",
                        Description = "",

                        ContributorType = ContributorType.ServiceProviderScanning,

                        Organization = dbMain_organizationUIBK,

                        // FK
                        //Project=null,
                    }
                },

                Status = ProjectStatus.Created,
                Started = DateTime.Now,
                Finished = DateTime.MinValue,

                WorkflowIdExt = _dbWorkflow_Context.Workflows.FirstOrDefault().Id,
                WorkflowApplyLevel = WorkflowApplyLevel.File,

                Order = null,

                AuthorizationUser = new List<DbMain_Project_Authorization_User>()
                {
                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),
                        UserIdExt = _gertraudZeindlId,
                        Permissions = PermissionType.Owner,

                        Description = string.Empty,

                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    },
                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _christophHaidacherId,
                        Permissions = PermissionType.Admin,

                        Description = string.Empty,

                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    },
                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _patrickSchoeneggerId,
                        Permissions = PermissionType.ServiceProviderInfrastructure,

                        Description = string.Empty,
                        
                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    },
                    new DbMain_Project_Authorization_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _guenterMuehlbergerId,
                        Permissions = PermissionType.ServiceProviderInfrastructure,

                        Description = string.Empty,

                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    }
                },
                AuthorizationUserGroup = null,

                NotificationUser = new List<DbMain_Project_Notification_User>()
                {
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _gertraudZeindlId,

                        Description = string.Empty,

                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        }, 
                        //NotificationString = string.Empty,
                        
                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    },
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _christophHaidacherId,

                        Description = string.Empty,

                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        },
                        //NotificationString = string.Empty,
                        
                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    },
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _patrickSchoeneggerId,

                        Description = string.Empty,

                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.All, EMail = true, Slack = true, Teams = true, SMS = true, WhatsApp = true, Telegram = true, Gotify = true },
                        },    
                        //NotificationString = string.Empty,
                        
                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    },
                    new DbMain_Project_Notification_User()
                    {
                        Id = Guid.NewGuid(),

                        UserIdExt = _guenterMuehlbergerId,

                        Description = string.Empty,

                        Notifications = new List<Notification>
                        {
                            new Notification() { NotificationType = NotificationType.All, EMail = true, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
                        },    
                        //NotificationString = string.Empty,

                        // FK
                        //Project = null,
                        //ProjectId = Guid.Empty
                    },
                },
                NotificationUserGroup = null,

                MachinesExt = new List<Guid>()
                {
                    _machineId
                },
                //MachinesExtString = string.Empty,   

                // FK                
            };

            List<DbMain_Project> tmp = new List<DbMain_Project>()
            {
                project
            };

            return tmp;
        }
    }
}
