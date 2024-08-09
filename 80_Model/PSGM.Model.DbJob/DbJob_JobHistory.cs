using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbJob
{
    [Table("JobHistory")]
    public class DbJob_JobHistory
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Required]
        [Column("JobType")]
        [Display(Name = "JobType")]
        public JobType JobType { get; set; } = JobType.Unknown;

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("JobStarted")]
        [Display(Name = "JobStarted")]
        public DateTime JobStarted { get; set; } = DateTime.MinValue;

        [Column("JobFinished")]
        [Display(Name = "JobFinished")]
        public DateTime JobFinished { get; set; } = DateTime.MinValue;

        [Column("MachineIdExt")]
        [Display(Name = "MachineIdExt")]
        public Guid MachineIdExt { get; set; } = Guid.Empty;    

        [Column("DeviceIdExt")]
        [Display(Name = "DeviceIdExt")]
        public Guid DeviceIdExt { get; set; } = Guid.Empty;

        [Column("ProjectIdExt")]
        [Display(Name = "ProjectIdExt")]
        public Guid ProjectIdExt { get; set; } = Guid.Empty;

        [Column("UserIdExt")]
        [Display(Name = "UserIdExt")]
        public Guid UserIdExt { get; set; } = Guid.Empty;

        [Column("FileIdExt")]
        [Display(Name = "FileIdExt")]
        public Guid FileIdExt { get; set; } = Guid.Empty;

        [Column("SubDirectoryIdExt")]
        [Display(Name = "SubDirectoryIdExt")]
        public Guid SubDirectoryIdExt { get; set; } = Guid.Empty;

        #region Audit details for faster file audit information
        [Required]
        [Column("CreatedDateTime")]
        [Display(Name = "CreatedDateTime")]
        public DateTime CreatedDateTime { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserIdExt")]
        [Display(Name = "CreatedByUserIdExt")]
        public Guid CreatedByUserIdExt { get; set; } = Guid.Empty;

        [Column("ModifiedDateTime")]
        [Display(Name = "ModifiedDateTime")]
        public DateTime ModifiedDateTime { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserIdExt")]
        [Display(Name = "ModifiedByUserIdExt")]
        public Guid ModifiedByUserIdExt { get; set; } = Guid.Empty;

        [Column("LastChanges")]
        [Display(Name = "LastChanges")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastChanges { get; set; } = string.Empty;
        #endregion
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
