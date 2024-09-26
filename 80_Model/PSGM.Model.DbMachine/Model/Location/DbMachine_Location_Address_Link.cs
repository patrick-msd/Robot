using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("Location_Address_Link")]
    public class DbMachine_Location_Address_Link
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
        public virtual DbMachine_Address? Address { get; set; }

        [ForeignKey("Location")]
        public Guid? LocationId { get; set; } = Guid.Empty;
        public virtual DbMachine_Location? Location { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
