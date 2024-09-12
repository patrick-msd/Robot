using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PSGM.Helper;

namespace PSGM.Model.DbStorage
{
    public class DbStorage_Context : DbContext
    {
        #region Variables
        public DatabaseType _databaseType = DatabaseType.SQLite;
        public DatabaseType DatabaseType { get { return _databaseType; } set { _databaseType = value; } }


        private string _connectionString = string.Empty;
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }


        private Guid _databaseSessionParameter_UserId = Guid.Empty;
        public Guid DatabaseSessionParameter_UserId { get { return _databaseSessionParameter_UserId; } set { _databaseSessionParameter_UserId = value; } }


        private Guid _databaseSessionParameter_MachineId = Guid.Empty;
        public Guid DatabaseSessionParameter_MachineId { get { return _databaseSessionParameter_MachineId; } set { _databaseSessionParameter_MachineId = value; } }


        private Guid _databaseSessionParameter_SoftwareId = Guid.Empty;
        public Guid DatabaseSessionParameter_SoftwareId { get { return _databaseSessionParameter_SoftwareId; } set { _databaseSessionParameter_SoftwareId = value; } }
        #endregion

        #region Context
        public DbStorage_Context() : base()
        {
        }

        public DbStorage_Context(DbContextOptions<DbStorage_Context> options) : base(options)
        {
        }

        public DbStorage_Context(DatabaseType databaseType, string connectionString) : base()
        {
            _databaseType = databaseType;
            _connectionString = connectionString;
        }
        #endregion

        #region DataSets
        public DbSet<DbStorage_File> Files { get; set; }
        public DbSet<DbStorage_File_AuditLog> File_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadata> FileMetadata { get; set; }
        public DbSet<DbStorage_FileMetadata_AuditLog> FileMetadata_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadataLink> FileMetadataLink { get; set; }
        public DbSet<DbStorage_FileMetadataLink_AuditLog> FileMetadataLink_AuditLog { get; set; }

