using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Project_Authorization_User_Link_AuditLog")]
    public class DbMain_Project_Authorization_User_Link_AuditLog
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
        [Display(Name = "EntityName")]
        [StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Action { get; set; } = string.Empty;

        [Required]
        [Column("DateTime")]
        [Display(Name = "DateTime")]
        public DateTime DateTime { get; set; } = DateTime.MinValue;

        [Required]
        [Column("UserIdExt")]
        [Display(Name = "UserIdExt")]
        public Guid UserIdExt { get; set; } = Guid.Empty;

        [Required]
        [Column("SoftwareIdExt")]
        [Display(Name = "SoftwareIdExt")]
        public Guid SoftwareIdExt { get; set; } = Guid.Empty;

        [Required]
        [Column("Changes")]
        [Display(Name = "Changes")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Changes { get; set; } = string.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        public DbMain_Project_Authorization_User_Link GetChanges()
        {
            return JsonConvert.DeserializeObject<DbMain_Project_Authorization_User_Link>(Changes);
        }
        #endregion
    }
}
