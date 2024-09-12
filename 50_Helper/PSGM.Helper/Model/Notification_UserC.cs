using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Helper
{
    public class Notification_User
    {
        public Guid UserIdExt { get; set; } = Guid.Empty;

        public NotificationType NotificationType { get; set; } = NotificationType.None;

        public string NotificationChannelsString { get; private set; } = string.Empty;

        [NotMapped]
        public List<NotificationChannel> NotificationChannels
        {
            get { return NotificationChannelsString != string.Empty ? JsonConvert.DeserializeObject<List<NotificationChannel>>(NotificationChannelsString) : null; }
            set { NotificationChannelsString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }
    }
}
