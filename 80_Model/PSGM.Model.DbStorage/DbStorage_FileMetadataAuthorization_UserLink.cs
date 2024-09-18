using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("FileMetadataAuthorization_UserLink")]
    public class DbStorage_FileMetadataAuthorization_UserLink
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("FileMetadata")]
        public Guid? FileMetadataId { get; set; }
        public virtual DbStorage_FileMetadata? FileMetadata { get; set; }

        [ForeignKey("FileMetadataAuthorization_User")]
        public Guid FileMetadataAuthorization_UserId { get; set; } = Guid.Empty;
        public virtual DbStorage_FileMetadataAuthorization_User? FileMetadataAuthorization_User { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
