using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("Order")]
    public class DbStorage_Order
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

        [Column("OderStatus")]
        [Display(Name = "OderStatus")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public OrderType OderStatus { get; set; } = OrderType.Undefined;

        [Column("OrderDocumentObjectName")]
        [Display(Name = "OrderDocumentObjectName")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string OrderDocumentObjectName { get; set; } = string.Empty;

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








        #region Audit details for faster qrcode audit information
        [Required]
        [Column("CreatedDateTime")]
        [Display(Name = "CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserIdExt")]
        [Display(Name = "CreatedByUserIdExt")]
        public Guid CreatedByUserIdExt { get; set; } = Guid.Empty;

        [Column("ModifiedDateTime")]
        [Display(Name = "ModifiedDateTime")]
        public DateTime ModifiedDateTime { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserIdExt")]
        [Display(Name = "ModifiedByUserIdExt")]
        public Guid ModifiedByUserIdExt { get; set; } = Guid.Empty;

        [Column("LastChanges")]
        [Display(Name = "LastChanges")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastChanges { get; set; } = string.Empty;
        #endregion
        #endregion

        #region Links
        [InverseProperty("Order")]
        public virtual DbStorage_OrderTemplate? CreatedWithOrderTemplate { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("SubDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? SubDirectory { get; set; }

        [ForeignKey("RootDirectory")]
        public Guid? RootDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
