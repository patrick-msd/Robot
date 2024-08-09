using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbUser
{
    [Table("User")]
    public class DbUser_User
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("LoginName")]
        [Display(Name = "LoginName")]
        [StringLength(127, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LoginName { get; set; } = string.Empty;

        [Required]
        [Column("FirstName")]
        [Display(Name = "FirstName")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Column("LastName")]
        [Display(Name = "LastName")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [Column("Password")]
        [Display(Name = "Password")]
        [StringLength(2048, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Column("MailAddress")]
        [Display(Name = "MailAddress")]
        [StringLength(511, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string MailAddress { get; set; } = string.Empty;

        [Column("PhoneNumber")]
        [Display(Name = "PhoneNumber")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column("MobilePhoneNumber")]
        [Display(Name = "MobilePhoneNumber")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string MobilePhoneNumber { get; set; } = string.Empty;
        #endregion

        #region Links
        // Many to Many --> User to UserGroup
        public virtual ICollection<DbUser_UserGroup>? UserGroups { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        [Column("UserKeyCloakUserId")]
        [Display(Name = "UserKeyCloakUserId")]
        public Guid? UserKeyCloakUserId { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
