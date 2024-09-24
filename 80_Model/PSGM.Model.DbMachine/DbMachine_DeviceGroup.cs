using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("DeviceGroup")]
    public class DbMachine_DeviceGroup
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
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("Location")]
        [Display(Name = "Location")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [Column("DeviceGroupeType")]
        [Display(Name = "DeviceGroupeType")]
        public DeviceGroupeType DeviceGroupeType { get; set; } = DeviceGroupeType.Undefined;

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;
        #endregion

        #region Links
        [InverseProperty("DeviceGroup")]
        public ICollection<DbMachine_Device>? Devices { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Machine")]
        public Guid? MachineId { get; set; }
        public virtual DbMachine_Machine? Machine { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
