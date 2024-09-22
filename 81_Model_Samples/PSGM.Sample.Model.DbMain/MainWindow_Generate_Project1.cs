using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Project> Generate_Project1(List<DbMain_Location> locations, List<DbMain_Organization> organizations)
        {
            Random random = new Random();

            Array values1 = Enum.GetValues(typeof(NotificationType));

            // Root Directory (Bucket) --> ProjectId\\DirectoryIds{1...n}\\FileId ...
            DbMain_Project project = new DbMain_Project()
            {
                Id = Guid.NewGuid(),

                Name = "Meldezettel",
                Description = "Digitalisierung der Meldezettel von ...",

                Organization = organizations.Where(p => p.Acronym.Contains("TLA")).First(),
                Contributors = new List<DbMain_Contributors>()
                {
                    new  DbMain_Contributors()
                    {
                        Id = Guid.NewGuid(),

                        Name = "Scanning",
                        Description = "",

                        ContributorType = ContributorType.ServiceProviderScanning,

                        Organization = organizations.Where(p => p.Acronym.Contains("UIBK")).First(),

                        // FK
                        //Project=null,
                    }
                },

                LocationLinks = new List<DbMain_Project_Location_Link>()
                {
                    new DbMain_Project_Location_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        Location =  locations.Where(p => p.AddressLink.Address.Line1.Contains("Innrain 52d")).First(),
                        //LocationId = null,

                        Project = null,
                        ProjectId = null
                    },

                    new DbMain_Project_Location_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        Location = locations.Where(p => p.AddressLink.Address.Line1.Contains("Michael-Gaismair-Straße 1")).First(),
                        //LocationId = null,

                        Project = null,
                        ProjectId = null
                    }
                },

                Status = ProjectStatus.Created,
                Started = DateTime.MinValue,
                Finished = DateTime.MinValue,

                MaxDirectorySize = 125000000,

                AqlQuantityImage = AqlQuantity.PerNaturalUnit,
                AqlInspectionLevelImage = AqlInspectionLevel.I,
                AqlAcceptableQualityLevelImage = AcceptableQualityLevel.ZeroPointZeroSixtyFive,
                AqlStateImage = AqlState.None,
                AqlStateLastChangeImage = DateTime.MinValue,

                AqlQuantityTranscription = AqlQuantity.PerNaturalUnit,
                AqlInspectionLevelTranscription = AqlInspectionLevel.I,
                AqlAcceptableQualityLevelTranscription = AcceptableQualityLevel.ZeroPointZeroSixtyFive,
                AqlStateTranscription = AqlState.None,
                AqlStateLastChangeTranscription = DateTime.MinValue,

                //WorkflowIdExt = _dbWorkflow_Context.Workflows.FirstOrDefault().Id,
                WorkflowApplyLevel = WorkflowApplyLevel.File,

                MachinesExt = new List<Guid>()
                {
                    _machineId
                },
                //MachinesExtString = string.Empty,

                DeliverySlip = null,

                AuthorizationUserLinks = new List<DbMain_Project_Authorization_User_Link>()
                {
                    new DbMain_Project_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        AuthorizationUser = new DbMain_Project_Authorization_User ()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _patrickSchoeneggerId,
                            Permissions = PermissionType.Owner,

                            Description = string.Empty,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //AuthorizationUserId = null,
                        
                        Project = null,
                        ProjectId = null
                    },
                    new DbMain_Project_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        AuthorizationUser = new DbMain_Project_Authorization_User ()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _guenterMuehlbergerId,
                            Permissions = PermissionType.Owner,

                            Description = string.Empty,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //AuthorizationUserId = null,

                        Project = null,
                        ProjectId = null
                    },
                    new DbMain_Project_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        AuthorizationUser = new DbMain_Project_Authorization_User ()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _gertraudZeindlId,
                            Permissions = PermissionType.Owner,

                            Description = string.Empty,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //AuthorizationUserId = null,

                        Project = null,
                        ProjectId = null
                    },
                    new DbMain_Project_Authorization_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        // FK
                        AuthorizationUser = new DbMain_Project_Authorization_User ()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _christophHaidacherId,
                            Permissions = PermissionType.Owner,

                            Description = string.Empty,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //AuthorizationUserId = null,

                        Project = null,
                        ProjectId = null
                    }
                },
                AuthorizationUserGroupLinks = null,

                NotificationUserLinks = new List<DbMain_Project_Notification_User_Link>()
                {
                    new DbMain_Project_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Project_Notification_User()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _patrickSchoeneggerId,

                            Description = string.Empty,

                            NotificationType = (NotificationType)values1.GetValue(random.Next(values1.Length)),

                            EMail = random.Next(100) <= 50 ? true : false,
                            Slack = random.Next(100) <= 50 ? true : false,
                            Teams = random.Next(100) <= 50 ? true : false,
                            SMS = random.Next(100) <= 50 ? true : false,
                            WhatsApp = random.Next(100) <= 50 ? true : false,
                            Telegram = random.Next(100) <= 50 ? true : false,
                            Gotify = random.Next(100) <= 50 ? true : false,

                            NotificationUserLinks = null,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //NotificationUserId = null,
                        
                        // FK
                        
                        Project = null,
                        ProjectId = null,
                    },
                    new DbMain_Project_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Project_Notification_User()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _patrickSchoeneggerId,

                            Description = string.Empty,

                            NotificationType = (NotificationType)values1.GetValue(random.Next(values1.Length)),

                            EMail = random.Next(100) <= 50 ? true : false,
                            Slack = random.Next(100) <= 50 ? true : false,
                            Teams = random.Next(100) <= 50 ? true : false,
                            SMS = random.Next(100) <= 50 ? true : false,
                            WhatsApp = random.Next(100) <= 50 ? true : false,
                            Telegram = random.Next(100) <= 50 ? true : false,
                            Gotify = random.Next(100) <= 50 ? true : false,

                            NotificationUserLinks = null,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //NotificationUserId = null,
                        
                        // FK
                        
                        Project = null,
                        ProjectId = null,
                    },
                    new DbMain_Project_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Project_Notification_User()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _patrickSchoeneggerId,

                            Description = string.Empty,

                            NotificationType = (NotificationType)values1.GetValue(random.Next(values1.Length)),

                            EMail = random.Next(100) <= 50 ? true : false,
                            Slack = random.Next(100) <= 50 ? true : false,
                            Teams = random.Next(100) <= 50 ? true : false,
                            SMS = random.Next(100) <= 50 ? true : false,
                            WhatsApp = random.Next(100) <= 50 ? true : false,
                            Telegram = random.Next(100) <= 50 ? true : false,
                            Gotify = random.Next(100) <= 50 ? true : false,

                            NotificationUserLinks = null,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //NotificationUserId = null,
                        
                        // FK
                        
                        Project = null,
                        ProjectId = null,
                    },
                    new DbMain_Project_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Project_Notification_User()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _patrickSchoeneggerId,

                            Description = string.Empty,

                            NotificationType = (NotificationType)values1.GetValue(random.Next(values1.Length)),

                            EMail = random.Next(100) <= 50 ? true : false,
                            Slack = random.Next(100) <= 50 ? true : false,
                            Teams = random.Next(100) <= 50 ? true : false,
                            SMS = random.Next(100) <= 50 ? true : false,
                            WhatsApp = random.Next(100) <= 50 ? true : false,
                            Telegram = random.Next(100) <= 50 ? true : false,
                            Gotify = random.Next(100) <= 50 ? true : false,

                            NotificationUserLinks = null,
                            
                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                        },
                        //NotificationUserId = null,
                        
                        // FK
                        
                        Project = null,
                        ProjectId = null,
                    },
                },
                NotificationUserGroupLinks = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,               
            };

            List<DbMain_Project> tmp = new List<DbMain_Project>()
            {
                project
            };

            return tmp;
        }
    }
}
