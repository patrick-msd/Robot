using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("File_VirtualUnit_UserGroup")]
    public class DbStorage_File_VirtualUnit_UserGroup
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        #region Audit details for faster file audit information
        [Required]
        [Column("CreatedDateTimeAutoFill")]
        [Display(Name = "CreatedDateTimeAutoFill")]
        public DateTime CreatedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserId_ExtAutoFill")]
        [Display(Name = "CreatedByUserId_ExtAutoFill")]
        public Guid CreatedByUserId_ExtAutoFill { get; set; } = Guid.Empty;

        [Column("ModifiedDateTimeAutoFill")]
        [Display(Name = "ModifiedDateTimeAutoFill")]
        public DateTime ModifiedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserId_ExtAutoFill")]
        [Display(Name = "ModifiedByUserId_ExtAutoFill")]
        public Guid ModifiedByUserId_ExtAutoFill { get; set; } = Guid.Empty;
        #endregion
        #endregion

        #region Links

        [InverseProperty("UserGroup")]
        public virtual ICollection<DbStorage_File_VirtualUnit_UserGroup_Notification>? Notifications { get; set; }

        [InverseProperty("UserGroup")]
        public virtual DbStorage_File_VirtualUnit_UserGroup_Permission? Permissions { get; set; }

        [InverseProperty("UserGroup")]
        public virtual ICollection<DbStorage_File_VirtualUnit_UserGroup_Link>? UserGroupLinks { get; set; }

        [InverseProperty("UserGroup")]
        public virtual ICollection<DbStorage_File_VirtualUnit_UserGroup_User_Link>? UserLinks { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
