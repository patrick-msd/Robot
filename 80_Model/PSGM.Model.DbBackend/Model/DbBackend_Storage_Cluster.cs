using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbBackend
{
    [Table("Storage_Cluster")]
    public class DbBackend_Storage_Cluster
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("BranchNumber")]
        [Display(Name = "BranchNumber")]
        public int BranchNumber { get; set; } = 0;

        [Column("Domain")]
        [Display(Name = "Domain")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Domain { get; set; } = string.Empty;

        [Column("Stars")]
        [Display(Name = "Stars")]
        public int Stars { get; set; } = -1;

        [Column("Order")]
        [Display(Name = "Order")]
        public int Order { get; set; } = -1;

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

        [Column("ReadOnlyMode")]
        [Display(Name = "ReadOnlyMode")]
        public bool ReadOnlyMode { get; set; } = false;

        [Column("Locked")]
        [Display(Name = "Locked")]
        public bool Locked { get; set; } = false;

        [Column("LockedDescription")]
        [Display(Name = "LockedDescription")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LockedDescription { get; set; } = string.Empty;

        [Column("Url")]
        [Display(Name = "Url")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Url { get; set; } = string.Empty;

        [Column("UrlPublic")]
        [Display(Name = "UrlPublic")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string UrlPublic { get; set; } = string.Empty;

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
        [InverseProperty("Cluster")]
        public virtual ICollection<DbBackend_Storage_Server>? StorageServers { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Backend")]
        public Guid? BackendId { get; set; }
        public virtual DbBackend_Backend? Backend { get; set; }
        #endregion

        #region Not Mapped
        public string GetStorageS3Endpoint(bool withBranch = true)
        {
            if (this.Backend is not null)
            {
                if (withBranch)
                {
                    return $"s3-{Enum.GetName(typeof(BackendType), this.Backend.BackendType).ToLower()}-{this.Id.ToString()}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                }
                else
                {
                    return $"s3-{Enum.GetName(typeof(BackendType), this.Backend.BackendType).ToLower()}-{this.Id.ToString()}.{this.Domain}";
                }
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
