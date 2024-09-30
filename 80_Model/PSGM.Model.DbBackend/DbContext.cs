using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PSGM.Helper;

namespace PSGM.Model.DbBackend
{
    public class DbBackend_Context : DbContext
    {
        #region Variables
        public DatabaseType _databaseType = DatabaseType.SQLite;
        public DatabaseType DatabaseType { get { return _databaseType; } set { _databaseType = value; } }

        private string _databaseConnectionString = string.Empty;
        public string DatabaseConnectionString { get { return _databaseConnectionString; } set { _databaseConnectionString = value; } }

        private Guid _databaseSessionParameter_UserId = Guid.Empty;
        public Guid DatabaseSessionParameter_UserId { get { return _databaseSessionParameter_UserId; } set { _databaseSessionParameter_UserId = value; } }

        private Guid _databaseSessionParameter_ComputerId = Guid.Empty;
        public Guid DatabaseSessionParameter_ComputerId { get { return _databaseSessionParameter_ComputerId; } set { _databaseSessionParameter_ComputerId = value; } }

        private Guid _databaseSessionParameter_SoftwareId = Guid.Empty;
        public Guid DatabaseSessionParameter_SoftwareId { get { return _databaseSessionParameter_SoftwareId; } set { _databaseSessionParameter_SoftwareId = value; } }
        #endregion

        #region Context
        public DbBackend_Context() : base()
        {
        }

        public DbBackend_Context(DbContextOptions<DbBackend_Context> options) : base(options)
        {
        }

        public DbBackend_Context(DatabaseType databaseType, string connectionString) : base()
        {
            _databaseType = databaseType;
            _databaseConnectionString = connectionString;
        }
        #endregion

        #region DataSets
        public DbSet<DbBackend_Backend> Backends { get; set; }
        public DbSet<DbBackend_Backend_AuditLog> Backend_AuditLogs { get; set; }

        public DbSet<DbBackend_Database_Cluster> Clusters { get; set; }
        public DbSet<DbBackend_Database_Cluster_AuditLog> Cluster_AuditLogs { get; set; }

        public DbSet<DbBackend_Database_Server> Database_Servers { get; set; }
        public DbSet<DbBackend_Database_Server_AuditLog> Database_Server_AuditLogs { get; set; }

        public DbSet<DbBackend_Project> Projects { get; set; }
        public DbSet<DbBackend_Project_AuditLog> Project_AuditLogs { get; set; }

        public DbSet<DbBackend_Storage_Cluster> Storage_Cluster { get; set; }
        public DbSet<DbBackend_Storage_Cluster_AuditLog> Storage_Cluster_AuditLogs { get; set; }

        public DbSet<DbBackend_Storage_Server> Storage_Servers { get; set; }
        public DbSet<DbBackend_Storage_Server_AuditLog> Storage_Server_AuditLogs { get; set; }
        #endregion

        #region Overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            switch (_databaseType)
            {
                case DatabaseType.ConnectionString:
                    optionsBuilder.UseSqlite(_databaseConnectionString);
                    break;

                case DatabaseType.SQLite:
                    optionsBuilder.UseSqlite(_databaseConnectionString);
                    break;

                case DatabaseType.PostgreSQL:
                    optionsBuilder.UseNpgsql(_databaseConnectionString);
                    break;

                case DatabaseType.SQLServer:
                    optionsBuilder.UseSqlServer(_databaseConnectionString);
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


            //modelBuilder.ApplyConfiguration(new DbMain_WorkflowItemConfiguration());

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
            //}
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
                    case DbBackend_Backend backend:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            backend.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            backend.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            backend.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            backend.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Backend_AuditLogs.Add(new DbBackend_Backend_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = backend.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbBackend_Backend_AuditLog backend_AuditLog:
                        break;

                    case DbBackend_Database_Cluster cluster:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            cluster.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            cluster.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            cluster.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            cluster.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Cluster_AuditLogs.Add(new DbBackend_Database_Cluster_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = cluster.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbBackend_Database_Cluster_AuditLog cluster_AuditLog:
                        break;

                    case DbBackend_Database_Server database_Server:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            database_Server.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            database_Server.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            database_Server.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            database_Server.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Database_Server_AuditLogs.Add(new DbBackend_Database_Server_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = database_Server.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbBackend_Database_Server_AuditLog database_Server_AuditLog:
                        break;

                    case DbBackend_Project project:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            project.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            project.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            project.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            project.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Project_AuditLogs.Add(new DbBackend_Project_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbBackend_Project_AuditLog project_AuditLog:
                        break;

                    case DbBackend_Storage_Cluster storage_Cluster:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            storage_Cluster.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            storage_Cluster.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            storage_Cluster.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            storage_Cluster.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Storage_Cluster_AuditLogs.Add(new DbBackend_Storage_Cluster_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = storage_Cluster.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbBackend_Storage_Cluster_AuditLog storage_Cluster_AuditLog:
                        break;

                    case DbBackend_Storage_Server storage_Server:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            storage_Server.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            storage_Server.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            storage_Server.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            storage_Server.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Storage_Server_AuditLogs.Add(new DbBackend_Storage_Server_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = storage_Server.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbBackend_Storage_Server_AuditLog storage_Server_AuditLog:
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
            return _databaseConnectionString;
        }
        #endregion
    }
}
