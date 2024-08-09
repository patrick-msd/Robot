using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectoryParameter")]
    public class DbStorage_RootDirectoryParameter
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        #endregion

        #region Links
        [InverseProperty("RootDirectoryParameter")]
        public virtual ICollection<DbStorage_RootDirectoryParameterStorage>? Storages { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("RootDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
