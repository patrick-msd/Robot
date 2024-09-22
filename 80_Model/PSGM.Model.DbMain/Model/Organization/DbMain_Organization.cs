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
        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_Contributors>? Contributors { get; set; }

        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_Organization_Employee>? Employees { get; set; }

        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_Organization_EmployeeGroup>? EmployeeGroups { get; set; }

        [InverseProperty("Organization")]
        public virtual ICollection<DbMain_Organization_Location_Link>? LocationLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbMain_Project? Project { get; set; }

        [ForeignKey("DeliverySlipInternet")]
        public Guid? DeliverySlipInternetId { get; set; }
        public virtual DbMain_DeliverySlip? DeliverySlipInternet { get; set; }

        [ForeignKey("DeliverySlipExternal")]
        public Guid? DeliverySlipExternalId { get; set; }
        public virtual DbMain_DeliverySlip? DeliverySlipExternal { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
