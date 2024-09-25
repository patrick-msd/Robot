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
        public DbStorage_Context() : base()
        {
        }

        public DbStorage_Context(DbContextOptions<DbStorage_Context> options) : base(options)
        {
        }

        public DbStorage_Context(DatabaseType databaseType, string connectionString) : base()
        {
            _databaseType = databaseType;
            _databaseConnectionString = connectionString;
        }
        #endregion

        #region DataSets
        #region File
        public DbSet<DbStorage_File> Files { get; set; }
        public DbSet<DbStorage_File_AuditLog> File_AuditLogs { get; set; }

        public DbSet<DbStorage_File_Metadata> File_Metadata { get; set; }
        public DbSet<DbStorage_File_Metadata_AuditLog> File_Metadata_AuditLogs { get; set; }

        public DbSet<DbStorage_File_Metadata_Link> File_Metadata_Link { get; set; }
        public DbSet<DbStorage_File_Metadata_Link_AuditLog> File_Metadata_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_File_QrCode> File_QrCodes { get; set; }
        public DbSet<DbStorage_File_QrCode_AuditLog> File_QrCode_AuditLogs { get; set; }

        public DbSet<DbStorage_File_Quality> File_Qualities { get; set; }
        public DbSet<DbStorage_File_Quality_AuditLog> File_Quality_AuditLogs { get; set; }

        public DbSet<DbStorage_File_User> File_Users { get; set; }
        public DbSet<DbStorage_File_User_AuditLog> File_User_AuditLogs { get; set; }

        public DbSet<DbStorage_File_User_Link> File_User_Links { get; set; }
        public DbSet<DbStorage_File_User_Link_AuditLog> File_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_File_User_Notification> File_User_Notifications { get; set; }
        public DbSet<DbStorage_File_User_Notification_AuditLog> File_User_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_File_User_Permission> File_User_Permissions { get; set; }
        public DbSet<DbStorage_File_User_Permission_AuditLog> File_User_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_File_UserGroup> File_UserGroups { get; set; }
        public DbSet<DbStorage_File_UserGroup_AuditLog> File_UserGroup_AuditLogs { get; set; }

        public DbSet<DbStorage_File_UserGroup_Link> File_UserGroup_Links { get; set; }
        public DbSet<DbStorage_File_UserGroup_Link_AuditLog> File_UserGroup_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_File_UserGroup_Notification> File_UserGroup_Notifications { get; set; }
        public DbSet<DbStorage_File_UserGroup_Notification_AuditLog> File_UserGroup_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_File_UserGroup_Permission> File_UserGroup_Permissions { get; set; }
        public DbSet<DbStorage_File_UserGroup_Permission_AuditLog> File_UserGroup_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_File_UserGroup_User> _File_UserGroup_Users { get; set; }
        public DbSet<DbStorage_File_UserGroup_User_AuditLog> File_UserGroup_User_AuditLogs { get; set; }

        public DbSet<DbStorage_File_UserGroup_User_Link> _File_UserGroup_User_Links { get; set; }
        public DbSet<DbStorage_File_UserGroup_User_Link_AuditLog> File_UserGroup_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit> File_VirtualUnits { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_AuditLog> File_VirtualUnit_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_User> File_VirtualUnit_User { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_User_AuditLog> File_VirtualUnit_User_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_User_Link> File_VirtualUnit_User_Links { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_User_Link_AuditLog> File_VirtualUnit_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_User_Notification> File_VirtualUnit_User_Notifications { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_User_Notification_AuditLog> File_VirtualUnit_User_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_User_Permission> File_VirtualUnit_User_Permissions { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_User_Permission_AuditLog> File_VirtualUnit_User_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_UserGroup> File_VirtualUnit_UserGroups { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_UserGroup_AuditLog> File_VirtualUnit_UserGroup_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_UserGroup_Link> File_VirtualUnit_UserGroup_Links { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_UserGroup_Link_AuditLog> File_VirtualUnit_UserGroup_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_UserGroup_User> File_VirtualUnit_UserGroup_Users { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_UserGroup_User_AuditLog> File_VirtualUnit_UserGroup_User_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_UserGroup_User_Link> File_VirtualUnit_UserGroup_User_Links { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_UserGroup_User_Link_AuditLog> File_VirtualUnit_UserGroup_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_UserGroup_Notification> File_VirtualUnit_UserGroup_Notifications { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_UserGroup_Notification_AuditLog> File_VirtualUnit_UserGroup_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_File_VirtualUnit_UserGroup_Permission> File_VirtualUnit_UserGroup_Permissions { get; set; }
        public DbSet<DbStorage_File_VirtualUnit_UserGroup_Permission_AuditLog> File_VirtualUnit_UserGroup_Permission_AuditLogs { get; set; }
        #endregion

        #region Metadata Keys
        public DbSet<DbStorage_MetadataKey> MetadataKeys { get; set; }
        public DbSet<DbStorage_MetadataKey_AuditLog> MetadataKey_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_User> MetadataKey_Users { get; set; }
        public DbSet<DbStorage_MetadataKey_User_AuditLog> MetadataKey_User_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_User_Link> MetadataKey_User_Links { get; set; }
        public DbSet<DbStorage_MetadataKey_User_Link_AuditLog> MetadataKey_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_User_Notification> MetadataKey_User_Notifications { get; set; }
        public DbSet<DbStorage_MetadataKey_User_Notification_AuditLog> MetadataKey_User_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_User_Permission> MetadataKey_User_Permissions { get; set; }
        public DbSet<DbStorage_MetadataKey_User_Permission_AuditLog> MetadataKey_User_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_UserGroup> MetadataKey_UserGroups { get; set; }
        public DbSet<DbStorage_MetadataKey_UserGroup_AuditLog> MetadataKey_UserGroup_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_UserGroup_Link> MetadataKey_UserGroup_Links { get; set; }
        public DbSet<DbStorage_MetadataKey_UserGroup_Link_AuditLog> MetadataKey_UserGroup_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_UserGroup_Notification> MetadataKey_UserGroup_Notifications { get; set; }
        public DbSet<DbStorage_MetadataKey_UserGroup_Notification_AuditLog> MetadataKey_UserGroup_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_UserGroup_Permission> MetadataKey_UserGroup_Permissions { get; set; }
        public DbSet<DbStorage_MetadataKey_UserGroup_Permission_AuditLog> MetadataKey_UserGroup_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_UserGroup_User> MetadataKey_UserGroup_Users { get; set; }
        public DbSet<DbStorage_MetadataKey_UserGroup_User_AuditLog> MetadataKey_UserGroup_User_AuditLogs { get; set; }

        public DbSet<DbStorage_MetadataKey_UserGroup_User_Link> MetadataKey_UserGroup_User_Links { get; set; }
        public DbSet<DbStorage_MetadataKey_UserGroup_User_Link_AuditLog> MetadataKey_UserGroup_User_Link_AuditLogs { get; set; }
        #endregion

        #region RootDirectory
        public DbSet<DbStorage_RootDirectory> RootDirectories { get; set; }
        public DbSet<DbStorage_RootDirectory_AuditLog> RootDirectory_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata> RootDirectory_Metadata { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_AuditLog> RootDirectory_Metadata_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata_Link> RootDirectory_Metadata_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_Link_AuditLog> RootDirectory_Metadata_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_QrCode> RootDirectory_QrCodes { get; set; }
        public DbSet<DbStorage_RootDirectory_QrCode_AuditLog> RootDirectory_QrCode_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_Quality> RootDirectory_Qualities { get; set; }
        public DbSet<DbStorage_RootDirectory_Quality_AuditLog> RootDirectory_Quality_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_User> RootDirectory_Users { get; set; }
        public DbSet<DbStorage_RootDirectory_User_AuditLog> RootDirectory_User_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_User_Link> RootDirectory_User_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_User_Link_AuditLog> RootDirectory_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_User_Notification> RootDirectory_User_Notifications { get; set; }
        public DbSet<DbStorage_RootDirectory_User_Notification_AuditLog> RootDirectory_User_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_User_Permission> RootDirectory_User_Permissions { get; set; }
        public DbSet<DbStorage_RootDirectory_User_Permission_AuditLog> RootDirectory_User_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_UserGroup> RootDirectory_UserGroups { get; set; }
        public DbSet<DbStorage_RootDirectory_UserGroup_AuditLog> RootDirectory_UserGroup_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_UserGroup_Link> RootDirectory_UserGroup_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_UserGroup_Link_AuditLog> RootDirectory_UserGroup_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_UserGroup_Notification> RootDirectory_UserGroup_Notifications { get; set; }
        public DbSet<DbStorage_RootDirectory_UserGroup_Notification_AuditLog> RootDirectory_UserGroup_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_UserGroup_Permission> RootDirectory_UserGroup_Permissions { get; set; }
        public DbSet<DbStorage_RootDirectory_UserGroup_Permission_AuditLog> RootDirectory_UserGroup_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_UserGroup_User> RootDirectory_UserGroup_Users { get; set; }
        public DbSet<DbStorage_RootDirectory_UserGroup_User_AuditLog> RootDirectory_UserGroup_User_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_UserGroup_User_Link> RootDirectory_UserGroup_User_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_UserGroup_User_Link_AuditLog> RootDirectory_UserGroup_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit> RootDirectory_VirtualUnits { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_AuditLog> RootDirectory_VirtualUnit_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_User> RootDirectory_VirtualUnit_User { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_User_AuditLog> RootDirectory_VirtualUnit_User_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_User_Link> RootDirectory_VirtualUnit_User_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_User_Link_AuditLog> RootDirectory_VirtualUnit_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_User_Notification> RootDirectory_VirtualUnit_User_Notifications { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_User_Notification_AuditLog> RootDirectory_VirtualUnit_User_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_User_Permission> RootDirectory_VirtualUnit_User_Permissions { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_User_Permission_AuditLog> RootDirectory_VirtualUnit_User_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup> RootDirectory_VirtualUnit_UserGroups { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_AuditLog> RootDirectory_VirtualUnit_UserGroup_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_Link> RootDirectory_VirtualUnit_UserGroup_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_Link_AuditLog> RootDirectory_VirtualUnit_UserGroup_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_User> RootDirectory_VirtualUnit_UserGroup_Users { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_User_AuditLog> RootDirectory_VirtualUnit_UserGroup_User_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link> RootDirectory_VirtualUnit_UserGroup_User_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLog> RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification> RootDirectory_VirtualUnit_UserGroup_Notifications { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification_AuditLog> RootDirectory_VirtualUnit_UserGroup_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission> RootDirectory_VirtualUnit_UserGroup_Permissions { get; set; }
        public DbSet<DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission_AuditLog> RootDirectory_VirtualUnit_UserGroup_Permission_AuditLogs { get; set; }
        #endregion

        #region SubDirectory
        public DbSet<DbStorage_SubDirectory> SubDirectories { get; set; }
        public DbSet<DbStorage_SubDirectory_AuditLog> SubDirectory_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata> SubDirectory_Metadata { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_AuditLog> SubDirectory_Metadata_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata_Link> SubDirectory_Metadata_Link { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_Link_AuditLog> SubDirectory_Metadata_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_QrCode> SubDirectory_QrCodes { get; set; }
        public DbSet<DbStorage_SubDirectory_QrCode_AuditLog> SubDirectory_QrCode_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_Quality> SubDirectory_Qualities { get; set; }
        public DbSet<DbStorage_SubDirectory_Quality_AuditLog> SubDirectory_Quality_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_User> SubDirectory_Users { get; set; }
        public DbSet<DbStorage_SubDirectory_User_AuditLog> SubDirectory_User_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_User_Link> SubDirectory_User_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_User_Link_AuditLog> SubDirectory_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_User_Notification> SubDirectory_User_Notifications { get; set; }
        public DbSet<DbStorage_SubDirectory_User_Notification_AuditLog> SubDirectory_User_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_User_Permission> SubDirectory_User_Permissions { get; set; }
        public DbSet<DbStorage_SubDirectory_User_Permission_AuditLog> SubDirectory_User_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_UserGroup> SubDirectory_UserGroups { get; set; }
        public DbSet<DbStorage_SubDirectory_UserGroup_AuditLog> SubDirectory_UserGroup_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_UserGroup_Link> SubDirectory_UserGroup_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_UserGroup_Link_AuditLog> SubDirectory_UserGroup_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_UserGroup_Notification> SubDirectory_UserGroup_Notifications { get; set; }
        public DbSet<DbStorage_SubDirectory_UserGroup_Notification_AuditLog> SubDirectory_UserGroup_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_UserGroup_Permission> SubDirectory_UserGroup_Permissions { get; set; }
        public DbSet<DbStorage_SubDirectory_UserGroup_Permission_AuditLog> SubDirectory_UserGroup_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_UserGroup_User> SubDirectory_UserGroup_Users { get; set; }
        public DbSet<DbStorage_SubDirectory_UserGroup_User_AuditLog> SubDirectory_UserGroup_User_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_UserGroup_User_Link> SubDirectory_UserGroup_User_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_UserGroup_User_Link_AuditLog> SubDirectory_UserGroup_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit> SubDirectory_VirtualUnits { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_AuditLog> SubDirectory_VirtualUnit_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_User> SubDirectory_VirtualUnit_User { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_User_AuditLog> SubDirectory_VirtualUnit_User_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_User_Link> SubDirectory_VirtualUnit_User_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_User_Link_AuditLog> SubDirectory_VirtualUnit_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_User_Notification> SubDirectory_VirtualUnit_User_Notifications { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_User_Notification_AuditLog> SubDirectory_VirtualUnit_User_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_User_Permission> SubDirectory_VirtualUnit_User_Permissions { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_User_Permission_AuditLog> SubDirectory_VirtualUnit_User_Permission_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup> SubDirectory_VirtualUnit_UserGroups { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_AuditLog> SubDirectory_VirtualUnit_UserGroup_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_Link> SubDirectory_VirtualUnit_UserGroup_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_Link_AuditLog> SubDirectory_VirtualUnit_UserGroup_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_User> SubDirectory_VirtualUnit_UserGroup_Users { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_User_AuditLog> SubDirectory_VirtualUnit_UserGroup_User_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_User_Link> SubDirectory_VirtualUnit_UserGroup_User_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLog> SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification> SubDirectory_VirtualUnit_UserGroup_Notifications { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification_AuditLog> SubDirectory_VirtualUnit_UserGroup_Notification_AuditLogs { get; set; }

        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission> SubDirectory_VirtualUnit_UserGroup_Permissions { get; set; }
        public DbSet<DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission_AuditLog> SubDirectory_VirtualUnit_UserGroup_Permission_AuditLogs { get; set; }
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

            //modelBuilder.Entity<DbStorage_File>()
            //            .HasIndex(b => new { b.AuthorizationUserIdsExtString })
            //            .HasDatabaseName("IX_Names_Ascendingasd");

            //modelBuilder.Entity<DbStorage_File>()
            //            .HasIndex(b => new { b.AuthorizationUserGroupIdsExtString })
            //            .HasDatabaseName("IX_Names_Descendinasdg")
            //            .IsDescending();

            //modelBuilder.Entity<DbStorage_File>()
            //            .HasIndex(b => new { b.AuthorizationUserIdsExtString, b.AuthorizationUserGroupIdsExtString })
            //            .HasDatabaseName("IX_Names_Descendasding")
            //            .IsDescending();

            //modelBuilder.ApplyConfiguration(new ModelLogTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new ModelObjectTypeConfiguration());

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
                    #region File
                    case DbStorage_File file:
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
                            file.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            DbStorage_File fileOld = File_AuditLogs.Where(f => f.SourceId == file.Id).Last().GetChanges();

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
                            file.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
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

                            file.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_AuditLogs.Add(new DbStorage_File_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_AuditLog file_AuditLog:
                        break;

                    case DbStorage_File_Metadata file_Metadata:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_Metadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_Metadata.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_Metadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_Metadata.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_Metadata_AuditLogs.Add(new DbStorage_File_Metadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Metadata_AuditLog file_Metadata_AuditLog:
                        break;

                    case DbStorage_File_Metadata_Link file_Metadata_Link:
                        File_Metadata_Link_AuditLogs.Add(new DbStorage_File_Metadata_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Metadata_Link_AuditLog file_Metadata_Link_AuditLog:
                        break;

                    case DbStorage_File_QrCode file_QrCode:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_QrCode.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_QrCode.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_QrCode.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_QrCode.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_QrCode_AuditLogs.Add(new DbStorage_File_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_QrCode.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_QrCode_AuditLog file_QrCode_AuditLog:
                        break;

                    case DbStorage_File_Quality file_Quality:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_Quality.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_Quality.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_Quality.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_Quality.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_Quality_AuditLogs.Add(new DbStorage_File_Quality_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Quality.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Quality_AuditLog file_Quality_AuditLog:
                        break;

                    case DbStorage_File_User file_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_User_AuditLogs.Add(new DbStorage_File_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_User_AuditLog file_User_AuditLog:
                        break;

                    case DbStorage_File_User_Link file_User_Link:
                        File_User_Link_AuditLogs.Add(new DbStorage_File_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_User_Link_AuditLog file_User_Link_AuditLog:
                        break;

                    case DbStorage_File_User_Notification file_User_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_User_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_User_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_User_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_User_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_User_Notification_AuditLogs.Add(new DbStorage_File_User_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_User_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_User_Notification_AuditLog file_User_Notification_AuditLog:
                        break;

                    case DbStorage_File_User_Permission file_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_User_Permission_AuditLogs.Add(new DbStorage_File_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_User_Permission_AuditLog file_User_Permission_AuditLog:
                        break;

                    case DbStorage_File_UserGroup file_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_UserGroup_AuditLogs.Add(new DbStorage_File_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_UserGroup_AuditLog file_UserGroup_AuditLog:
                        break;

                    case DbStorage_File_UserGroup_Link file_UserGroup_Link:
                        File_UserGroup_Link_AuditLogs.Add(new DbStorage_File_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_UserGroup_Link_AuditLog file_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_File_UserGroup_Notification file_UserGroup_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_UserGroup_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_UserGroup_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_UserGroup_Notification_AuditLogs.Add(new DbStorage_File_UserGroup_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_UserGroup_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_UserGroup_Notification_AuditLog file_UserGroup_Notification_AuditLog:
                        break;

                    case DbStorage_File_UserGroup_Permission file_UserGroup_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_UserGroup_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_UserGroup_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_UserGroup_Permission_AuditLogs.Add(new DbStorage_File_UserGroup_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_UserGroup_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_UserGroup_Permission_AuditLog file_UserGroup_Permission_AuditLog:
                        break;

                    case DbStorage_File_UserGroup_User file_UserGroup_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_UserGroup_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_UserGroup_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_UserGroup_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_UserGroup_User_AuditLogs.Add(new DbStorage_File_UserGroup_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_UserGroup_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_UserGroup_User_AuditLog file_UserGroup_User_AuditLog:
                        break;

                    case DbStorage_File_UserGroup_User_Link file_UserGroup_User_Link:
                        File_UserGroup_User_Link_AuditLogs.Add(new DbStorage_File_UserGroup_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_UserGroup_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_UserGroup_User_Link_AuditLog file_UserGroup_User_Link_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit file_VirtualUnit:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_AuditLogs.Add(new DbStorage_File_VirtualUnit_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_AuditLog file_VirtualUnit_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_User file_VirtualUnit_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_User_AuditLogs.Add(new DbStorage_File_VirtualUnit_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_User_AuditLog file_VirtualUnit_User_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_User_Link file_VirtualUnit_User_Link:
                        File_VirtualUnit_User_Link_AuditLogs.Add(new DbStorage_File_VirtualUnit_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_User_Link_AuditLog file_VirtualUnit_User_Link_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_User_Notification file_VirtualUnit_User_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit_User_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_User_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit_User_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_User_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_User_Notification_AuditLogs.Add(new DbStorage_File_VirtualUnit_User_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_User_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_User_Notification_AuditLog file_VirtualUnit_User_Notification_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_User_Permission file_VirtualUnit_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_User_Permission_AuditLogs.Add(new DbStorage_File_VirtualUnit_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_User_Permission_AuditLog file_VirtualUnit_User_Permission_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup file_VirtualUnit_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_UserGroup_AuditLogs.Add(new DbStorage_File_VirtualUnit_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_AuditLog file_VirtualUnit_UserGroup_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_Link file_VirtualUnit_UserGroup_Link:
                        File_VirtualUnit_UserGroup_Link_AuditLogs.Add(new DbStorage_File_VirtualUnit_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_Link_AuditLog file_VirtualUnit_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_Notification file_VirtualUnit_UserGroup_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit_UserGroup_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit_UserGroup_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_UserGroup_Notification_AuditLogs.Add(new DbStorage_File_VirtualUnit_UserGroup_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_UserGroup_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_Notification_AuditLog file_VirtualUnit_UserGroup_Notification_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_Permission file_VirtualUnit_UserGroup_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit_UserGroup_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit_UserGroup_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_UserGroup_Permission_AuditLogs.Add(new DbStorage_File_VirtualUnit_UserGroup_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_UserGroup_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_Permission_AuditLog file_VirtualUnit_UserGroup_Permission_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_User file_VirtualUnit_UserGroup_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_VirtualUnit_UserGroup_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            file_VirtualUnit_UserGroup_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_VirtualUnit_UserGroup_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        File_VirtualUnit_UserGroup_User_AuditLogs.Add(new DbStorage_File_VirtualUnit_UserGroup_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_UserGroup_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_User_AuditLog file_VirtualUnit_UserGroup_User_AuditLog:
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_User_Link file_VirtualUnit_UserGroup_User_Link:
                        File_VirtualUnit_UserGroup_User_Link_AuditLogs.Add(new DbStorage_File_VirtualUnit_UserGroup_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_VirtualUnit_UserGroup_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_VirtualUnit_UserGroup_User_Link_AuditLog file_VirtualUnit_UserGroup_User_Link_AuditLog:
                        break;
                    #endregion

                    #region Metadata Keys
                    case DbStorage_MetadataKey metadataKey:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_AuditLogs.Add(new DbStorage_MetadataKey_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_AuditLog metadataKey_AuditLog:
                        break;

                    case DbStorage_MetadataKey_User metadataKey_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_User_AuditLogs.Add(new DbStorage_MetadataKey_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_User_AuditLog metadataKey_User_AuditLog:
                        break;

                    case DbStorage_MetadataKey_User_Link metadataKey_User_Link:
                        MetadataKey_User_Link_AuditLogs.Add(new DbStorage_MetadataKey_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_User_Link_AuditLog metadataKey_User_Link_AuditLog:
                        break;

                    case DbStorage_MetadataKey_User_Notification metadataKey_User_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey_User_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_User_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey_User_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_User_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_User_Notification_AuditLogs.Add(new DbStorage_MetadataKey_User_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_User_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_User_Notification_AuditLog metadataKey_User_Notification_AuditLog:
                        break;

                    case DbStorage_MetadataKey_User_Permission metadataKey_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_User_Permission_AuditLogs.Add(new DbStorage_MetadataKey_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_User_Permission_AuditLog metadataKey_User_Permission_AuditLog:
                        break;

                    case DbStorage_MetadataKey_UserGroup metadataKey_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_UserGroup_AuditLogs.Add(new DbStorage_MetadataKey_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_UserGroup_AuditLog metadataKey_UserGroup_AuditLog:
                        break;

                    case DbStorage_MetadataKey_UserGroup_Link metadataKey_UserGroup_Link:
                        MetadataKey_UserGroup_Link_AuditLogs.Add(new DbStorage_MetadataKey_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_UserGroup_Link_AuditLog metadataKey_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_MetadataKey_UserGroup_Notification metadataKey_UserGroup_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey_UserGroup_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey_UserGroup_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_UserGroup_Notification_AuditLogs.Add(new DbStorage_MetadataKey_UserGroup_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_UserGroup_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_UserGroup_Notification_AuditLog metadataKey_UserGroup_Notification_AuditLog:
                        break;

                    case DbStorage_MetadataKey_UserGroup_Permission metadataKey_UserGroup_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey_UserGroup_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey_UserGroup_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_UserGroup_Permission_AuditLogs.Add(new DbStorage_MetadataKey_UserGroup_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_UserGroup_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_UserGroup_Permission_AuditLog metadataKey_UserGroup_Permission_AuditLog:
                        break;

                    case DbStorage_MetadataKey_UserGroup_User metadataKey_UserGroup_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            metadataKey_UserGroup_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            metadataKey_UserGroup_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            metadataKey_UserGroup_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        MetadataKey_UserGroup_User_AuditLogs.Add(new DbStorage_MetadataKey_UserGroup_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_UserGroup_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_UserGroup_User_AuditLog metadataKey_UserGroup_User_AuditLog:
                        break;

                    case DbStorage_MetadataKey_UserGroup_User_Link metadataKey_UserGroup_User_Link:
                        MetadataKey_UserGroup_User_Link_AuditLogs.Add(new DbStorage_MetadataKey_UserGroup_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = metadataKey_UserGroup_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_MetadataKey_UserGroup_User_Link_AuditLog metadataKey_UserGroup_User_Link_AuditLog:
                        break;








                        _AuditLogs

                    #endregion

                    #region RootDirectory
                    case DbStorage_RootDirectory rootDirectory:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_AuditLogs.Add(new DbStorage_RootDirectory_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_AuditLog rootDirectory_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata rootDirectory_Metadata:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_Metadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_Metadata.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_Metadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_Metadata.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_Metadata_AuditLogs.Add(new DbStorage_RootDirectory_Metadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Metadata_AuditLog rootDirectory_Metadata_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata_Link rootDirectory_Metadata_Link:
                        RootDirectory_Metadata_Link_AuditLogs.Add(new DbStorage_RootDirectory_Metadata_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Metadata_Link_AuditLog rootDirectory_Metadata_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_QrCode rootDirectory_QrCode:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_QrCode.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_QrCode.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_QrCode.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_QrCode.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_QrCode_AuditLogs.Add(new DbStorage_RootDirectory_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_QrCode.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_QrCode_AuditLog rootDirectory_QrCode_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Quality rootDirectory_Quality:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_Quality.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_Quality.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_Quality.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_Quality.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_Quality_AuditLogs.Add(new DbStorage_RootDirectory_Quality_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Quality.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Quality_AuditLog rootDirectory_Quality_AuditLog:
                        break;

                    case DbStorage_RootDirectory_User RootDirectory_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            RootDirectory_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            RootDirectory_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_User_AuditLogs.Add(new DbStorage_RootDirectory_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_User_AuditLog RootDirectory_User_AuditLog:
                        break;

                    case DbStorage_RootDirectory_User_Link RootDirectory_User_Link:
                        RootDirectory_User_Link_AuditLogs.Add(new DbStorage_RootDirectory_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_User_Link_AuditLog RootDirectory_User_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_User_Notification RootDirectory_User_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            RootDirectory_User_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_User_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            RootDirectory_User_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_User_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_User_Notification_AuditLogs.Add(new DbStorage_RootDirectory_User_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_User_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_User_Notification_AuditLog RootDirectory_User_Notification_AuditLog:
                        break;

                    case DbStorage_RootDirectory_User_Permission RootDirectory_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            RootDirectory_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            RootDirectory_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_User_Permission_AuditLogs.Add(new DbStorage_RootDirectory_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_User_Permission_AuditLog RootDirectory_User_Permission_AuditLog:
                        break;

                    case DbStorage_RootDirectory_UserGroup RootDirectory_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            RootDirectory_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            RootDirectory_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_UserGroup_AuditLogs.Add(new DbStorage_RootDirectory_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_UserGroup_AuditLog RootDirectory_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectory_UserGroup_Link RootDirectory_UserGroup_Link:
                        RootDirectory_UserGroup_Link_AuditLogs.Add(new DbStorage_RootDirectory_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_UserGroup_Link_AuditLog RootDirectory_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_UserGroup_Notification RootDirectory_UserGroup_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            RootDirectory_UserGroup_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            RootDirectory_UserGroup_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_UserGroup_Notification_AuditLogs.Add(new DbStorage_RootDirectory_UserGroup_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_UserGroup_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_UserGroup_Notification_AuditLog RootDirectory_UserGroup_Notification_AuditLog:
                        break;

                    case DbStorage_RootDirectory_UserGroup_Permission RootDirectory_UserGroup_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            RootDirectory_UserGroup_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            RootDirectory_UserGroup_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_UserGroup_Permission_AuditLogs.Add(new DbStorage_RootDirectory_UserGroup_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_UserGroup_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_UserGroup_Permission_AuditLog RootDirectory_UserGroup_Permission_AuditLog:
                        break;

                    case DbStorage_RootDirectory_UserGroup_User RootDirectory_UserGroup_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            RootDirectory_UserGroup_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            RootDirectory_UserGroup_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            RootDirectory_UserGroup_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_UserGroup_User_AuditLogs.Add(new DbStorage_RootDirectory_UserGroup_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_UserGroup_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_UserGroup_User_AuditLog RootDirectory_UserGroup_User_AuditLog:
                        break;

                    case DbStorage_RootDirectory_UserGroup_User_Link RootDirectory_UserGroup_User_Link:
                        RootDirectory_UserGroup_User_Link_AuditLogs.Add(new DbStorage_RootDirectory_UserGroup_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = RootDirectory_UserGroup_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_UserGroup_User_Link_AuditLog RootDirectory_UserGroup_User_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit rootDirectory_VirtualUnit:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_AuditLog rootDirectory_VirtualUnit_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User rootDirectory_VirtualUnit_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_User_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User_AuditLog rootDirectory_VirtualUnit_User_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User_Link rootDirectory_VirtualUnit_User_Link:
                        RootDirectory_VirtualUnit_User_Link_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User_Link_AuditLog rootDirectory_VirtualUnit_User_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User_Notification rootDirectory_VirtualUnit_User_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit_User_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_User_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit_User_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_User_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_User_Notification_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_User_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_User_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User_Notification_AuditLog rootDirectory_VirtualUnit_User_Notification_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User_Permission rootDirectory_VirtualUnit_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_User_Permission_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_User_Permission_AuditLog rootDirectory_VirtualUnit_User_Permission_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup rootDirectory_VirtualUnit_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_UserGroup_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_AuditLog rootDirectory_VirtualUnit_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_Link rootDirectory_VirtualUnit_UserGroup_Link:
                        RootDirectory_VirtualUnit_UserGroup_Link_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_Link_AuditLog rootDirectory_VirtualUnit_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification rootDirectory_VirtualUnit_UserGroup_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit_UserGroup_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit_UserGroup_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_UserGroup_Notification_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_UserGroup_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_Notification_AuditLog rootDirectory_VirtualUnit_UserGroup_Notification_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission rootDirectory_VirtualUnit_UserGroup_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit_UserGroup_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit_UserGroup_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_UserGroup_Permission_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_UserGroup_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_Permission_AuditLog rootDirectory_VirtualUnit_UserGroup_Permission_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_User rootDirectory_VirtualUnit_UserGroup_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_VirtualUnit_UserGroup_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            rootDirectory_VirtualUnit_UserGroup_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_VirtualUnit_UserGroup_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        RootDirectory_VirtualUnit_UserGroup_User_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_UserGroup_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_User_AuditLog rootDirectory_VirtualUnit_UserGroup_User_AuditLog:
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link rootDirectory_VirtualUnit_UserGroup_User_Link:
                        RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLogs.Add(new DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_VirtualUnit_UserGroup_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_VirtualUnit_UserGroup_User_Link_AuditLog rootDirectory_VirtualUnit_UserGroup_User_Link_AuditLog:
                        break;
                    #endregion

                    #region SubDirectory
                    case DbStorage_SubDirectory subDirectory:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_AuditLogs.Add(new DbStorage_SubDirectory_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_AuditLog subDirectory_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata subDirectory_Metadata:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_Metadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_Metadata.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_Metadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_Metadata.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_Metadata_AuditLogs.Add(new DbStorage_SubDirectory_Metadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Metadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Metadata_AuditLog subDirectory_Metadata_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata_Link subDirectory_Metadata_Link:
                        SubDirectory_Metadata_Link_AuditLogs.Add(new DbStorage_SubDirectory_Metadata_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Metadata_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Metadata_Link_AuditLog subDirectory_Metadata_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_QrCode subDirectory_QrCode:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_QrCode.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_QrCode.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_QrCode.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_QrCode.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_QrCode_AuditLogs.Add(new DbStorage_SubDirectory_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_QrCode.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_QrCode_AuditLog subDirectory_QrCode_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Quality subDirectory_Quality:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_Quality.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_Quality.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_Quality.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_Quality.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_Quality_AuditLogs.Add(new DbStorage_SubDirectory_Quality_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Quality.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Quality_AuditLog subDirectory_Quality_AuditLog:
                        break;

                    case DbStorage_SubDirectory_User SubDirectory_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            SubDirectory_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            SubDirectory_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_User_AuditLogs.Add(new DbStorage_SubDirectory_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_User_AuditLog SubDirectory_User_AuditLog:
                        break;

                    case DbStorage_SubDirectory_User_Link SubDirectory_User_Link:
                        SubDirectory_User_Link_AuditLogs.Add(new DbStorage_SubDirectory_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_User_Link_AuditLog SubDirectory_User_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_User_Notification SubDirectory_User_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            SubDirectory_User_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_User_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            SubDirectory_User_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_User_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_User_Notification_AuditLogs.Add(new DbStorage_SubDirectory_User_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_User_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_User_Notification_AuditLog SubDirectory_User_Notification_AuditLog:
                        break;

                    case DbStorage_SubDirectory_User_Permission SubDirectory_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            SubDirectory_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            SubDirectory_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_User_Permission_AuditLogs.Add(new DbStorage_SubDirectory_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_User_Permission_AuditLog SubDirectory_User_Permission_AuditLog:
                        break;

                    case DbStorage_SubDirectory_UserGroup SubDirectory_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            SubDirectory_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            SubDirectory_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_UserGroup_AuditLogs.Add(new DbStorage_SubDirectory_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_UserGroup_AuditLog SubDirectory_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectory_UserGroup_Link SubDirectory_UserGroup_Link:
                        SubDirectory_UserGroup_Link_AuditLogs.Add(new DbStorage_SubDirectory_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_UserGroup_Link_AuditLog SubDirectory_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_UserGroup_Notification SubDirectory_UserGroup_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            SubDirectory_UserGroup_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            SubDirectory_UserGroup_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_UserGroup_Notification_AuditLogs.Add(new DbStorage_SubDirectory_UserGroup_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_UserGroup_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_UserGroup_Notification_AuditLog SubDirectory_UserGroup_Notification_AuditLog:
                        break;

                    case DbStorage_SubDirectory_UserGroup_Permission SubDirectory_UserGroup_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            SubDirectory_UserGroup_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            SubDirectory_UserGroup_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_UserGroup_Permission_AuditLogs.Add(new DbStorage_SubDirectory_UserGroup_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_UserGroup_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_UserGroup_Permission_AuditLog SubDirectory_UserGroup_Permission_AuditLog:
                        break;

                    case DbStorage_SubDirectory_UserGroup_User SubDirectory_UserGroup_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            SubDirectory_UserGroup_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            SubDirectory_UserGroup_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            SubDirectory_UserGroup_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_UserGroup_User_AuditLogs.Add(new DbStorage_SubDirectory_UserGroup_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_UserGroup_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_UserGroup_User_AuditLog SubDirectory_UserGroup_User_AuditLog:
                        break;

                    case DbStorage_SubDirectory_UserGroup_User_Link SubDirectory_UserGroup_User_Link:
                        SubDirectory_UserGroup_User_Link_AuditLogs.Add(new DbStorage_SubDirectory_UserGroup_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = SubDirectory_UserGroup_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_UserGroup_User_Link_AuditLog SubDirectory_UserGroup_User_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit subDirectory_VirtualUnit:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_AuditLog subDirectory_VirtualUnit_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User subDirectory_VirtualUnit_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_User_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User_AuditLog subDirectory_VirtualUnit_User_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User_Link subDirectory_VirtualUnit_User_Link:
                        SubDirectory_VirtualUnit_User_Link_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User_Link_AuditLog subDirectory_VirtualUnit_User_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User_Notification subDirectory_VirtualUnit_User_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit_User_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_User_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit_User_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_User_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_User_Notification_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_User_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_User_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User_Notification_AuditLog subDirectory_VirtualUnit_User_Notification_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User_Permission subDirectory_VirtualUnit_User_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit_User_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_User_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit_User_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_User_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_User_Permission_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_User_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_User_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_User_Permission_AuditLog subDirectory_VirtualUnit_User_Permission_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup subDirectory_VirtualUnit_UserGroup:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit_UserGroup.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit_UserGroup.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_UserGroup_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_AuditLog subDirectory_VirtualUnit_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_Link subDirectory_VirtualUnit_UserGroup_Link:
                        SubDirectory_VirtualUnit_UserGroup_Link_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_Link_AuditLog subDirectory_VirtualUnit_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification subDirectory_VirtualUnit_UserGroup_Notification:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit_UserGroup_Notification.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup_Notification.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit_UserGroup_Notification.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup_Notification.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_UserGroup_Notification_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_UserGroup_Notification.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_Notification_AuditLog subDirectory_VirtualUnit_UserGroup_Notification_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission subDirectory_VirtualUnit_UserGroup_Permission:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit_UserGroup_Permission.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup_Permission.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit_UserGroup_Permission.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup_Permission.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_UserGroup_Permission_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_UserGroup_Permission.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_Permission_AuditLog subDirectory_VirtualUnit_UserGroup_Permission_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_User subDirectory_VirtualUnit_UserGroup_User:
                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_VirtualUnit_UserGroup_User.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup_User.CreatedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else
                        {
                            subDirectory_VirtualUnit_UserGroup_User.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_VirtualUnit_UserGroup_User.ModifiedByUserId_ExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion

                        SubDirectory_VirtualUnit_UserGroup_User_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_UserGroup_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_User_AuditLog subDirectory_VirtualUnit_UserGroup_User_AuditLog:
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_User_Link subDirectory_VirtualUnit_UserGroup_User_Link:
                        SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLogs.Add(new DbStorage_SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_VirtualUnit_UserGroup_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserId_Ext = DatabaseSessionParameter_UserId,
                            SoftwareId_Ext = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_VirtualUnit_UserGroup_User_Link_AuditLog subDirectory_VirtualUnit_UserGroup_User_Link_AuditLog:
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
