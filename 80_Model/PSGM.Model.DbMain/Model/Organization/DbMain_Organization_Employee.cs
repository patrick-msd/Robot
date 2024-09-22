using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization_Employee")]
    public class DbMain_Organization_Employee
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Acronym")]
        [Display(Name = "Acronym")]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Acronym { get; set; } = string.Empty;

        [Column("DaytimePhoneNumber")]
        [Display(Name = "DaytimePhoneNumber")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DaytimePhoneNumber { get; set; } = string.Empty;

        [Column("EveningPhoneNumber")]
        [Display(Name = "EveningPhoneNumber")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string EveningPhoneNumber { get; set; } = string.Empty;

        [Required]
        [Column("EMail")]
        [Display(Name = "EMail")]
        [StringLength(511, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string EMail { get; set; } = string.Empty;

        [Required]
        [Column("EmployeeType")]
        [Display(Name = "EmployeeType")]
        public EmployeeType EmployeeType { get; set; } = EmployeeType.Unknown;

        [Required]
        [Column("UserIdExt")]
        [Display(Name = "UserIdExt")]
        public Guid UserIdExt { get; set; } = Guid.Empty;

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
        #endregion

        #region Backlinks (ForeignKeys)
        [InverseProperty("Employee")]
        public virtual ICollection<DbMain_Organization_Employee_Link>? EmployeeLinks { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
