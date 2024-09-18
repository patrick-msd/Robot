using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectoryMetadataAuthorization_UserGroupLink")]
    public class DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink
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
        [ForeignKey("RootDirectoryMetadata")]
        public Guid? RootDirectoryMetadataId { get; set; }
        public virtual DbStorage_RootDirectoryMetadata? RootDirectoryMetadata { get; set; }

        [ForeignKey("RootDirectoryMetadataAuthorization_UserGroup")]
        public Guid RootDirectoryMetadataAuthorization_UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_RootDirectoryMetadataAuthorization_UserGroup? RootDirectoryMetadataAuthorization_UserGroup { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
