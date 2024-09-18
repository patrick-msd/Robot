using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("DbStorage_SubDirectoryMetadataAuthorization_UserLink")]
    public class DbStorage_SubDirectoryMetadataAuthorization_UserLink
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
        [ForeignKey("SubDirectoryMetadata")]
        public Guid? SubDirectoryMetadataId { get; set; }
        public virtual DbStorage_SubDirectoryMetadata? SubDirectoryMetadata { get; set; }

        [ForeignKey("SubDirectoryMetadataAuthorization_User")]
        public Guid SubDirectoryMetadataAuthorization_UserId { get; set; } = Guid.Empty;
        public virtual DbStorage_SubDirectoryMetadataAuthorization_User? SubDirectoryMetadataAuthorization_User { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
