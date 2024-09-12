namespace PSGM.Helper
{
    public class Authorization_UserGroup
    {
        public Guid UserGroupIdExt { get; set; } = Guid.Empty;

        public PermissionType Permissions { get; set; } = PermissionType.None;
    }
}
