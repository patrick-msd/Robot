using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("QrCodeType")]
    public class DbMain_QrCodeType
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Name_EN")]
        [Display(Name = "Name_EN")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name_EN { get; set; } = string.Empty;

        [Required]
        [Column("Description_EN")]
        [Display(Name = "Description_EN")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description_EN { get; set; } = string.Empty;

        [Column("Name_DE")]
        [Display(Name = "Name_DE")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name_DE { get; set; } = string.Empty;

        [Column("Description_DE")]
        [Display(Name = "Description_DE")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description_DE { get; set; } = string.Empty;

        [Column("Name_FR")]
        [Display(Name = "Name_FR")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name_FR { get; set; } = string.Empty;

        [Column("Description_FR")]
        [Display(Name = "Description_FR")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description_FR { get; set; } = string.Empty;

        [Column("Name_SP")]
        [Display(Name = "Name_SP")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name_SP { get; set; } = string.Empty;

        [Column("Description_SP")]
        [Display(Name = "Description_SP")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description_SP { get; set; } = string.Empty;

        [Column("Name_IT")]
        [Display(Name = "Name_IT")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name_IT { get; set; } = string.Empty;

        [Column("Description_IT")]
        [Display(Name = "Description_IT")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description_IT { get; set; } = string.Empty;

        [Column("WorkflowApplyLevel_String")]
        [Display(Name = "WorkflowApplyLevel_String")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string WorkflowApplyLevel_String { get; private set; } = string.Empty;

        [Column("WorkflowExecutionLevel_String")]
        [Display(Name = "WorkflowExecutionLevel_String")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string WorkflowExecutionLevel_String { get; private set; } = string.Empty;

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
        [InverseProperty("QrCodeType")]
        public virtual ICollection<DbMain_QrCode>? QrCodes { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        #endregion
    }
}
