using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("File_Notification_UserGroup")]
    public class DbStorage_File_Notification_UserGroup
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
        [Column("UserGroupIdExt")]
        [Display(Name = "UserGroupIdExt")]
        public Guid UserGroupIdExt { get; set; } = Guid.Empty;

        [Column("NotificationType")]
        [Display(Name = "NotificationType")]
        public NotificationType NotificationType { get; set; } = NotificationType.None;

        [Column("EMail")]
        [Display(Name = "EMail")]
        public bool EMail { get; set; } = false;

        [Column("Slack")]
        [Display(Name = "Slack")]
        public bool Slack { get; set; } = false;

        [Column("Teams")]
        [Display(Name = "Teams")]
        public bool Teams { get; set; } = false;

        [Column("SMS")]
        [Display(Name = "SMS")]
        public bool SMS { get; set; } = false;

        [Column("WhatsApp")]
        [Display(Name = "WhatsApp")]
        public bool WhatsApp { get; set; } = false;

        [Column("Telegram")]
        [Display(Name = "Telegram")]
        public bool Telegram { get; set; } = false;

        [Column("Gotify")]
        [Display(Name = "Gotify")]
        public bool Gotify { get; set; } = false;
        #endregion

        #region Links
        [InverseProperty("NotificationUserGroup")]
        public virtual ICollection<DbStorage_File_Notification_UserGroup_Link>? NotificationUserGroupLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
