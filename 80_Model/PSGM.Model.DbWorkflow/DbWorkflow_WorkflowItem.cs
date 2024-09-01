using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbWorkflow
{
    [Table("WorkflowItem")]
    public class DbWorkflow_WorkflowItem
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

        [Required]
        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;

        [Required]
        [Column("ApplyLevel")]
        [Display(Name = "ApplyLevel")]
        public WorkflowApplyLevel ApplyLevel { get; set; } = WorkflowApplyLevel.Undefined;

        [Required]
        [Column("WorkflowExecutionLevel")]
        [Display(Name = "WorkflowExecutionLevel")]
        public WorkflowExecutionLevel WorkflowExecutionLevel { get; set; } = WorkflowExecutionLevel.Undefined;        
        #endregion

        #region Links
        [InverseProperty("WorkflowItem")]
        public virtual ICollection<DbWorkflow_WorkflowItemLink>? WorkflowItemLinks { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        #endregion
    }
}
