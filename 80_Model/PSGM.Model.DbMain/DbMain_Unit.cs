using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbMain
{
    [Table("Unit")]
    public class DbMain_Unit
    {
        #region Entities
        [Key]
        [Required]
        [Column("Id")]
        [Display(Name = "Id")]
        public Guid Id { get; set; }

        [Column("Suffix")]
        [Display(Name = "Suffix")]
        [StringLength(127, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Suffix { get; set; } = string.Empty;

        [Required]
        [Column("Name")]
        [Display(Name = "Name")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Name { get; set; } = string.Empty;

        [Column("Description")]
        [Display(Name = "Description")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("Objects")]
        [Display(Name = "Objects")]
        public long Objects { get; set; } = 0;

        [Column("DirectorySize")]
        [Display(Name = "DirectorySize")]
        public long DirectorySize { get; set; } = 0;

        [Column("DocumentType")]
        [Display(Name = "DocumentType")]
        public bool DocumentType { get; set; } = false;

        [Column("Locked")]
        [Display(Name = "Locked")]
        public bool Locked { get; set; } = false;

        [Column("JobsIdExtString")]
        [Display(Name = "JobsIdExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string JobsIdExtString { get; private set; } = string.Empty;

        [Column("WorkflowItemExtString")]
        [Display(Name = "WorkflowItemExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string WorkflowItemsExtString { get; private set; } = string.Empty;

        [Column("BackupsExtString")]
        [Display(Name = "BackupsExtString")]
        [StringLength(16383, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string BackupsExtString { get; private set; } = string.Empty;

        #region Audit details for faster file audit information
        [Required]
        [Column("CreatedDateTimeAutoFill")]
        [Display(Name = "CreatedDateTimeAutoFill")]
        public DateTime CreatedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Required]
        [Column("CreatedByUserIdExtAutoFill")]
        [Display(Name = "CreatedByUserIdExtAutoFill")]
        public Guid CreatedByUserIdExtAutoFill { get; set; } = Guid.Empty;

        [Column("ModifiedDateTimeAutoFill")]
        [Display(Name = "ModifiedDateTimeAutoFill")]
        public DateTime ModifiedDateTimeAutoFill { get; set; } = DateTime.MinValue;

        [Column("ModifiedByUserIdExtAutoFill")]
        [Display(Name = "ModifiedByUserIdExtAutoFill")]
        public Guid ModifiedByUserIdExtAutoFill { get; set; } = Guid.Empty;

        [Column("LastModificationChanges")]
        [Display(Name = "LastModificationChanges")]
        [StringLength(8191, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LastModificationChanges { get; set; } = string.Empty;
        #endregion
        #endregion

        #region Links
        [InverseProperty("ParentUnit")]
        public virtual ICollection<DbMain_Unit>? Unit { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("DeliveryBill")]
        public Guid? DeliveryBillId { get; set; }
        public virtual DbMain_DeliveryBill? DeliveryBill { get; set; }


        [ForeignKey("ParentUnit")]
        public Guid? ParentUnitId { get; set; }
        public virtual DbMain_Unit? ParentUnit { get; set; }
        #endregion

        #region Links (Outside DB)
        #endregion

        #region Not Mapped
        [NotMapped]
        public List<Guid>? JobsIdExt
        {
            get { return JobsIdExtString != string.Empty ? JobsIdExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { JobsIdExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        [NotMapped]
        public List<Guid>? WorkflowItemsExt
        {
            get { return WorkflowItemsExtString != string.Empty ? WorkflowItemsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { WorkflowItemsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }

        //[NotMapped]
        //public List<Guid>? AuthorizedUsersExt
        //{
        //    get { return AuthorizedUsersExtString != string.Empty ? AuthorizedUsersExtString.Split(',').Select(Guid.Parse).ToList() : null; }
        //    set { AuthorizedUsersExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        //}

        //[NotMapped]
        //public List<Guid>? AuthorizedUserGroupsExt
        //{
        //    get { return AuthorizedUserGroupsExtString != string.Empty ? AuthorizedUserGroupsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
        //    set { AuthorizedUserGroupsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        //}

        [NotMapped]
        public List<Guid>? BackupsExt
        {
            get { return BackupsExtString != string.Empty ? BackupsExtString.Split(',').Select(Guid.Parse).ToList() : null; }
            set { BackupsExtString = value != null ? string.Join(',', value.Select(x => x.ToString())) : string.Empty; }
        }
        #endregion
    }
}
