using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Project")]
    public class DbMain_Project
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("Status")]
        [Display(Name = "Status")]
        public ProjectStatus Status { get; set; } = ProjectStatus.Undefined;

        [Column("Started")]
        [Display(Name = "Started")]
        public DateTime Started { get; set; } = DateTime.MinValue;

        [Column("Finished")]
        [Display(Name = "Finished")]
        public DateTime Finished { get; set; } = DateTime.MinValue;

        [Column("AqlQuantityImage")]
        [Display(Name = "AqlQuantityImage")]
        public AqlQuantity AqlQuantityImage { get; set; } = AqlQuantity.None;

        [Column("AqlInspectionLevelImage")]
        [Display(Name = "AqlInspectionLevelImage")]
        public AqlInspectionLevel AqlInspectionLevelImage { get; set; } = AqlInspectionLevel.None;

        [Column("AqlAcceptableQualityLevelImage")]
        [Display(Name = "AqlAcceptableQualityLevelImage")]
        public AcceptableQualityLevel AqlAcceptableQualityLevelImage { get; set; } = AcceptableQualityLevel.None;

        [Column("AqlStateImage")]
        [Display(Name = "AqlStateImage")]
        public AqlState AqlStateImage { get; set; } = AqlState.None;

        [Column("AqlStateLastChangeImage")]
        [Display(Name = "AqlStateLastChangeImage")]
        public DateTime AqlStateLastChangeImage { get; set; } = DateTime.MinValue;

        [Column("AqlQuantityTranscription")]
        [Display(Name = "AqlQuantityTranscription")]
        public AqlQuantity AqlQuantityTranscription { get; set; } = AqlQuantity.None;

        [Column("AqlInspectionLevelTranscription")]
        [Display(Name = "AqlInspectionLevelTranscription")]
        public AqlInspectionLevel AqlInspectionLevelTranscription { get; set; } = AqlInspectionLevel.None;

        [Column("AqlAcceptableQualityLevelTranscription")]
        [Display(Name = "AqlAcceptableQualityLevelTranscription")]
        public AcceptableQualityLevel AqlAcceptableQualityLevelTranscription { get; set; } = AcceptableQualityLevel.None;

        [Column("AqlStateTranscription")]
        [Display(Name = "AqlStateTranscription")]
        public AqlState AqlStateTranscription { get; set; } = AqlState.None;

        [Column("AqlStateLastChangeTranscription")]
        [Display(Name = "AqlStateLastChangeTranscription")]
        public DateTime AqlStateLastChangeTranscription { get; set; } = DateTime.MinValue;

        [Column("MaxDirectorySize")]
        [Display(Name = "MaxDirectorySize")]
        public long MaxDirectorySize { get; set; } = 125000000;     // Byte

        [Column("Machines_ExtString")]
        [Display(Name = "Machines_ExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Machines_ExtString { get; private set; } = string.Empty;

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
        [InverseProperty("Project")]
        public virtual ICollection<DbMain_Contributors>? Contributors { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_DeliverySlip>? DeliverySlips { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_Project_Location_Link>? LocationLinks { get; set; }

        [InverseProperty("Project")]
        public virtual DbMain_Organization? Organization { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_WorkflowGroup>? WorkflowGroups { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Guid>? Machines_Ext
        {
            get { return Machines_ExtString != string.Empty ? Machines_ExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { Machines_ExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }
        #endregion
    }
}
