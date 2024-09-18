using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectoryNotification_UserGroupLink")]
    public class DbStorage_RootDirectoryNotification_UserGroupLink
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
        [ForeignKey("RootDirectory")]
        public Guid? RootDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }

        [ForeignKey("RootDirectoryNotification_UserGroup")]
        public Guid RootDirectoryNotification_UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_RootDirectoryNotification_UserGroup? RootDirectoryNotification_UserGroup { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
