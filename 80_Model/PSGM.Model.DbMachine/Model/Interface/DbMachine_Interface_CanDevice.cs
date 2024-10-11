using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("Interface_CanDevice")]
    public class DbMachine_Interface_CanDevice
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("CanDeviceId")]
        [Display(Name = "CanDeviceId")]
        public uint CanDeviceId { get; set; } = 0;

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

        [Column("Timeout")]
        [Display(Name = "Timeout")]
        public int Timeout { get; set; } = 1000;

        [Column("InitializeAtSplashScreen")]
        [Display(Name = "InitializeAtSplashScreen")]
        public bool InitializeAtSplashScreen { get; set; } = false;

        [Column("ConnectAtSplashScreen")]
        [Display(Name = "ConnectAtSplashScreen")]
        public bool ConnectAtSplashScreen { get; set; } = false;

        [Column("AutoStartAtSplashScreen")]
        [Display(Name = "AutoStartAtSplashScreen")]
        public bool AutoStartAtSplashScreen { get; set; } = false;

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
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Interface_Can")]
        public Guid? Interface_CanId { get; set; }
        public virtual DbMachine_Interface_Can? Interface_Can { get; set; }
        #endregion

        #region Not Mapped
        #region Configuration Motion Nanotec V1.0.0
        public void SetConfigurationMotionNanotecV1_0_0(Configuration_Motion_NanotecV1_0_0 configuration)
        {
            ConfigurationString = JsonConvert.SerializeObject(configuration);
        }

        public Configuration_Motion_NanotecV1_0_0? GetConfigurationMotionNanotecV1_0_0()
        {
            return JsonConvert.DeserializeObject<Configuration_Motion_NanotecV1_0_0>(ConfigurationString);
        }
        #endregion
        #endregion
    }
}
