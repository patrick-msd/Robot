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

        private string _databaseConnectionString = string.Empty;
        public string DatabaseConnectionString { get { return _databaseConnectionString; } set { _databaseConnectionString = value; } }

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
            _databaseConnectionString = connectionString;
        }
        #endregion

        #region DataSets
        #region Address
        public DbSet<DbMain_Address> Addresses { get; set; }
        public DbSet<DbMain_Address_AuditLog> Address_AuditLog { get; set; }
        #endregion

        #region Archive
        public DbSet<DbMain_Archive_Job> Archives_Jobs { get; set; }
        public DbSet<DbMain_Archive_Job_AuditLog> Archive_Job_AuditLog { get; set; }

        public DbSet<DbMain_Archive_Job_Link> Archive_Job_Links { get; set; }
        public DbSet<DbMain_Archive_Job_Link_AuditLog> Archive_Job_Link_AuditLog { get; set; }
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

        public DbSet<DbMain_Organization_Employee_Notification> Organization_Employee_Notification { get; set; }
        public DbSet<DbMain_Organization_Employee_Notification_AuditLog> Organization_Employee_Notification_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Employee_Permission> Organization_Employee_Permission { get; set; }
        public DbSet<DbMain_Organization_Employee_Permission_AuditLog> Organization_Employee_Permission_AuditLog { get; set; }

        public DbSet<DbMain_Organization_EmployeeGroup> Organization_EmployeeGroup { get; set; }
        public DbSet<DbMain_Organization_EmployeeGroup_AuditLog> Organization_EmployeeGroup_AuditLog { get; set; }

        public DbSet<DbMain_Organization_Location_Link> Organization_Location_Links { get; set; }
        public DbSet<DbMain_Organization_Location_Link_AuditLog> Organization_Location_Link_AuditLog { get; set; }
        #endregion

        #region Project
        public DbSet<DbMain_Project> Projects { get; set; }
        public DbSet<DbMain_Project_AuditLog> Project_AuditLog { get; set; }
        #endregion

        #region Unit
        public DbSet<DbMain_Unit> Units { get; set; }
        public DbSet<DbMain_Unit_AuditLog> Unit_AuditLog { get; set; }

        public DbSet<DbMain_VirtualRootUnit> VirtualRootUnits { get; set; }
        public DbSet<DbMain_VirtualRootUnit_AuditLog> VirtualRootUnit_AuditLog { get; set; }

        public DbSet<DbMain_VirtualRootUnit_User_Permission> VirtualRootUnit_User_Permissions { get; set; }
        public DbSet<DbMain_VirtualRootUnit_User_Permission_AuditLog> VirtualRootUnit_User_Permission_AuditLog { get; set; }

        public DbSet<DbMain_VirtualSubUnit> VirtualSubUnits { get; set; }
        public DbSet<DbMain_VirtualSubUnit_AuditLog> VirtualSubUnit_AuditLog { get; set; }

        public DbSet<DbMain_VirtualSubUnit_User_Permission> VirtualSubUnit_User_Permissions { get; set; }
        public DbSet<DbMain_VirtualSubUnit_User_Permission_AuditLog> VirtualSubUnit_User_Permission_AuditLog { get; set; }
        #endregion

        #region Workflow
        public DbSet<DbMain_WorkflowGroup> dbMain_WorkflowGroups { get; set; }
        public DbSet<DbMain_WorkflowGroup_AuditLog> WorkflowGroup_AuditLog { get; set; }

        public DbSet<DbMain_WorkflowItem> WorkflowItems { get; set; }
        public DbSet<DbMain_WorkflowItem_AuditLog> WorkflowItem_AuditLog { get; set; }

        public DbSet<DbMain_WorkflowItem_Link> WorkflowItem_Links { get; set; }
        public DbSet<DbMain_WorkflowItem_Link_AuditLog> WorkflowItem_Link_AuditLog { get; set; }
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


            modelBuilder.ApplyConfiguration(new DbMain_WorkflowItemConfiguration());

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
                            address.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            address.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            address.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Address_AuditLog.Add(new DbMain_Address_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = address.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Address_AuditLog address_AuditLog:
                        break;
                    #endregion

                    #region Archive
                    case DbMain_Archive_Job archive_Job:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            archive_Job.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            archive_Job.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            archive_Job.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            archive_Job.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Archive_Job_AuditLog.Add(new DbMain_Archive_Job_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = archive_Job.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Archive_Job_AuditLog archive_Job_AuditLog:
                        break;

                    case DbMain_Archive_Job_Link archive_Job_Link:
                        Archive_Job_Link_AuditLog.Add(new DbMain_Archive_Job_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = archive_Job_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Archive_Job_Link_AuditLog archive_Job_Link_AuditLog:
                        break;
                    #endregion

                    #region Contributor
                    case DbMain_Contributors contributor:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            contributor.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            contributor.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            contributor.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            contributor.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Contributor_AuditLog.Add(new DbMain_Contributors_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = contributor.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
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
                            deliverySlip.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            deliverySlip.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            deliverySlip.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        DeliverySlip_AuditLog.Add(new DbMain_DeliverySlip_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = deliverySlip.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
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
                            deliverySlip_Template.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            deliverySlip_Template.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            deliverySlip_Template.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        DeliverySlip_Template_AuditLog.Add(new DbMain_DeliverySlip_Template_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = deliverySlip_Template.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_DeliverySlip_Template_AuditLog deliverySlip_Template_AuditLog:
                        break;
                    #endregion

                    #region Location
                    case DbMain_Location location:
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

                        Location_AuditLog.Add(new DbMain_Location_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = location.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
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
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
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
                            organization.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_AuditLog.Add(new DbMain_Organization_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
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
                            organization_Employee.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_Employee.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Employee.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_Employee_AuditLog.Add(new DbMain_Organization_Employee_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Employee.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Employee_AuditLog organization_Employee_AuditLog:
                        break;

                    case DbMain_Organization_Employee_Notification organization_Employee_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization_Employee_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Employee_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_Employee_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Employee_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_Employee_Notification_AuditLog.Add(new DbMain_Organization_Employee_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Employee_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Employee_Notification_AuditLog organization_Employee_Notification_AuditLog:
                        break;

                    case DbMain_Organization_Employee_Permission organization_Employee_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization_Employee_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Employee_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_Employee_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_Employee_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_Employee_Permission_AuditLog.Add(new DbMain_Organization_Employee_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Employee_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Employee_Permission_AuditLog organization_Employee_Permission_AuditLog:
                        break;

                    case DbMain_Organization_EmployeeGroup organization_EmployeeGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            organization_EmployeeGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            organization_EmployeeGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            organization_EmployeeGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            organization_EmployeeGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Organization_EmployeeGroup_AuditLog.Add(new DbMain_Organization_EmployeeGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_EmployeeGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_EmployeeGroup_AuditLog organization_EmployeeGroup_AuditLog:
                        break;

                    case DbMain_Organization_Location_Link organization_Location_Link:
                        Organization_Location_Link_AuditLog.Add(new DbMain_Organization_Location_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = organization_Location_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Organization_Location_Link_AuditLog organization_Location_Link_AuditLog:
                        break;
                    #endregion

                    #region Project
                    case DbMain_Project project:
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

                        Project_AuditLog.Add(new DbMain_Project_AuditLog
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

                    case DbMain_Project_AuditLog project_AuditLog:
                        break;
                    #endregion

                    #region Unit
                    case DbMain_Unit unit:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            unit.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            unit.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            unit.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            unit.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        Unit_AuditLog.Add(new DbMain_Unit_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = unit.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_Unit_AuditLog unit_AuditLog:
                        break;

                    case DbMain_VirtualRootUnit virtualRootUnit:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            virtualRootUnit.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            virtualRootUnit.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            virtualRootUnit.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            virtualRootUnit.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        VirtualRootUnit_AuditLog.Add(new DbMain_VirtualRootUnit_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = virtualRootUnit.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_VirtualRootUnit_AuditLog virtualUnit_AuditLog:
                        break;

                    case DbMain_VirtualRootUnit_User_Permission virtualRootUnit_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            virtualRootUnit_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            virtualRootUnit_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            virtualRootUnit_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            virtualRootUnit_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        VirtualRootUnit_User_Permission_AuditLog.Add(new DbMain_VirtualRootUnit_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = virtualRootUnit_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_VirtualRootUnit_User_Permission_AuditLog virtualRootUnit_User_Permission_AuditLog:
                        break;

                    case DbMain_VirtualSubUnit virtualSubUnit:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            virtualSubUnit.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            virtualSubUnit.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            virtualSubUnit.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            virtualSubUnit.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        VirtualSubUnit_AuditLog.Add(new DbMain_VirtualSubUnit_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = virtualSubUnit.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_VirtualSubUnit_AuditLog virtualSubUnit_AuditLog:
                        break;

                    case DbMain_VirtualSubUnit_User_Permission virtualSubUnit_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            virtualSubUnit_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            virtualSubUnit_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            virtualSubUnit_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            virtualSubUnit_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        VirtualSubUnit_User_Permission_AuditLog.Add(new DbMain_VirtualSubUnit_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = virtualSubUnit_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_VirtualSubUnit_User_Permission_AuditLog virtualSubUnit_User_Permission_AuditLog:
                        break;
                    #endregion

                    #region Workflow
                    case DbMain_WorkflowGroup workflowGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            workflowGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            workflowGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            workflowGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            workflowGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        WorkflowGroup_AuditLog.Add(new DbMain_WorkflowGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = workflowGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_WorkflowGroup_AuditLog workflowGroup_AuditLog:
                        break;

                    case DbMain_WorkflowItem workflowItem:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            workflowItem.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            workflowItem.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            workflowItem.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            workflowItem.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        WorkflowItem_AuditLog.Add(new DbMain_WorkflowItem_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = workflowItem.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_WorkflowItem_AuditLog workflowItem_AuditLog:
                        break;

                    case DbMain_WorkflowItem_Link workflowItem_Link:
                        WorkflowItem_Link_AuditLog.Add(new DbMain_WorkflowItem_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = workflowItem_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbMain_WorkflowItem_Link_AuditLog workflowItem_Link_AuditLog:
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
