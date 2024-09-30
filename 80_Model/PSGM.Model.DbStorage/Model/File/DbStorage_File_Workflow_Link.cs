using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("File_Workflow_Link")]
    public class DbStorage_File_Workflow_Link
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
        [ForeignKey("File")]
        public Guid? FileId { get; set; }
        public virtual DbStorage_File? File { get; set; }

        [ForeignKey("Workflow")]
        public Guid? WorkflowId { get; set; } = Guid.Empty;
        public virtual DbStorage_File_Workflow? Workflow { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
