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

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;

        [Column("Timeout")]
        [Display(Name = "Timeout")]
        public int Timeout { get; set; } = 1000;

        [Column("InitialzeAtSplashscreen")]
        [Display(Name = "InitialzeAtSplashscreen")]
        public bool InitialzeAtSplashscreen { get; set; } = false;

        [Column("ConnectAtSplashscreen")]
        [Display(Name = "ConnectAtSplashscreen")]
        public bool ConnectAtSplashscreen { get; set; } = false;

        [Column("AutoStartAtSplashscreen")]
        [Display(Name = "AutoStartAtSplashscreen")]
        public bool AutoStartAtSplashscreen { get; set; } = false;

        [Column("HomingAtSplashscreen")]
        [Display(Name = "HomingAtSplashscreen")]
        public bool HomingAtSplashscreen { get; set; } = false;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Interface_Can")]
        public Guid? Interface_CanId { get; set; }
        public virtual DbMachine_Interface_Can? Interface_Can { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
