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

        private string _databaseConnectionString = string.Empty;
        public string DatabaseConnectionString { get { return _databaseConnectionString; } set { _databaseConnectionString = value; } }

        private Guid _databaseSessionParameter_UserId = Guid.Empty;
        public Guid DatabaseSessionParameter_UserId { get { return _databaseSessionParameter_UserId; } set { _databaseSessionParameter_UserId = value; } }

        private Guid _databaseSessionParameter_ComputerId = Guid.Empty;
        public Guid DatabaseSessionParameter_ComputerId { get { return _databaseSessionParameter_ComputerId; } set { _databaseSessionParameter_ComputerId = value; } }

        private Guid _databaseSessionParameter_ApplicationId = Guid.Empty;
        public Guid DatabaseSessionParameter_ApplicationId { get { return _databaseSessionParameter_ApplicationId; } set { _databaseSessionParameter_ApplicationId = value; } }
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
            _databaseConnectionString = connectionString;
        }
        #endregion

        #region DataSets
        #region Address
        public DbSet<DbMachine_Address> Addresses { get; set; }
        public DbSet<DbMachine_Address_AuditLog> Address_AuditLogs { get; set; }
        #endregion

        #region Computer
        public DbSet<DbMachine_Computer> Computers { get; set; }
        public DbSet<DbMachine_Computer_AuditLog> Computer_AuditLogs { get; set; }
        #endregion

        #region Device
        public DbSet<DbMachine_Device> Devices { get; set; }
        public DbSet<DbMachine_Device_AuditLog> Device_AuditLogs { get; set; }

        public DbSet<DbMachine_DeviceGroup> DeviceGroups { get; set; }
        public DbSet<DbMachine_DeviceGroup_AuditLog> DeviceGroup_AuditLogs { get; set; }
        #endregion

        #region Interface
        public DbSet<DbMachine_Interface_Can> Interfaces_Can { get; set; }
        public DbSet<DbMachine_Interface_Can_AuditLog> Interface_Can_AuditLogs { get; set; }

        public DbSet<DbMachine_Interface_CanDevice> Interfaces_CanDevice { get; set; }
        public DbSet<DbMachine_Interface_CanDevice_AuditLog> Interfaces_CanDevice_AuditLogs { get; set; }

        public DbSet<DbMachine_Interface_Ethernet> Interfaces_Ethernet { get; set; }
        public DbSet<DbMachine_Interface_Ethernet_AuditLog> Interface_Ethernet_AuditLogs { get; set; }

        public DbSet<DbMachine_Interface_Serial> Interfaces_Serial { get; set; }
        public DbSet<DbMachine_Interface_Serial_AuditLog> Interface_Serial_AuditLogs { get; set; }
        #endregion

        #region Location
        public DbSet<DbMachine_Location> Locations { get; set; }
        public DbSet<DbMachine_Location_Address_Link> Location_Address_Links { get; set; }

        public DbSet<DbMachine_Location_Address_Link_AuditLog> Location_Address_Link_AuditLogs { get; set; }
        public DbSet<DbMachine_Location_AuditLog> Location_AuditLogs { get; set; }
        #endregion

        #region Machine
        public DbSet<DbMachine_Machine> Machines { get; set; }
        public DbSet<DbMachine_Machine_AuditLog> Machine_AuditLogs { get; set; }

        public DbSet<DbMachine_Machine_Location_Link> Machine_Location_Links { get; set; }
        public DbSet<DbMachine_Machine_Location_Link_AuditLog> Machine_Location_Link_AuditLogs { get; set; }

        public DbSet<DbMachine_Machine_Project_Link> Machine_Project_Links { get; set; }
        public DbSet<DbMachine_Machine_Project_Link_AuditLog> Machine_Project_Link_AuditLogs { get; set; }
        #endregion

        #region Project
        public DbSet<DbMachine_Project> Projects { get; set; }
        public DbSet<DbMachine_Project_AuditLog> Project_AuditLogs { get; set; }
        #endregion
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
                    #region Address
                    case DbMachine_Address address:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            address.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            address.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            address.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            address.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Address_AuditLogs.Add(new DbMachine_Address_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = address.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Address_AuditLog address_AuditLog:
                        break;
                    #endregion

                    #region Computer
                    case DbMachine_Computer computer:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            computer.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            computer.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            computer.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            computer.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Computer_AuditLogs.Add(new DbMachine_Computer_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = computer.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Computer_AuditLog computer_AuditLog:
                        break;
                    #endregion

                    #region Device
                    case DbMachine_Device device:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            device.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            device.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            device.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            device.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Device_AuditLogs.Add(new DbMachine_Device_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = device.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Device_AuditLog device_AuditLog:
                        break;

                    case DbMachine_DeviceGroup deviceGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            deviceGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            deviceGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            deviceGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            deviceGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        DeviceGroup_AuditLogs.Add(new DbMachine_DeviceGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = deviceGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_DeviceGroup_AuditLog deviceGroup_AuditLog:
                        break;
                    #endregion

                    #region Interfaces
                    case DbMachine_Interface_Can interface_Can:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            interface_Can.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            interface_Can.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            interface_Can.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            interface_Can.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Interface_Can_AuditLogs.Add(new DbMachine_Interface_Can_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_Can.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_Can_AuditLog interface_Can_AuditLog:
                        break;

                    case DbMachine_Interface_CanDevice interface_CanDevice:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            interface_CanDevice.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            interface_CanDevice.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            interface_CanDevice.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            interface_CanDevice.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Interfaces_CanDevice_AuditLogs.Add(new DbMachine_Interface_CanDevice_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_CanDevice.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_CanDevice_AuditLog interface_CanDevice_AuditLog:
                        break;

                    case DbMachine_Interface_Ethernet interface_Ethernet:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            interface_Ethernet.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            interface_Ethernet.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            interface_Ethernet.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            interface_Ethernet.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Interface_Ethernet_AuditLogs.Add(new DbMachine_Interface_Ethernet_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_Ethernet.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_Ethernet_AuditLog interface_Ethernet_AuditLog:
                        break;

                    case DbMachine_Interface_Serial interface_Serial:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            interface_Serial.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            interface_Serial.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            interface_Serial.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            interface_Serial.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Interface_Serial_AuditLogs.Add(new DbMachine_Interface_Serial_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = interface_Serial.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Interface_Serial_AuditLog interface_Serial_AuditLog:
                        break;
                    #endregion

                    #region Location
                    case DbMachine_Location location:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            location.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            location.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            location.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            location.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Location_AuditLogs.Add(new DbMachine_Location_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = location.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Location_AuditLog location_AuditLog:
                        break;

                    case DbMachine_Location_Address_Link location_Address_Link:
                        Location_Address_Link_AuditLogs.Add(new DbMachine_Location_Address_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = location_Address_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Location_Address_Link_AuditLog location_Address_Link_AuditLog:
                        break;
                    #endregion

                    #region Machine
                    case DbMachine_Machine machine:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            machine.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            machine.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            machine.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            machine.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Machine_AuditLogs.Add(new DbMachine_Machine_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = machine.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Machine_AuditLog machine_AuditLog:
                        break;

                    case DbMachine_Machine_Location_Link machine_Location_Link:
                        Machine_Location_Link_AuditLogs.Add(new DbMachine_Machine_Location_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = machine_Location_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Machine_Location_Link_AuditLog machine_Location_Link_AuditLog:
                        break;

                    case DbMachine_Machine_Project_Link machine_Project_Link:
                        Machine_Project_Link_AuditLogs.Add(new DbMachine_Machine_Project_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = machine_Project_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Machine_Project_Link_AuditLog machine_Project_Link_AuditLog:
                        break;
                    #endregion

                    #region Project
                    case DbMachine_Project project:
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

                        Project_AuditLogs.Add(new DbMachine_Project_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_ApplicationId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMachine_Project_AuditLog project_AuditLog:
                        break;
                    #endregion

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
