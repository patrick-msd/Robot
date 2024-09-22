using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization_EmployeeGroup_Link")]
    public class DbMain_Organization_EmployeeGroup_Link
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
        [ForeignKey("Organization")]
        public Guid? OrganizationId { get; set; }
        public virtual DbMain_Organization? Organization { get; set; }

        [ForeignKey("EmployeeGroup")]
        public Guid? EmployeeGroupId { get; set; } = Guid.Empty;
        public virtual DbMain_Organization_EmployeeGroup? EmployeeGroup { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
