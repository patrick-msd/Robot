using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization_Notification_User_Link")]
    public class DbMain_Organization_Notification_User_Link
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Organization")]
        public Guid? OrganizationId { get; set; }
        public virtual DbMain_Organization? Organization { get; set; }

        [ForeignKey("NotificationUser")]
        public Guid? NotificationUserId { get; set; } = Guid.Empty;
        public virtual DbMain_Organization_Notification_User? NotificationUser { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
