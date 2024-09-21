using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Location_Address_Link")]
    public class DbMain_Location_Address_Link
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
        [ForeignKey("Address")]
        public Guid? AddressId { get; set; }
        public virtual DbMain_Address? Address { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; } = Guid.Empty;
        public virtual DbMain_Location? Location { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
