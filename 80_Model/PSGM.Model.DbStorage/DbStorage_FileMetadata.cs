using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("FileMetadata")]
    public class DbStorage_FileMetadata
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Key")]
        [Display(Name = "Key")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Key { get; set; } = string.Empty;

        [Column("Value")]
        [Display(Name = "Value")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Value { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("Hidden")]
        [Display(Name = "Hidden")]
        public bool Hidden { get; set; } = false;

        [Column("EditAll")]
        [Display(Name = "EditAll")]
        public bool EditAll { get; set; } = false;

        [Column("ViewAll")]
        [Display(Name = "ViewAll")]
        public bool ViewAll { get; set; } = false;

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
        [InverseProperty("FileMetadata")]
        public virtual ICollection<DbStorage_FileMetadataAuthorization_UserLink>? Authorization_UserLinks { get; set; }

        [InverseProperty("FileMetadata")]
        public virtual ICollection<DbStorage_FileMetadataAuthorization_UserGroupLink>? Authorization_UserGroupLinks { get; set; }

        [InverseProperty("FileMetadata")]
        public virtual ICollection<DbStorage_FileMetadataLink>? FileMetadataLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
