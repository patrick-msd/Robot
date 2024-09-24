using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PSGM.Helper;

namespace PSGM.Model.DbMachine
{
    public class DbMachine_Context : DbContext
    {
        #region Variables
        public DatabaseType _databaseType = DatabaseType.SQLite;
        public DatabaseType DatabaseType { get { return _databaseType; } set { _databaseType = value; } }


        private string _connectionString = string.Empty;
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }


        private string _connectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbMachine\\DbMachine.db";
        public string ConnectionStringSQLite { get { return _connectionStringSQLite; } set { _connectionStringSQLite = value; } }


        private string _connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";
        public string ConnectionStringPostgreSQL { get { return _connectionStringPostgreSQL; } set { _connectionStringPostgreSQL = value; } }


        private string _connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
        public string ConnectionStringSQLServer { get { return _connectionStringSQLServer; } set { _connectionStringSQLServer = value; } }
        #endregion

        #region Context
        public DbMachine_Context() : base()
        {
        }

        public DbMachine_Context(DbContextOptions<DbMachine_Context> options) : base(options)
        {
        }

        public DbMachine_Context(DatabaseType databaseType, string connectionString) : base()
        {
            _databaseType = databaseType;
            _connectionString = connectionString;
        }
        #endregion

        #region DataSets
        public DbSet<DbMachine_Address> Addresses { get; set; }
        public DbSet<DbMachine_Address_AuditLog> Address_AuditLogs { get; set; }

        public DbSet<DbMachine_Device> Devices { get; set; }
        public DbSet<DbMachine_Device_AuditLog> Device_AuditLogs { get; set; }

        public DbSet<DbMachine_DeviceGroup> DeviceGroups { get; set; }
        public DbSet<DbMachine_DeviceGroup_AuditLog> DeviceGroup_AuditLogs { get; set; }

        public DbSet<DbMachine_Interface_Can> Interfaces_Can { get; set; }
        public DbSet<DbMachine_Interface_Can_AuditLog> Interface_Can_AuditLogs { get; set; }

        public DbSet<DbMachine_Interface_CanDevice> Interfaces_CanDevice { get; set; }
        public DbSet<DbMachine_Interface_CanDevice_AuditLog> Interfaces_CanDevice_AuditLogs { get; set; }

        public DbSet<DbMachine_Interface_Ethernet> Interfaces_Ethernet { get; set; }
        public DbSet<DbMachine_Interface_Ethernet_AuditLog> Interface_Ethernet_AuditLogs { get; set; }

        public DbSet<DbMachine_Interface_Serial> Interfaces_Serial { get; set; }
        public DbSet<DbMachine_Interface_Serial_AuditLog> Interface_Serial_AuditLogs { get; set; }

        public DbSet<DbMachine_Location> Locations { get; set; }
        public DbSet<DbMachine_Location_AuditLog> Location_AuditLogs { get; set; }

        public DbSet<DbMachine_Machine> Machines { get; set; }
        public DbSet<DbMachine_Machine_AuditLog> Machine_AuditLogs { get; set; }
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
                    case DbMachine_Address address:
                        Address_AuditLogs.Add(new DbMachine_Address_AuditLog
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

                    case DbMachine_Address_AuditLog address_AuditLog:
                        break;

                    case DbMachine_Device device:
                        Device_AuditLogs.Add(new DbMachine_Device_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = device.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = device.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Device_AuditLog device_AuditLog:
                        break;

                    case DbMachine_DeviceGroup deviceGroup:
                        DeviceGroup_AuditLogs.Add(new DbMachine_DeviceGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = deviceGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = deviceGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_DeviceGroup_AuditLog deviceGroup_AuditLog:
                        break;

                    case DbMachine_Interface_Can interface_Can:
                        Interface_Can_AuditLogs.Add(new DbMachine_Interface_Can_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_Can.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = interface_Can.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_Can_AuditLog interface_Can_AuditLog:
                        break;

                    case DbMachine_Interface_CanDevice interface_CanDevice:
                        Interfaces_CanDevice_AuditLogs.Add(new DbMachine_Interface_CanDevice_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_CanDevice.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = interface_CanDevice.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_CanDevice_AuditLog interface_CanDevice_AuditLog:
                        break;

                    case DbMachine_Interface_Ethernet interface_Ethernet:
                        Interface_Ethernet_AuditLogs.Add(new DbMachine_Interface_Ethernet_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_Ethernet.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = interface_Ethernet.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_Ethernet_AuditLog interface_Ethernet_AuditLog:
                        break;

                    case DbMachine_Interface_Serial interface_Serial:
                        Interface_Serial_AuditLogs.Add(new DbMachine_Interface_Serial_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_Serial.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = interface_Serial.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_Serial_AuditLog interface_Serial_AuditLog:
                        break;

                    case DbMachine_Location location:
                        Location_AuditLogs.Add(new DbMachine_Location_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = location.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = intelocationrfaceCan.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Location_AuditLog location_AuditLog:
                        break;

                    case DbMachine_Machine machine:
                        Machine_AuditLogs.Add(new DbMachine_Machine_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = machine.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = machine.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Machine_AuditLog machine_AuditLog:
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
