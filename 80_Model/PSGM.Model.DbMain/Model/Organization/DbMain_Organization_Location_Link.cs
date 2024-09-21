using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization_Location_Link")]
    public class DbMain_Organization_Location_Link
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

        [ForeignKey("Location")]
        public Guid LocationId { get; set; } = Guid.Empty;
        public virtual DbMain_Location? Location { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
