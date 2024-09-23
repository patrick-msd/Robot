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

        [Column("DirectoryState")]
        [Display(Name = "DirectoryState")]
        public DirectoryState DirectoryState { get; set; } = DirectoryState.Undefined;

        [Column("DirectoryLocked")]
        [Display(Name = "DirectoryLocked")]
        public bool DirectoryLocked { get; set; } = false;

        #region No direct access
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
        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_File>? Files { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual DbStorage_RootDirectory_QrCode? QrCode { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual DbStorage_RootDirectory_Quality? Quality { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectory_Metadata_Link>? MetadataLinks { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_SubDirectory>? SubDirectories { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectory_User_Link>? UserLinks { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectory_UserGroup_Link>? UserGroupLinks { get; set; }

        [InverseProperty("RootDirectory")]
        public virtual ICollection<DbStorage_RootDirectory_VirtualRootUnit>? VirtualRootUnits { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
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

        [NotMapped]
        public List<Guid>? ArchiveIds_Ext
        {
            get { return ArchiveIds_ExtString != string.Empty ? ArchiveIds_ExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { ArchiveIds_ExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }
        #endregion
    }
}
