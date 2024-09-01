using PSGM.Helper;
using PSGM.Model.DbStorage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("SubDirectoryAuthorization_User")]
    public class DbStorage_SubDirectoryAuthorization_User
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(16384, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("Permissions")]
        [Display(Name = "Permissions")]
        public PermissionsType Permissions { get; set; } = PermissionsType.None;

        [Required]
        [Column("UserIdExt")]
        [Display(Name = "UserIdExt")]
        public Guid UserIdExt { get; set; } = Guid.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("SubDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? SubDirectory { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
