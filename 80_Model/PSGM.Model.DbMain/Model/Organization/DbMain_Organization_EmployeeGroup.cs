using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization_EmployeeGroup")]
    public class DbMain_Organization_EmployeeGroup
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
        [Column("Permissions")]
        [Display(Name = "Permissions")]
        public EmployeeType Permissions { get; set; } = EmployeeType.None;

        [Required]
        [Column("UserGroupIdExt")]
        [Display(Name = "UserGroupIdExt")]
        public Guid UserGroupIdExt { get; set; } = Guid.Empty;

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
        [InverseProperty("EmployeeGroup")]
        public virtual ICollection<DbMain_Organization_Employee>? Employees { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Organization")]
        public Guid? OrganizationId { get; set; }
        public virtual DbMain_Organization? Organization { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
