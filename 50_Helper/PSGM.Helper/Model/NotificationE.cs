namespace PSGM.Helper
{
    public enum NotificationType : int
    {
        None = 0,

        Inherited = 1,

        All = 10000,

        StatusChangeFile = 20000,
        StatusChangeDirectory = 20001,
        StatusChangeSubDirectory = 20002,

        StatusChangeProject = 30000,

        StatusChangeDeliverySlip = 20002,
    }

    public enum NotificationTriggerType : int
    {
        None = 0,

        Project = 10000,
        DeliverySlip = 10001,
        Unit = 10002,

        Archive = 20000,
        Job = 20001,
        Machine = 20002,
        Software = 20003,
        Storage = 20004,
        StorageDirectories = 20005,
        StorageFiles = 20006,
        Workflow = 20007,
    }

    public enum NotificationTriggerState : int
    {
        None = 0,

        All = 10000,

        Created = 20000,
        Updated = 20001,
        Deleted = 20002,
        CreatedUpdated = 20003,
        CreatedDeleted = 20004,
        UpdatedDeleted = 20005,
        CreatedUpdatedDeleted = 20006,

        Started = 30000,
        InProgress = 30001,
        Hold = 30002,
        Stopped = 30003,
        Finished = 30004,
    }
}
