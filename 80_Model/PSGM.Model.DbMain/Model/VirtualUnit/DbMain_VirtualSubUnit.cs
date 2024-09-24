using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("VirtualSubUnit")]
    public class DbMain_VirtualSubUnit
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Suffix")]
        [Display(Name = "Suffix")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Suffix { get; set; } = string.Empty;

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Prefix")]
        [Display(Name = "Prefix")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Prefix { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("Stars")]
        [Display(Name = "Stars")]
        public int Stars { get; set; } = -1;

        [Column("Order")]
        [Display(Name = "Order")]
        public int Order { get; set; } = -1;

        [Required]
        [Column("Permissions")]
        [Display(Name = "Permissions")]
        public VirtualUnitPermissions Permissions { get; set; } = VirtualUnitPermissions.Undefined;

        [Column("Filter")]
        [Display(Name = "Filter")]
        [StringLength(2048, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Filter { get; set; } = string.Empty;










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
        [InverseProperty("ParentSubUnit")]
        public virtual ICollection<DbMain_VirtualSubUnit>? Unit { get; set; }

        [InverseProperty("SubUnit")]
        public virtual ICollection<DbMain_VirtualSubUnit_User_Permission>? UserPermissions { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)      
        [ForeignKey("RootUnit")]
        public Guid? RootUnitId { get; set; }
        public virtual DbMain_VirtualRootUnit? RootUnit { get; set; }

        [ForeignKey("ParentSubUnit")]
        public Guid? ParentSubUnitId { get; set; }
        public virtual DbMain_VirtualSubUnit? ParentSubUnit { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
