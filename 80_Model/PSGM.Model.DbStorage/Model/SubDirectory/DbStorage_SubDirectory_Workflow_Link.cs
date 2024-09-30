using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("SubDirectory_Workflow_Link")]
    public class DbStorage_SubDirectory_Workflow_Link
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
        [ForeignKey("SubDirectory")]
        public Guid? SubDirectoryId { get; set; }
        public virtual DbStorage_SubDirectory? SubDirectory { get; set; }

        [ForeignKey("Workflow")]
        public Guid? WorkflowId { get; set; } = Guid.Empty;
        public virtual DbStorage_SubDirectory_Workflow? Workflow { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
