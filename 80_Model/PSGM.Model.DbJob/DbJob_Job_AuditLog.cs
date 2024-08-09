using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbJob
{
    [Table("Job_AuditLog")]
    public class DbJob_Job_AuditLog
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

        //[Required]
        //[Column("TableName")]
        //[Display(Name = "TableName")]
        //[StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string TableName { get; set; } = string.Empty;

        //[Required]
        //[Column("EntityName")]
        //[Display(Name = "EntityName")]
        //[StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string EntityName { get; set; } = string.Empty;

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

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        public DbJob_Job GetChagnes()
        {
            return JsonConvert.DeserializeObject<DbJob_Job>(Changes);
        }
        #endregion
    }
}
