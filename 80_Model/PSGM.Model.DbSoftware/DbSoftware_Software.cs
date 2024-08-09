using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbSoftware
{
    [Table("Software")]
    public class DbSoftware_Software
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
        [StringLength(127, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("Version")]
        [Display(Name = "Version")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Version { get; set; } = string.Empty;

        [Required]
        [Column("ReleaseChannel")]
        [Display(Name = "ReleaseChannel")]
        public ReleaseChannel ReleaseChannel { get; set; } = ReleaseChannel.Unknown;

        [Required]
        [Column("SoftwareType")]
        [Display(Name = "SoftwareType")]
        public SoftwareType SoftwareType { get; set; } = SoftwareType.Unknown;

        [Required]
        [Column("ReleaseDate")]
        [Display(Name = "ReleaseDate")]
        public DateTime ReleaseDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column("EndOfLife")]
        [Display(Name = "EndOfLife")]
        public DateTime EndOfLife { get; set; } = DateTime.UtcNow;

        [Column("UpdateServer")]
        [Display(Name = "UpdateServer")]
        [StringLength(2048, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string UpdateServer { get; set; } = string.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
