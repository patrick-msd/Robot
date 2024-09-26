using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("Interface_Serial")]
    public class DbMachine_Interface_Serial
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("PortName")]
        [Display(Name = "PortName")]
        [StringLength(64, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string PortName { get; set; } = string.Empty;

        [Required]
        [Column("BaudRate")]
        [Display(Name = "BaudRate")]
        public int BaudRate { get; set; } = 0;

        [Required]
        [Column("Parity")]
        [Display(Name = "Parity")]
        public byte Parity { get; set; } = 0;

        [Required]
        [Column("StopBits")]
        [Display(Name = "StopBits")]
        public byte StopBits { get; set; } = 0;

        [Required]
        [Column("Handshake")]
        [Display(Name = "Handshake")]
        public byte Handshake { get; set; } = 0;

        [Column("ReadTimeout")]
        [Display(Name = "ReadTimeout")]
        public int ReadTimeout { get; set; } = 1000;

        [Column("WriteTimeout")]
        [Display(Name = "WriteTimeout")]
        public int WriteTimeout { get; set; } = 1000;

        [Column("SerialPortRetrySending")]
        [Display(Name = "SerialPortRetrySending")]
        public int SerialPortRetrySending { get; set; } = 3;

        [Column("MonitoringInterval")]
        [Display(Name = "MonitoringInterval")]
        public int MonitoringInterval { get; set; } = 1000;

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
        [ForeignKey("Device")]
        public Guid? DeviceId { get; set; }
        public virtual DbMachine_Device? Device { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
