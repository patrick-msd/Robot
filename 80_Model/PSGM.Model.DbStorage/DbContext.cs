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
        #region File
        public DbSet<DbStorage_File> Files { get; set; }
        public DbSet<DbStorage_File_AuditLog> File_AuditLog { get; set; }

        public DbSet<DbStorage_File_Authorization_User> File_Authorization_Users { get; set; }
        public DbSet<DbStorage_File_Authorization_User_AuditLog> File_Authorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_File_Authorization_User_Link> File_Authorization_User_Links { get; set; }
        public DbSet<DbStorage_File_Authorization_User_Link_AuditLog> File_Authorization_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_File_Authorization_UserGroup> File_Authorization_UserGroups { get; set; }
        public DbSet<DbStorage_File_Authorization_UserGroup_AuditLog> File_Authorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_File_Authorization_UserGroup_Link> File_Authorization_UserGroup_Links { get; set; }
        public DbSet<DbStorage_File_Authorization_UserGroup_Link_AuditLog> File_Authorization_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_File_Metadata> File_Metadata { get; set; }
        public DbSet<DbStorage_File_Metadata_AuditLog> File_Metadata_AuditLog { get; set; }

        public DbSet<DbStorage_File_Metadata_Authorization_User> File_MetadataAuthorization_Users { get; set; }
        public DbSet<DbStorage_File_Metadata_Authorization_User_AuditLog> File_Metadata_Authorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_File_Metadata_Authorization_User_Link> File_MetadataAuthorization_User_Links { get; set; }
        public DbSet<DbStorage_File_Metadata_Authorization_User_Link_AuditLog> File_Metadata_Authorization_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_File_Metadata_Authorization_UserGroup> File_MetadataAuthorization_UserGroups { get; set; }
        public DbSet<DbStorage_File_Metadata_Authorization_UserGroup_AuditLog> File_Metadata_Authorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_File_Metadata_Authorization_UserGroup_Link> File_MetadataAuthorization_UserGroup_Links { get; set; }
        public DbSet<DbStorage_File_Metadata_Authorization_UserGroup_Link_AuditLog> File_Metadata_Authorization_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_File_Metadata_Link> File_Metadata_Link { get; set; }
        public DbSet<DbStorage_File_Metadata_Link_AuditLog> File_Metadata_Link_AuditLog { get; set; }

        public DbSet<DbStorage_File_Notification_User> File_Notification_Users { get; set; }
        public DbSet<DbStorage_File_Notification_User_AuditLog> File_Notification_User_AuditLog { get; set; }

        public DbSet<DbStorage_File_Notification_User_Link> File_Notification_User_Links { get; set; }
        public DbSet<DbStorage_File_Notification_User_Link_AuditLog> File_Notification_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_File_Notification_UserGroup> File_Notification_UserGroups { get; set; }
        public DbSet<DbStorage_File_Notification_UserGroup_AuditLog> File_Notification_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_File_Notification_UserGroup_Link> File_Notification_UserGroup_Links { get; set; }
        public DbSet<DbStorage_File_Notification_UserGroup_Link_AuditLog> File_Notification_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_File_QrCode> File_QrCodes { get; set; }
        public DbSet<DbStorage_File_QrCode_AuditLog> File_QrCode_AuditLog { get; set; }

        public DbSet<DbStorage_File_Quality> File_Qualities { get; set; }
        public DbSet<DbStorage_File_Quality_AuditLog> File_Quality_AuditLog { get; set; }
        #endregion

        #region RootDirectory
        public DbSet<DbStorage_RootDirectory> RootDirectories { get; set; }
        public DbSet<DbStorage_RootDirectory_AuditLog> RootDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Authorization_User> RootDirectory_Authorization_Users { get; set; }
        public DbSet<DbStorage_RootDirectory_Authorization_User_AuditLog> RootDirectory_Authorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Authorization_User_Link> RootDirectory_Authorization_User_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Authorization_User_Link_AuditLog> RootDirectory_Authorization_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Authorization_UserGroup> RootDirectory_Authorization_UserGroups { get; set; }
        public DbSet<DbStorage_RootDirectory_Authorization_UserGroup_AuditLog> RootDirectory_Authorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Authorization_UserGroup_Link> RootDirectory_Authorization_UserGroup_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Authorization_UserGroup_Link_AuditLog> RootDirectory_Authorization_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata> RootDirectory_Metadata { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_AuditLog> RootDirectory_Metadata_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_User> RootDirectory_Metadata_Authorization_Users { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_User_AuditLog> RootDirectory_Metadata_Authorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_User_Link> RootDirectory_Metadata_Authorization_User_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_User_Link_AuditLog> RootDirectory_Metadata_Authorization_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_UserGroup> RootDirectory_Metadata_Authorization_UserGroups { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_UserGroup_AuditLog> RootDirectory_Metadata_Authorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link> RootDirectory_Metadata_Authorization_UserGroup_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog> RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Metadata_Link> RootDirectory_Metadata_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Metadata_Link_AuditLog> RootDirectory_Metadata_Link_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Notification_User> RootDirectory_Notification_Users { get; set; }
        public DbSet<DbStorage_RootDirectory_Notification_User_AuditLog> RootDirectory_Notification_User_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Notification_User_Link> RootDirectoryNotification_User_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Notification_User_Link_AuditLog> RootDirectory_Notification_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Notification_UserGroup> RootDirectory_Notification_UserGroups { get; set; }
        public DbSet<DbStorage_RootDirectory_Notification_UserGroup_AuditLog> RootDirectory_Notification_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Notification_UserGroup_Link> RootDirectoryNotification_UserGroup_Links { get; set; }
        public DbSet<DbStorage_RootDirectory_Notification_UserGroup_Link_AuditLog> RootDirectory_Notification_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_QrCode> RootDirectory_QrCodes { get; set; }
        public DbSet<DbStorage_RootDirectory_QrCode_AuditLog> RootDirectory_QrCode_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory_Quality> RootDirectory_Qualities { get; set; }
        public DbSet<DbStorage_RootDirectory_Quality_AuditLog> RootDirectory_Quality_AuditLog { get; set; }
        #endregion

        #region SubDirectory
        public DbSet<DbStorage_SubDirectory> SubDirectories { get; set; }
        public DbSet<DbStorage_SubDirectory_AuditLog> SubDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Authorization_User> SubDirectory_Authorization_Users { get; set; }
        public DbSet<DbStorage_SubDirectory_Authorization_User_AuditLog> SubDirectory_Authorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Authorization_User_Link> SubDirectory_Authorization_User_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_Authorization_User_Link_AuditLog> SubDirectory_Authorization_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Authorization_UserGroup> SubDirectory_Authorization_UserGroups { get; set; }
        public DbSet<DbStorage_SubDirectory_Authorization_UserGroup_AuditLog> SubDirectory_Authorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Authorization_UserGroup_Link> SubDirectory_Authorization_UserGroup_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_Authorization_UserGroup_Link_AuditLog> SubDirectory_Authorization_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata> SubDirectory_Metadata { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_AuditLog> SubDirectory_Metadata_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_User> SubDirectory_MetadataAuthorization_Users { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_User_AuditLog> SubDirectory_MetadataAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_User_Link> SubDirectory_MetadataAuthorization_User_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_User_Link_AuditLog> SubDirectory_MetadataAuthorization_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_UserGroup> SubDirectory_MetadataAuthorization_UserGroups { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_UserGroup_AuditLog> SubDirectory_MetadataAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link> SubDirectory_MetadataAuthorization_UserGroup_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link_AuditLog> SubDirectory_MetadataAuthorization_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Metadata_Link> SubDirectory_Metadata_Link { get; set; }
        public DbSet<DbStorage_SubDirectory_Metadata_Link_AuditLog> SubDirectory_Metadata_Link_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Notification_User> SubDirectory_Notification_Users { get; set; }
        public DbSet<DbStorage_SubDirectory_Notification_User_AuditLog> SubDirectory_Notification_User_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Notification_User_Link> SubDirectory_Notification_User_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_Notification_User_Link_AuditLog> SubDirectory_Notification_User_Link_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Notification_UserGroup> SubDirectory_Notification_UserGroups { get; set; }
        public DbSet<DbStorage_SubDirectory_Notification_UserGroup_AuditLog> SubDirectory_Notification_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Notification_UserGroup_Link> SubDirectory_Notification_UserGroup_Links { get; set; }
        public DbSet<DbStorage_SubDirectory_Notification_UserGroup_Link_AuditLog> SubDirectory_Notification_UserGroup_Link_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_QrCode> SubDirectory_QrCodes { get; set; }
        public DbSet<DbStorage_SubDirectory_QrCode_AuditLog> SubDirectory_QrCode_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory_Quality> SubDirectory_Qualities { get; set; }
        public DbSet<DbStorage_SubDirectory_Quality_AuditLog> SubDirectory_Quality_AuditLog { get; set; }
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
                    #region File
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

                    case DbStorage_File_Authorization_User file_Authorization_User:
                        File_Authorization_User_AuditLog.Add(new DbStorage_File_Authorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Authorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Authorization_User_AuditLog file_Authorization_User_AuditLog:
                        break;

                    case DbStorage_File_Authorization_User_Link file_Authorization_User_Link:
                        File_Authorization_User_Link_AuditLog.Add(new DbStorage_File_Authorization_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Authorization_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Authorization_User_Link_AuditLog file_Authorization_User_Link_AuditLog:
                        break;

                    case DbStorage_File_Authorization_UserGroup file_Authorization_UserGroup:
                        File_Authorization_UserGroup_AuditLog.Add(new DbStorage_File_Authorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Authorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Authorization_UserGroup_AuditLog file_Authorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_File_Authorization_UserGroup_Link file_Authorization_UserGroup_Link:
                        File_Authorization_UserGroup_Link_AuditLog.Add(new DbStorage_File_Authorization_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Authorization_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Authorization_UserGroup_Link_AuditLog file_Authorization_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_File_Metadata file_Metadata:
                        File_Metadata_AuditLog.Add(new DbStorage_File_Metadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster subDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            file_Metadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file_Metadata.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            file_Metadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file_Metadata.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_File_Metadata_AuditLog file_Metadata_AuditLog:
                        break;

                    case DbStorage_File_Metadata_Authorization_User file_Metadata_Authorization_User:
                        File_Metadata_Authorization_User_AuditLog.Add(new DbStorage_File_Metadata_Authorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata_Authorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Metadata_Authorization_User_AuditLog file_Metadata_Authorization_User_AuditLog:
                        break;

                    case DbStorage_File_Metadata_Authorization_User_Link file_Metadata_Authorization_User_Link:
                        File_Metadata_Authorization_User_Link_AuditLog.Add(new DbStorage_File_Metadata_Authorization_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata_Authorization_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Metadata_Authorization_User_Link_AuditLog file_Metadata_Authorization_User_Link_AuditLog:
                        break;

                    case DbStorage_File_Metadata_Authorization_UserGroup file_Metadata_Authorization_UserGroup:
                        File_Metadata_Authorization_UserGroup_AuditLog.Add(new DbStorage_File_Metadata_Authorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata_Authorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Metadata_Authorization_UserGroup_AuditLog file_Metadata_Authorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_File_Metadata_Authorization_UserGroup_Link file_Metadata_Authorization_UserGroup_Link:
                        File_Metadata_Authorization_UserGroup_Link_AuditLog.Add(new DbStorage_File_Metadata_Authorization_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata_Authorization_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Metadata_Authorization_UserGroup_Link_AuditLog file_Metadata_Authorization_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_File_Metadata_Link file_Metadata_Link:
                        File_Metadata_Link_AuditLog.Add(new DbStorage_File_Metadata_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Metadata_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Metadata_Link_AuditLog file_Metadata_Link_AuditLog:
                        break;

                    case DbStorage_File_Notification_User file_Notification_User:
                        File_Notification_User_AuditLog.Add(new DbStorage_File_Notification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Notification_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Notification_User_AuditLog file_Notification_User_AuditLog:
                        break;

                    case DbStorage_File_Notification_User_Link file_Notification_User_Link:
                        File_Notification_User_Link_AuditLog.Add(new DbStorage_File_Notification_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Notification_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Notification_User_Link_AuditLog file_Notification_User_Link_AuditLog:
                        break;

                    case DbStorage_File_Notification_UserGroup file_Notification_UserGroup:
                        File_Notification_UserGroup_AuditLog.Add(new DbStorage_File_Notification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Notification_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Notification_UserGroup_AuditLog file_Notification_UserGroup_AuditLog:
                        break;

                    case DbStorage_File_Notification_UserGroup_Link file_Notification_UserGroup_Link:
                        File_Notification_UserGroup_Link_AuditLog.Add(new DbStorage_File_Notification_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Notification_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Notification_UserGroup_Link_AuditLog file_Notification_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_File_QrCode file_QrCode:
                        File_QrCode_AuditLog.Add(new DbStorage_File_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_QrCode.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_QrCode_AuditLog file_QrCode_AuditLog:
                        break;

                    case DbStorage_File_Quality file_Quality:
                        File_Quality_AuditLog.Add(new DbStorage_File_Quality_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = file_Quality.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_File_Quality_AuditLog file_Quality_AuditLog:
                        break;
                    #endregion

                    #region RootDirectory
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

                    case DbStorage_RootDirectory_Authorization_User rootDirectory_Authorization_User:
                        RootDirectory_Authorization_User_AuditLog.Add(new DbStorage_RootDirectory_Authorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Authorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Authorization_User_AuditLog rootDirectory_Authorization_User_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Authorization_User_Link rootDirectory_Authorization_User_Link:
                        RootDirectory_Authorization_User_Link_AuditLog.Add(new DbStorage_RootDirectory_Authorization_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Authorization_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Authorization_User_Link_AuditLog rootDirectory_Authorization_User_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Authorization_UserGroup rootDirectory_Authorization_UserGroup:
                        RootDirectory_Authorization_UserGroup_AuditLog.Add(new DbStorage_RootDirectory_Authorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Authorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Authorization_UserGroup_AuditLog rootDirectory_Authorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Authorization_UserGroup_Link rootDirectory_Authorization_UserGroup_Link:
                        RootDirectory_Authorization_UserGroup_Link_AuditLog.Add(new DbStorage_RootDirectory_Authorization_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Authorization_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Authorization_UserGroup_Link_AuditLog rootDirectory_Authorization_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata rootDirectory_Metadata:
                        RootDirectory_Metadata_AuditLog.Add(new DbStorage_RootDirectory_Metadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster subDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectory_Metadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_Metadata.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            rootDirectory_Metadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory_Metadata.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_RootDirectory_Metadata_AuditLog rootDirectory_Metadata_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_User rootDirectory_Metadata_Authorization_User:
                        RootDirectory_Metadata_Authorization_User_AuditLog.Add(new DbStorage_RootDirectory_Metadata_Authorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata_Authorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_User_AuditLog rootDirectory_Metadata_Authorization_User_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_User_Link rootDirectory_Metadata_Authorization_User_Link:
                        RootDirectory_Metadata_Authorization_User_Link_AuditLog.Add(new DbStorage_RootDirectory_Metadata_Authorization_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata_Authorization_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_User_Link_AuditLog rootDirectory_Metadata_Authorization_User_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_UserGroup rootDirectory_Metadata_Authorization_UserGroup:
                        RootDirectory_Metadata_Authorization_UserGroup_AuditLog.Add(new DbStorage_RootDirectory_Metadata_Authorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata_Authorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_UserGroup_AuditLog rootDirectory_Metadata_Authorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link rootDirectory_Metadata_Authorization_UserGroup_Link:
                        RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog.Add(new DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata_Authorization_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog rootDirectory_Metadata_Authorization_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Metadata_Link rootDirectory_Metadata_Link:
                        RootDirectory_Metadata_Link_AuditLog.Add(new DbStorage_RootDirectory_Metadata_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Metadata_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Metadata_Link_AuditLog rootDirectory_Metadata_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Notification_User rootDirectory_Notification_User:
                        RootDirectory_Notification_User_AuditLog.Add(new DbStorage_RootDirectory_Notification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Notification_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Notification_User_AuditLog rootDirectory_Notification_User_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Notification_User_Link rootDirectory_Notification_User_Link:
                        RootDirectory_Notification_User_Link_AuditLog.Add(new DbStorage_RootDirectory_Notification_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Notification_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Notification_User_Link_AuditLog rootDirectory_Notification_User_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Notification_UserGroup rootDirectory_Notification_UserGroup:
                        RootDirectory_Notification_UserGroup_Link_AuditLog.Add(new DbStorage_RootDirectory_Notification_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Notification_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Notification_UserGroup_AuditLog rootDirectory_Notification_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Notification_UserGroup_Link rootDirectory_Notification_UserGroup_Link:
                        RootDirectory_Notification_UserGroup_Link_AuditLog.Add(new DbStorage_RootDirectory_Notification_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Notification_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Notification_UserGroup_Link_AuditLog rootDirectory_Notification_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_RootDirectory_QrCode rootDirectory_QrCode:
                        RootDirectory_QrCode_AuditLog.Add(new DbStorage_RootDirectory_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_QrCode.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_QrCode_AuditLog rootDirectory_QrCode_AuditLog:
                        break;

                    case DbStorage_RootDirectory_Quality rootDirectory_Quality:
                        RootDirectory_Quality_AuditLog.Add(new DbStorage_RootDirectory_Quality_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory_Quality.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectory_Quality_AuditLog rootDirectory_Quality_AuditLog:
                        break;
                    #endregion

                    #region SubDirectory
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

                    case DbStorage_SubDirectory_Authorization_User subDirectory_Authorization_User:
                        SubDirectory_Authorization_User_AuditLog.Add(new DbStorage_SubDirectory_Authorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Authorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Authorization_User_AuditLog subDirectory_Authorization_User_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Authorization_User_Link subDirectory_Authorization_User_Link:
                        SubDirectory_Authorization_User_Link_AuditLog.Add(new DbStorage_SubDirectory_Authorization_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Authorization_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Authorization_User_Link_AuditLog subDirectory_Authorization_User_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Authorization_UserGroup subDirectory_Authorization_UserGroup:
                        SubDirectory_Authorization_UserGroup_AuditLog.Add(new DbStorage_SubDirectory_Authorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Authorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Authorization_UserGroup_AuditLog subDirectory_Authorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Authorization_UserGroup_Link subDirectory_Authorization_UserGroup_Link:
                        SubDirectory_Authorization_UserGroup_Link_AuditLog.Add(new DbStorage_SubDirectory_Authorization_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Authorization_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Authorization_UserGroup_Link_AuditLog subDirectory_Authorization_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata subDirectory_Metadata:
                        SubDirectory_Metadata_AuditLog.Add(new DbStorage_SubDirectory_Metadata_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Metadata.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster subDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectory_Metadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_Metadata.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            subDirectory_Metadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory_Metadata.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_SubDirectory_Metadata_AuditLog subDirectory_Metadata_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_User subDirectory_MetadataAuthorization_User:
                        SubDirectory_MetadataAuthorization_User_AuditLog.Add(new DbStorage_SubDirectory_Metadata_Authorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_MetadataAuthorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_User_AuditLog subDirectory_MetadataAuthorization_User_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_User_Link subDirectory_MetadataAuthorization_User_Link:
                        SubDirectory_MetadataAuthorization_User_Link_AuditLog.Add(new DbStorage_SubDirectory_Metadata_Authorization_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_MetadataAuthorization_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_User_Link_AuditLog subDirectory_MetadataAuthorization_User_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_UserGroup subDirectory_MetadataAuthorization_UserGroup:
                        SubDirectory_MetadataAuthorization_UserGroup_AuditLog.Add(new DbStorage_SubDirectory_Metadata_Authorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_MetadataAuthorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_UserGroup_AuditLog subDirectory_MetadataAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link subDirectory_MetadataAuthorization_UserGroup_Link:
                        SubDirectory_MetadataAuthorization_UserGroup_Link_AuditLog.Add(new DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_MetadataAuthorization_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Metadata_Authorization_UserGroup_Link_AuditLog subDirectory_MetadataAuthorization_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Metadata_Link subDirectory_Metadata_Link:
                        SubDirectory_Metadata_Link_AuditLog.Add(new DbStorage_SubDirectory_Metadata_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Metadata_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Metadata_Link_AuditLog subDirectory_Metadata_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Notification_User subDirectory_Notification_User:
                        SubDirectory_Notification_User_AuditLog.Add(new DbStorage_SubDirectory_Notification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Notification_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Notification_User_AuditLog subDirectory_Notification_User_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Notification_User_Link subDirectory_Notification_User_Link:
                        SubDirectory_Notification_User_Link_AuditLog.Add(new DbStorage_SubDirectory_Notification_User_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Notification_User_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Notification_User_Link_AuditLog subDirectory_Notification_User_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Notification_UserGroup subDirectory_Notification_UserGroup:
                        SubDirectory_Notification_UserGroup_AuditLog.Add(new DbStorage_SubDirectory_Notification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Notification_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Notification_UserGroup_AuditLog subDirectory_Notification_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Notification_UserGroup_Link subDirectory_Notification_UserGroup_Link:
                        SubDirectory_Notification_UserGroup_Link_AuditLog.Add(new DbStorage_SubDirectory_Notification_UserGroup_Link_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Notification_UserGroup_Link.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Notification_UserGroup_Link_AuditLog subDirectory_Notification_UserGroup_Link_AuditLog:
                        break;

                    case DbStorage_SubDirectory_QrCode subDirectory_QrCode:
                        SubDirectory_QrCode_AuditLog.Add(new DbStorage_SubDirectory_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_QrCode.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_QrCode_AuditLog subDirectory_QrCode_AuditLog:
                        break;

                    case DbStorage_SubDirectory_Quality subDirectory_Quality:
                        SubDirectory_Quality_AuditLog.Add(new DbStorage_SubDirectory_Quality_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory_Quality.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectory_Quality_AuditLog subDirectory_Quality_AuditLog:
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
