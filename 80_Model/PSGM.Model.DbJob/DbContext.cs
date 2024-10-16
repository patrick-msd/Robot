﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PSGM.Helper;

namespace PSGM.Model.DbJob
{
    public class DbJob_Context : DbContext
    {
        #region Variables
        public DatabaseType _databaseType = DatabaseType.SQLite;
        public DatabaseType DatabaseType { get { return _databaseType; } set { _databaseType = value; } }


        private string _connectionString = string.Empty;
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }


        private string _connectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbJob\\DbJob.db";
        public string ConnectionStringSQLite { get { return _connectionStringSQLite; } set { _connectionStringSQLite = value; } }


        private string _connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";
        public string ConnectionStringPostgreSQL { get { return _connectionStringPostgreSQL; } set { _connectionStringPostgreSQL = value; } }


        private string _connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
        public string ConnectionStringSQLServer { get { return _connectionStringSQLServer; } set { _connectionStringSQLServer = value; } }








        private Guid _databaseSessionParameter_UserId = Guid.Empty;
        public Guid DatabaseSessionParameter_UserId { get { return _databaseSessionParameter_UserId; } set { _databaseSessionParameter_UserId = value; } }


        private Guid _databaseSessionParameter_MachineId = Guid.Empty;
        public Guid DatabaseSessionParameter_MachienId { get { return _databaseSessionParameter_MachineId; } set { _databaseSessionParameter_MachineId = value; } }


        private Guid _databaseSessionParameter_SoftwareId = Guid.Empty;
        public Guid DatabaseSessionParameter_SoftwareId { get { return _databaseSessionParameter_SoftwareId; } set { _databaseSessionParameter_SoftwareId = value; } }
        #endregion

        #region Context
        public DbJob_Context() : base()
        {
        }

        public DbJob_Context(DbContextOptions<DbJob_Context> options) : base(options)
        {
        }

        public DbJob_Context(DatabaseType databaseType, string connectionString) : base()
        {
            _databaseType = databaseType;
            _connectionString = connectionString;
        }
        #endregion

        #region DataSets
        public DbSet<DbJob_Job> Jobs { get; set; }
        public DbSet<DbJob_Job_AuditLog> Job_AuditLogs { get; set; }

        public DbSet<DbJob_JobHistory> Jobs_History { get; set; }
        public DbSet<DbJob_JobHistory_AuditLog> JobHistoy_AuditLogs { get; set; }
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
                    optionsBuilder.UseSqlite(_connectionStringSQLite);
                    break;

                case DatabaseType.PostgreSQL:
                    optionsBuilder.UseNpgsql(_connectionStringPostgreSQL);
                    break;

                case DatabaseType.SQLServer:
                    optionsBuilder.UseSqlServer(_connectionStringSQLServer);
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
                    case DbJob_Job job:
                        Job_AuditLogs.Add(new DbJob_Job_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = job.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = job.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster job audit information
                        if (entry.State == EntityState.Added)
                        {
                            job.CreatedDateTime = DateTime.UtcNow;
                            job.CreatedByUserIdExt = DatabaseSessionParameter_UserId;
                            job.LastChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());

                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            job.ModifiedDateTime = DateTime.UtcNow;
                            job.ModifiedByUserIdExt = DatabaseSessionParameter_UserId;
                            job.LastChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());
                        }
                        #endregion
                        break;

                    case DbJob_Job_AuditLog job_AuditLog:
                        break;

                    case DbJob_JobHistory jobHistory:
                        Job_AuditLogs.Add(new DbJob_Job_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = jobHistory.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = jobHistory.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster jobHistory audit information
                        if (entry.State == EntityState.Added)
                        {
                            jobHistory.CreatedDateTime = DateTime.UtcNow;
                            jobHistory.CreatedByUserIdExt = DatabaseSessionParameter_UserId;
                            jobHistory.LastChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());

                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            jobHistory.ModifiedDateTime = DateTime.UtcNow;
                            jobHistory.ModifiedByUserIdExt = DatabaseSessionParameter_UserId;
                            jobHistory.LastChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());
                        }
                        #endregion
                        break;

                    case DbJob_JobHistory_AuditLog jobbHistory_AuditLog:
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
            switch (DatabaseType)
            {
                case DatabaseType.ConnectionString:
                    return _connectionString;

                case DatabaseType.SQLite:
                    return _connectionStringSQLite;

                case DatabaseType.PostgreSQL:
                    return _connectionStringPostgreSQL;

                case DatabaseType.SQLServer:
                    return _connectionStringSQLServer;

                default:
                    throw new Exception("Unsupported database type");
            }
        }
        #endregion
    }
}
