using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("DeliverySlip_Template")]
    public class DbMain_DeliverySlip_Template
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

        [Column("DeliverySlipState")]
        [Display(Name = "DeliverySlipState")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DeliverySlipType DeliverySlipState { get; set; } = DeliverySlipType.Undefined;

        [Column("DeliverySlipDocumentObjectName")]
        [Display(Name = "DeliverySlipDocumentObjectName")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DeliverySlipDocumentObjectName { get; set; } = string.Empty;

        [Column("OderProcessingStartedDateTime")]
        [Display(Name = "OderProcessingStartedDateTime")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DateTime OderProcessingStartedDateTime { get; set; } = DateTime.MinValue;

        [Column("OderProcessingStartedUserIdExt")]
        [Display(Name = "OderProcessingStartedUserIdExt")]
        public Guid OderProcessingStartedUserIdExt { get; set; } = Guid.Empty;

        [Column("OderProcessingFinishedDateTime")]
        [Display(Name = "OderProcessingFinishedDateTime")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DateTime OderProcessingFinishedDateTime { get; set; } = DateTime.MinValue;

        [Column("OderProcessingFinishedUserIdExt")]
        [Display(Name = "OderProcessingFinishedUserIdExt")]
        public Guid OderProcessingFinishedUserIdExt { get; set; } = Guid.Empty;

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
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("DeliverySlip")]
        public Guid? DeliverySlipId { get; set; }
        public virtual DbMain_DeliverySlip? DeliverySlip { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
