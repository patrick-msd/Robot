using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("File_VirtualSubUnit_UserGroup_Link")]
    public class DbStorage_File_VirtualSubUnit_UserGroup_Link
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
        [ForeignKey("VirtualSubUnit")]
        public Guid? VirtualSubUnitId { get; set; }
        public virtual DbStorage_File_VirtualSubUnit? VirtualSubUnit { get; set; }

        [ForeignKey("UserGroup")]
        public Guid? UserGroupId { get; set; } = Guid.Empty;
        public virtual DbStorage_File_VirtualSubUnit_UserGroup? UserGroup { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
