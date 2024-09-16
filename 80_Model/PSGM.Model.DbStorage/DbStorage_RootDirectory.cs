using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectory")]
    public class DbStorage_RootDirectory
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Suffix")]
        [Display(Name = "Suffix")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Suffix { get; set; } = string.Empty;

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Prefix")]
        [Display(Name = "Prefix")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Prefix { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("Stars")]
        [Display(Name = "Stars")]
        public int Stars { get; set; } = -1;

        [Column("Order")]
        [Display(Name = "Order")]
         int Order { get; set; } = -1;

        [Column("DirectoryState")]
        [Display(Name = "DirectoryState")]
        public DirectoryState DirectoryState { get; set; } = DirectoryState.Undefined; 

        [Column("SuffixProjectOwner")]
        [Display(Name = "SuffixProjectOwner")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string SuffixProjectOwner { get; set; } = string.Empty;

        [Required]
        [Column("NameProjectOwner")]
        [Display(Name = "NameProjectOwner")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string NameProjectOwner { get; set; } = string.Empty;

        [Column("PrefixProjectOwner")]
        [Display(Name = "PrefixProjectOwner")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string PrefixProjectOwner { get; set; } = string.Empty;

        [Column("DescriptionProjectOwner")]
        [Display(Name = "DescriptionProjectOwner")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DescriptionProjectOwner { get; set; } = string.Empty;

        [Column("DirectoryLocked")]
        [Display(Name = "DirectoryLocked")]
        public bool DirectoryLocked { get; set; } = false;

        #region No direct access
        [Column("AuthorizationUserIdsExtString")]
        [Display(Name = "AuthorizationUserIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AuthorizationUserIdsExtString { get; private set; } = string.Empty;

        [Column("AuthorizationUserGroupIdsExtString")]
        [Display(Name = "AuthorizationUserGroupIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AuthorizationUserGroupIdsExtString { get; private set; } = string.Empty;

        [Column("NotificationUserIdsExtString")]
        [Display(Name = "NotificationUserIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string NotificationUserIdsExtString { get; private set; } = string.Empty;

        [Column("NotificationUserGroupIdsExtString")]
        [Display(Name = "NotificationUserGroupIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string NotificationUserGroupIdsExtString { get; private set; } = string.Empty;

        [Column("JobIdsExtString")]
        [Display(Name = "JobIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string JobIdsExtString { get; private set; } = string.Empty;

        [Column("WorkflowItemIdsExtString")]
        [Display(Name = "WorkflowItemIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string WorkflowItemIdsExtString { get; private set; } = string.Empty;

        [Column("BackupIdsExtString")]
        [Display(Name = "BackupIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string BackupIdsExtString { get; private set; } = string.Empty;
        #endregion

        #region Autofill
        [Column("ObjectsAutofill")]
        [Display(Name = "ObjectsAutofill")]
        public int DirectoryObjectsAutofill { get; set; } = -1;

        [Column("DirectorySizeAutofill")]
        [Display(Name = "DirectorySizeAutofill")]
        public long DirectorySizeAutofill { get; set; } = -1;
        #endregion

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
        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_File>? Files { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual DbStorage_QrCode? QrCode { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual DbStorage_Quality? Quality { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectoryMetadataLink>? RootDirectoryMetadataLinks { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_SubDirectory>? SubDirectories { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Authorization_User> AuthorizationUsersIdExt
        {
            get { return AuthorizationUserIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Authorization_User>>(AuthorizationUserIdsExtString) : null; }
            set { AuthorizationUserIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Authorization_UserGroup> AuthorizationUserGroupIdsExt
        {
            get { return AuthorizationUserGroupIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Authorization_UserGroup>>(AuthorizationUserGroupIdsExtString) : null; }
            set { AuthorizationUserGroupIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Notification_User> NotificationUserIdsExt
        {
            get { return NotificationUserIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Notification_User>>(NotificationUserIdsExtString) : null; }
            set { NotificationUserIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Notification_UserGroup> NotificationUserGroupIdsExt
        {
            get { return NotificationUserGroupIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Notification_UserGroup>>(NotificationUserGroupIdsExtString) : null; }
            set { NotificationUserGroupIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? JobIdsExt
        {
            get { return JobIdsExtString != string.Empty ? JobIdsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { JobIdsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? WorkflowItemIdsExt
        {
            get { return WorkflowItemIdsExtString != string.Empty ? WorkflowItemIdsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { WorkflowItemIdsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? BackupIdsExt
        {
            get { return BackupIdsExtString != string.Empty ? BackupIdsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { BackupIdsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }
        #endregion
    }
}
