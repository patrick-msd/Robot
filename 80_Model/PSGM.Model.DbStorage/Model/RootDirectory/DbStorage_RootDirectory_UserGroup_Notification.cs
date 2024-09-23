using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectory_UserGroup_Notification")]
    public class DbStorage_RootDirectory_UserGroup_Notification
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

        [Column("TriggerType")]
        [Display(Name = "TriggerType")]
        public NotificationTriggerType TriggerType { get; set; } = NotificationTriggerType.None;

        [Column("TriggerState")]
        [Display(Name = "TriggerState")]
        public NotificationTriggerState TriggerState { get; set; } = NotificationTriggerState.None;

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
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("UserGroup")]
        public Guid? UserGroupId { get; set; }
        public virtual DbStorage_RootDirectory_UserGroup? UserGroup { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}

