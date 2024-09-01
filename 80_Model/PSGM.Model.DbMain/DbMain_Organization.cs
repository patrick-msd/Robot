using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Organization")]
    public class DbMain_Organization
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

        [Column("Acronym")]
        [Display(Name = "Acronym")]
        [StringLength(32, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 1)]
        public string Acronym { get; set; } = string.Empty;

        [Column("DaytimePhoneNumber")]
        [Display(Name = "DaytimePhoneNumber")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string DaytimePhoneNumber { get; set; } = string.Empty;

        [Column("EveningPhoneNumber")]
        [Display(Name = "EveningPhoneNumber")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string EveningPhoneNumber { get; set; } = string.Empty;

        [Required]
        [Column("EMail")]
        [Display(Name = "EMail")]
        [StringLength(511, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string EMail { get; set; } = string.Empty;

        [Required]
        [Column("Homepage")]
        [Display(Name = "Homepage")]
        [StringLength(511, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Homepage { get; set; } = string.Empty;
        #endregion

        #region Links
        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_Contributors>? Contributors { get; set; }

        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_Location>? Locations { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbMain_Project? Project { get; set; }
        #endregion

        #region Links (Outside DB)
        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_OrganizationAuthorization_User>? AuthorizationUser { get; set; }

        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_OrganizationAuthorization_UserGroup>? AuthorizationUserGroup { get; set; }

        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_OrganizationNotification_User>? NotificationUser { get; set; }

        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_OrganizationNotification_UserGroup>? NotificationUserGroup { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
