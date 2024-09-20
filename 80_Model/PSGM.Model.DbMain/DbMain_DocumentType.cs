using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("DocumentType")]
    public class DbMain_DocumentType
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

        [Required]
        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Column("Status")]
        [Display(Name = "Status")]
        public ProjectStatus Status { get; set; } = ProjectStatus.Undefined;

        [Column("Started")]
        [Display(Name = "Started")]
        public DateTime Started { get; set; } = DateTime.MinValue;

        [Column("Finished")]
        [Display(Name = "Finished")]
        public DateTime Finished { get; set; } = DateTime.MinValue;

        [Column("WorkflowIdExt")]
        [Display(Name = "WorkflowIdExt")]
        public Guid WorkflowIdExt { get; set; } = Guid.Empty;

        [Column("WorkflowApplyLevel")]
        [Display(Name = "WorkflowApplyLevel")]
        public WorkflowApplyLevel WorkflowApplyLevel { get; set; } = WorkflowApplyLevel.Undefined;

        [Column("MachinesExtString")]
        [Display(Name = "MachinesExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string MachinesExtString { get; private set; } = string.Empty;
        #endregion

        #region Links
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("DeliveryBill")]
        public Guid? DeliveryBillId { get; set; }
        public virtual DbMain_DeliverySlip? DeliveryBill { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Guid> MachinesExt
        {
            get { return MachinesExtString != string.Empty ? MachinesExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { MachinesExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }
        #endregion
    }
}
