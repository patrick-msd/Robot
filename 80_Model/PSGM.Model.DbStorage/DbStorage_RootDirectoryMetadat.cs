using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectoryMetadata")]
    public class DbStorage_RootDirectoryMetadata
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

        [Column("EditAll")]
        [Display(Name = "EditAll")]
        public bool EditAll { get; set; } = false;

        [Column("ViewAll")]
        [Display(Name = "ViewAll")]
        public bool ViewAll { get; set; } = false;

        [Column("AuthorizationUsersString")]
        [Display(Name = "AuthorizationUsersString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AuthorizationUsersString { get; private set; } = string.Empty;

        [Column("AuthorizationUserGroupsString")]
        [Display(Name = "AuthorizationUserGroupsString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AuthorizationUserGroupsString { get; private set; } = string.Empty;

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
        [InverseProperty("RootDirectoryMetadata")]
        public virtual ICollection<DbStorage_RootDirectoryMetadataLink>? RootDirectoryMetadataLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("RootDirectory")]
        public Guid? RootDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Authorization_User> AuthorizationUsers
        {
            get { return AuthorizationUsersString != string.Empty ? JsonConvert.DeserializeObject<List<Authorization_User>>(AuthorizationUsersString) : null; }
            set { AuthorizationUsersString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Authorization_UserGroup> AuthorizationUserGroups
        {
            get { return AuthorizationUserGroupsString != string.Empty ? JsonConvert.DeserializeObject<List<Authorization_UserGroup>>(AuthorizationUserGroupsString) : null; }
            set { AuthorizationUserGroupsString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }
        #endregion
    }
}
