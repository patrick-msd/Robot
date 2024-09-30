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
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("ApplicationName")]
        [Display(Name = "ApplicationName")]
        [StringLength(1024, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ApplicationName { get; set; } = string.Empty;

        [Required]
        [Column("InitializeAtSplashScreen")]
        [Display(Name = "InitializeAtSplashScreen")]
        public bool InitializeAtSplashScreen { get; set; } = false;

        [Required]
        [Column("ConnectAtSplashScreen")]
        [Display(Name = "ConnectAtSplashScreen")]
        public bool ConnectAtSplashScreen { get; set; } = false;

        [Required]
        [Column("AutoStartAtSplashScreen")]
        [Display(Name = "AutoStartAtSplashScreen")]
        public bool AutoStartAtSplashScreen { get; set; } = false;

        [Required]
        [Column("HomingAtSplashScreen")]
        [Display(Name = "HomingAtSplashScreen")]
        public bool HomingAtSplashScreen { get; set; } = false;

        #region Audit details for faster file audit information
        [Required]
        [Column("CreatedDateTimeAutoFill")]
        [Display(Name = "CreatedDateTimeAutoFill")]
        public DateTime CreatedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserId_ExtAutoFill")]
        [Display(Name = "CreatedByUserId_ExtAutoFill")]
        public Guid CreatedByUserId_ExtAutoFill { get; set; } = Guid.Empty;

        [Column("ModifiedDateTimeAutoFill")]
        [Display(Name = "ModifiedDateTimeAutoFill")]
        public DateTime ModifiedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserId_ExtAutoFill")]
        [Display(Name = "ModifiedByUserId_ExtAutoFill")]
        public Guid ModifiedByUserId_ExtAutoFill { get; set; } = Guid.Empty;
        #endregion
        #endregion

        #region Links

        [InverseProperty("Machine")]
        public virtual ICollection<DbMachine_Computer>? Computer { get; set; }

        [InverseProperty("Machine")]
        public virtual ICollection<DbMachine_Machine_Location_Link>? LocationLinks { get; set; }

        [InverseProperty("Machine")]
        public virtual ICollection<DbMachine_DeviceGroup>? DeviceGroups { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; } = Guid.Empty;
        public virtual DbMachine_Project? Project { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
