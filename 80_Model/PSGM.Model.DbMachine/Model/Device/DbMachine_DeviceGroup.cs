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

        [Column("ConfigurationString")]
        [Display(Name = "ConfigurationString")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ConfigurationString { get; set; } = string.Empty;

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
        [InverseProperty("DeviceGroup")]
        public ICollection<DbMachine_Device>? Devices { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Machine")]
        public Guid? MachineId { get; set; }
        public virtual DbMachine_Machine? Machine { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
