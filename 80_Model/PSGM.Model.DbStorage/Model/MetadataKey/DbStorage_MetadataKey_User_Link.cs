using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("MetadataKey_User_Link")]
    public class DbStorage_MetadataKey_User_Link
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
        [ForeignKey("MetadataKey")]
        public Guid? MetadataKeyId { get; set; }
        public virtual DbStorage_MetadataKey? MetadataKey { get; set; }

        [ForeignKey("User")]
        public Guid? UserId { get; set; } = Guid.Empty;
        public virtual DbStorage_MetadataKey_User? User { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
