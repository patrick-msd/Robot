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
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("QrCode")]
        public Guid? QrCodeId { get; set; }
        public virtual DbMain_QrCode? QrCode { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
