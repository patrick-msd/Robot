﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectory_User_AuditLog")]
    public class DbStorage_SubDirectory_User_AuditLog
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("SourceId")]
        [Display(Name = "SourceId")]
        public Guid SourceId { get; set; } = Guid.Empty;

        [Required]
        [Column("Action")]
        [Display(Name = "EntityName")]
        [StringLength(256, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Action { get; set; } = string.Empty;

        [Required]
        [Column("DateTime")]
        [Display(Name = "DateTime")]
        public DateTime DateTime { get; set; } = DateTime.MinValue;

        [Required]
        [Column("UserId_Ext")]
        [Display(Name = "UserId_Ext")]
        public Guid UserId_Ext { get; set; } = Guid.Empty;

        [Required]
        [Column("SoftwareId_Ext")]
        [Display(Name = "SoftwareId_Ext")]
        public Guid SoftwareId_Ext { get; set; } = Guid.Empty;

        [Required]
        [Column("Changes")]
        [Display(Name = "Changes")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Changes { get; set; } = string.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Not Mapped
        public DbStorage_SubDirectory_User? GetChanges()
        {
            return JsonConvert.DeserializeObject<DbStorage_SubDirectory_User>(Changes);
        }
        #endregion
    }
}
