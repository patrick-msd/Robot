using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectoryMetadataAuthorization_UserLink")]
    public class DbStorage_RootDirectoryMetadataAuthorization_UserLink
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

        [ForeignKey("RootDirectoryMetadataAuthorization_User")]
        public Guid RootDirectoryMetadataAuthorization_UserId { get; set; } = Guid.Empty;
        public virtual DbStorage_RootDirectoryMetadataAuthorization_User? RootDirectoryMetadataAuthorization_User { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
