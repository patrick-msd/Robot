using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("WorkflowType")]
    public class DbMain_WorkflowType
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

        [Column("ApplyLevel_String")]
        [Display(Name = "ApplyLevel_String")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ApplyLevel_String { get; private set; } = string.Empty;

        [Column("ExecutionLevel_String")]
        [Display(Name = "ExecutionLevel_String")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExecutionLevel_String { get; private set; } = string.Empty;

        [Column("StorageType_String")]
        [Display(Name = "StorageType_String")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageType_String { get; private set; } = string.Empty;

        [Column("StorageClass_String")]
        [Display(Name = "StorageClass_String")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageClass_String { get; private set; } = string.Empty;

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
        [InverseProperty("WorkflowType")]
        public virtual ICollection<DbMain_WorkflowItem>? WorkflowItems { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<WorkflowApplyLevel>? ApplyLevel
        {
            get { return ApplyLevel_String != string.Empty ? ApplyLevel_String.Split(',').Select(x => (WorkflowApplyLevel)Enum.Parse(typeof(WorkflowApplyLevel), x)).ToList() : null; }
            set { ApplyLevel_String = value != null ? string.Join(',', value) : string.Empty; }
        }

        [NotMapped]
        public List<WorkflowExecutionLevel>? ExecutionLevel
        {
            get { return ExecutionLevel_String != string.Empty ? ExecutionLevel_String.Split(',').Select(x => (WorkflowExecutionLevel)Enum.Parse(typeof(WorkflowExecutionLevel), x)).ToList() : null; }
            set { ExecutionLevel_String = value != null ? string.Join(',', value) : string.Empty; }
        }

        [NotMapped]
        public List<StorageType>? StorageType
        {
            get { return StorageType_String != string.Empty ? StorageType_String.Split(',').Select(x => (StorageType)Enum.Parse(typeof(StorageType), x)).ToList() : null; }
            set { StorageType_String = value != null ? string.Join(',', value) : string.Empty; }
        }

        [NotMapped]
        public List<StorageClass>? StorageClass
        {
            get { return StorageClass_String != string.Empty ? StorageClass_String.Split(',').Select(x => (StorageClass)Enum.Parse(typeof(StorageClass), x)).ToList() : null; }
            set { StorageClass_String = value != null ? string.Join(',', value) : string.Empty; }
        }
        #endregion
    }
}
