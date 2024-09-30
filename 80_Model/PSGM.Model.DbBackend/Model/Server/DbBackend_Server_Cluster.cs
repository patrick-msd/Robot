using PSGM.Helper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbBackend
{
    [Table("Server_Cluster")]
    public class DbBackend_Server_Cluster
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
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Description { get; set; } = string.Empty;

        [Column("BranchNumber")]
        [Display(Name = "BranchNumber")]
        public int BranchNumber { get; set; } = 0;

        [Column("Domain")]
        [Display(Name = "Domain")]
        [StringLength(255, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Domain { get; set; } = string.Empty;

        [Column("Stars")]
        [Display(Name = "Stars")]
        public int Stars { get; set; } = -1;

        [Column("Order")]
        [Display(Name = "Order")]
        public int Order { get; set; } = -1;

        [Column("ServerType")]
        [Display(Name = "ServerType")]
        public ServerType ServerType { get; set; } = ServerType.Undefined;

        [Column("ServerPort")]
        [Display(Name = "ServerPort")]
        public int ServerPort { get; set; } = 0;

        [Column("ServerUsername")]
        [Display(Name = "ServerUsername")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ServerUsername { get; set; } = string.Empty;

        [Column("ServerPassword")]
        [Display(Name = "ServerPassword")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ServerPassword { get; set; } = string.Empty;

        [Column("ReadOnlyMode")]
        [Display(Name = "ReadOnlyMode")]
        public bool ReadOnlyMode { get; set; } = false;

        [Column("Locked")]
        [Display(Name = "Locked")]
        public bool Locked { get; set; } = false;

        [Column("LockedDescription")]
        [Display(Name = "LockedDescription")]
        [StringLength(8192, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string LockedDescription { get; set; } = string.Empty;

        [Column("Url")]
        [Display(Name = "Url")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Url { get; set; } = string.Empty;

        [Column("UrlPublic")]
        [Display(Name = "UrlPublic")]
        [StringLength(1023, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string UrlPublic { get; set; } = string.Empty;

        [Column("Configuration")]
        [Display(Name = "Configuration")]
        [StringLength(65536, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string Configuration { get; set; } = string.Empty;

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
        [InverseProperty("Cluster")]
        public virtual ICollection<DbBackend_Server_Server>? ServerServers { get; set; }
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Backend")]
        public Guid? BackendId { get; set; }
        public virtual DbBackend_Backend? Backend { get; set; }
        #endregion

        #region Not Mapped
        public string GetServerConnection(bool withBranch)
        {
            if (this.Backend is not null)
            {
                if (withBranch)
                {
                    string host = $"db-{Enum.GetName(typeof(BackendType), this.Backend.BackendType).ToLower()}-{this.Id.ToString()}.branch{this.BranchNumber.ToString("D3")}.{this.Domain}:{this.ServerPort.ToString()}";

                    return $"{host}";
                }
                else
                {
                    string host = $"{Enum.GetName(typeof(BackendType), this.Backend.BackendType).ToLower()}-{this.Id.ToString()}.{this.Domain}:{this.ServerPort.ToString()}";

                    return $"{host}";
                }
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion
    }
}
