using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("OrganizationNotification_User")]
    public class DbMain_OrganizationNotification_User
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
        [Column("UserIdExt")]
        [Display(Name = "UserIdExt")]
        public Guid UserIdExt { get; set; } = Guid.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Organization")]
        public Guid? OrganizationId { get; set; }
        public virtual DbMain_Organization? Organization { get; set; }
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

