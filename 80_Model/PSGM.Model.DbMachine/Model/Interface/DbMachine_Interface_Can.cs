using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("Interface_Can")]
    public class DbMachine_Interface_Can
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("SerialNumber")]
        [Display(Name = "SerialNumber")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string SerialNumber { get; set; } = string.Empty;

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;

        [Column("Timeout")]
        [Display(Name = "Timeout")]
        public int Timeout { get; set; } = 1000;

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
        [InverseProperty("Interface_Can")]
        public ICollection<DbMachine_Interface_CanDevice>? Interface_CanDevices { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Device")]
        public Guid? DeviceId { get; set; }
        public virtual DbMachine_Device? Device { get; set; }
        #endregion

        #region Not Mapped
        [NotMapped]
        public bool HasCanDevices
        {
            get
            {
                if (Interface_CanDevices != null)
                {
                    if (Interface_CanDevices.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion
    }
}
