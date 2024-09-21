using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectory_Metadata_Authorization_User_Link")]
    public class DbStorage_SubDirectory_Metadata_Authorization_User_Link
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
        public virtual DbStorage_SubDirectory_Metadata? Metadata { get; set; }

        [ForeignKey("AuthorizationUser")]
        public Guid AuthorizationUserId { get; set; } = Guid.Empty;
        public virtual DbStorage_SubDirectory_Metadata_Authorization_User? AuthorizationUser { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
