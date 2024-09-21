using CommunityToolkit.HighPerformance.Helpers;
using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectory_Metadata")]
    public class DbStorage_SubDirectory_Metadata
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

        [Column("ApplicableForFiles")]
        [Display(Name = "ApplicableForFiles")]
        public bool ApplicableForFiles { get; set; } = false;

        [Column("MetadataType")]
        [Display(Name = "MetadataType")]
        public MetadataType MetadataType { get; set; } = MetadataType.Unknown;

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
        [InverseProperty("Metadata")]
        public virtual ICollection<DbStorage_SubDirectory_Metadata_Authorization_User_Link>? AuthorizationUserLinks { get; set; }

        [InverseProperty("Metadata")]
        public virtual ICollection<DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link>? AuthorizationUserGroupLinks { get; set; }

        [InverseProperty("Metadata")]
        public virtual ICollection<DbStorage_SubDirectory_Metadata_Link>? MetadataLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        #endregion
    }
}
