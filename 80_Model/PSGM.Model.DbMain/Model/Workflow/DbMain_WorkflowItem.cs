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
        [Column("Enable")]
        [Display(Name = "Enable")]
        public bool Enable { get; set; } = false;

        [Column("Order")]
        [Display(Name = "Order")]
        public int Order { get; set; } = -1;

        [Required]
        [Column("ApplyLevel")]
        [Display(Name = "ApplyLevel")]
        public WorkflowApplyLevel ApplyLevel { get; set; } = WorkflowApplyLevel.Undefined;

        [Required]
        [Column("ExecutionLevel")]
        [Display(Name = "ExecutionLevel")]
        public WorkflowExecutionLevel ExecutionLevel { get; set; } = WorkflowExecutionLevel.Undefined;

        [Required]
        [Column("StorageType")]
        [Display(Name = "StorageType")]
        public StorageType StorageType { get; set; } = StorageType.Undefined;

        [Required]
        [Column("StorageClass")]
        [Display(Name = "StorageClass")]
        public StorageClass StorageClass { get; set; } = StorageClass.Undefined;

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;

        [Required]
        [Column("WorkflowStatus")]
        [Display(Name = "WorkflowStatus")]
        public WorkflowStatus WorkflowStatus { get; set; } = WorkflowStatus.Undefined;

        [Required]
        [Column("WorkflowStarted")]
        [Display(Name = "WorkflowStarted")]
        public DateTime WorkflowStarted { get; set; } = DateTime.MinValue;

        [Column("WorkflowFinished")]
        [Display(Name = "WorkflowFinished")]
        public DateTime WorkflowFinished { get; set; } = DateTime.MinValue;

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
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("WorkflowGroup")]
        public Guid? WorkflowGroupId { get; set; } = Guid.Empty;
        public virtual DbMain_WorkflowGroup? WorkflowGroup { get; set; }

        [ForeignKey("WorkflowType")]
        public Guid? WorkflowTypeId { get; set; } = Guid.Empty;
        public virtual DbMain_WorkflowType? WorkflowType { get; set; }
        #endregion

        #region Not Mapped
        #region Save image
        public void SetSaveImageConfigurationV1_0_0(ConfigurationSaveImageV1_0_0 configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public ConfigurationSaveImageV1_0_0? GetSaveImageConfigurationV1_0_0()
        {
            return JsonConvert.DeserializeObject<ConfigurationSaveImageV1_0_0>(Configuration);
        }
        #endregion

        #region Resize
        public void SetResizeConfigurationV1_0_0(ConfigurationResizeV1_0_0 configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public ConfigurationResizeV1_0_0? GetResizeConfigurationV1_0_0()
        {
            return JsonConvert.DeserializeObject<ConfigurationResizeV1_0_0>(Configuration);
        }
        #endregion

        #region Darktable
        public void SetDarktableConfigurationV1_0_0(List<ConfigurationDarktableV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationDarktableV1_0_0>? GetDarktableConfigurationV1_0_0()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationDarktableV1_0_0>>(Configuration);
        }
        #endregion

        #region Crop
        public void SetCropConfigurationV1_0_0(List<ConfigurationCropV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationCropV1_0_0>? GetCropConfigurationV1_0_0()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationCropV1_0_0>>(Configuration);
        }
        #endregion

        #region Rotate
        public void SetRotateConfigurationV1_0_0(List<ConfigurationRotateV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationRotateV1_0_0>? GetRotateConfigurationV1_0_0()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationRotateV1_0_0>>(Configuration);
        }

        public void SetRotateConfigurationV2_0_0(List<ConfigurationRotateV2_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationRotateV2_0_0>? GetRotateConfigurationV2_0_0()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationRotateV2_0_0>>(Configuration);
        }
        #endregion

        #region Sharpen
        public void SetSharpenConfigurationV1_0_0(List<ConfigurationSharpenV1_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationSharpenV1_0_0>? GetSharpenConfigurationV1_0_0()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationSharpenV1_0_0>>(Configuration);
        }

        public void SetSharpenConfigurationV2_0_0(List<ConfigurationSharpenV2_0_0> configuration)
        {
            Configuration = JsonConvert.SerializeObject(configuration);
        }

        public List<ConfigurationSharpenV2_0_0>? GetSharpenConfigurationV2_0_0()
        {
            return JsonConvert.DeserializeObject<List<ConfigurationSharpenV2_0_0>>(Configuration);
        }
        #endregion
        #endregion
    }
}
