using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Sample.Model.DbStorage
{
    public partial class MainWindow : System.Windows.Window
    {
        public List<DbMain_Organization> Generate_Organization2(int count, List<DbMain_Location> locations)
        {
            Random random = new Random();

            List<DbMain_Organization> tmp = new List<DbMain_Organization>();

            //for (int i = 0; i < count; i++)
            //{
            //    DbMain_Organization organization = new DbMain_Organization()
            //    {
            //        Id = Guid.NewGuid(),

            //        Name = "University Innsbruck (DEA)",
            //        Description = "",
            //        Acronym = "UIBK",

            //        EMail = "",
            //        Homepage = "",

            //        DaytimePhoneNumber = "+43 512 123456789",
            //        EveningPhoneNumber = "+43 512 123456789",

            //        LocationLinks = new List<DbMain_Organization_Location_Link>()
            //        {
            //            new DbMain_Organization_Location_Link()
            //            {
            //                Id = Guid.NewGuid(),

            //                Location = locations[random.Next(locations.Count)],
            //                //LocationId = null,

            //                Organization = null,
            //                OrganizationId = null,
            //            }
            //        },

            //        AuthorizationUser = new List<DbMain_Organization_Authorization_User>()
            //        {
            //            new DbMain_Organization_Authorization_User()
            //            {
            //                Id = Guid.NewGuid(),

            //                UserIdExt = patrickSchoeneggerId,
            //                Permissions = PermissionType.Owner,

            //                Description = string.Empty,
                        
            //                //CreatedByUserIdExtAutoFill = Guid.Empty,
            //                //CreatedDateTimeAutoFill = DateTime.Now,
            //                //ModifiedByUserIdExtAutoFill = Guid.Empty,
            //                //ModifiedDateTimeAutoFill = DateTime.Now,
                        
            //                // FK
            //                Organization = null,
            //                OrganizationId = null,
            //            },

            //            new DbMain_Organization_Authorization_User()
            //            {
            //                Id = Guid.NewGuid(),

            //                UserIdExt = guenterMuehlbergerId,
            //                Permissions = PermissionType.Admin,

            //                Description = string.Empty,
                        
            //                //CreatedByUserIdExtAutoFill = Guid.Empty,
            //                //CreatedDateTimeAutoFill = DateTime.Now,
            //                //ModifiedByUserIdExtAutoFill = Guid.Empty,
            //                //ModifiedDateTimeAutoFill = DateTime.Now,

            //                // FK
            //                Organization = null,
            //                OrganizationId = null,
            //            }
            //        },
            //        AuthorizationUserGroup = null,

            //        NotificationUser = new List<DbMain_Organization_Notification_User>()
            //        {
            //            new DbMain_Organization_Notification_User()
            //            {
            //                Id = Guid.NewGuid(),

            //                UserIdExt = patrickSchoeneggerId,

            //                Description = string.Empty,

            //                Notifications = new List<Notification>
            //                {
            //                    new Notification() { NotificationType = NotificationType.All, EMail = true, Slack = true, Teams = true, SMS = true, WhatsApp = true, Telegram = true, Gotify = true },
            //                },        
            //                //NotificationString = string.Empty,  

            //                // FK
            //                //Organization = null,
            //                //OrganizationId = Guid.Empty, 
            //            },
            //            new DbMain_Organization_Notification_User()
            //            {
            //                Id = Guid.NewGuid(),

            //                UserIdExt = guenterMuehlbergerId,

            //                Description = string.Empty,

            //                Notifications = new List<Notification>
            //                {
            //                    new Notification() { NotificationType = NotificationType.None, EMail = false, Slack = false, Teams = false, SMS = false, WhatsApp = false, Telegram = false, Gotify = false },
            //                },        
            //                //NotificationString = string.Empty,  

            //                // FK
            //                //Organization = null,
            //                //OrganizationId = Guid.Empty, 
            //            },
            //        },
            //        NotificationUserGroup = null,

            //        Contributors = null,

            //        //CreatedByUserIdExtAutoFill = Guid.Empty,
            //        //CreatedDateTimeAutoFill = DateTime.Now,
            //        //ModifiedByUserIdExtAutoFill = Guid.Empty,
            //        //ModifiedDateTimeAutoFill = DateTime.Now,  

            //        // FK
            //        Project = null,
            //        ProjectId = null
            //    };

            //    tmp.Add(organization);
            //}

            return tmp;
        }
    }
}
