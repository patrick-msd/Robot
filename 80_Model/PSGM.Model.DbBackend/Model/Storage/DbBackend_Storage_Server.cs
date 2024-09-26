using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbBackend
{
    [Table("Storage_Server")]
    public class DbBackend_Storage_Server
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

        [Column("Node")]
        [Display(Name = "Node")]
        public int Node { get; set; } = 0;

        [Column("FirstIpSegment")]
        [Display(Name = "FirstIpSegment")]
        public int FirstIpSegment { get; set; } = 0;

        [Column("LastIpSegment")]
        [Display(Name = "LastIpSegment")]
        public int LastIpSegment { get; set; } = 0;

        [Column("VLAN")]
        [Display(Name = "VLAN")]
        public int VLAN { get; set; } = 0;

        [Column("ServerDNS")]
        [Display(Name = "ServerDNS")]
        [StringLength(512, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ServerDNS { get; set; } = string.Empty;

        [Column("ServerIP")]
        [Display(Name = "ServerIP")]
        [StringLength(128, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        public string ServerIP { get; set; } = string.Empty;

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
        #endregion

        #region Backlinks (ForeignKeys)
        [ForeignKey("Cluster")]
        public Guid? ClusterId { get; set; }
        public virtual DbBackend_Storage_Cluster? Cluster { get; set; }
        #endregion

        #region Not Mapped
        public string GetServerName()
        {
            if (this.ServerDNS == string.Empty)
            {
                return $"srv{this.VLAN.ToString("D3")}-{this.LastIpSegment.ToString("D3")}";
            }
            else
            {
                return ServerDNS;
            }
        }

        public string GetIpAddress()
        {
            if (this.ServerIP == string.Empty)
            {
                if (this.Cluster is not null)
                {
                    return $"{this.FirstIpSegment}.{this.Cluster.BranchNumber}.{this.VLAN}.{this.LastIpSegment}";
                }
                else
                {
                    return string.Empty;
                }
            }
            else
            {
                return ServerIP;
            }
        }
        #endregion
    }
}
