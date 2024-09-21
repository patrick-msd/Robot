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

        [Column("InternalContactUserIdExt")]
        [Display(Name = "InternalContactUserIdExt")]
        public Guid InternalContactUserIdExt { get; set; } = Guid.Empty;

        [Column("InternalContributorsUserIdExt")]
        [Display(Name = "InternalContributorsUserIdExt")]
        public Guid InternalContributorsUserIdExt { get; set; } = Guid.Empty;

        [Column("ExternalContactUserIdExt")]
        [Display(Name = "ExternalContactUserIdExt")]
        public Guid ExternalContactUserIdExt { get; set; } = Guid.Empty;

        [Column("ExternalContributorsUserIdExt")]
        [Display(Name = "ExternalContributorsUserIdExt")]
        public Guid ExternalContributorsUserIdExt { get; set; } = Guid.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("DeliverySlipIsDirectory")]
        [Display(Name = "DeliverySlipIsDirectory")]
        public bool DeliverySlipIsDirectory { get; set; } = false;

        [Column("DeliverySliplState")]
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

        [Column("ProcessingStartedUserIdExt")]
        [Display(Name = "ProcessingStartedUserIdExt")]
        public Guid ProcessingStartedUserIdExt { get; set; } = Guid.Empty;

        [Column("ProcessingFinishedDateTime")]
        [Display(Name = "ProcessingFinishedDateTime")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DateTime ProcessingFinishedDateTime { get; set; } = DateTime.MinValue;

        [Column("ProcessingFinishedUserIdExt")]
        [Display(Name = "ProcessingFinishedUserIdExt")]
        public Guid ProcessingFinishedUserIdExt { get; set; } = Guid.Empty;

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
        [InverseProperty("DeliverySlip")]
        public virtual ICollection<DbMain_DocumentType>? DocumentTypes { get; set; }

        [InverseProperty("DeliverySlip")]
        public virtual DbMain_DeliverySlip_Template? CreatedWithDeliverySlipTemplate { get; set; }

        [InverseProperty("DeliverySlip")]
        public virtual ICollection<DbMain_Unit>? Units { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbMain_Project? Project { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
