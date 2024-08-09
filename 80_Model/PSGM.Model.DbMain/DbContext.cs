using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public class DbMain_Context : DbContext
    {
        #region Variables
        public DatabaseType _databaseType = DatabaseType.SQLite;
        public DatabaseType DatabaseType { get { return _databaseType; } set { _databaseType = value; } }


        private string _connectionString = string.Empty;
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }


        private string _connectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbMain\\DbMain.db";
        public string ConnectionStringSQLite { get { return _connectionStringSQLite; } set { _connectionStringSQLite = value; } }


        private string _connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";
        public string ConnectionStringPostgreSQL { get { return _connectionStringPostgreSQL; } set { _connectionStringPostgreSQL = value; } }


        private string _connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
        public string ConnectionStringSQLServer { get { return _connectionStringSQLServer; } set { _connectionStringSQLServer = value; } }
        #endregion

        #region Context
        public DbMain_Context() : base()
        {
        }

        public DbMain_Context(DbContextOptions<DbMain_Context> options) : base(options)
        {
        }

        public DbMain_Context(DatabaseType databaseType, string connectionString) : base()
        {
            _databaseType = databaseType;
            _connectionString = connectionString;
        }
        #endregion

        #region DataSets
        public DbSet<DbMain_Address> Addresses { get; set; }
        public DbSet<DbMain_Address_AuditLog> Address_AuditLog { get; set; }

        public DbSet<DbMain_Contributors> Contributors { get; set; }
        public DbSet<DbMain_Contributors_AuditLog> Contributor_AuditLog { get; set; }

        public DbSet<DbMain_Location> Locations { get; set; }
        public DbSet<DbMain_Location_AuditLog> Location_AuditLog { get; set; }

        public DbSet<DbMain_Organization> Organizations { get; set; }
        public DbSet<DbMain_Organization_AuditLog> Organization_AuditLog { get; set; }

        public DbSet<DbMain_OrganizationAuthorization_User> OrganizationAuthorization_User { get; set; }
        public DbSet<DbMain_OrganizationAuthorization_User_AuditLog> OrganizationAuthorization_User_AuditLog { get; set; }

        public DbSet<DbMain_OrganizationAuthorization_UserGroup> OrganizationAuthorization_UserGroup { get; set; }
        public DbSet<DbMain_OrganizationAuthorization_UserGroup_AuditLog> OrganizationAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbMain_OrganizationNotification_User> OrganizationNotification_User { get; set; }
        public DbSet<DbMain_OrganizationNotification_User_AuditLog> OrganizationNotification_User_AuditLog { get; set; }

        public DbSet<DbMain_OrganizationNotification_UserGroup> OrganizationNotification_UserGroup { get; set; }
        public DbSet<DbMain_OrganizationNotification_UserGroup_AuditLog> OrganizationNotification_UserGroup_AuditLog { get; set; }

        public DbSet<DbMain_Project> Projects { get; set; }
        public DbSet<DbMain_Project_AuditLog> Project_AuditLog { get; set; }

        public DbSet<DbMain_ProjectAuthorization_User> ProjectAuthorization_User { get; set; }
        public DbSet<DbMain_ProjectAuthorization_User_AuditLog> ProjectAuthorization_User_AuditLog { get; set; }

        public DbSet<DbMain_ProjectAuthorization_UserGroup> ProjectAuthorization_UserGroup { get; set; }
        public DbSet<DbMain_ProjectAuthorization_UserGroup_AuditLog> ProjectAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbMain_ProjectNotification_User> ProjectNotification_User { get; set; }
        public DbSet<DbMain_ProjectNotification_User_AuditLog> ProjectNotification_User_AuditLog { get; set; }

        public DbSet<DbMain_ProjectNotification_UserGroup> ProjectNotification_UserGroup { get; set; }
        public DbSet<DbMain_ProjectNotification_UserGroup_AuditLog> ProjectNotification_UserGroup_AuditLog { get; set; }

        public DbSet<DbMain_ProjectParameter> ProjectParameters { get; set; }
        public DbSet<DbMain_ProjectParameter_AuditLog> ProjectParameter_AuditLog { get; set; }

        public DbSet<DbMain_ProjectParameterStorage> ProjectParametersStorage { get; set; }
        public DbSet<DbMain_ProjectParameterStorage_AuditLog> ProjectParametersStorage_AuditLog { get; set; }
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
                    case DbMain_Address address:
                        Address_AuditLog.Add(new DbMain_Address_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = address.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = address.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Address_AuditLog address_AuditLog:
                        break;

                    case DbMain_Contributors contributors:
                        Contributor_AuditLog.Add(new DbMain_Contributors_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = contributors.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = contributors.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Contributors_AuditLog contributors_AuditLog:
                        break;

                    case DbMain_Location location:
                        Location_AuditLog.Add(new DbMain_Location_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = location.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = location.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Location_AuditLog location_AuditLog:
                        break;

                    case DbMain_Organization organization:
                        Organization_AuditLog.Add(new DbMain_Organization_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = organization.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_AuditLog organization_AuditLog:
                        break;
                    case DbMain_OrganizationAuthorization_User organizationAuthorization_User:
                        OrganizationAuthorization_User_AuditLog.Add(new DbMain_OrganizationAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organizationAuthorization_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = organizationAuthorization_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_OrganizationAuthorization_User_AuditLog organizationAuthorization_User_AuditLog:
                        break;

                    case DbMain_OrganizationAuthorization_UserGroup organizationAuthorization_UserGroup:
                        OrganizationAuthorization_UserGroup_AuditLog.Add(new DbMain_OrganizationAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organizationAuthorization_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = organizationAuthorization_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_OrganizationAuthorization_UserGroup_AuditLog organizationAuthorization_UserGroup_AuditLog:
                        break;

                    case DbMain_OrganizationNotification_User organizationNotification_User:
                        OrganizationNotification_User_AuditLog.Add(new DbMain_OrganizationNotification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organizationNotification_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = organizationNotification_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_OrganizationNotification_User_AuditLog organizationNotification_User_AuditLog:
                        break;

                    case DbMain_OrganizationNotification_UserGroup organizationNotification_UserGroup:
                        OrganizationNotification_UserGroup_AuditLog.Add(new DbMain_OrganizationNotification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organizationNotification_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = organizationNotification_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_OrganizationNotification_UserGroup_AuditLog organizationNotification_UserGroup_AuditLog:
                        break;

                    case DbMain_Project project:
                        Project_AuditLog.Add(new DbMain_Project_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = project.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_AuditLog project_AuditLog:
                        break;

                    case DbMain_ProjectAuthorization_User projectAuthorization_User:
                        ProjectAuthorization_User_AuditLog.Add(new DbMain_ProjectAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = projectAuthorization_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = projectAuthorization_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_ProjectAuthorization_User_AuditLog projectAuthorization_User_AuditLog:
                        break;

                    case DbMain_ProjectAuthorization_UserGroup projectAuthorization_UserGroup:
                        ProjectAuthorization_UserGroup_AuditLog.Add(new DbMain_ProjectAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = projectAuthorization_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = projectAuthorization_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_ProjectAuthorization_UserGroup_AuditLog projectAuthorization_UserGroup_AuditLog:
                        break;

                    case DbMain_ProjectNotification_User projectNotification_User:
                        ProjectNotification_User_AuditLog.Add(new DbMain_ProjectNotification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = projectNotification_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = projectNotification_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_ProjectNotification_User_AuditLog projectNotification_User_AuditLog:
                        break;

                    case DbMain_ProjectNotification_UserGroup projectNotification_UserGroup:
                        ProjectNotification_UserGroup_AuditLog.Add(new DbMain_ProjectNotification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = projectNotification_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = projectNotification_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_ProjectNotification_UserGroup_AuditLog projectNotification_UserGroup_AuditLog:
                        break;

                    case DbMain_ProjectParameter projectParameter:
                        ProjectParameter_AuditLog.Add(new DbMain_ProjectParameter_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = projectParameter.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = projectParameter.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_ProjectParameter_AuditLog projectParameter_AuditLog:
                        break;

                    case DbMain_ProjectParameterStorage projectParameterStorage:
                        ProjectParameter_AuditLog.Add(new DbMain_ProjectParameter_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = projectParameterStorage.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = projectParameterStorage.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_ProjectParameterStorage_AuditLog projectParameterStorage_AuditLog:
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
