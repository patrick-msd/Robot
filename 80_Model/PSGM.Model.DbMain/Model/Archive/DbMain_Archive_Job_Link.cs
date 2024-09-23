using Newtonsoft.Json;
using PSGM.Model.DbMain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Archive_Job_Link")]
    public class DbMain_Archive_Job_Link
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Project")]
        public Guid? ProjectId { get; set; }
        public virtual DbMain_Project? Project { get; set; }

        [ForeignKey("ArchiveJob")]
        public Guid? ArchiveJobId { get; set; } = Guid.Empty;
        public virtual DbMain_Archive_Job? ArchiveJob { get; set; }

        [ForeignKey("Unit")]
        public Guid? UnitId { get; set; }
        public virtual DbMain_Unit? Unit { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
