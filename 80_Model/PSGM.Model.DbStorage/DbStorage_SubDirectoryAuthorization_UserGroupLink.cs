using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectoryAuthorization_UserGroupLink")]
    public class DbStorage_SubDirectoryAuthorization_UserGroupLink
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
        [ForeignKey("SubDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? SubDirectory { get; set; }

        [ForeignKey("SubDirectoryAuthorization_UserGroup")]
        public Guid SubDirectoryAuthorization_UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_SubDirectoryAuthorization_UserGroup? SubDirectoryAuthorization_UserGroup { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
