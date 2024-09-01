using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorageStructure
{
    [Table("ProjectParameterStorage")]
    public class DbStorageStructure_ProjectStorage
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("DatabaseType")]
        [Display(Name = "DatabaseType")]
        public DatabaseType DatabaseType { get; set; } = DatabaseType.Undefined;

        [Column("DatabaseFilePath")]
        [Display(Name = "DatabaseFilePath")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DatabaseFilePath { get; set; } = string.Empty;

        [Column("DatabaseConnectionString")]
        [Display(Name = "DatabaseConnectionString")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DatabaseConnectionString { get; set; } = string.Empty;

        [Column("StorageType")]
        [Display(Name = "StorageType")]
        public StorageType StorageType { get; set; } = StorageType.Unknown;

        [Column("StorageClass")]
        [Display(Name = "StorageClass")]
        public StorageClass StorageClass { get; set; } = StorageClass.Unknown;

        [Column("StorageTier")]
        [Display(Name = "StorageTier")]
        public StorageTier StorageTier { get; set; } = StorageTier.Unknown;        

        [Column("StorageFilePath")]
        [Display(Name = "StorageFilePath")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageFilePath { get; set; } = string.Empty;

        [Column("StorageS3Endpoint")]
        [Display(Name = "StorageS3Endpoint")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageS3Endpoint { get; set; } = string.Empty;

        [Column("StorageS3BucketName")]
        [Display(Name = "StorageS3BucketName")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageS3BucketName { get; set; } = string.Empty;

        [Column("StorageS3AccessKey")]
        [Display(Name = "StorageS3AccessKey")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageS3AccessKey { get; set; } = string.Empty;

        [Column("StorageS3SecretKey")]
        [Display(Name = "StorageS3SecretKey")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageS3SecretKey { get; set; } = string.Empty;

        [Column("StorageS3Secure")]
        [Display(Name = "StorageS3Secure")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public bool StorageS3Secure { get; set; } = true;

        [Column("StorageS3Region")]
        [Display(Name = "StorageS3Region")]
        [StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageS3Region { get; set; } = string.Empty;

        [Column("Url")]
        [Display(Name = "Url")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Url { get; set; } = string.Empty;

        [Column("UrlPublic")]
        [Display(Name = "UrlPublic")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string UrlPublic { get; set; } = string.Empty;

        [Column("ReadOnlyMode")]
        [Display(Name = "ReadOnlyMode")]
        public bool ReadOnlyMode { get; set; } = true;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbStorageStructure_Project? Project { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
