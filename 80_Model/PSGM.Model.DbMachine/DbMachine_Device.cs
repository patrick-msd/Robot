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
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
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
        [Column("Serialnumber")]
        [Display(Name = "Serialnumber")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Serialnumber { get; set; } = string.Empty;

        [Column("ConfigurationString")]
        [Display(Name = "ConfigurationString")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ConfigurationString { get; set; } = string.Empty;

        [Column("AttachmentsString")]
        [Display(Name = "AttachmentsString")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AttachmentsString { get; set; } = string.Empty;

        [Required]
        [Column("InitializeAtSplashscreen")]
        [Display(Name = "InitializeAtSplashscreen")]
        public bool InitializeAtSplashscreen { get; set; } = false;

        [Required]
        [Column("ConnectAtSplashscreen")]
        [Display(Name = "ConnectAtSplashscreen")]
        public bool ConnectAtSplashscreen { get; set; } = false;

        [Required]
        [Column("AutoStartAtSplashscreen")]
        [Display(Name = "AutoStartAtSplashscreen")]
        public bool AutoStartAtSplashscreen { get; set; } = false;

        [Required]
        [Column("HomingAtSplashscreen")]
        [Display(Name = "HomingAtSplashscreen")]
        public bool HomingAtSplashscreen { get; set; } = false;
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

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
