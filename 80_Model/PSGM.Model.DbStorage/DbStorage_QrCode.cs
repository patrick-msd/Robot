using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("QrCode")]
    public class DbStorage_QrCode
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

        #region Audit details for faster qrcode audit information
        [Required]
        [Column("CreatedDateTime")]
        [Display(Name = "CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserIdExt")]
        [Display(Name = "CreatedByUserIdExt")]
        public Guid CreatedByUserIdExt { get; set; } = Guid.Empty;

        [Column("ModifiedDateTime")]
        [Display(Name = "ModifiedDateTime")]
        public DateTime ModifiedDateTime { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserIdExt")]
        [Display(Name = "ModifiedByUserIdExt")]
        public Guid ModifiedByUserIdExt { get; set; } = Guid.Empty;

        [Column("LastChanges")]
        [Display(Name = "LastChanges")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastChanges { get; set; } = string.Empty;
        #endregion
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("File")]
        public Guid? FileId { get; set; }
        public virtual DbStorage_File? File { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
