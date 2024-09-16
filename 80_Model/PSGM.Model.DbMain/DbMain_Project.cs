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






        [Column("WorkflowIdExt")]
        [Display(Name = "WorkflowIdExt")]
        public Guid WorkflowIdExt { get; set; } = Guid.Empty;

        [Column("WorkflowApplyLevel")]
        [Display(Name = "WorkflowApplyLevel")]
        public WorkflowApplyLevel WorkflowApplyLevel { get; set; } = WorkflowApplyLevel.Undefined;

        [Column("MachinesExtString")]
        [Display(Name = "MachinesExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string MachinesExtString { get; private set; } = string.Empty;
        #endregion

        #region Links
        [InverseProperty("Project")]
        public virtual DbMain_DeliveryBill? DeliveryBill { get; set; }

        [InverseProperty("Project")]
        public virtual DbMain_Organization? Organization { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_Contributors>? Contributors { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_ProjectAuthorization_User>? AuthorizationUser { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_ProjectAuthorization_UserGroup>? AuthorizationUserGroup { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_ProjectNotification_User>? NotificationUser { get; set; }

        [InverseProperty("Project")]
        public virtual ICollection<DbMain_ProjectNotification_UserGroup>? NotificationUserGroup { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Guid> MachinesExt
        {
            get { return MachinesExtString != string.Empty ? MachinesExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { MachinesExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }
        #endregion
    }
}
