using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("File_Notification_User")]
    public class DbStorage_File_Notification_User
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
        [Column("UserIdExt")]
        [Display(Name = "UserIdExt")]
        public Guid UserIdExt { get; set; } = Guid.Empty;

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

        #region Audit details for faster file audit information
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
        #endregion
        #endregion

        #region Links
        [InverseProperty("NotificationUser")]
        public virtual ICollection<DbStorage_File_Notification_User_Link>? NotificationUserLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
