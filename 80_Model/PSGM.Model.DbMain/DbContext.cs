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


        private Guid _databaseSessionParameter_UserId = Guid.Empty;
        public Guid DatabaseSessionParameter_UserId { get { return _databaseSessionParameter_UserId; } set { _databaseSessionParameter_UserId = value; } }


        private Guid _databaseSessionParameter_MachineId = Guid.Empty;
        public Guid DatabaseSessionParameter_MachineId { get { return _databaseSessionParameter_MachineId; } set { _databaseSessionParameter_MachineId = value; } }


        private Guid _databaseSessionParameter_SoftwareId = Guid.Empty;
        public Guid DatabaseSessionParameter_SoftwareId { get { return _databaseSessionParameter_SoftwareId; } set { _databaseSessionParameter_SoftwareId = value; } }
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
        #region Address
        public DbSet<DbMain_Address> Addresses { get; set; }
        public DbSet<DbMain_Address_AuditLog> Address_AuditLog { get; set; }
        #endregion

        #region Contributor
        public DbSet<DbMain_Contributors> Contributors { get; set; }
        public DbSet<DbMain_Contributors_AuditLog> Contributor_AuditLog { get; set; }
        #endregion

        #region Delivery Slip
        public DbSet<DbMain_DeliverySlip> DeliverySlip { get; set; }
        public DbSet<DbMain_DeliverySlip_AuditLog> DeliverySlip_AuditLog { get; set; }

        public DbSet<DbMain_DeliverySlip_Template> DeliverySlip_Templates { get; set; }
        public DbSet<DbMain_DeliverySlip_Template_AuditLog> DeliverySlip_Template_AuditLog { get; set; }
        #endregion

        #region DocumentType
        public DbSet<DbMain_DocumentType> DocumentTypes { get; set; }
        public DbSet<DbMain_DocumentType_AuditLog> DocumentType_AuditLog { get; set; }
        #endregion

        #region Location
        public DbSet<DbMain_Location> Locations { get; set; }
        public DbSet<DbMain_Location_AuditLog> Location_AuditLog { get; set; }

        public DbSet<DbMain_Location_Address_Link> Location_Address_Links { get; set; }
        public DbSet<DbMain_Location_Address_Link_AuditLog> Location_Address_Link_AuditLog { get; set; }
        #endregion

        #region Organization
        public DbSet<DbMain_Organization> Organizations { get; set; }
        public DbSet<DbMain_Organization_AuditLog> Organization_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Employee> Organization_Employee { get; set; }
        public DbSet<DbMain_Organization_Employee_AuditLog> Organization_Employee_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Employee_Link> Organization_Employee_Links { get; set; }
        public DbSet<DbMain_Organization_Employee_Link_AuditLog> Organization_Employee_Link_AuditLog { get; set; }

        public DbSet<DbMain_Organization_EmployeeGroup> Organization_EmployeeGroup { get; set; }
        public DbSet<DbMain_Organization_EmployeeGroup_AuditLog> Organization_EmployeeGroup_AuditLog { get; set; }

        public DbSet<DbMain_Organization_EmployeeGroup_Link> Organization_EmployeeGroup_Links { get; set; }
        public DbSet<DbMain_Organization_EmployeeGroup_Link_AuditLog> Organization_EmployeeGroup_Link_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Location_Link> Organization_Location_Links { get; set; }
        public DbSet<DbMain_Organization_Location_Link_AuditLog> Organization_Location_Link_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Notification_User> Organization_Notification_User { get; set; }
        public DbSet<DbMain_Organization_Notification_User_AuditLog> Organization_Notification_User_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Notification_User_Link> Organization_Notification_User_Links { get; set; }
        public DbSet<DbMain_Organization_Notification_User_Link_AuditLog> Organization_Notification_User_Link_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Notification_UserGroup> Organization_Notification_UserGroup { get; set; }
        public DbSet<DbMain_Organization_Notification_UserGroup_AuditLog> Organization_Notification_UserGroup_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Notification_UserGroup_Link> Organization_Notification_UserGroup_Links { get; set; }
        public DbSet<DbMain_Organization_Notification_UserGroup_Link_AuditLog> Organization_Notification_UserGroup_Link_AuditLog { get; set; }
        #endregion

        #region Project
        public DbSet<DbMain_Project> Projects { get; set; }
        public DbSet<DbMain_Project_AuditLog> Project_AuditLog { get; set; }

        public DbSet<DbMain_Project_Authorization_User> Project_Authorization_User { get; set; }
        public DbSet<DbMain_Project_Authorization_User_AuditLog> Project_Authorization_User_AuditLog { get; set; }

        public DbSet<DbMain_Project_Authorization_User_Link> Project_Authorization_User_Link { get; set; }
        public DbSet<DbMain_Project_Authorization_User_Link_AuditLog> Project_Authorization_User_Link_AuditLog { get; set; }

        public DbSet<DbMain_Project_Authorization_UserGroup> Project_Authorization_UserGroup { get; set; }
        public DbSet<DbMain_Project_Authorization_UserGroup_AuditLog> Project_Authorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbMain_Project_Authorization_UserGroup_Link> Project_Authorization_UserGroup_Link { get; set; }
        public DbSet<DbMain_Project_Authorization_UserGroup_Link_AuditLog> Project_Authorization_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbMain_Project_Location_Link> Project_Location_Link { get; set; }
        public DbSet<DbMain_Project_Location_Link_AuditLog> Project_Location_Link_AuditLog { get; set; }

        public DbSet<DbMain_Project_Notification_User> Project_Notification_User { get; set; }
        public DbSet<DbMain_Project_Notification_User_AuditLog> Project_Notification_User_AuditLog { get; set; }

        public DbSet<DbMain_Project_Notification_User_Link> Project_Notification_User_Link { get; set; }
        public DbSet<DbMain_Project_Notification_User_Link_AuditLog> Project_Notification_User_Link_AuditLog { get; set; }

        public DbSet<DbMain_Project_Notification_UserGroup> Project_Notification_UserGroup { get; set; }
        public DbSet<DbMain_Project_Notification_UserGroup_AuditLog> Project_Notification_UserGroup_AuditLog { get; set; }

        public DbSet<DbMain_Project_Notification_UserGroup_Link> Project_Notification_UserGroup_Link { get; set; }
        public DbSet<DbMain_Project_Notification_UserGroup_Link_AuditLog> Project_Notification_UserGroup_Link_AuditLog { get; set; }
        #endregion

        #region Unit
        public DbSet<DbMain_Unit> Units { get; set; }
        public DbSet<DbMain_Unit_AuditLog> Unit_AuditLog { get; set; }
        #endregion
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
                    case DbMain_Address address:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            address.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            address.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            address.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            address.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Address_AuditLog.Add(new DbMain_Address_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = address.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Address_AuditLog address_AuditLog:
                        break;
                    #endregion

                    #region Contributor
                    case DbMain_Contributors contributor:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            contributor.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            contributor.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            contributor.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            contributor.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Contributor_AuditLog.Add(new DbMain_Contributors_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = contributor.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Contributors_AuditLog contributors_AuditLog:
                        break;
                    #endregion

                    #region Delivery Slip
                    case DbMain_DeliverySlip deliverySlip:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            deliverySlip.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            deliverySlip.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            deliverySlip.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            deliverySlip.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        DeliverySlip_AuditLog.Add(new DbMain_DeliverySlip_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = deliverySlip.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_DeliverySlip_AuditLog deliverySlip_AuditLog:
                        break;

                    case DbMain_DeliverySlip_Template deliverySlip_Template:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            deliverySlip_Template.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            deliverySlip_Template.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            deliverySlip_Template.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            deliverySlip_Template.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        DeliverySlip_Template_AuditLog.Add(new DbMain_DeliverySlip_Template_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = deliverySlip_Template.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_DeliverySlip_Template_AuditLog deliverySlip_Template_AuditLog:
                        break;
                    #endregion

                    #region DocumentType
                    case DbMain_DocumentType documentType:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            documentType.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            documentType.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            documentType.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            documentType.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        DocumentType_AuditLog.Add(new DbMain_DocumentType_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = documentType.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_DocumentType_AuditLog documentType_AuditLog:
                        break;
                    #endregion

                    #region Location
                    case DbMain_Location location:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            location.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            location.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            location.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            location.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Location_AuditLog.Add(new DbMain_Location_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = location.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Location_AuditLog location_AuditLog:
                        break;

                    case DbMain_Location_Address_Link location_Address_Link:
                        Location_Address_Link_AuditLog.Add(new DbMain_Location_Address_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = location_Address_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Location_Address_Link_AuditLog location_Address_Link_AuditLog:
                        break;
                    #endregion

                    #region Organization
                    case DbMain_Organization organization:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_AuditLog.Add(new DbMain_Organization_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_AuditLog organization_AuditLog:
                        break;

                    case DbMain_Organization_Employee organization_Employee:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization_Employee.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Employee.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_Employee.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Employee.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_Employee_AuditLog.Add(new DbMain_Organization_Employee_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Employee.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Employee_AuditLog organization_Employee_AuditLog:
                        break;

                    case DbMain_Organization_Employee_Link organization_Employee_Link:
                        Organization_Employee_Link_AuditLog.Add(new DbMain_Organization_Employee_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Employee_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Employee_Link_AuditLog organization_Employee_Link_AuditLog:
                        break;

                    case DbMain_Organization_EmployeeGroup organization_EmployeeGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization_EmployeeGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization_EmployeeGroup.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_EmployeeGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_EmployeeGroup.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_EmployeeGroup_AuditLog.Add(new DbMain_Organization_EmployeeGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_EmployeeGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_EmployeeGroup_AuditLog organization_EmployeeGroup_AuditLog:
                        break;

                    case DbMain_Organization_EmployeeGroup_Link organization_EmployeeGroup_Link:
                        Organization_EmployeeGroup_Link_AuditLog.Add(new DbMain_Organization_EmployeeGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_EmployeeGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_EmployeeGroup_Link_AuditLog organization_EmployeeGroup_Link_AuditLog:
                        break;

                    case DbMain_Organization_Location_Link organization_Location_Link:
                        Organization_Location_Link_AuditLog.Add(new DbMain_Organization_Location_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Location_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Location_Link_AuditLog organization_Location_Link_AuditLog:
                        break;

                    case DbMain_Organization_Notification_User organization_Notification_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization_Notification_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Notification_User.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_Notification_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Notification_User.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_Notification_User_AuditLog.Add(new DbMain_Organization_Notification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Notification_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Notification_User_AuditLog organization_Notification_User_AuditLog:
                        break;

                    case DbMain_Organization_Notification_User_Link organization_Notification_User_Link:
                        Organization_Notification_User_Link_AuditLog.Add(new DbMain_Organization_Notification_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Notification_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Notification_User_Link_AuditLog organization_Notification_User_Link_AuditLog:
                        break;

                    case DbMain_Organization_Notification_UserGroup organization_Notification_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization_Notification_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Notification_UserGroup.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_Notification_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Notification_UserGroup.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_Notification_UserGroup_AuditLog.Add(new DbMain_Organization_Notification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Notification_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Notification_UserGroup_AuditLog organization_Notification_UserGroup_AuditLog:
                        break;

                    case DbMain_Organization_Notification_UserGroup_Link organization_Notification_UserGroup_Link:
                        Organization_Notification_UserGroup_Link_AuditLog.Add(new DbMain_Organization_Notification_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Notification_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Notification_UserGroup_Link_AuditLog organization_Notification_UserGroup_Link_AuditLog:
                        break;
                    #endregion

                    #region Project
                    case DbMain_Project project:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            project.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            project.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            project.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            project.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Project_AuditLog.Add(new DbMain_Project_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_AuditLog project_AuditLog:
                        break;

                    case DbMain_Project_Authorization_User project_Authorization_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            project_Authorization_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            project_Authorization_User.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            project_Authorization_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            project_Authorization_User.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Project_Authorization_User_AuditLog.Add(new DbMain_Project_Authorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Authorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Authorization_User_AuditLog project_Authorization_User_AuditLog:
                        break;

                    case DbMain_Project_Authorization_User_Link project_Authorization_User_Link:
                        Project_Authorization_User_Link_AuditLog.Add(new DbMain_Project_Authorization_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Authorization_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Authorization_User_Link_AuditLog project_Authorization_User_Link_AuditLog:
                        break;

                    case DbMain_Project_Authorization_UserGroup project_Authorization_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            project_Authorization_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            project_Authorization_UserGroup.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            project_Authorization_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            project_Authorization_UserGroup.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Project_Authorization_UserGroup_AuditLog.Add(new DbMain_Project_Authorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Authorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Authorization_UserGroup_AuditLog project_Authorization_UserGroup_AuditLog:
                        break;

                    case DbMain_Project_Authorization_UserGroup_Link project_Authorization_UserGroup_Link:
                        Project_Authorization_UserGroup_Link_AuditLog.Add(new DbMain_Project_Authorization_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Authorization_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Authorization_UserGroup_Link_AuditLog project_Authorization_UserGroup_Link_AuditLog:
                        break;

                    case DbMain_Project_Location_Link project_Location_Link:
                        Project_Location_Link_AuditLog.Add(new DbMain_Project_Location_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Location_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Location_Link_AuditLog project_Location_Link_AuditLog:
                        break;

                    case DbMain_Project_Notification_User project_Notification_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            project_Notification_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            project_Notification_User.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            project_Notification_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            project_Notification_User.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Project_Notification_User_AuditLog.Add(new DbMain_Project_Notification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Notification_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Notification_User_AuditLog project_Notification_User_AuditLog:
                        break;

                    case DbMain_Project_Notification_User_Link project_Notification_User_Link:
                        Project_Notification_User_Link_AuditLog.Add(new DbMain_Project_Notification_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Notification_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Notification_User_Link_AuditLog project_Notification_User_Link_AuditLog:
                        break;

                    case DbMain_Project_Notification_UserGroup project_Notification_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            project_Notification_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            project_Notification_UserGroup.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            project_Notification_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            project_Notification_UserGroup.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Project_Notification_UserGroup_AuditLog.Add(new DbMain_Project_Notification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Notification_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Notification_UserGroup_AuditLog project_Notification_UserGroup_AuditLog:
                        break;

                    case DbMain_Project_Notification_UserGroup_Link project_Notification_UserGroup_Link:
                        Project_Notification_UserGroup_Link_AuditLog.Add(new DbMain_Project_Notification_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = project_Notification_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Project_Notification_UserGroup_Link_AuditLog project_Notification_UserGroup_Link_AuditLog:
                        break;
                    #endregion

                    #region Unit
                    case DbMain_Unit unit:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            unit.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            unit.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            unit.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            unit.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Unit_AuditLog.Add(new DbMain_Unit_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = unit.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Unit_AuditLog unit_AuditLog:
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
            return _connectionString;
        }
        #endregion
    }
}
