using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbBackend
{
    [Table("Structure")]
    public class DbBackend_Cluster
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

        [Column("ClusterNumber")]
        [Display(Name = "ClusterNumber")]
        public int ClusterNumber { get; set; } = 0;

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

        [Column("BackendType")]
        [Display(Name = "BackendType")]
        public BackendType BackendType { get; set; } = BackendType.Undefined;

        [Column("DatabaseType")]
        [Display(Name = "DatabaseType")]
        public DatabaseType DatabaseType { get; set; } = DatabaseType.Undefined;

        [Column("DatabaseFilePath")]
        [Display(Name = "DatabaseFilePath")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DatabaseFilePath { get; set; } = string.Empty;

        [Column("DatabasePort")]
        [Display(Name = "DatabasePort")]
        public int DatabasePort { get; set; } = 0;

        [Column("DatabaseUsername")]
        [Display(Name = "DatabaseUsername")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DatabaseUsername { get; set; } = string.Empty;

        [Column("DatabasePassword")]
        [Display(Name = "DatabasePassword")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DatabasePassword { get; set; } = string.Empty;

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
        public virtual ICollection<DbBackend_Server>? Server { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbBackend_Project? Project { get; set; }
        #endregion

        #region Not Mapped
        public string GetDatabaseConnectionStringWithoutBranch()
        {
            if (this.Project is not null)
            {
                if (this.StorageClass == StorageClass.Data || this.StorageClass == StorageClass.DataThumbnail || this.StorageClass == StorageClass.DataAndDataThumbnail)
                {
                    string host = $"{this.Project.Id}-db-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
                else if (this.StorageClass == StorageClass.DataRaw || this.StorageClass == StorageClass.DataRawThumbnail || this.StorageClass == StorageClass.DataRawAndDataRawThumbnail)
                {
                    string host = $"{this.Project.Id}-db-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
                else if (this.StorageClass == StorageClass.DataTranscription)
                {
                    string host = $"{this.Project.Id}-db-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
                else
                {
                    string host = $"{Enum.GetName(typeof(BackendType), this.BackendType).ToLower()}-db-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetDatabaseConnectionStringWithBranch()
        {
            if (this.Project is not null)
            {
                if (this.StorageClass == StorageClass.Data || this.StorageClass == StorageClass.DataThumbnail || this.StorageClass == StorageClass.DataAndDataThumbnail)
                {
                    string host = $"{this.Project.Id}-db-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
                else if (this.StorageClass == StorageClass.DataRaw || this.StorageClass == StorageClass.DataRawThumbnail || this.StorageClass == StorageClass.DataRawAndDataRawThumbnail)
                {
                    string host = $"{this.Project.Id}-db-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
                else if (this.StorageClass == StorageClass.DataTranscription)
                {
                    string host = $"{this.Project.Id}-db-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
                else
                {
                    string host = $"{Enum.GetName(typeof(BackendType), this.BackendType).ToLower()}-db-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                    string database = Enum.GetName(typeof(BackendType), this.BackendType);

                    return $"Host={host}:{this.DatabasePort};Database=Db{database}_{this.Project.Id};Username={this.DatabaseUsername};Password={this.DatabasePassword}";
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetStorageS3EndpointWithoutBranch()
        {
            if (this.Project is not null)
            {
                if (this.StorageClass == StorageClass.Data || this.StorageClass == StorageClass.DataThumbnail || this.StorageClass == StorageClass.DataAndDataThumbnail)
                {
                    return $"{this.Project.Id}-s3-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                }
                else if (this.StorageClass == StorageClass.DataRaw || this.StorageClass == StorageClass.DataRawThumbnail || this.StorageClass == StorageClass.DataRawAndDataRawThumbnail)
                {
                    return $"{this.Project.Id}-s3-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                }
                else if (this.StorageClass == StorageClass.DataTranscription)
                {
                    return $"{this.Project.Id}-s3-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                }
                else
                {
                    return $"{Enum.GetName(typeof(BackendType), BackendType.Main).ToLower()}-s3-clu{this.ClusterNumber.ToString("D3")}.{this.Domain}";
                }
            }
            else
            {
                return string.Empty;
            }
        }

        public string GetStorageS3EndpointWithBranch()
        {
            if (this.Project is not null)
            {
                if (this.StorageClass == StorageClass.Data || this.StorageClass == StorageClass.DataThumbnail || this.StorageClass == StorageClass.DataAndDataThumbnail)
                {
                    return $"{this.Project.Id}-s3-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                }
                else if (this.StorageClass == StorageClass.DataRaw || this.StorageClass == StorageClass.DataRawThumbnail || this.StorageClass == StorageClass.DataRawAndDataRawThumbnail)
                {
                    return $"{this.Project.Id}-s3-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                }
                else if (this.StorageClass == StorageClass.DataTranscription)
                {
                    return $"{this.Project.Id}-s3-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
                }
                else
                {
                    return $"{Enum.GetName(typeof(BackendType), BackendType.Main).ToLower()}-s3-clu{this.ClusterNumber.ToString("D3")}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}";
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
