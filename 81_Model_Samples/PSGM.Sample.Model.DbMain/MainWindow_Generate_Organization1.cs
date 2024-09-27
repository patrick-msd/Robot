using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Organization> Generate_Organization1(List<DbMain_Location> locations)
        {
            Random random = new Random();

            Array values = Enum.GetValues(typeof(PermissionType));

            DbMain_Organization organizationUIBK = new DbMain_Organization()
            {
                Id = Guid.NewGuid(),
                
                Name = "University Innsbruck (DEA)",
                Description = "",
                Acronym = "UIBK",

                EMail = "",
                Homepage = "",

                DaytimePhoneNumber = "+43 512 123456789",
                EveningPhoneNumber = "+43 512 123456789",

                LocationLinks = new List<DbMain_Organization_Location_Link>()
                {
                    new DbMain_Organization_Location_Link()
                    {
                        Id = Guid.NewGuid(),

                        Location = locations.Where(p => p.AddressLink.Address.Line1.Contains("Innrain 52d")).First(),
                        //LocationId = null,

                        Organization = null,
                        OrganizationId = null,
                    }
                },

                Employees = new List<DbMain_Organization_Employee>()
                {
                    new DbMain_Organization_Employee ()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _guenterMuehlbergerId,
                        
                        Acronym = "MUG",

                        EMail = "",

                        DaytimePhoneNumber = "+43 512 123456789",
                        EveningPhoneNumber = "+43 512 123456789",

                        FieldOfEmployment = FieldOfEmployment.ScanManager,

                        Permissions = new DbMain_Organization_Employee_Permission()
                        {
                            Id = Guid.NewGuid(),

                            Description = string.Empty,

                            PermissionAddresses = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionContributors = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionDeliverySlips = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionLocations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionOrganizations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionUnits = (PermissionType)values.GetValue(random.Next(values.Length)),

                            PermissionArchive = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionJob = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionMachine = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionSoftware = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorage = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageDirectories = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageFiles = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionWorkflow = (PermissionType)values.GetValue(random.Next(values.Length)),

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,
                            
                            // FK
                            Employee = null,
                            EmployeeId = null,
                        },

                        Notifications = new List<DbMain_Organization_Employee_Notification>()
                        {
                            new DbMain_Organization_Employee_Notification()
                            {
                                Id = Guid.NewGuid(),

                                Description = string.Empty,

                                TriggerType = NotificationTriggerType.WorkflowQualityCheckForImage,
                                TriggerState = NotificationTriggerState.CreatedUpdatedDeleted,

                                EMail =  random.Next(100) <= 50 ? true : false,
                                Slack =  random.Next(100) <= 50 ? true : false,
                                Teams = random.Next(100) <= 50 ? true : false,
                                SMS =  random.Next(100) <= 50 ? true : false,
                                WhatsApp = random.Next(100) <= 50 ? true : false,
                                Telegram = random.Next(100) <= 50 ? true : false,
                                Gotify = random.Next(100) <= 50 ? true : false,

                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,
                                
                                // FK
                                Employee = null,
                                EmployeeId = null,
                            }
                            // More notifications ....
                        },
             
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                        
                        // FK
                        EmployeeGroup = null,
                        EmployeeGroupId = null,

                        Organization = null,
                        OrganizationId = null,
                    },
                    new DbMain_Organization_Employee ()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _patrickSchoeneggerId,

                        Acronym = "SOP",

                        EMail = "",

                        DaytimePhoneNumber = "+43 512 123456789",
                        EveningPhoneNumber = "+43 512 123456789",

                        FieldOfEmployment = FieldOfEmployment.ScanEmployee,

                        Permissions = new DbMain_Organization_Employee_Permission()
                        {
                            Id = Guid.NewGuid(),

                            Description = string.Empty,

                            PermissionAddresses = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionContributors = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionDeliverySlips = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionLocations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionOrganizations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionUnits = (PermissionType)values.GetValue(random.Next(values.Length)),

                            PermissionArchive = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionJob = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionMachine = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionSoftware = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorage = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageDirectories = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageFiles = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionWorkflow = (PermissionType)values.GetValue(random.Next(values.Length)),

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Employee = null,
                            EmployeeId = null,
                        },

                        Notifications = new List<DbMain_Organization_Employee_Notification>()
                        {
                            new DbMain_Organization_Employee_Notification()
                            {
                                Id = Guid.NewGuid(),

                                Description = string.Empty,

                                TriggerType = NotificationTriggerType.WorkflowImage,
                                TriggerState = NotificationTriggerState.CreatedUpdatedDeleted,

                                EMail = random.Next(100) <= 50 ? true : false,
                                Slack =  random.Next(100) <= 50 ? true : false,
                                Teams = random.Next(100) <= 50 ? true : false,
                                SMS =  random.Next(100) <= 50 ? true : false,
                                WhatsApp = random.Next(100) <= 50 ? true : false,
                                Telegram = random.Next(100) <= 50 ? true : false,
                                Gotify = random.Next(100) <= 50 ? true : false,
                                
                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Employee = null,
                                EmployeeId = null,
                            }
                            // More notifications ....
                        },

                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        EmployeeGroup = null,
                        EmployeeGroupId = null,

                        Organization = null,
                        OrganizationId = null,
                    },
                },
                EmployeeGroups = null,

                Contributors = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,  

                // FK
                Project = null,
                ProjectId = null,

                DeliverySlipCreator = null,
                DeliverySlipCreatorId = null,
                
                DeliverySlipRecipient = null,
                DeliverySlipRecipientId = null,
            };

            DbMain_Organization organizationTLA = new DbMain_Organization()
            {
                Id = Guid.NewGuid(),

                Name = "Tiroler Landesarchiv",
                Description = "Das Tiroler Landesarchiv (TLA) ist ein öffentliches Archiv des Bundeslandes Tirol und befindet sich in Innsbruck. Es bildet eine Abteilung des Amtes der Tiroler Landesregierung.",
                Acronym = "TLA",

                EMail = "",
                Homepage = "",

                DaytimePhoneNumber = "+43 512 123456789",
                EveningPhoneNumber = "+43 512 123456789",
                
                LocationLinks = new List<DbMain_Organization_Location_Link>()
                {
                    new DbMain_Organization_Location_Link()
                    {
                        Id = Guid.NewGuid(),

                        Location = locations.Where(p => p.AddressLink.Address.Line1.Contains("Michael-Gaismair-Straße 1")).First(),
                        //LocationId = null,

                        Organization = null,
                        OrganizationId = null,
                    }
                },

                Employees = new List<DbMain_Organization_Employee>()
                {
                    new DbMain_Organization_Employee ()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _gertraudZeindlId,

                        Acronym = "ZEG",

                        EMail = "",

                        DaytimePhoneNumber = "+43 512 123456789",
                        EveningPhoneNumber = "+43 512 123456789",

                        FieldOfEmployment = FieldOfEmployment.ProjectManager,

                        Permissions = new DbMain_Organization_Employee_Permission()
                        {
                            Id = Guid.NewGuid(),

                            Description = string.Empty,

                            PermissionAddresses = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionContributors = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionDeliverySlips = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionLocations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionOrganizations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionUnits = (PermissionType)values.GetValue(random.Next(values.Length)),

                            PermissionArchive = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionJob = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionMachine = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionSoftware = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorage = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageDirectories = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageFiles = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionWorkflow = (PermissionType)values.GetValue(random.Next(values.Length)),

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Employee = null,
                            EmployeeId = null,
                        },

                        Notifications = new List<DbMain_Organization_Employee_Notification>()
                        {
                            new DbMain_Organization_Employee_Notification()
                            {
                                Id = Guid.NewGuid(),

                                Description = string.Empty,

                                TriggerType = NotificationTriggerType.DeliverySlip,
                                TriggerState = NotificationTriggerState.CreatedUpdatedDeleted,

                                EMail =  random.Next(100) <= 50 ? true : false,
                                Slack =  random.Next(100) <= 50 ? true : false,
                                Teams = random.Next(100) <= 50 ? true : false,
                                SMS =  random.Next(100) <= 50 ? true : false,
                                WhatsApp = random.Next(100) <= 50 ? true : false,
                                Telegram = random.Next(100) <= 50 ? true : false,
                                Gotify = random.Next(100) <= 50 ? true : false,

                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Employee = null,
                                EmployeeId = null,
                            }
                            // More notifications ....
                        },
             
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,
                        
                        // FK
                        EmployeeGroup = null,
                        EmployeeGroupId = null,

                        Organization = null,
                        OrganizationId = null,
                    },
                    new DbMain_Organization_Employee ()
                    {
                        Id = Guid.NewGuid(),

                        UserId_Ext = _christophHaidacherId,

                        Acronym = "HAC",

                        EMail = "",

                        DaytimePhoneNumber = "+43 512 123456789",
                        EveningPhoneNumber = "+43 512 123456789",

                        FieldOfEmployment = FieldOfEmployment.ProjectEmployee,
                        
                        Permissions = new DbMain_Organization_Employee_Permission()
                        {
                            Id = Guid.NewGuid(),

                            Description = string.Empty,

                            PermissionAddresses = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionContributors = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionDeliverySlips = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionLocations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionOrganizations = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionUnits = (PermissionType)values.GetValue(random.Next(values.Length)),

                            PermissionArchive = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionJob = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionMachine = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionSoftware = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorage = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageDirectories = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionStorageFiles = (PermissionType)values.GetValue(random.Next(values.Length)),
                            PermissionWorkflow = (PermissionType)values.GetValue(random.Next(values.Length)),

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            Employee = null,
                            EmployeeId = null,
                        },

                        Notifications = new List<DbMain_Organization_Employee_Notification>()
                        {
                            new DbMain_Organization_Employee_Notification()
                            {
                                Id = Guid.NewGuid(),

                                Description = string.Empty,

                                TriggerType = NotificationTriggerType.DeliverySlip,
                                TriggerState = NotificationTriggerState.CreatedUpdatedDeleted,

                                EMail =  random.Next(100) <= 50 ? true : false,
                                Slack =  random.Next(100) <= 50 ? true : false,
                                Teams = random.Next(100) <= 50 ? true : false,
                                SMS =  random.Next(100) <= 50 ? true : false,
                                WhatsApp = random.Next(100) <= 50 ? true : false,
                                Telegram = random.Next(100) <= 50 ? true : false,
                                Gotify = random.Next(100) <= 50 ? true : false,

                                //CreatedByUserIdExtAutoFill = Guid.Empty,
                                //CreatedDateTimeAutoFill = DateTime.Now,
                                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                                //ModifiedDateTimeAutoFill = DateTime.Now,

                                // FK
                                Employee = null,
                                EmployeeId = null,
                            }
                            // More notifications ....
                        },
             
                        //CreatedByUserIdExtAutoFill = Guid.Empty,
                        //CreatedDateTimeAutoFill = DateTime.Now,
                        //ModifiedByUserIdExtAutoFill = Guid.Empty,
                        //ModifiedDateTimeAutoFill = DateTime.Now,

                        // FK
                        EmployeeGroup = null,
                        EmployeeGroupId = null,

                        Organization = null,
                        OrganizationId = null,
                    },
                },
                EmployeeGroups = null,

                Contributors = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,  

                // FK
                Project = null,
                ProjectId = null,

                DeliverySlipCreator = null,
                DeliverySlipCreatorId = null,
                
                DeliverySlipRecipient = null,
                DeliverySlipRecipientId = null,
            };

            List<DbMain_Organization> tmp = new List<DbMain_Organization>()
            {
                organizationUIBK,
                organizationTLA
            };

            return tmp;
        }
    }
}
