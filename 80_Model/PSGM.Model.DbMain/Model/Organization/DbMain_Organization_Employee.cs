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
        [Column("FieldOfEmployment")]
        [Display(Name = "FieldOfEmployment")]
        public FieldOfEmployment FieldOfEmployment { get; set; } = FieldOfEmployment.Unknown;

        [Required]
        [Column("UserId_Ext")]
        [Display(Name = "UserId_Ext")]
        public Guid UserId_Ext { get; set; } = Guid.Empty;

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
        [InverseProperty("Employee")]
        public virtual ICollection<DbMain_Organization_Employee_Notification>? Notifications { get; set; }

        [InverseProperty("Employee")]
        public virtual DbMain_Organization_Employee_Permission? Permissions { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Organization")]
        public Guid? OrganizationId { get; set; }
        public virtual DbMain_Organization? Organization { get; set; }

        [ForeignKey("EmployeeGroup")]
        public Guid? EmployeeGroupId { get; set; }
        public virtual DbMain_Organization_EmployeeGroup? EmployeeGroup { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
