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

        public DbSet<DbStorage_FileAuthorization_User> FileAuthorization_Users { get; set; }
        public DbSet<DbStorage_FileAuthorization_User_AuditLog> FileAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_FileAuthorization_UserGroup> FileAuthorization_UserGroups { get; set; }
        public DbSet<DbStorage_FileAuthorization_UserGroup_AuditLog> FileAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_FileAuthorization_UserLink> FileAuthorization_UserLinks { get; set; }
        public DbSet<DbStorage_FileAuthorization_UserLink_AuditLog> FileAuthorization_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_FileAuthorization_UserGroupLink> FileAuthorization_UserGroupLinks { get; set; }
        public DbSet<DbStorage_FileAuthorization_UserGroupLink_AuditLog> FileAuthorization_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadata> FileMetadata { get; set; }
        public DbSet<DbStorage_FileMetadata_AuditLog> FileMetadata_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadataAuthorization_User> FileMetadataAuthorization_Users { get; set; }
        public DbSet<DbStorage_FileMetadataAuthorization_User_AuditLog> FileMetadataAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadataAuthorization_UserGroup> FileMetadataAuthorization_UserGroups { get; set; }
        public DbSet<DbStorage_FileMetadataAuthorization_UserGroup_AuditLog> FileMetadataAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadataAuthorization_UserGroupLink> FileMetadataAuthorization_UserGroupLinks { get; set; }
        public DbSet<DbStorage_FileMetadataAuthorization_UserGroupLink_AuditLog> FileMetadataAuthorization_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadataAuthorization_UserLink> FileMetadataAuthorization_UserLinks { get; set; }
        public DbSet<DbStorage_FileMetadataAuthorization_UserLink_AuditLog> FileMetadataAuthorization_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_FileMetadataLink> FileMetadataLink { get; set; }
        public DbSet<DbStorage_FileMetadataLink_AuditLog> FileMetadataLink_AuditLog { get; set; }

        public DbSet<DbStorage_FileNotification_User> FileNotification_Users { get; set; }
        public DbSet<DbStorage_FileNotification_User_AuditLog> FileNotification_User_AuditLog { get; set; }

        public DbSet<DbStorage_FileNotification_UserGroup> FileNotification_UserGroups { get; set; }
        public DbSet<DbStorage_FileNotification_UserGroup_AuditLog> FileNotification_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_FileNotification_UserLink> FileNotification_UserLinks { get; set; }
        public DbSet<DbStorage_FileNotification_UserLink_AuditLog> FileNotification_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_FileNotification_UserGroupLink> FileNotification_UserGroupLinks { get; set; }
        public DbSet<DbStorage_FileNotification_UserGroupLink_AuditLog> FileNotification_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_QrCode> QrCodes { get; set; }
        public DbSet<DbStorage_QrCode_AuditLog> QrCode_AuditLog { get; set; }

        public DbSet<DbStorage_Quality> Qualities { get; set; }
        public DbSet<DbStorage_Quality_AuditLog> Quality_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory> RootDirectories { get; set; }
        public DbSet<DbStorage_RootDirectory_AuditLog> RootDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryAuthorization_UserLink> RootDirectoryAuthorization_UserLinks { get; set; }
        public DbSet<DbStorage_RootDirectoryAuthorization_UserLink_AuditLog> RootDirectoryAuthorization_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryAuthorization_UserGroupLink> RootDirectoryAuthorization_UserGroupLinks { get; set; }
        public DbSet<DbStorage_RootDirectoryAuthorization_UserGroupLink_AuditLog> RootDirectoryAuthorization_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryMetadata> RootDirectoryMetadata { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadata_AuditLog> RootDirectoryMetadata_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryMetadataLink> RootDirectoryMetadataLink { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadataLink_AuditLog> RootDirectoryMetadataLink_AuditLog { get; set; }



        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_User> RootDirectoryMetadataAuthorization_Users { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_User_AuditLog> RootDirectoryMetadataAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_UserGroup> RootDirectoryMetadataAuthorization_UserGroups { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_UserGroup_AuditLog> RootDirectoryMetadataAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink> RootDirectoryMetadataAuthorization_UserGroupLinks { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog> RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_UserLink> RootDirectoryMetadataAuthorization_UserLinks { get; set; }
        public DbSet<DbStorage_RootDirectoryMetadataAuthorization_UserLink_AuditLog> RootDirectoryMetadataAuthorization_UserLink_AuditLog { get; set; }




        public DbSet<DbStorage_RootDirectoryNotification_UserLink> RootDirectoryNotification_UserLinks { get; set; }
        public DbSet<DbStorage_RootDirectoryNotification_UserLink_AuditLog> RootDirectoryNotification_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryNotification_UserGroupLink> RootDirectoryNotification_UserGroupLinks { get; set; }
        public DbSet<DbStorage_RootDirectoryNotification_UserGroupLink_AuditLog> RootDirectoryNotification_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory> SubDirectories { get; set; }
        public DbSet<DbStorage_SubDirectory_AuditLog> SubDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryAuthorization_UserLink> SubDirectoryAuthorization_UserLinks { get; set; }
        public DbSet<DbStorage_SubDirectoryAuthorization_UserLink_AuditLog> SubDirectoryAuthorization_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryAuthorization_UserGroupLink> SubDirectoryAuthorization_UserGroupLinks { get; set; }
        public DbSet<DbStorage_SubDirectoryAuthorization_UserGroupLink_AuditLog> SubDirectoryAuthorization_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadata> SubDirectoryMetadata { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadata_AuditLog> SubDirectoryMetadata_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_User> SubDirectoryMetadataAuthorization_Users { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_User_AuditLog> SubDirectoryMetadataAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_UserGroup> SubDirectoryMetadataAuthorization_UserGroups { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_UserGroup_AuditLog> SubDirectoryMetadataAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink> SubDirectoryMetadataAuthorization_UserGroupLinks { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog> SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_UserLink> SubDirectoryMetadataAuthorization_UserLinks { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadataAuthorization_UserLink_AuditLog> SubDirectoryMetadataAuthorization_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryMetadataLink> SubDirectoryMetadataLink { get; set; }
        public DbSet<DbStorage_SubDirectoryMetadataLink_AuditLog> SubDirectoryMetadataLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryNotification_UserLink> SubDirectoryNotification_UserLinks { get; set; }
        public DbSet<DbStorage_SubDirectoryNotification_UserLink_AuditLog> SubDirectoryNotification_UserLink_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryNotification_UserGroupLink> SubDirectoryNotification_UserGroupLinks { get; set; }
        public DbSet<DbStorage_SubDirectoryNotification_UserGroupLink_AuditLog> SubDirectoryNotification_UserGroupLink_AuditLog { get; set; }
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

                    case DbStorage_FileAuthorization_User fileAuthorization_User:
                        FileAuthorization_User_AuditLog.Add(new DbStorage_FileAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileAuthorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileAuthorization_User_AuditLog fileAuthorization_User_AuditLog:
                        break;

                    case DbStorage_FileAuthorization_UserGroup fileAuthorization_UserGroup:
                        FileAuthorization_UserGroup_AuditLog.Add(new DbStorage_FileAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileAuthorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileAuthorization_UserGroup_AuditLog fileAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_FileAuthorization_UserLink fileAuthorization_UserLink:
                        FileAuthorization_UserLink_AuditLog.Add(new DbStorage_FileAuthorization_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileAuthorization_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileAuthorization_UserLink_AuditLog fileAuthorization_UserLink_AuditLog:
                        break;

                    case DbStorage_FileAuthorization_UserGroupLink fileAuthorization_UserGroupLink:
                        FileAuthorization_UserGroupLink_AuditLog.Add(new DbStorage_FileAuthorization_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileAuthorization_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileAuthorization_UserGroupLink_AuditLog fileAuthorization_UserGroupLink_AuditLog:
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

                        #region Automatically added: Audit details for faster subDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            fileMetadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            fileMetadata.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            fileMetadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            fileMetadata.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_FileMetadata_AuditLog fileMetadata_AuditLog:
                        break;

                    case DbStorage_FileMetadataAuthorization_User fileMetadataAuthorization_User:
                        FileMetadataAuthorization_User_AuditLog.Add(new DbStorage_FileMetadataAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileMetadataAuthorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileMetadataAuthorization_User_AuditLog fileMetadataAuthorization_User_AuditLog:
                        break;

                    case DbStorage_FileMetadataAuthorization_UserGroup fileMetadataAuthorization_UserGroup:
                        FileMetadataAuthorization_UserGroup_AuditLog.Add(new DbStorage_FileMetadataAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileMetadataAuthorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileMetadataAuthorization_UserGroup_AuditLog fileMetadataAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_FileMetadataAuthorization_UserGroupLink fileMetadataAuthorization_UserGroupLink:
                        FileMetadataAuthorization_UserGroupLink_AuditLog.Add(new DbStorage_FileMetadataAuthorization_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileMetadataAuthorization_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileMetadataAuthorization_UserGroupLink_AuditLog fileMetadataAuthorization_UserGroupLink_AuditLog:
                        break;

                    case DbStorage_FileMetadataAuthorization_UserLink fileMetadataAuthorization_UserLink:
                        FileMetadataAuthorization_UserLink_AuditLog.Add(new DbStorage_FileMetadataAuthorization_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileMetadataAuthorization_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileMetadataAuthorization_UserLink_AuditLog fileMetadataAuthorization_UserLink_AuditLog:
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

                    case DbStorage_FileNotification_User fileNotification_User:
                        FileNotification_User_AuditLog.Add(new DbStorage_FileNotification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileNotification_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileNotification_User_AuditLog fileNotification_User_AuditLog:
                        break;

                    case DbStorage_FileNotification_UserGroup fileNotification_UserGroup:
                        FileNotification_UserGroup_AuditLog.Add(new DbStorage_FileNotification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileNotification_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileNotification_UserGroup_AuditLog fileNotification_UserGroup_AuditLog:
                        break;

                    case DbStorage_FileNotification_UserLink fileNotification_UserLink:
                        FileNotification_UserLink_AuditLog.Add(new DbStorage_FileNotification_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileNotification_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileNotification_UserLink_AuditLog fileNotification_UserLink_AuditLog:
                        break;

                    case DbStorage_FileNotification_UserGroupLink fileNotification_UserGroupLink:
                        FileNotification_UserGroupLink_AuditLog.Add(new DbStorage_FileNotification_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileNotification_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileNotification_UserGroupLink_AuditLog fileNotification_UserGroupLink_AuditLog:
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

                    case DbStorage_Quality quality:
                        Quality_AuditLog.Add(new DbStorage_Quality_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = quality.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_Quality_AuditLog quality_AuditLog:
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

                    case DbStorage_RootDirectoryAuthorization_UserLink rootDirectoryAuthorization_UserLink:
                        RootDirectoryAuthorization_UserLink_AuditLog.Add(new DbStorage_RootDirectoryAuthorization_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryAuthorization_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryAuthorization_UserLink_AuditLog rootDirectoryAuthorization_UserLink_AuditLog:
                        break;

                    case DbStorage_RootDirectoryAuthorization_UserGroupLink rootDirectoryAuthorization_UserGroupLink:
                        RootDirectoryAuthorization_UserGroupLink_AuditLog.Add(new DbStorage_RootDirectoryAuthorization_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryAuthorization_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryAuthorization_UserGroupLink_AuditLog rootDirectoryAuthorization_UserGroupLink_AuditLog:
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

                        #region Automatically added: Audit details for faster subDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            rootDirectoryMetadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectoryMetadata.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            rootDirectoryMetadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectoryMetadata.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
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

                    case DbStorage_RootDirectoryMetadataAuthorization_User rootDirectoryMetadataAuthorization_User:
                        RootDirectoryMetadataAuthorization_User_AuditLog.Add(new DbStorage_RootDirectoryMetadataAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryMetadataAuthorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryMetadataAuthorization_User_AuditLog rootDirectoryMetadataAuthorization_User_AuditLog:
                        break;

                    case DbStorage_RootDirectoryMetadataAuthorization_UserGroup rootDirectoryMetadataAuthorization_UserGroup:
                        RootDirectoryMetadataAuthorization_UserGroup_AuditLog.Add(new DbStorage_RootDirectoryMetadataAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryMetadataAuthorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryMetadataAuthorization_UserGroup_AuditLog rootDirectoryMetadataAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink rootDirectoryMetadataAuthorization_UserGroupLink:
                        RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog.Add(new DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryMetadataAuthorization_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryMetadataAuthorization_UserGroupLink_AuditLog rootDirectoryMetadataAuthorization_UserGroupLink_AuditLog:
                        break;

                    case DbStorage_RootDirectoryMetadataAuthorization_UserLink rootDirectoryMetadataAuthorization_UserLink:
                        RootDirectoryMetadataAuthorization_UserLink_AuditLog.Add(new DbStorage_RootDirectoryMetadataAuthorization_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryMetadataAuthorization_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryMetadataAuthorization_UserLink_AuditLog rootDirectoryMetadataAuthorization_UserLink_AuditLog:
                        break;

                    case DbStorage_RootDirectoryNotification_UserLink rootDirectoryNotification_UserLink:
                        RootDirectoryNotification_UserLink_AuditLog.Add(new DbStorage_RootDirectoryNotification_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryNotification_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryNotification_UserLink_AuditLog rootDirectoryNotification_UserLink_AuditLog:
                        break;

                    case DbStorage_RootDirectoryNotification_UserGroupLink rootDirectoryNotification_UserGroupLink:
                        RootDirectoryNotification_UserGroupLink_AuditLog.Add(new DbStorage_RootDirectoryNotification_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryNotification_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryNotification_UserGroupLink_AuditLog rootDirectoryNotification_UserGroupLink_AuditLog:
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

                    case DbStorage_SubDirectoryAuthorization_UserLink subDirectoryAuthorization_UserLink:
                        SubDirectoryAuthorization_UserLink_AuditLog.Add(new DbStorage_SubDirectoryAuthorization_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryAuthorization_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryAuthorization_UserLink_AuditLog subDirectoryAuthorization_UserLink_AuditLog:
                        break;

                    case DbStorage_SubDirectoryAuthorization_UserGroupLink subDirectoryAuthorization_UserGroupLink:
                        SubDirectoryAuthorization_UserGroupLink_AuditLog.Add(new DbStorage_SubDirectoryAuthorization_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryAuthorization_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryAuthorization_UserGroupLink_AuditLog subDirectoryAuthorization_UserGroupLink_AuditLog:
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

                        #region Automatically added: Audit details for faster subDirectory audit information
                        if (entry.State == EntityState.Added)
                        {
                            subDirectoryMetadata.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectoryMetadata.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            subDirectoryMetadata.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectoryMetadata.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                        }
                        #endregion
                        break;

                    case DbStorage_SubDirectoryMetadata_AuditLog subDirectoryMetadata_AuditLog:
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_User subDirectoryMetadataAuthorization_User:
                        SubDirectoryMetadataAuthorization_User_AuditLog.Add(new DbStorage_SubDirectoryMetadataAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryMetadataAuthorization_User.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_User_AuditLog subDirectoryMetadataAuthorization_User_AuditLog:
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_UserGroup subDirectoryMetadataAuthorization_UserGroup:
                        SubDirectoryMetadataAuthorization_UserGroup_AuditLog.Add(new DbStorage_SubDirectoryMetadataAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryMetadataAuthorization_UserGroup.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_UserGroup_AuditLog subDirectoryMetadataAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink subDirectoryMetadataAuthorization_UserGroupLink:
                        SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog.Add(new DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryMetadataAuthorization_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_UserGroupLink_AuditLog subDirectoryMetadataAuthorization_UserGroupLink_AuditLog:
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_UserLink subDirectoryMetadataAuthorization_UserLink:
                        SubDirectoryMetadataAuthorization_UserLink_AuditLog.Add(new DbStorage_SubDirectoryMetadataAuthorization_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryMetadataAuthorization_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryMetadataAuthorization_UserLink_AuditLog subDirectoryMetadataAuthorization_UserLink_AuditLog:
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

                    case DbStorage_SubDirectoryNotification_UserLink subDirectoryNotification_UserLink:
                        SubDirectoryNotification_UserLink_AuditLog.Add(new DbStorage_SubDirectoryNotification_UserLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryNotification_UserLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryNotification_UserLink_AuditLog subDirectoryNotification_UserLink_AuditLog:
                        break;

                    case DbStorage_SubDirectoryNotification_UserGroupLink subDirectoryNotification_UserGroupLink:
                        SubDirectoryNotification_UserGroupLink_AuditLog.Add(new DbStorage_SubDirectoryNotification_UserGroupLink_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryNotification_UserGroupLink.Id,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryNotification_UserGroupLink_AuditLog subDirectoryNotification_UserGroupLink_AuditLog:
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
