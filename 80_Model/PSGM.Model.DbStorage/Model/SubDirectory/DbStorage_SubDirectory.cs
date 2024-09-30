using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectory")]
    public class DbStorage_SubDirectory
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
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
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
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
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

        [Column("Locked")]
        [Display(Name = "Locked")]
        public bool Locked { get; set; } = false;

        [Column("LockedDescription")]
        [Display(Name = "LockedDescription")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LockedDescription { get; set; } = string.Empty;

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
        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory_Archive_Link>? ArchiveLinks { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory_Job_Link>? JobLinks { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_File>? Files { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual DbStorage_SubDirectory_QrCode? QrCode { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual DbStorage_SubDirectory_Quality? Quality { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory_Metadata_Link>? MetadataLinks { get; set; }

        [InverseProperty("ParentSubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory>? SubDirectories { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory_User_Link>? UserLinks { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory_UserGroup_Link>? UserGroupLinks { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory_VirtualUnit>? VirtualUnits { get; set; }

        [InverseProperty("SubDirectory")]
        public virtual ICollection<DbStorage_SubDirectory_Workflow_Link>? WorkflowLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("RootDirectory")]
        public Guid? RootDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }

        [ForeignKey("ParentSubDirectory")]
        public Guid? ParentSubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? ParentSubDirectory { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
