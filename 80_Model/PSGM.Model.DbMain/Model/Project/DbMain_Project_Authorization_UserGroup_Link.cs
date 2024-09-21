using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Project_Authorization_UserGroup_Link")]
    public class DbMain_Project_Authorization_UserGroup_Link
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
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbMain_Project? Project { get; set; }

        [ForeignKey("AuthorizationUserGroup")]
        public Guid? AuthorizationUserGroupId { get; set; } = Guid.Empty;
        public virtual DbMain_Project_Authorization_UserGroup? AuthorizationUserGroup { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
