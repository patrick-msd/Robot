using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbWorkflow
{
    [Table("WorkflowItemLink")]
    public class DbWorkflow_WorkflowItemLink
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Order")]
        [Display(Name = "Order")]
        public uint Order { get; set; } = 0;

        [Required]
        [Column("ApplyLevel")]
        [Display(Name = "ApplyLevel")]
        public WorkflowApplyLevel ApplyLevel { get; set; } = WorkflowApplyLevel.Undefined;

        [Required]
        [Column("StorageType")]
        [Display(Name = "StorageType")]
        public StorageType StorageType { get; set; } = StorageType.Unknown;

        [Required]
        [Column("StorageClass")]
        [Display(Name = "StorageClass")]
        public StorageClass StorageClass { get; set; } = StorageClass.Unknown;

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;

        [Required]
        [Column("ExecutionPermissions")]
        [Display(Name = "ExecutionPermissions")]
        public PermissionsType ExecutionPermissions { get; set; } = PermissionsType.None;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Workflow")]
        public Guid WorkflowId { get; set; } = Guid.Empty;
        public virtual DbWorkflow_Workflow? Workflow { get; set; }

        [ForeignKey("WorkflowItem")]
        public Guid WorkflowItemId { get; set; } = Guid.Empty;
        public virtual DbWorkflow_WorkflowItem? WorkflowItem { get; set; }
        #endregion

        #region Links (Outside DB)
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
