﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSGM.Model.DbStorage
{
    [Table("RootDirectory_Archive_Link")]
    public class DbStorage_RootDirectory_Archive_Link
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
        [ForeignKey("RootDirectory")]
        public Guid? RootDirectoryId { get; set; }
        public virtual DbStorage_RootDirectory? RootDirectory { get; set; }

        [ForeignKey("Archive")]
        public Guid? ArchiveId { get; set; } = Guid.Empty;
        public virtual DbStorage_RootDirectory_Archive? Archive { get; set; }
        #endregion

        #region Not Mapped
        #endregion
    }
}
