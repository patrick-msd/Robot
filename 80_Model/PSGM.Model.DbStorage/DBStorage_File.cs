
using Newtonsoft.Json;
using PSGM.Helper;
using PSGM.Model.DbMain;
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
        [StringLength(127, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Suffix { get; set; } = string.Empty;

        [Column("RawFileIdsString")]
        [Display(Name = "RawFileIdsString")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string RawFileIdsString { get; private set; } = string.Empty;

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        //[Required]
        //[Column("StorageType")]
        //[Display(Name = "StorageType")]
        //public StorageType StorageType { get; set; } = StorageType.Unknown;

        //[Column("StoragePath")]
        //[Display(Name = "StoragePath")]
        //[StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StoragePath { get; set; } = string.Empty;

        //[Column("StorageUrl")]
        //[Display(Name = "StorageUrl")]
        //[StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StorageUrl { get; set; } = string.Empty;

        //[Column("StorageUrlPublic")]
        //[Display(Name = "StorageUrlPublic")]
        //[StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StorageUrlPublic { get; set; } = string.Empty;

        //[Column("StorageEndpoint")]
        //[Display(Name = "StorageEndpoint")]
        //[StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StorageEndpoint { get; set; } = string.Empty;

        //[Column("StorageBucketName")]
        //[Display(Name = "StorageBucketName")]
        //[StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StorageBucketName { get; set; } = string.Empty;

        //[Column("StorageAccessKey")]
        //[Display(Name = "StorageAccessKey")]
        //[StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StorageAccessKey { get; set; } = string.Empty;

        //[Column("StorageSecretKey")]
        //[Display(Name = "StorageSecretKey")]
        //[StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StorageSecretKey { get; set; } = string.Empty;

        //[Column("StorageSecure")]
        //[Display(Name = "StorageSecure")]
        //public bool StorageSecure { get; set; } = true;

        //[Column("StorageLocation")]
        //[Display(Name = "StorageLocation")]
        //[StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string StorageLocation { get; set; } = string.Empty;

        [Column("StorageObjectName")]
        [Display(Name = "StorageObjectName")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectName { get; set; } = string.Empty;

        [Column("StorageObjectUrlPublic")]
        [Display(Name = "StorageObjectUrlPublic")]
        [StringLength(4096, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectUrlPublic { get; set; } = string.Empty;

        [Required]
        [Column("ObjectExtension")]
        [Display(Name = "ObjectExtension")]
        public FileExtension ObjectExtension { get; set; } = FileExtension.Undefined;

        [Required]
        [Column("ObjectSize")]
        [Display(Name = "ObjectSize")]
        /// <summary>
        /// File size in bytes
        /// </summary>
        public long ObjectSize { get; set; } = 0;

        [Column("ObjectMetadataString")]
        [Display(Name = "ObjectMetadataString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ObjectMetadataString { get; private set; } = string.Empty;

        [Column("MachineIdExt")]
        [Display(Name = "MachineIdExt")]
        public Guid MachineIdExt { get; set; } = Guid.Empty;

        [Column("DeviceIdExt")]
        [Display(Name = "DeviceIdExt")]
        public Guid DeviceIdExt { get; set; } = Guid.Empty;

        [Column("JobsIdExtString")]
        [Display(Name = "JobsIdExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string JobsIdExtString { get; private set; } = string.Empty;

        [Column("WorkflowItemExtString")]
        [Display(Name = "WorkflowItemExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string WorkflowItemsExtString { get; private set; } = string.Empty;

        //[Column("AuthorizedUsersExtString")]
        //[Display(Name = "AuthorizedUsersExtString")]
        //[StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string AuthorizedUsersExtString { get; private set; } = string.Empty;

        //[Column("AuthorizedUserGroupsExtString")]
        //[Display(Name = "AuthorizedUserGroupsExtString")]
        //[StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //public string AuthorizedUserGroupsExtString { get; private set; } = string.Empty;

        [Column("BackupsExtString")]
        [Display(Name = "BackupsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string BackupsExtString { get; private set; } = string.Empty;

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
        [InverseProperty("File")]
        public virtual DbStorage_QrCode? QrCode { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileAuthorization_User>? AuthorizationUser { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileAuthorization_UserGroup>? AuthorizationUserGroup { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileNotification_User>? NotificationUser { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileNotification_UserGroup>? NotificationUserGroup { get; set; }
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
        public List<Guid>? JobsIdExt
        {
            get { return JobsIdExtString != string.Empty ? JobsIdExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { JobsIdExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<WorkflowItemLog> WorkflowItemsExt
        {
            get { return WorkflowItemsExtString != string.Empty ? JsonConvert.DeserializeObject<List<WorkflowItemLog>>(WorkflowItemsExtString) : null; }
            set { WorkflowItemsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        //[NotMapped]
        //public List<Guid>? AuthorizedUsersExt
        //{
        //    get { return AuthorizedUsersExtString != string.Empty ? AuthorizedUsersExtString.Split(',').Select(Guid.Parse).ToList() : null; }
        //    set { AuthorizedUsersExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        //}

        //[NotMapped]
        //public List<Guid>? AuthorizedUserGroupsExt
        //{
        //    get { return AuthorizedUserGroupsExtString != string.Empty ? AuthorizedUserGroupsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
        //    set { AuthorizedUserGroupsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        //}

        [NotMapped]
        public List<Guid>? BackupsExt
        {
            get { return BackupsExtString != string.Empty ? BackupsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { BackupsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        public void SetImageMetadata(ImageHelper imageHelper)
        {
            if (imageHelper != null)
            {
                ImageHelper imageHelperTemp = new ImageHelper()
                {
                    FileId = imageHelper.FileId,
                    FileRawIds = imageHelper.FileRawIds,

                    ExposureTime = imageHelper.ExposureTime,
                    DateDigitized = imageHelper.DateDigitized,

                    CameraDeviceId = imageHelper.CameraDeviceId
                };

                ObjectMetadataString = JsonConvert.SerializeObject(imageHelperTemp);
            }
            else
            {
                ObjectMetadataString = string.Empty;
            }
        }

        public ImageHelper GetImageMetadata()
        {
            return ObjectMetadataString != string.Empty ? JsonConvert.DeserializeObject<ImageHelper>(ObjectMetadataString) : null;
        }
        #endregion
    }
}
