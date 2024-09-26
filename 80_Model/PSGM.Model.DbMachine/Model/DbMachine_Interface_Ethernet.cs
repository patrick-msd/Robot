using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("Interface_Ethernet")]
    public class DbMachine_Interface_Ethernet
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("IpAddress")]
        [Display(Name = "IpAddress")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string IpAddress { get; set; } = string.Empty;

        [Required]
        [Column("Port")]
        [Display(Name = "Port")]
        public int Port { get; set; } = 0;

        [Column("Timeout")]
        [Display(Name = "Timeout")]
        public int Timeout { get; set; } = 1000;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Device")]
        public Guid? DeviceId { get; set; }
        public virtual DbMachine_Device? Device { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
