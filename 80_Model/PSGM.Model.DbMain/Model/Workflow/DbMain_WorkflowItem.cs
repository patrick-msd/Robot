using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("WorkflowItem")]
    public class DbMain_WorkflowItem
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

        [Required]
        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("ApplyLevel")]
        [Display(Name = "ApplyLevel")]
        public WorkflowApplyLevel ApplyLevel { get; set; } = WorkflowApplyLevel.Undefined;

        [Required]
        [Column("WorkflowExecutionLevel")]
        [Display(Name = "WorkflowExecutionLevel")]
        public WorkflowExecutionLevel WorkflowExecutionLevel { get; set; } = WorkflowExecutionLevel.Undefined;

        [Required]
        [Column("StorageType")]
        [Display(Name = "StorageType")]
        public StorageType StorageType { get; set; } = StorageType.Unknown;

        [Required]
        [Column("StorageClass")]
        [Display(Name = "StorageClass")]
        public StorageClass StorageClass { get; set; } = StorageClass.Unknown;

        [Required]
        [Column("Permissions")]
        [Display(Name = "Permissions")]
        public EmployeeType Permissions { get; set; } = EmployeeType.None;

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;





        [Required]
        [Column("WorkflowStatus")]
        [Display(Name = "WorkflowStatus")]
        public WorkflowStatus WorkflowStatus { get; set; } = WorkflowStatus.Unknown;

        [Required]
        [Column("WorkflowStarted")]
        [Display(Name = "WorkflowStarted")]
        public DateTime WorkflowStarted { get; set; } = DateTime.MinValue;

        [Column("WorkflowFinished")]
        [Display(Name = "WorkflowFinished")]
        public DateTime WorkflowFinished { get; set; } = DateTime.MinValue;

        [Column("MachineId_Ext")]
        [Display(Name = "MachineId_Ext")]
        public Guid MachineId_Ext { get; set; } = Guid.Empty;











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
        [InverseProperty("WorkflowItem")]
        public virtual DbMain_WorkflowType? WorkflowType { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("WorkflowGroup")]
        public Guid? WorkflowGroupId { get; set; } = Guid.Empty;
        public virtual DbMain_WorkflowGroup? WorkflowGroup { get; set; }
        #endregion

        #region Not Mapped
        #region Save image
        public void SetSaveImageV1_0_0Configuration(ConfigurationSaveImageV1_0_0 configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public ConfigurationSaveImageV1_0_0 GetSaveImageV1_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<ConfigurationSaveImageV1_0_0>(Configuration); ;
        }
        #endregion

        #region Resize
        public void SetResizeV1_0_0Configuration(ConfigurationResizeV1_0_0 configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public ConfigurationResizeV1_0_0 GetResizeV1_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<ConfigurationResizeV1_0_0>(Configuration); ;
        }
        #endregion

        #region Darktable
        public void SetDarktableV1_0_0Configuration(List<ConfigurationDarktableV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationDarktableV1_0_0> GetDarktableV1_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationDarktableV1_0_0>>(Configuration); ;
        }
        #endregion

        #region Crop
        public void SetCropV1_0_0Configuration(List<ConfigurationCropV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationCropV1_0_0> GetCropV1_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationCropV1_0_0>>(Configuration); ;
        }
        #endregion

        #region Rotate
        public void SetRotateV1_0_0Configuration(List<ConfigurationRotateV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationRotateV1_0_0> GetRotateV1_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationRotateV1_0_0>>(Configuration); ;
        }

        public void SetRotateV2_0_0Configuration(List<ConfigurationRotateV2_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationRotateV2_0_0> GetRotateV2_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationRotateV2_0_0>>(Configuration); ;
        }
        #endregion

        #region Sharpen
        public void SetSharpenV1_0_0Configuration(List<ConfigurationSharpenV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationSharpenV1_0_0> GetSharpenV1_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationSharpenV1_0_0>>(Configuration); ;
        }

        public void SetSharpenV2_0_0Configuration(List<ConfigurationSharpenV2_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationSharpenV2_0_0> GetSharpenV2_0_0Configuration()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationSharpenV2_0_0>>(Configuration); ;
        }
        #endregion
        #endregion
    }
}