        public DbSet<DbStorage_QrCode> QrCodes { get; set; }
        public DbSet<DbStorage_QrCode_AuditLog> QrCode_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory> RootDirectories { get; set; }
        public DbSet<DbStorage_RootDirectory_AuditLog> RootDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryMetadata> RootDirectoryMetadata { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadata_AuditLog> RootDirectoryMetadata_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryMetadataLink> RootDirectoryMetadataLink { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadataLink_AuditLog> RootDirectoryMetadataLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory> SubDirectories { get; set; }
        public DbSet<DbStorage_SubDirectory_AuditLog> SubDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadata> SubDirectoryMetadata { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadata_AuditLog> SubDirectoryMetadata_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadataLink> SubDirectoryMetadataLink { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadataLink_AuditLog> SubDirectoryMetadataLink_AuditLog { get; set; }
        #endregion

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_databaseType)
            {
                case DatabaseType.ConnectionString:
                    optionsBuilder.UseSqlite(_connectionString);
                    break;

                case DatabaseType.SQLite:
                    optionsBuilder.UseSqlite(_connectionString);
                    break;

                case DatabaseType.PostgreSQL:
                    optionsBuilder.UseNpgsql(_connectionString);
                    break;

                case DatabaseType.SQLServer:
                    optionsBuilder.UseSqlServer(_connectionString);
                    break;

                default:
                    throw new Exception($"Invalid database type: {_databaseType}");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding
            // https://www.learnentityframeworkcore.com/migrations/seeding
            // https://www.learnentityframeworkcore.com/configuration/data-annotation-attributes

            modelBuilder.HasDefaultSchema("psgm");

            //modelBuilder.ApplyConfiguration(new ModelLogTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ModelObjectTypeConfiguration());

            //	//modelBuilder.HasDefaultSchema("public");
            //	//base.OnModelCreating(modelBuilder);
            //	modelBuilder.Entity<Models.ModelCluster>().ToTable("Cluster");
            //	modelBuilder.ApplyConfiguration(new Models.Configuration.ClusterTypeConfiguration());
            //	//modelBuilder.Entity<Enrollment>().ToTable("Enrollment");
            //	//modelBuilder.Entity<Student>().ToTable("Student");

            //	// Test setup
            //	List<Models.ModelSite> sites = new List<Models.ModelSite>();
            //	sites.Add(new Models.ModelSite() { SiteId = new Guid("9F0420FD-87E0-4C7B-999A-091D0DBDC3AE"), Name = "Hall in Tirol", Comment = "" });
            //	sites.Add(new Models.ModelSite() { SiteId = new Guid("64CFEC2A-A59E-4E77-8796-86AE854F5AB4"), Name = "Buch in Tirol", Comment = "Productiv Cluster 2" });
            //	modelBuilder.Entity<Models.ModelSite>().HasData(sites);

            //	List<Models.ModelTenant> tenants = new List<Models.ModelTenant>();
            //	tenants.Add(new Models.ModelTenant() { TenantId = new Guid("C4FE4119-D5DB-42B3-B937-DCBF497A5BCB"), Name = "Mechatronic System Design e.U.", Comment = "" });
            //	modelBuilder.Entity<Models.ModelTenant>().HasData(tenants);

            //	List<Models.ModelCluster> clusters = new List<Models.ModelCluster>();
            //	clusters.Add(new Models.ModelCluster() { ClusterId = new Guid("6E92A1D7-EF34-4378-96FB-831749CDC588"), Name = "clu0001", Comment = "Productiv Cluster 1", SiteId = new Guid("9F0420FD-87E0-4C7B-999A-091D0DBDC3AE"), TenantId = new Guid("C4FE4119-D5DB-42B3-B937-DCBF497A5BCB") });
            //	clusters.Add(new Models.ModelCluster() { ClusterId = new Guid("9235B29B-9FE7-41AD-BE44-AA7A56DF9F6E"), Name = "clu0002", Comment = "Productiv Cluster 2", SiteId = new Guid("9F0420FD-87E0-4C7B-999A-091D0DBDC3AE"), TenantId = new Guid("C4FE4119-D5DB-42B3-B937-DCBF497A5BCB") });
            //	clusters.Add(new Models.ModelCluster() { ClusterId = new Guid("7758D761-22F6-4683-89D0-70F065507C9C"), Name = "clu0003", Comment = "Test Cluster 1", SiteId = new Guid("9F0420FD-87E0-4C7B-999A-091D0DBDC3AE"), TenantId = new Guid("C4FE4119-D5DB-42B3-B937-DCBF497A5BCB") });
            //	modelBuilder.Entity<Models.ModelCluster>().HasData(clusters);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                                        .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified || e.State == EntityState.Deleted)
                                        .ToList();

            foreach (var entry in entries)
            {
                switch (entry.Entity)
                {
                    case DbStorage_File file:
                        File_AuditLog.Add(new DbStorage_File_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            // Update changes on sub directory
                            if (file.SubDirectory is not null)
                            {
                                file.SubDirectory.DirectoryObjectsAutofill += 1;
                                file.SubDirectory.DirectorySizeAutofill += file.ObjectSize;

                                // Update changes on parent sub directories
                                if (file.SubDirectory.ParentSubDirectory is not null)
                                {
                                    DbStorage_SubDirectory? item = file.SubDirectory.ParentSubDirectory;
                                    DbStorage_SubDirectory? itemOld = item;

                                    do
                                    {
                                        item.DirectoryObjectsAutofill += 1;
                                        item.DirectorySizeAutofill += file.ObjectSize;

                                        itemOld = item;
                                        item = item.ParentSubDirectory;
                                    } while (item is not null);

                                    if (itemOld.RootDirectory is not null)
                                    {
                                        itemOld.RootDirectory.DirectoryObjectsAutofill += 1;
                                        itemOld.RootDirectory.DirectorySizeAutofill += file.ObjectSize;
                                    }
                                }
                            }

                            // Update changes on root directory
                            if (file.RootDirectory is not null)
                            {
                                file.RootDirectory.DirectoryObjectsAutofill += 1;
                                file.RootDirectory.DirectorySizeAutofill += file.ObjectSize;
                            }

                            file.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            DbStorage_File fileOld = File_AuditLog.Where(f => f.SourceId == file.Id).Last().GetChanges();

                            // Update changes on sub directory
                            if (file.SubDirectory is not null)
                            {
                                file.SubDirectory.DirectorySizeAutofill -= fileOld.ObjectSize;
                                file.SubDirectory.DirectorySizeAutofill += file.ObjectSize;

                                // Update changes on parent sub directories
                                if (file.SubDirectory.ParentSubDirectory is not null)
                                {
                                    DbStorage_SubDirectory? item = file.SubDirectory.ParentSubDirectory;
                                    DbStorage_SubDirectory? itemOld = item;

                                    do
                                    {
                                        item.DirectorySizeAutofill -= fileOld.ObjectSize;
                                        item.DirectorySizeAutofill += file.ObjectSize;

                                        itemOld = item;
                                        item = item.ParentSubDirectory;
                                    } while (item is not null);

                                    if (itemOld.RootDirectory is not null)
                                    {
                                        itemOld.RootDirectory.DirectorySizeAutofill -= fileOld.ObjectSize;
                                        itemOld.RootDirectory.DirectorySizeAutofill += file.ObjectSize;
                                    }
                                }
                            }

                            // Update changes on root directory
                            if (file.RootDirectory is not null)
                            {
                                file.RootDirectory.DirectorySizeAutofill -= fileOld.ObjectSize;
                                file.RootDirectory.DirectorySizeAutofill += file.ObjectSize;
                            }

                            file.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Deleted)
                        {
                            // Update changes on sub directory
                            if (file.SubDirectory is not null)
                            {
                                file.SubDirectory.DirectoryObjectsAutofill -= 1;
                                file.SubDirectory.DirectorySizeAutofill -= file.ObjectSize;

                                // Update changes on parent sub directories
                                if (file.SubDirectory.ParentSubDirectory is not null)
                                {
                                    DbStorage_SubDirectory? item = file.SubDirectory.ParentSubDirectory;
                                    DbStorage_SubDirectory? itemOld = item;

                                    do
                                    {
                                        item.DirectoryObjectsAutofill -= 1;
                                        item.DirectorySizeAutofill -= file.ObjectSize;

                                        itemOld = item;
                                        item = item.ParentSubDirectory;
                                    } while (item is not null);

                                    if (itemOld.RootDirectory is not null)
                                    {
                                        itemOld.RootDirectory.DirectoryObjectsAutofill -= 1;
                                        itemOld.RootDirectory.DirectorySizeAutofill -= file.ObjectSize;
                                    }
                                }
                            }

                            // Update changes on root directory
                            if (file.RootDirectory is not null)
                            {
                                file.RootDirectory.DirectoryObjectsAutofill -= 1;
                                file.RootDirectory.DirectorySizeAutofill -= file.ObjectSize;
                            }

                            file.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_File_AuditLog file_AuditLog:
                        break;

                    case DbStorage_FileMetadata fileMetadata:
                        FileMetadata_AuditLog.Add(new DbStorage_FileMetadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileMetadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileMetadata_AuditLog fileMetadata_AuditLog:
                        break;

                    case DbStorage_FileMetadataLink fileMetadataLink:
                        FileMetadataLink_AuditLog.Add(new DbStorage_FileMetadataLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileMetadataLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileMetadataLink_AuditLog fileMetadataLink_AuditLog:
                        break;

                    case DbStorage_QrCode qrCode:
                        QrCode_AuditLog.Add(new DbStorage_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = qrCode.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_QrCode_AuditLog qrCode_AuditLog:
                        break;

                    case DbStorage_RootDirectory rootDirectory:
                        RootDirectory_AuditLog.Add(new DbStorage_RootDirectory_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster rootDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            rootDirectory.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_RootDirectory_AuditLog rootDirectory_AuditLog:
                        break;

                    case DbStorage_RootDirectoryMetadata rootDirectoryMetadata:
                        RootDirectoryMetadata_AuditLog.Add(new DbStorage_RootDirectoryMetadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryMetadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryMetadata_AuditLog rootDirectoryMetadata_AuditLog:
                        break;

                    case DbStorage_RootDirectoryMetadataLink rootDirectoryMetadataLink:
                        RootDirectoryMetadataLink_AuditLog.Add(new DbStorage_RootDirectoryMetadataLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryMetadataLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryMetadataLink_AuditLog rootDirectoryMetadataLink_AuditLog:
                        break;

                    case DbStorage_SubDirectory subDirectory:
                        SubDirectory_AuditLog.Add(new DbStorage_SubDirectory_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster subDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            subDirectory.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_SubDirectory_AuditLog subDirectory_AuditLog:
                        break;

                    case DbStorage_SubDirectoryMetadata subDirectoryMetadata:
                        SubDirectoryMetadata_AuditLog.Add(new DbStorage_SubDirectoryMetadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryMetadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryMetadata_AuditLog subDirectoryMetadata_AuditLog:
                        break;

                    case DbStorage_SubDirectoryMetadataLink subDirectoryMetadataLink:
                        SubDirectoryMetadataLink_AuditLog.Add(new DbStorage_SubDirectoryMetadataLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryMetadataLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryMetadataLink_AuditLog subDirectoryMetadataLink_AuditLog:
                        break;

                    default:
                        break;
                }
            }

            return base.SaveChanges();
        }
        #endregion

        #region Functions
        public string GetConnectionString()
        {
            return _connectionString;
        }
        #endregion
    }
}
