using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectoryMetadataAuthorization_UserGroupLink")]
    public class DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink
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

        [ForeignKey("SubDirectoryMetadataAuthorization_UserGroup")]
        public Guid SubDirectoryMetadataAuthorization_UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_SubDirectoryMetadataAuthorization_UserGroup? SubDirectoryMetadataAuthorization_UserGroup { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
