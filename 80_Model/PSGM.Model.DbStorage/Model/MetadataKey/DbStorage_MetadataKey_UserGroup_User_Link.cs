using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("MetadataKey_UserGroup_User_Link")]
    public class DbStorage_MetadataKey_UserGroup_User_Link
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
        [ForeignKey("UserGroup")]
        public Guid? UserGroupId { get; set; }
        public virtual DbStorage_MetadataKey_UserGroup? UserGroup { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; } = Guid.Empty;
        public virtual DbStorage_MetadataKey_UserGroup_User? User { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
