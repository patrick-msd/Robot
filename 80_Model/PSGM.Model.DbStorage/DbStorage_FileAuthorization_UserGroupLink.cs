using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("FileAuthorization_UserGroupLink")]
    public class DbStorage_FileAuthorization_UserGroupLink
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
        [ForeignKey("File")]
        public Guid? FileId { get; set; }
        public virtual DbStorage_File? File { get; set; }

        [ForeignKey("FileAuthorization_UserGroup")]
        public Guid FileAuthorization_UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_FileAuthorization_UserGroup? FileAuthorization_UserGroup { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
