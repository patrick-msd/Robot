namespace PSGM.Helper
{
    public enum NotificationType : int
    {
        None = 0,
        Inherited = 1,

        All = 10000,

        StatusChange = 20000,
    }

    public enum NotificationChannel : int
    {
        None = 0,

        EMail = 10000,

        Slack = 20000,
        Teams = 20001,

        SMS = 30000,
        WhatsApp = 30001,
        Telegram = 30002,
        Gotify = 30003,
    }
}
