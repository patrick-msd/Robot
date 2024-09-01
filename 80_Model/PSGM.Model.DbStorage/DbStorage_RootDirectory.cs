using PSGM.Model.DbMain;
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
        [StringLength(127, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Suffix { get; set; } = string.Empty;

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("Objects")]
        [Display(Name = "Objects")]
        public long Objects { get; set; } = 0;

        [Column("DirectorySize")]
        [Display(Name = "DirectorySize")]
        public long DirectorySize { get; set; } = 0;

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

        [Column("LastModificationChanges")]
        [Display(Name = "LastModificationChanges")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastModificationChanges { get; set; } = string.Empty;
        #endregion
        #endregion

        #region Links
        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_File>? Files { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_SubDirectory>? SubDirectories { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectoryAuthorization_User>? AuthorizationUser { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectoryAuthorization_UserGroup>? AuthorizationUserGroup { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectoryNotification_User>? NotificationUser { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectoryNotification_UserGroup>? NotificationUserGroup { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
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
