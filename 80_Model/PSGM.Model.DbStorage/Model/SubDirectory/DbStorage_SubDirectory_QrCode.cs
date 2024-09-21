using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectory_QrCode")]
    public class DbStorage_SubDirectory_QrCode
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
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("QrCodeType")]
        [Display(Name = "QrCodeType")]
        public QrCodeType QrCodeType { get; set; } = QrCodeType.Undefined;

        #region Audit details for faster file audit information
        [Required]
        [Column("CreatedDateTimeAutoFill")]
        [Display(Name = "CreatedDateTimeAutoFill")]
        public DateTime CreatedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserIdExtAutoFill")]
        [Display(Name = "CreatedByUserIdExtAutoFill")]
        public Guid CreatedByUserIdExtAutoFill { get; set; } = Guid.Empty;

        [Column("ModifiedDateTimeAutoFill")]
        [Display(Name = "ModifiedDateTimeAutoFill")]
        public DateTime ModifiedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserIdExtAutoFill")]
        [Display(Name = "ModifiedByUserIdExtAutoFill")]
        public Guid ModifiedByUserIdExtAutoFill { get; set; } = Guid.Empty;
        #endregion
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("SubDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? SubDirectory { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
