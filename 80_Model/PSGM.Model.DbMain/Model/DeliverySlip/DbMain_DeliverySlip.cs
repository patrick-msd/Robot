using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("DeliverySlip")]
    public class DbMain_DeliverySlip
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
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("InternalContactUserId_Ext")]
        [Display(Name = "InternalContactUserId_Ext")]
        public Guid InternalContactUserId_Ext { get; set; } = Guid.Empty;

        [Column("ExternalContactUserId_Ext")]
        [Display(Name = "ExternalContactUserId_Ext")]
        public Guid ExternalContactUserId_Ext { get; set; } = Guid.Empty;

        [Column("DeliverySlipIsDirectory")]
        [Display(Name = "DeliverySlipIsDirectory")]
        public bool DeliverySlipIsDirectory { get; set; } = false;

        [Column("NumberOfUnits")]
        [Display(Name = "NumberOfUnits")]
        public int NumberOfUnits { get; set; } = 0;

        [Column("DeliverySlipState")]
        [Display(Name = "DeliverySlipState")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DeliverySlipType DeliverySlipState { get; set; } = DeliverySlipType.Undefined;

        [Column("DocumentObjectName")]
        [Display(Name = "DocumentObjectName")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DocumentObjectName { get; set; } = string.Empty;

        [Column("ProcessingStartedDateTime")]
        [Display(Name = "ProcessingStartedDateTime")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DateTime ProcessingStartedDateTime { get; set; } = DateTime.MinValue;

        [Column("Machines_ExtString")]
        [Display(Name = "Machines_ExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Machines_ExtString { get; private set; } = string.Empty;

        [Column("ProcessingStartedUserId_Ext")]
        [Display(Name = "ProcessingStartedUserId_Ext")]
        public Guid ProcessingStartedUserId_Ext { get; set; } = Guid.Empty;

        [Column("ProcessingFinishedDateTime")]
        [Display(Name = "ProcessingFinishedDateTime")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DateTime ProcessingFinishedDateTime { get; set; } = DateTime.MinValue;

        [Column("ProcessingFinishedUserId_Ext")]
        [Display(Name = "ProcessingFinishedUserId_Ext")]
        public Guid ProcessingFinishedUserId_Ext { get; set; } = Guid.Empty;

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
        [InverseProperty("DeliverySlip")]
        public virtual DbMain_DeliverySlip_Template? CreatedWithDeliverySlipTemplate { get; set; }

        [InverseProperty("DeliverySlipInternet")]
        public virtual DbMain_Organization? InternalOrganization { get; set; }

        [InverseProperty("DeliverySlipExternal")]
        public virtual DbMain_Organization? ExternalOrganization { get; set; }

        [InverseProperty("DeliverySlip")]
        public virtual ICollection<DbMain_Unit>? Units { get; set; }

        [InverseProperty("DeliverySlip")]
        public virtual DbMain_WorkflowGroup? ApplicableWorkflowGroup { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbMain_Project? Project { get; set; }
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
