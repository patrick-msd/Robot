using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMachine
{
    [Table("Machine")]
    public class DbMachine_Machine
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
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("ApplicationName")]
        [Display(Name = "ApplicationName")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ApplicationName { get; set; } = string.Empty;

        [Required]
        [Column("InitialzeAtSplashscreen")]
        [Display(Name = "InitialzeAtSplashscreen")]
        public bool InitialzeAtSplashscreen { get; set; } = false;

        [Required]
        [Column("ConnectAtSplashscreen")]
        [Display(Name = "ConnectAtSplashscreen")]
        public bool ConnectAtSplashscreen { get; set; } = false;

        [Required]
        [Column("AutoStartAtSplashscreen")]
        [Display(Name = "AutoStartAtSplashscreen")]
        public bool AutoStartAtSplashscreen { get; set; } = false;

        [Required]
        [Column("HomingAtSplashscreen")]
        [Display(Name = "HomingAtSplashscreen")]
        public bool HomingAtSplashscreen { get; set; } = false;
        #endregion

        #region Links
        [InverseProperty("Machine")]
        public virtual DbMachine_Location? Location { get; set; }

        [InverseProperty("Machine")]
        public virtual ICollection<DbMachine_DeviceGroup>? DeviceGroups { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
