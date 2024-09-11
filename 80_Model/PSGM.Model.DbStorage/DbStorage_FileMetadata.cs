using PSGM.Model.DbMain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("FileMetadata")]
    public class DbStorage_FileMetadata
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Metadata")]
        [Display(Name = "Metadata")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Metadata { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        #region Audit details for faster metadata audit information
        [Required]
        [Column("CreatedDateTimeAutoFill")]
        [Display(Name = "CreatedDateTimeAutoFill")]
        public DateTime CreatedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserIdExtAutoFill")]
        [Display(Name = "CreatedByUserIdExtAutoFill")]
        public Guid CreatedByUserIdExtAutoFill { get; set; } = Guid.Empty;

        [Column("ModifiedDateTimeAutoFill")]
        [Display(Name = "ModifiedDateTimeAutoFill")]
        public DateTime ModifiedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserIdExtAutoFill")]
        [Display(Name = "ModifiedByUserIdExtAutoFill")]
        public Guid ModifiedByUserIdExtAutoFill { get; set; } = Guid.Empty;

        [Column("LastModificationChangesAutoFill")]
        [Display(Name = "LastModificationChangesAutoFill")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastModificationChangesAutoFill { get; set; } = string.Empty;
        #endregion
        #endregion

        #region Links
        [InverseProperty("FileMetadata")]
        public virtual ICollection<DbStorage_FileMetadataAuthorization_User>? AuthorizationUsers { get; set; }

        [InverseProperty("FileMetadata")]
        public virtual ICollection<DbStorage_FileMetadataAuthorization_UserGroup>? AuthorizationUserGroups { get; set; }

        [InverseProperty("FileMetadata")]
        public virtual ICollection<DbStorage_FileMetadataNotification_User>? NotificationUsers { get; set; }

        [InverseProperty("FileMetadata")]
        public virtual ICollection<DbStorage_FileMetadataNotification_UserGroup>? NotificationUserGroups { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("File")]
        public Guid? FileId { get; set; }
        public virtual DbStorage_File? File { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
