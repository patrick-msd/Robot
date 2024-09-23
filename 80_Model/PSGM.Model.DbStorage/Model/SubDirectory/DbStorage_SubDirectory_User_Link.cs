using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectory_User_Link")]
    public class DbStorage_SubDirectory_User_Link
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

        [ForeignKey("User")]
        public Guid? UserId { get; set; } = Guid.Empty;
        public virtual DbStorage_SubDirectory_User? User { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
