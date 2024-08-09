namespace PSGM.Helper
{
    public class Notification
    {
        public NotificationType NotificationType { get; set; } = NotificationType.None;

        public bool EMail { get; set; } = false;

        public bool Slack { get; set; } = false;
        public bool Teams { get; set; } = false;

        public bool SMS { get; set; } = false;

        public bool WhatsApp { get; set; } = false;
        public bool Telegram { get; set; } = false;

        public bool Gotify { get; set; } = false;
    }
}