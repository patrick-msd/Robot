using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("OrganizationAuthorization_UserGroup")]
    public class DbMain_OrganizationAuthorization_UserGroup
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
        [Column("UserGroupIdExt")]
        [Display(Name = "UserGroupIdExt")]
        public Guid UserGroupIdExt { get; set; } = Guid.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Organization")]
        public Guid? OrganizationId { get; set; }
        public virtual DbMain_Organization? Organization { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
