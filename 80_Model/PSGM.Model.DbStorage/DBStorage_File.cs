
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

        [Column("StorageObjectName")]
        [Display(Name = "StorageObjectName")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectName { get; set; } = string.Empty;

        [Column("StorageObjectUrl")]
        [Display(Name = "StorageObjectUrl")]
        [StringLength(4096, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string StorageObjectUrl { get; set; } = string.Empty;

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

        [Column("LastModificationChangesAutoFill")]
        [Display(Name = "LastModificationChangesAutoFill")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastModificationChangesAutoFill { get; set; } = string.Empty;
        #endregion
        #endregion

        #region Links
        [InverseProperty("File")]
        public virtual ICollection<DbStorage_QrCode>? Metadata { get; set; }

        [InverseProperty("File")]
        public virtual DbStorage_QrCode? QrCode { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileAuthorization_User>? AuthorizationUsers { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileAuthorization_UserGroup>? AuthorizationUserGroups { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileNotification_User>? NotificationUsers { get; set; }

        [InverseProperty("File")]
        public virtual ICollection<DbStorage_FileNotification_UserGroup>? NotificationUserGroups { get; set; }
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
