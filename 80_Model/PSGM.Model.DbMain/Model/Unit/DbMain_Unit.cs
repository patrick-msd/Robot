using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Unit")]
    public class DbMain_Unit
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

        [Column("SuffixProjectOwner")]
        [Display(Name = "SuffixProjectOwner")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string SuffixProjectOwner { get; set; } = string.Empty;

        [Required]
        [Column("NameProjectOwner")]
        [Display(Name = "NameProjectOwner")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string NameProjectOwner { get; set; } = string.Empty;

        [Column("PrefixProjectOwner")]
        [Display(Name = "PrefixProjectOwner")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string PrefixProjectOwner { get; set; } = string.Empty;

        [Column("DescriptionProjectOwner")]
        [Display(Name = "DescriptionProjectOwner")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DescriptionProjectOwner { get; set; } = string.Empty;

        [Column("Stars")]
        [Display(Name = "Stars")]
        public int Stars { get; set; } = -1;

        [Column("Order")]
        [Display(Name = "Order")]
        public int Order { get; set; } = -1;

        [Column("NaturalUnit")]
        [Display(Name = "NaturalUnit")]
        public bool NaturalUnit { get; set; } = false;

        [Column("PreparationDateTime")]
        [Display(Name = "PreparationDateTime")]
        public DateTime PreparationDateTime { get; set; } = DateTime.MinValue;

        [Column("PreparationUserId_Ext")]
        [Display(Name = "PreparationUserId_Ext")]
        public Guid PreparationUserId_Ext { get; set; } = Guid.Empty;

        [Column("PreparationNotes")]
        [Display(Name = "PreparationNotes")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string PreparationNotes { get; set; } = string.Empty;

        [Column("AqlStateImage")]
        [Display(Name = "AqlStateImage")]
        public AqlState AqlStateImage { get; set; } = AqlState.None;

        [Column("AqlStateLastChangeImage")]
        [Display(Name = "AqlStateLastChangeImage")]
        public DateTime AqlStateLastChangeImage { get; set; } = DateTime.MinValue;

        [Column("AqlStateTranscription")]
        [Display(Name = "AqlStateTranscription")]
        public AqlState AqlStateTranscription { get; set; } = AqlState.None;

        [Column("AqlStateLastChangeTranscription")]
        [Display(Name = "AqlStateLastChangeTranscription")]
        public DateTime AqlStateLastChangeTranscription { get; set; } = DateTime.MinValue;

        [Column("ArchiveJobStarted")]
        [Display(Name = "ArchiveJobStarted")]
        public DateTime LastArchiveJobStarted { get; set; } = DateTime.MinValue;

        [Column("ArchiveJobFinished")]
        [Display(Name = "ArchiveJobFinished")]
        public DateTime LastArchiveJobFinished { get; set; } = DateTime.MinValue;   

        [Column("ObjectsOnStorageInUnit")]
        [Display(Name = "ObjectsOnStorageInUnit")]
        public int ObjectsOnStorageInUnit { get; set; } = 0;

        [Column("DirectorySizeOnStorageInUnit")]
        [Display(Name = "DirectorySizeOnStorageInUnit")]
        public long DirectorySizeOnStorageInUnit { get; set; } = 0;

        [Column("Locked")]
        [Display(Name = "Locked")]
        public bool Locked { get; set; } = false;

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
        [InverseProperty("Unit")]
        public virtual DbMain_WorkflowGroup? ApplicableWorkflowGroup { get; set; }

        [InverseProperty("ParentUnit")]
        public virtual ICollection<DbMain_Unit>? Units { get; set; }

        [InverseProperty("Unit")]
        public virtual ICollection<DbMain_QrCode>? QrCodes { get; set; }

        [InverseProperty("Unit")]
        public virtual ICollection<DbMain_Unit_Defect>? UnitDefects { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("DeliverySlip")]
        public Guid? DeliverySlipId { get; set; }
        public virtual DbMain_DeliverySlip? DeliverySlip { get; set; }

        [ForeignKey("ParentUnit")]
        public Guid? ParentUnitId { get; set; }
        public virtual DbMain_Unit? ParentUnit { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
