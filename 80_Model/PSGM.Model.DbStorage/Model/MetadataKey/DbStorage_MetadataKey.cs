﻿using Newtonsoft.Json;
using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("MetadataKey")]
    public class DbStorage_MetadataKey
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        //[Required]
        //[Column("Key")]
        //[Display(Name = "Key")]
        //[StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string Key { get; set; } = string.Empty;

        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

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
        [InverseProperty("Key")]
        public virtual ICollection<DbStorage_File_Metadata>? FileMetadata { get; set; }

        [InverseProperty("MetadataKey")]
        public virtual ICollection<DbStorage_MetadataKey_User_Link>? UserLinks { get; set; }

        [InverseProperty("MetadataKey")]
        public virtual ICollection<DbStorage_MetadataKey_UserGroup_Link>? UserGroupLinks { get; set; }

        [InverseProperty("Key")]
        public virtual ICollection<DbStorage_RootDirectory_Metadata>? RootDirectoryMetadata { get; set; }

        [InverseProperty("Key")]
        public virtual ICollection<DbStorage_SubDirectory_Metadata>? SubDirectoryMetadata { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        #endregion
    }
}
