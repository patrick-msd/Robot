using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("FileNotification_UserGroupLink")]
    public class DbStorage_FileNotification_UserGroupLink
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

        [ForeignKey("FileNotification_UserGroup")]
        public Guid FileNotification_UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_FileNotification_UserGroup? FileNotification_UserGroup { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
