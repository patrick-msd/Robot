
using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("File")]
    public class DbStorage_File
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

        [Column("Stars")]
        [Display(Name = "Stars")]
        public int Stars { get; set; } = -1;

        [Column("Order")]
        [Display(Name = "Order")]
        public int Order { get; set; } = -1;

        [Required]
        [Column("ObjectExtension")]
        [Display(Name = "ObjectExtension")]
        public FileExtension ObjectExtension { get; set; } = FileExtension.Undefined;

        [Required]
        [Column("ObjectSize")]
        [Display(Name = "ObjectSize")]
        public long ObjectSize { get; set; } = -1;

        [Column("StorageObjectName")]
        [Display(Name = "StorageObjectName")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectName { get; set; } = string.Empty;

        [Column("StorageObjectVersion")]
        [Display(Name = "StorageObjectVersion")]
        public int StorageObjectVersion { get; set; } = 0;

        [Column("StorageObjectUrl")]
        [Display(Name = "StorageObjectUrl")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectUrl { get; set; } = string.Empty;

        [Column("StorageObjectUrlPublic")]
        [Display(Name = "StorageObjectUrlPublic")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectUrlPublic { get; set; } = string.Empty;

        [Column("ExtId1")]
        [Display(Name = "ExtId1")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId1 { get; set; } = string.Empty;

        [Column("ExtId2")]
        [Display(Name = "ExtId2")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId2 { get; set; } = string.Empty;

        [Column("ExtId3")]
        [Display(Name = "ExtId3")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId3 { get; set; } = string.Empty;

        [Column("ExtId4")]
        [Display(Name = "ExtId4")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId4 { get; set; } = string.Empty;

        [Column("ExtId5")]
        [Display(Name = "ExtId5")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId5 { get; set; } = string.Empty;

        [Column("ExtId6")]
        [Display(Name = "ExtId6")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId6 { get; set; } = string.Empty;

        [Column("ExtId7")]
        [Display(Name = "ExtId7")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId7 { get; set; } = string.Empty;

        [Column("ExtId8")]
        [Display(Name = "ExtId8")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId8 { get; set; } = string.Empty;

        [Column("ExtId9")]
        [Display(Name = "ExtId9")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId9 { get; set; } = string.Empty;

        [Column("ExtId10")]
        [Display(Name = "ExtId10")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ExtId10 { get; set; } = string.Empty;

        [Column("MachineIdExt")]
        [Display(Name = "MachineIdExt")]
        public Guid MachineIdExt { get; set; } = Guid.Empty;

        [Column("DeviceIdExt")]
        [Display(Name = "DeviceIdExt")]
        public Guid DeviceIdExt { get; set; } = Guid.Empty;

        [Column("SoftwareIdExt")]
        [Display(Name = "SoftwareIdExt")]
        public Guid SoftwareIdExt { get; set; } = Guid.Empty;

        #region No direct access
        [Column("RawFileIdsString")]
        [Display(Name = "RawFileIdsString")]
        [StringLength(2048, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string RawFileIdsString { get; private set; } = string.Empty;

        [Column("JobIdsExtString")]
        [Display(Name = "JobIdsExtString")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string JobIdsExtString { get; private set; } = string.Empty;

        [Column("WorkflowItemIdsExtString")]
        [Display(Name = "WorkflowItemIdsExtString")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string WorkflowItemIdsExtString { get; private set; } = string.Empty;

        [Column("BackupIdsExtString")]
        [Display(Name = "BackupIdsExtString")]
        [StringLength(32766, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string BackupIdsExtString { get; private set; } = string.Empty;
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
        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileAuthorization_UserLink>? Authorization_UserLinks { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileAuthorization_UserGroupLink>? Authorization_UserGroupLinks { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileMetadataLink>? MetadataLinks { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileNotification_UserLink>? Notification_UserLinks { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileNotification_UserGroupLink>? Notification_UserGroupLinks { get; set; }

        [InverseProperty("File")]
        public virtual DbStorage_QrCode? QrCode { get; set; }

        [InverseProperty("File")]
        public virtual DbStorage_Quality? Quality { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("RootDirectory")]
        public Guid? RootDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }

        [ForeignKey("SubDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? SubDirectory { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Guid>? RawFileIds
        {
            get { return RawFileIdsString != string.Empty ? RawFileIdsString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { RawFileIdsString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? JobIdsExt
        {
            get { return JobIdsExtString != string.Empty ? JobIdsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { JobIdsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid> WorkflowItemIdsExt
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
