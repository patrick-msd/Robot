using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectory_Metadata")]
    public class DbStorage_RootDirectory_Metadata
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Value")]
        [Display(Name = "Value")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Value { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("MetadataSource")]
        [Display(Name = "MetadataSource")]
        public MetadataSource MetadataSource { get; set; } = MetadataSource.Unknown;

        [Column("MetadataPermissions")]
        [Display(Name = "MetadataPermissions")]
        public MetadataPermissions MetadataPermissions { get; set; } = MetadataPermissions.Unknown;

        [Column("ApplicableForFiles")]
        [Display(Name = "ApplicableForFiles")]
        public bool ApplicableForFiles { get; set; } = false;

        [Column("Stars")]
        [Display(Name = "Stars")]
        public int Stars { get; set; } = -1;

        [Column("Order")]
        [Display(Name = "Order")]
        public int Order { get; set; } = -1;

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

        [InverseProperty("Metadata")]
        public virtual ICollection<DbStorage_RootDirectory_Metadata_Link>? MetadataLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Key")]
        public Guid? KeyId { get; set; }
        public virtual DbStorage_MetadataKey? Key { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
