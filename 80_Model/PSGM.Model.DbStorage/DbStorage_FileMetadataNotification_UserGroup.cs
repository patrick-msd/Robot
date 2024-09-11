using Newtonsoft.Json;
using PSGM.Helper;
using PSGM.Model.DbStorage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("FileMetadataNotification_UserGroup")]
    public class DbStorage_FileMetadataNotification_UserGroup
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(16384, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("NotificationString")]
        [Display(Name = "NotificationString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string NotificationString { get; private set; } = string.Empty;

        [Required]
        [Column("UserGroupIdExt")]
        [Display(Name = "UserGroupIdExt")]
        public Guid UserGroupIdExt { get; set; } = Guid.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("FileMetadata")]
        public Guid? FileMetadataId { get; set; }
        public virtual DbStorage_FileMetadata? FileMetadata { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Notification> Notifications
        {
            get { return NotificationString != string.Empty ? JsonConvert.DeserializeObject<List<Notification>>(NotificationString) : null; }
            set { NotificationString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }
        #endregion
    }
}
