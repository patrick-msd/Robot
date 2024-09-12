namespace PSGM.Helper
{
    public class Authorization_User
    {
        public Guid UserIdExt { get; set; } = Guid.Empty;

        public PermissionType Permissions { get; set; } = PermissionType.None;
    }
}
