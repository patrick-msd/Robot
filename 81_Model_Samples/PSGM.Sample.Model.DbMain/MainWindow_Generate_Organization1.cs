using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Organization> Generate_Organization1(List<DbMain_Location> locations)
        {
            Random random = new Random();

            Array values1 = Enum.GetValues(typeof(NotificationType));

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

                EmployeeLinks = new List<DbMain_Organization_Employee_Link>()
                {
                    new DbMain_Organization_Employee_Link()
                    {
                        Id = Guid.NewGuid(),

                        Employee = new DbMain_Organization_Employee ()
                        {
                            Id = Guid.NewGuid(),

                            Acronym = "PS",

                            EMail = "",
                            DaytimePhoneNumber = "+43 512 123456789",
                            EveningPhoneNumber = "+43 512 123456789",

                            EmployeeType = EmployeeType.Owner,

                            UserIdExt = _patrickSchoeneggerId,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            EmployeeLinks = null,
                        },
                        //EmployeeId = null,
                        
                        // FK
                        Organization = null,
                        OrganizationId = null,
                    },

                    new DbMain_Organization_Employee_Link()
                    {
                        Id = Guid.NewGuid(),

                        Employee = new DbMain_Organization_Employee ()
                        {
                            Id = Guid.NewGuid(),

                            Acronym = "PS",

                            EMail = "",
                            DaytimePhoneNumber = "+43 512 123456789",
                            EveningPhoneNumber = "+43 512 123456789",

                            EmployeeType = EmployeeType.Owner,

                            UserIdExt = _guenterMuehlbergerId,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            EmployeeLinks = null,
                        },
                        //EmployeeId = null,
                        
                        // FK
                        Organization = null,
                        OrganizationId = null,
                    },
                },
                EmployeeGroupLinks = null,

hgjhgj               NotificationUserLinks = new List<DbMain_Organization_Notification_User_Link>()
                {
                    new DbMain_Organization_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Organization_Notification_User()
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
                        Organization = null,
                        OrganizationId = null,
                    },

                    new DbMain_Organization_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Organization_Notification_User()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _guenterMuehlbergerId,

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
                        Organization = null,
                        OrganizationId = null,
                    },
                },
fghj              NotificationUserGroupLinks = null,

                Contributors = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,  

                // FK
                Project = null,
                ProjectId = null
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

                EmployeeLinks = new List<DbMain_Organization_Employee_Link>()
                {
                    new DbMain_Organization_Employee_Link()
                    {
                        Id = Guid.NewGuid(),

                        Employee = new DbMain_Organization_Employee ()
                        {
                            Id = Guid.NewGuid(),

                            Acronym = "PS",

                            EMail = "",
                            DaytimePhoneNumber = "+43 512 123456789",
                            EveningPhoneNumber = "+43 512 123456789",

                            EmployeeType = EmployeeType.Owner,

                            UserIdExt = _gertraudZeindlId,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            EmployeeLinks = null,
                        },
                        //EmployeeId = null,
                        
                        // FK
                        Organization = null,
                        OrganizationId = null,
                    },

                    new DbMain_Organization_Employee_Link()
                    {
                        Id = Guid.NewGuid(),

                        Employee = new DbMain_Organization_Employee ()
                        {
                            Id = Guid.NewGuid(),

                            Acronym = "PS",

                            EMail = "",
                            DaytimePhoneNumber = "+43 512 123456789",
                            EveningPhoneNumber = "+43 512 123456789",

                            EmployeeType = EmployeeType.Owner,

                            UserIdExt = _christophHaidacherId,

                            //CreatedByUserIdExtAutoFill = Guid.Empty,
                            //CreatedDateTimeAutoFill = DateTime.Now,
                            //ModifiedByUserIdExtAutoFill = Guid.Empty,
                            //ModifiedDateTimeAutoFill = DateTime.Now,

                            // FK
                            EmployeeLinks = null,
                        },
                        //EmployeeId = null,
                        
                        // FK
                        Organization = null,
                        OrganizationId = null,
                    },
                },
                EmployeeGroupLinks = null,

gfh               NotificationUserLinks = new List<DbMain_Organization_Notification_User_Link>()
                {
                    new DbMain_Organization_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Organization_Notification_User()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _gertraudZeindlId,

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
                        Organization = null,
                        OrganizationId = null,
                    },

                    new DbMain_Organization_Notification_User_Link()
                    {
                        Id = Guid.NewGuid(),

                        NotificationUser = new DbMain_Organization_Notification_User()
                        {
                            Id = Guid.NewGuid(),

                            UserIdExt = _christophHaidacherId,

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
                        Organization = null,
                        OrganizationId = null,
                    },
                },
fdhg               NotificationUserGroupLinks = null,

                Contributors = null,

                //CreatedByUserIdExtAutoFill = Guid.Empty,
                //CreatedDateTimeAutoFill = DateTime.Now,
                //ModifiedByUserIdExtAutoFill = Guid.Empty,
                //ModifiedDateTimeAutoFill = DateTime.Now,  

                // FK
                Project = null,
                ProjectId = null
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
