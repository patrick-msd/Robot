using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Location")]
    public class DbMain_Location
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(16384, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        #region Audit details for faster file audit information
        [Required]
        [Column("CreatedDateTimeAutoFill")]
        [Display(Name = "CreatedDateTimeAutoFill")]
        public DateTime CreatedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserIdExtAutoFill")]
        [Display(Name = "CreatedByUserIdExtAutoFill")]
        public Guid CreatedByUserIdExtAutoFill { get; set; } = Guid.Empty;

        [Column("ModifiedDateTimeAutoFill")]
        [Display(Name = "ModifiedDateTimeAutoFill")]
        public DateTime ModifiedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserIdExtAutoFill")]
        [Display(Name = "ModifiedByUserIdExtAutoFill")]
        public Guid ModifiedByUserIdExtAutoFill { get; set; } = Guid.Empty;
        #endregion
        #endregion

        #region Links
        [InverseProperty("Location")]
        public virtual DbMain_Location_Address_Link? AddressLink { get; set; }

        [InverseProperty("Location")]
        public virtual ICollection<DbMain_Organization_Location_Link>? OrganizationLocationLink { get; set; }

        [InverseProperty("Location")]
        public virtual ICollection<DbMain_Project_Location_Link>? ProjectLocationLink { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)


        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
