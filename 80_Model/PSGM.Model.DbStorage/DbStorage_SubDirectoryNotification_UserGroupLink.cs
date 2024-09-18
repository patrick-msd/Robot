using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectoryNotification_UserGroupLink")]
    public class DbStorage_SubDirectoryNotification_UserGroupLink
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

        [ForeignKey("SubDirectoryNotification_UserGroup")]
        public Guid SubDirectoryNotification_UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_SubDirectoryNotification_UserGroup? SubDirectoryNotification_UserGroup { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
