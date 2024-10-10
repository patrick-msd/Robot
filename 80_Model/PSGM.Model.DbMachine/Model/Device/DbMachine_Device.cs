using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("Device")]
    public class DbMachine_Device
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("DeviceName")]
        [Display(Name = "DeviceName")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DeviceName { get; set; } = string.Empty;

        [Column("DeviceDescription")]
        [Display(Name = "DeviceDescription")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DeviceDescription { get; set; } = string.Empty;

        [Column("DeviceLocation")]
        [Display(Name = "DeviceLocation")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public DeviceLocation DeviceLocation { get; set; } = DeviceLocation.Undefined;

        [Required]
        [Column("DeviceCategory")]
        [Display(Name = "DeviceCategory")]
        public DeviceCategory DeviceCategory { get; set; } = DeviceCategory.Undefined;

        [Required]
        [Column("DeviceManufacturer")]
        [Display(Name = "DeviceManufacturer")]
        public DeviceManufacturer DeviceManufacturer { get; set; } = DeviceManufacturer.Undefined;

        [Required]
        [Column("DeviceType")]
        [Display(Name = "DeviceType")]
        public DeviceType DeviceType { get; set; } = DeviceType.Undefined;

        [Column("DeviceUrl")]
        [Display(Name = "DeviceUrl")]
        [StringLength(2048, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DeviceUrl { get; set; } = string.Empty;

        [Required]
        [Column("SerialNumber")]
        [Display(Name = "SerialNumber")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string SerialNumber { get; set; } = string.Empty;

        [Column("ConfigurationString")]
        [Display(Name = "ConfigurationString")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ConfigurationString { get; set; } = string.Empty;

        [Column("AttachmentsString")]
        [Display(Name = "AttachmentsString")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AttachmentsString { get; set; } = string.Empty;

        [Required]
        [Column("InitializeAtSplashScreen")]
        [Display(Name = "InitializeAtSplashScreen")]
        public bool InitializeAtSplashScreen { get; set; } = false;

        [Required]
        [Column("ConnectAtSplashScreen")]
        [Display(Name = "ConnectAtSplashScreen")]
        public bool ConnectAtSplashScreen { get; set; } = false;

        [Required]
        [Column("AutoStartAtSplashScreen")]
        [Display(Name = "AutoStartAtSplashScreen")]
        public bool AutoStartAtSplashScreen { get; set; } = false;

        [Required]
        [Column("HomingAtSplashScreen")]
        [Display(Name = "HomingAtSplashScreen")]
        public bool HomingAtSplashScreen { get; set; } = false;

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
        [InverseProperty("Device")]
        public DbMachine_Interface_Can? Interfaces_Can { get; set; }

        [InverseProperty("Device")]
        public DbMachine_Interface_Ethernet? Interfaces_Ethernet { get; set; }

        [InverseProperty("Device")]
        public DbMachine_Interface_Serial? Interfaces_Serial { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("DeviceGroup")]
        public Guid? DeviceGroupId { get; set; }
        public virtual DbMachine_DeviceGroup? DeviceGroup { get; set; }
        #endregion

        #region Not Mapped
        #region Configuration Control RobotElectronics V1.0.0
        public void SetConfigurationControlRobotElectronicsV1_0_0(Configuration_Control_RobotElectronicsV1_0_0 configuration)
        {
            ConfigurationString = JsonConvert.SerializeObject(configuration);
        }

        public Configuration_Control_RobotElectronicsV1_0_0? GetConfigurationControlRobotElectronicsV1_0_0()
        {
            return JsonConvert.DeserializeObject<Configuration_Control_RobotElectronicsV1_0_0>(ConfigurationString);
        }
        #endregion

        #region Configuration Robot Doosan V1.0.0
        public void SetConfigurationRobotDoosanV1_0_0(Configuration_Control_RobotElectronicsV1_0_0 configuration)
        {
            ConfigurationString = JsonConvert.SerializeObject(configuration);
        }

        public Configuration_Robot_DoosanV1_0_0? GetConfigurationRobotDoosanV1_0_0()
        {
            return JsonConvert.DeserializeObject<Configuration_Robot_DoosanV1_0_0>(ConfigurationString);
        }
        #endregion
        #endregion
    }
}
