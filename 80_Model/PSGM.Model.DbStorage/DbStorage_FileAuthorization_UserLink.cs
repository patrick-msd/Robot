using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("FileAuthorization_UserLink")]
    public class DbStorage_FileAuthorization_UserLink
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

        [ForeignKey("FileAuthorization_User")]
        public Guid FileAuthorization_UserId { get; set; } = Guid.Empty;
        public virtual DbStorage_FileAuthorization_User? FileAuthorization_User { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
