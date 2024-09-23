using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization_Employee_Permission_AuditLog")]
    public class DbMain_Organization_Employee_Permission_AuditLog
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("SourceId")]
        [Display(Name = "SourceId")]
        public Guid SourceId { get; set; } = Guid.Empty;

        [Required]
        [Column("Action")]
        [Display(Name = "Action")]
        [StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Action { get; set; } = string.Empty;

        [Required]
        [Column("DateTime")]
        [Display(Name = "DateTime")]
        public DateTime DateTime { get; set; } = DateTime.MinValue;

        [Required]
        [Column("Changes")]
        [Display(Name = "Changes")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Changes { get; set; } = string.Empty;

        [Required]
        [Column("UserId_Ext")]
        [Display(Name = "UserId_Ext")]
        public Guid UserId_Ext { get; set; } = Guid.Empty;

        [Required]
        [Column("SoftwareId_Ext")]
        [Display(Name = "SoftwareId_Ext")]
        public Guid SoftwareId_Ext { get; set; } = Guid.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        public DbMain_Organization_Employee_Permission? GetChanges()
        {
            return JsonConvert.DeserializeObject<DbMain_Organization_Employee_Permission>(Changes);
        }
        #endregion
    }
}
