using Newtonsoft.Json;
using PSGM.Helper;
using PSGM.Model.DbStorage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("FileNotification_UserGroup")]
    public class DbStorage_FileNotification_UserGroup
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

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
        [ForeignKey("File")]
        public Guid? FileId { get; set; }
        public virtual DbStorage_File? File { get; set; }
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
