
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

        [Column("RawFileIdsString")]
        [Display(Name = "RawFileIdsString")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string RawFileIdsString { get; private set; } = string.Empty;

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

        [Required]
        [Column("ObjectExtension")]
        [Display(Name = "ObjectExtension")]
        public FileExtension ObjectExtension { get; set; } = FileExtension.Undefined;

        [Required]
        [Column("ObjectSize")]
        [Display(Name = "ObjectSize")]
        public long ObjectSize { get; set; } = 0;

        [Column("StorageObjectName")]
        [Display(Name = "StorageObjectName")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectName { get; set; } = string.Empty;

        [Column("StorageObjectUrl")]
        [Display(Name = "StorageObjectUrl")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectUrl { get; set; } = string.Empty;

        [Column("StorageObjectUrlPublic")]
        [Display(Name = "StorageObjectUrlPublic")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectUrlPublic { get; set; } = string.Empty;

        [Column("AuthorizationUserIdsExtString")]
        [Display(Name = "AuthorizationUserIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AuthorizationUserIdsExtString { get; private set; } = string.Empty;

        [Column("AuthorizationUserGroupIdsExtString")]
        [Display(Name = "AuthorizationUserGroupIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string AuthorizationUserGroupIdsExtString { get; private set; } = string.Empty;

        [Column("NotificationUserIdsExtString")]
        [Display(Name = "NotificationUserIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string NotificationUserIdsExtString { get; private set; } = string.Empty;

        [Column("NotificationUserGroupIdsExtString")]
        [Display(Name = "NotificationUserGroupIdsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string NotificationUserGroupIdsExtString { get; private set; } = string.Empty;

        [Column("ObjectMetadataString")]
        [Display(Name = "ObjectMetadataString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ObjectMetadataString { get; private set; } = string.Empty;

        [Column("ExtId1")]
        [Display(Name = "ExtId1")]
        public string ExtId1 { get; set; } = string.Empty;

        [Column("ExtId2")]
        [Display(Name = "ExtId2")]
        public string ExtId2 { get; set; } = string.Empty;

        [Column("ExtId3")]
        [Display(Name = "ExtId3")]
        public string ExtId3 { get; set; } = string.Empty;

        [Column("ExtId4")]
        [Display(Name = "ExtId4")]
        public string ExtId4 { get; set; } = string.Empty;

        [Column("ExtId5")]
        [Display(Name = "ExtId5")]
        public string ExtId5 { get; set; } = string.Empty;

        [Column("ExtId6")]
        [Display(Name = "ExtId6")]
        public string ExtId6 { get; set; } = string.Empty;

        [Column("ExtId7")]
        [Display(Name = "ExtId7")]
        public string ExtId7 { get; set; } = string.Empty;

        [Column("ExtId8")]
        [Display(Name = "ExtId8")]
        public string ExtId8 { get; set; } = string.Empty;

        [Column("ExtId9")]
        [Display(Name = "ExtId9")]
        public string ExtId9 { get; set; } = string.Empty;

        [Column("ExtId10")]
        [Display(Name = "ExtId10")]
        public string ExtId10 { get; set; } = string.Empty;

        [Column("MachineIdExt")]
        [Display(Name = "MachineIdExt")]
        public Guid MachineIdExt { get; set; } = Guid.Empty;

        [Column("DeviceIdExt")]
        [Display(Name = "DeviceIdExt")]
        public Guid DeviceIdExt { get; set; } = Guid.Empty;

        #region No direct access
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
        public virtual ICollection<DbStorage_FileMetadataLink>? FileMetadataLinks { get; set; }

        [InverseProperty("File")]
        public virtual DbStorage_QrCode? QrCode { get; set; }
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
        public List<Authorization_User> AuthorizationUsersIdExt
        {
            get { return AuthorizationUserIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Authorization_User>>(AuthorizationUserIdsExtString) : null; }
            set { AuthorizationUserIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Authorization_UserGroup> AuthorizationUserGroupIdsExt
        {
            get { return AuthorizationUserGroupIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Authorization_UserGroup>>(AuthorizationUserGroupIdsExtString) : null; }
            set { AuthorizationUserGroupIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Notification_User> NotificationUserIdsExt
        {
            get { return NotificationUserIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Notification_User>>(NotificationUserIdsExtString) : null; }
            set { NotificationUserIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
        }

        [NotMapped]
        public List<Notification_UserGroup> NotificationUserGroupIdsExt
        {
            get { return NotificationUserGroupIdsExtString != string.Empty ? JsonConvert.DeserializeObject<List<Notification_UserGroup>>(NotificationUserGroupIdsExtString) : null; }
            set { NotificationUserGroupIdsExtString = value != null ? JsonConvert.SerializeObject(value) : string.Empty; }
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


        //public DbStorage_File GetAuditLogs()
        //{



        //    return LastModificationChangesAutoFill != string.Empty ? JsonConvert.DeserializeObject<DbStorage_File>(LastModificationChangesAutoFill) : null;
        //}





        #endregion
    }
}
