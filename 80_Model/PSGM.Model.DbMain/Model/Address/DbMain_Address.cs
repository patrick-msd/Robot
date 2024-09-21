using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Address")]
    public class DbMain_Address
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("Line1")]
        [Display(Name = "Line1")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Line1 { get; set; } = string.Empty;

        [Column("Line2")]
        [Display(Name = "Line2")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Line2 { get; set; } = string.Empty;

        [Required]
        [Column("City")]
        [Display(Name = "City")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string City { get; set; } = string.Empty;

        [Required]
        [Column("State")]
        [Display(Name = "State")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string State { get; set; } = string.Empty;

        [Required]
        [Column("CountryCode")]
        [Display(Name = "CountryCode")]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string CountryCode { get; set; } = string.Empty;

        [Required]
        [Column("CountryName")]
        [Display(Name = "CountryName")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string CountryName { get; set; } = string.Empty;

        [Column("PostalCode")]
        [Display(Name = "PostalCode")]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string PostalCode { get; set; } = string.Empty;

        [Column("RegionCode")]
        [Display(Name = "RegionCode")]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string RegionCode { get; set; } = string.Empty;

        [Column("RegionName")]
        [Display(Name = "RegionName")]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string RegionName { get; set; } = string.Empty;

        [Column("GpsAltitude")]
        [Display(Name = "GpsAltitude")]
        public int GpsAltitude { get; set; } = 0;

        [Column("GpsLatitudeDegree")]
        [Display(Name = "GpsLatitudeDegree")]
        public decimal GpsLatitudeDegree { get; set; } = 0.000m;

        [Column("GpsLatitudeMinute")]
        [Display(Name = "GpsLatitudeMinute")]
        public decimal GpsLatitudeMinute { get; set; } = 0.000m;

        [Column("GpsLatitudeSecond")]
        [Display(Name = "GpsLatitudeSecond")]
        public decimal GpsLatitudeSecond { get; set; } = 0.000m;

        [Column("GpsLatitudeCardinalPoint")]
        [Display(Name = "GpsLatitudeCardinalPoint")]
        public char GpsLatitudeCardinalPoint { get; set; } = char.MinValue;

        [Column("GpsLongitudeDegree")]
        [Display(Name = "GpsLongitudeDegree")]
        public decimal GpsLongitudeDegree { get; set; } = 0.000m;

        [Column("GpsLongitudeMinute")]
        [Display(Name = "GpsLongitudeMinute")]
        public decimal GpsLongitudeMinute { get; set; } = 0.000m;

        [Column("GpsLongitudeSecond")]
        [Display(Name = "GpsLongitudeSecond")]
        public decimal GpsLongitudeSecond { get; set; } = 0.000m;

        [Column("GpsLongitudeCardinalPoint")]
        [Display(Name = "GpsLongitudeCardinalPoint")]
        public char GpsLongitudeCardinalPoint { get; set; } = char.MinValue;

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
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Address")]
        public Guid? AddressLinkId { get; set; }
        public virtual DbMain_Location_Address_Link? AddressLink { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
