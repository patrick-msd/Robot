
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

        [Column("MachineId_Ext")]
        [Display(Name = "MachineId_Ext")]
        public Guid MachineId_Ext { get; set; } = Guid.Empty;

        [Column("DeviceId_Ext")]
        [Display(Name = "DeviceId_Ext")]
        public Guid DeviceId_Ext { get; set; } = Guid.Empty;

        [Column("SoftwareId_Ext")]
        [Display(Name = "SoftwareId_Ext")]
        public Guid SoftwareId_Ext { get; set; } = Guid.Empty;

        #region No direct access
        [Column("RawFileIdsString")]
        [Display(Name = "RawFileIdsString")]
        [StringLength(2048, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string RawFileIdsString { get; private set; } = string.Empty;

        [Column("ArchiveIds_ExtString")]
        [Display(Name = "ArchiveIds_ExtString")]
        [StringLength(32766, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ArchiveIds_ExtString { get; private set; } = string.Empty;

        [Column("JobIdsExt_String")]
        [Display(Name = "JobIdsExt_String")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string JobIdsExt_String { get; private set; } = string.Empty;

        [Column("WorkflowItemIds_ExtString")]
        [Display(Name = "WorkflowItemIds_ExtString")]
        [StringLength(65532, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string WorkflowItemIds_ExtString { get; private set; } = string.Empty;
        #endregion

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
        [InverseProperty("File")]
        public virtual ICollection<DbStorage_File_Metadata_Link>? MetadataLinks { get; set; }

        [InverseProperty("File")]
        public virtual DbStorage_File_QrCode? QrCode { get; set; }

        [InverseProperty("File")]
        public virtual DbStorage_File_Quality? Quality { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_File_User_Link>? UserLinks { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_File_UserGroup_Link>? UserGroupLinks { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_File_VirtualUnit>? VirtualUnits { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("RootDirectory")]
        public Guid? RootDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }

        [ForeignKey("SubDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? SubDirectory { get; set; }
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Guid>? RawFileIds
        {
            get { return RawFileIdsString != string.Empty ? RawFileIdsString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { RawFileIdsString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? ArchiveIds_Ext
        {
            get { return ArchiveIds_ExtString != string.Empty ? ArchiveIds_ExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { ArchiveIds_ExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? JobIds_Ext
        {
            get { return JobIdsExt_String != string.Empty ? JobIdsExt_String.Split(',').Select(Guid.Parse).ToList() : null; }
            set { JobIdsExt_String = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? WorkflowItemIds_Ext
        {
            get { return WorkflowItemIds_ExtString != string.Empty ? WorkflowItemIds_ExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { WorkflowItemIds_ExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }
        #endregion
    }
}
