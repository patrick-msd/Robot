namespace PSGM.Model.DbStorage
{
    public partial class WorkflowItemLog
    {
        public Guid WorkflowItemId = Guid.Empty;

        public DateTime Started = DateTime.MinValue;

        public DateTime Finished = DateTime.MinValue;
    }
}
