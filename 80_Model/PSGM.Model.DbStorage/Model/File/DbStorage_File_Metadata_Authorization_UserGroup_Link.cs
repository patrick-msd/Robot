using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("File_Metadata_Authorization_UserGroup_Link")]
    public class DbStorage_File_Metadata_Authorization_UserGroup_Link
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
        [ForeignKey("Metadata")]
        public Guid? MetadataId { get; set; }
        public virtual DbStorage_File_Metadata? Metadata { get; set; }

        [ForeignKey("AuthorizationUserGroup")]
        public Guid AuthorizationUserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_File_Metadata_Authorization_UserGroup? AuthorizationUserGroup { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
