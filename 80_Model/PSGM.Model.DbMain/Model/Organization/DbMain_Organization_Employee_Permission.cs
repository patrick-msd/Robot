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
        [Column("PermissionAddresses")]
        [Display(Name = "PermissionAddresses")]
        public PermissionType PermissionAddresses { get; set; } = PermissionType.None;

        [Column("PermissionContributors")]
        [Display(Name = "PermissionContributors")]
        public PermissionType PermissionContributors { get; set; } = PermissionType.None;

        [Column("PermissionDeliverySlips")]
        [Display(Name = "PermissionDeliverySlips")]
        public PermissionType PermissionDeliverySlips { get; set; } = PermissionType.None;

        [Column("PermissionLocations")]
        [Display(Name = "PermissionLocations")]
        public PermissionType PermissionLocations { get; set; } = PermissionType.None;

        [Column("PermissionOrganizations")]
        [Display(Name = "PermissionOrganizations")]
        public PermissionType PermissionOrganizations { get; set; } = PermissionType.None;

        [Column("PermissionUnits")]
        [Display(Name = "PermissionUnits")]
        public PermissionType PermissionUnits { get; set; } = PermissionType.None;
        #endregion

        #region Common permissions
        [Column("PermissionArchive")]
        [Display(Name = "PermissionArchive")]
        public PermissionType PermissionArchive { get; set; } = PermissionType.None;

        [Column("PermissionJob")]
        [Display(Name = "PermissionJob")]
        public PermissionType PermissionJob { get; set; } = PermissionType.None;

        [Column("PermissionMachine")]
        [Display(Name = "PermissionMachine")]
        public PermissionType PermissionMachine { get; set; } = PermissionType.None;

        [Column("PermissionSoftware")]
        [Display(Name = "PermissionSoftware")]
        public PermissionType PermissionSoftware { get; set; } = PermissionType.None;

        [Column("PermissionStorage")]
        [Display(Name = "PermissionStorage")]
        public PermissionType PermissionStorage { get; set; } = PermissionType.None;

        [Column("PermissionStorageDirectories")]
        [Display(Name = "PermissionStorageDirectories")]
        public PermissionType PermissionStorageDirectories { get; set; } = PermissionType.None;

        [Column("PermissionStorageFiles")]
        [Display(Name = "PermissionStorageFiles")]
        public PermissionType PermissionStorageFiles { get; set; } = PermissionType.None;

        [Column("PermissionWorkflow")]
        [Display(Name = "PermissionWorkflow")]
        public PermissionType PermissionWorkflow { get; set; } = PermissionType.None;
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

