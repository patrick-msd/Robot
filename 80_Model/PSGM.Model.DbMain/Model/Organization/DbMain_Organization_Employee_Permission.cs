using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization_Employee_Permission")]
    public class DbMain_Organization_Employee_Permission
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

        #region Project specific permissions
        [Column("Addresses")]
        [Display(Name = "Addresses")]
        public PermissionType Addresses { get; set; } = PermissionType.None;

        [Column("Contributors")]
        [Display(Name = "Contributors")]
        public PermissionType Contributors { get; set; } = PermissionType.None;

        [Column("DeliverySlips")]
        [Display(Name = "DeliverySlips")]
        public PermissionType DeliverySlips { get; set; } = PermissionType.None;

        [Column("Locations")]
        [Display(Name = "Locations")]
        public PermissionType Locations { get; set; } = PermissionType.None;

        [Column("Organizations")]
        [Display(Name = "Organizations")]
        public PermissionType Organizations { get; set; } = PermissionType.None;

        [Column("Units")]
        [Display(Name = "Units")]
        public PermissionType Units { get; set; } = PermissionType.None;
        #endregion

        #region Common permissions
        [Column("Archive")]
        [Display(Name = "Archive")]
        public PermissionType Archive { get; set; } = PermissionType.None;

        [Column("Job")]
        [Display(Name = "Job")]
        public PermissionType Job { get; set; } = PermissionType.None;

        [Column("Machine")]
        [Display(Name = "Machine")]
        public PermissionType Machine { get; set; } = PermissionType.None;

        [Column("Software")]
        [Display(Name = "Software")]
        public PermissionType Software { get; set; } = PermissionType.None;

        [Column("Storage")]
        [Display(Name = "Storage")]
        public PermissionType Storage { get; set; } = PermissionType.None;

        [Column("StorageDirectories")]
        [Display(Name = "StorageDirectories")]
        public PermissionType StorageDirectories { get; set; } = PermissionType.None;

        [Column("StorageFiles")]
        [Display(Name = "StorageFiles")]
        public PermissionType StorageFiles { get; set; } = PermissionType.None;

        [Column("Workflow")]
        [Display(Name = "Workflow")]
        public PermissionType Workflow { get; set; } = PermissionType.None;
        #endregion

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
        [ForeignKey("Employee")]
        public Guid? EmployeeId { get; set; }
        public virtual DbMain_Organization_Employee? Employee { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}

