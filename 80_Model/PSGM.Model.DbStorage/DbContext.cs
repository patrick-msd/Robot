using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PSGM.Helper;
using PSGM.Model.DbMain;

namespace PSGM.Model.DbStorage
{
    public class DbStorage_Context : DbContext
    {
        #region Variables
        public DatabaseType _databaseType = DatabaseType.SQLite;
        public DatabaseType DatabaseType { get { return _databaseType; } set { _databaseType = value; } }


        private string _connectionString = string.Empty;
        public string ConnectionString { get { return _connectionString; } set { _connectionString = value; } }


        private string _connectionStringSQLite = "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbStorage\\DbStorage.db";
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

        public DbSet<DbStorage_FileAuthorization_User> FileAuthorization_User { get; set; }
        public DbSet<DbStorage_FileAuthorization_User_AuditLog> FileAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_FileAuthorization_UserGroup> FileAuthorization_UserGroup { get; set; }
        public DbSet<DbStorage_FileAuthorization_UserGroup_AuditLog> FileAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_FileNotification_User> FileNotification_User { get; set; }
        public DbSet<DbStorage_FileNotification_User_AuditLog> FileNotification_User_AuditLog { get; set; }

        public DbSet<DbStorage_FileNotification_UserGroup> FileNotification_UserGroup { get; set; }
        public DbSet<DbStorage_FileNotification_UserGroup_AuditLog> FileNotification_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_FileParameter> FileParameters { get; set; }
        public DbSet<DbStorage_FileParameter_AuditLog> FileParameter_AuditLog { get; set; }

        public DbSet<DbStorage_FileParameterStorage> FileParametersStorage { get; set; }
        public DbSet<DbStorage_FileParameterStorage_AuditLog> FileParameterStorage_AuditLog { get; set; }

        public DbSet<DbStorage_Order> Orders { get; set; }
        public DbSet<DbStorage_Order_AuditLog> Order_AuditLog { get; set; }

        public DbSet<DbStorage_OrderTemplate> OrderTemplates { get; set; }
        public DbSet<DbStorage_OrderTemplate_AuditLog> OrderTemplate_AuditLog { get; set; }

        //public DbSet<DbStorage_Project> Projects { get; set; }
        //public DbSet<DbStorage_Project_AuditLog> Project_AuditLog { get; set; }

        public DbSet<DbStorage_QrCode> QrCodes { get; set; }
        public DbSet<DbStorage_QrCode_AuditLog> QrCode_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectory> RootDirectories { get; set; }
        public DbSet<DbStorage_RootDirectory_AuditLog> RootDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryAuthorization_User> RootDirectoryAuthorization_User { get; set; }
        public DbSet<DbStorage_RootDirectoryAuthorization_User_AuditLog> RootDirectoryAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryAuthorization_UserGroup> RootDirectoryAuthorization_UserGroup { get; set; }
        public DbSet<DbStorage_RootDirectoryAuthorization_UserGroup_AuditLog> RootDirectoryAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryNotification_User> RootDirectoryNotification_User { get; set; }
        public DbSet<DbStorage_RootDirectoryNotification_User_AuditLog> RootDirectoryNotification_User_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryNotification_UserGroup> RootDirectoryNotification_UserGroup { get; set; }
        public DbSet<DbStorage_RootDirectoryNotification_UserGroup_AuditLog> RootDirectoryNotification_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryParameter> RootDirectoryParameters { get; set; }
        public DbSet<DbStorage_RootDirectoryParameter_AuditLog> RootDirectoryParameter_AuditLog { get; set; }

        public DbSet<DbStorage_RootDirectoryParameterStorage> RootDirectoryParametersStorage { get; set; }
        public DbSet<DbStorage_RootDirectoryParameterStorage_AuditLog> RootDirectoryParameterStorage_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectory> SubDirectories { get; set; }
        public DbSet<DbStorage_SubDirectory_AuditLog> SubDirectory_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryAuthorization_User> SubDirectoryAuthorization_User { get; set; }
        public DbSet<DbStorage_SubDirectoryAuthorization_User_AuditLog> SubDirectoryAuthorization_User_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryAuthorization_UserGroup> SubDirectoryAuthorization_UserGroup { get; set; }
        public DbSet<DbStorage_SubDirectoryAuthorization_UserGroup_AuditLog> SubDirectoryAuthorization_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryNotification_User> SubDirectoryNotification_User { get; set; }
        public DbSet<DbStorage_SubDirectoryNotification_User_AuditLog> SubDirectoryNotification_User_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryNotification_UserGroup> SubDirectoryNotification_UserGroup { get; set; }
        public DbSet<DbStorage_SubDirectoryNotification_UserGroup_AuditLog> SubDirectoryNotification_UserGroup_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryParameter> SubDirectoryParameters { get; set; }
        public DbSet<DbStorage_SubDirectoryParameter_AuditLog> SubDirectoryParameter_AuditLog { get; set; }

        public DbSet<DbStorage_SubDirectoryParameterStorage> SubDirectoryParametersStorage { get; set; }
        public DbSet<DbStorage_SubDirectoryParameterStorage_AuditLog> SubDirectoryParameterStorage_AuditLog { get; set; }
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
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = file.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });

                        #region Automatically added: Audit details for faster file audit information
                        if (entry.State == EntityState.Added)
                        {
                            if (file.SubDirectory is not null)
                            {
                                file.SubDirectory.Objects += 1;
                                file.SubDirectory.DirectorySize += file.ObjectSize;
                            }

                            if (file.RootDirectory is not null)
                            {
                                file.RootDirectory.Objects += 1;
                                file.RootDirectory.DirectorySize += file.ObjectSize;
                            }

                            file.CreatedDateTimeAutoFill = DateTime.UtcNow;
                            file.CreatedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                            file.LastModificationChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());

                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            file.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            file.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                            file.LastModificationChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());
                        }
                        else if (entry.State == EntityState.Deleted)
                        {
                            if (file.SubDirectory is not null)
                            {
                                file.SubDirectory.Objects -= 1;
                                file.SubDirectory.DirectorySize -= file.ObjectSize;
                            }

                            if (file.RootDirectory is not null)
                            {
                                file.RootDirectory.Objects -= 1;
                                file.RootDirectory.DirectorySize -= file.ObjectSize;
                            }
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
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = fileAuthorization_User.GetType().Name,
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
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = fileAuthorization_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileAuthorization_UserGroup_AuditLog fileAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_FileNotification_User fileNotification_User:
                        FileNotification_User_AuditLog.Add(new DbStorage_FileNotification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileNotification_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = fileNotification_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileNotification_User_AuditLog fileNotification_User_User_AuditLog:
                        break;

                    case DbStorage_FileNotification_UserGroup fileNotification_UserGroup:
                        FileNotification_UserGroup_AuditLog.Add(new DbStorage_FileNotification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileNotification_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = fileNotification_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileNotification_UserGroup_AuditLog fileNotification_UserGroup_AuditLog:
                        break;

                    case DbStorage_FileParameter fileParameter:
                        FileParameter_AuditLog.Add(new DbStorage_FileParameter_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileParameter.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = fileParameter.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileParameter_AuditLog fileParameter_AuditLog:
                        break;

                    case DbStorage_FileParameterStorage fileParameterStorage:
                        FileParameterStorage_AuditLog.Add(new DbStorage_FileParameterStorage_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = fileParameterStorage.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = fileParameterStorage.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_FileParameterStorage_AuditLog fileParameterStorage_AuditLog:
                        break;

                    case DbStorage_Order order:
                        Order_AuditLog.Add(new DbStorage_Order_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = order.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = order.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_Order_AuditLog order_AuditLog:
                        break;

                    case DbStorage_OrderTemplate orderTemplate:
                        OrderTemplate_AuditLog.Add(new DbStorage_OrderTemplate_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = orderTemplate.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = orderTemplate.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_OrderTemplate_AuditLog orderTemplate_AuditLog:
                        break;

                    //case DbStorage_Project project:
                    //    Project_AuditLog.Add(new DbStorage_Project_AuditLog
                    //    {
                    //        Id = new Guid(),

                    //        SourceId = project.Id,
                    //        //TableName = entry.Metadata.GetTableName(),
                    //        //EntityName = project.GetType().Name,
                    //        Action = entry.State.ToString(),
                    //        DateTime = DateTime.UtcNow,
                    //        UserIdExt = DatabaseSessionParameter_UserId,
                    //        SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                    //        Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                    //    });
                    //    break;

                    //case DbStorage_Project_AuditLog project_AuditLog:
                    //    break;

                    case DbStorage_QrCode qrCode:
                        QrCode_AuditLog.Add(new DbStorage_QrCode_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = qrCode.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = qrCode.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_QrCode_AuditLog qrCode_AuditLog:
                        break;

                    case DbStorage_RootDirectory rootDirectory:
                        RootDirectory_AuditLog.Add(new DbStorage_RootDirectory_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectory.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = rootDirectory.GetType().Name,
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
                            rootDirectory.LastModificationChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());

                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            rootDirectory.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            rootDirectory.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                            rootDirectory.LastModificationChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());
                        }
                        #endregion
                        break;

                    case DbStorage_RootDirectory_AuditLog rootDirectory_AuditLog:
                        break;

                    case DbStorage_RootDirectoryAuthorization_User rootDirectoryAuthorization_User:
                        RootDirectoryAuthorization_User_AuditLog.Add(new DbStorage_RootDirectoryAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryAuthorization_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = rootDirectoryAuthorization_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryAuthorization_User_AuditLog rootDirectoryAuthorization_User_AuditLog:
                        break;

                    case DbStorage_RootDirectoryAuthorization_UserGroup rootDirectoryAuthorization_UserGroup:
                        RootDirectoryAuthorization_UserGroup_AuditLog.Add(new DbStorage_RootDirectoryAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryAuthorization_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = rootDirectoryAuthorization_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryAuthorization_UserGroup_AuditLog rootDirectoryAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectoryNotification_User rootDirectoryNotification_User:
                        RootDirectoryNotification_User_AuditLog.Add(new DbStorage_RootDirectoryNotification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryNotification_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = rootDirectoryNotification_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryNotification_User_AuditLog rootDirectoryNotification_User_AuditLog:
                        break;

                    case DbStorage_RootDirectoryNotification_UserGroup rootDirectoryNotification_UserGroup:
                        RootDirectoryNotification_UserGroup_AuditLog.Add(new DbStorage_RootDirectoryNotification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryNotification_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = rootDirectoryNotification_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryNotification_UserGroup_AuditLog rootDirectoryNotification_UserGroup_AuditLog:
                        break;

                    case DbStorage_RootDirectoryParameter rootDirectoryParameter:
                        RootDirectoryParameter_AuditLog.Add(new DbStorage_RootDirectoryParameter_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryParameter.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = rootDirectoryParameter.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryParameter_AuditLog rootDirectoryParameter_AuditLog:
                        break;

                    case DbStorage_RootDirectoryParameterStorage rootDirectoryParameterStorage:
                        RootDirectoryParameterStorage_AuditLog.Add(new DbStorage_RootDirectoryParameterStorage_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = rootDirectoryParameterStorage.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = rootDirectoryParameterStorage.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_RootDirectoryParameterStorage_AuditLog rootDirectoryParameterStorage_AuditLog:
                        break;

                    case DbStorage_SubDirectory subDirectory:
                        SubDirectory_AuditLog.Add(new DbStorage_SubDirectory_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectory.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = subDirectory.GetType().Name,
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
                            subDirectory.LastModificationChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());

                        }
                        else if (entry.State == EntityState.Modified)
                        {
                            subDirectory.ModifiedDateTimeAutoFill = DateTime.UtcNow;
                            subDirectory.ModifiedByUserIdExtAutoFill = DatabaseSessionParameter_UserId;
                            subDirectory.LastModificationChanges = JsonConvert.SerializeObject(entry.CurrentValues.ToObject());
                        }
                        #endregion
                        break;

                    case DbStorage_SubDirectory_AuditLog subDirectory_AuditLog:
                        break;

                    case DbStorage_SubDirectoryAuthorization_User subDirectoryAuthorization_User:
                        SubDirectoryAuthorization_User_AuditLog.Add(new DbStorage_SubDirectoryAuthorization_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryAuthorization_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = subDirectoryAuthorization_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryAuthorization_User_AuditLog subDirectoryAuthorization_User_AuditLog:
                        break;

                    case DbStorage_SubDirectoryAuthorization_UserGroup subDirectoryAuthorization_UserGroup:
                        SubDirectoryAuthorization_UserGroup_AuditLog.Add(new DbStorage_SubDirectoryAuthorization_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryAuthorization_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = subDirectoryAuthorization_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryAuthorization_UserGroup_AuditLog subDirectoryAuthorization_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectoryNotification_User subDirectoryNotification_User:
                        SubDirectoryNotification_User_AuditLog.Add(new DbStorage_SubDirectoryNotification_User_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryNotification_User.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = subDirectoryNotification_User.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryNotification_User_AuditLog subDirectoryNotification_User_AuditLog:
                        break;

                    case DbStorage_SubDirectoryNotification_UserGroup subDirectoryNotification_UserGroup:
                        SubDirectoryNotification_UserGroup_AuditLog.Add(new DbStorage_SubDirectoryNotification_UserGroup_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryNotification_UserGroup.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = subDirectoryNotification_UserGroup.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryNotification_UserGroup_AuditLog subDirectoryNotification_UserGroup_AuditLog:
                        break;

                    case DbStorage_SubDirectoryParameter subDirectoryParameter:
                        SubDirectoryParameter_AuditLog.Add(new DbStorage_SubDirectoryParameter_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryParameter.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = subDirectoryParameter.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryParameter_AuditLog subDirectoryParameter_AuditLog:
                        break;

                    case DbStorage_SubDirectoryParameterStorage subDirectoryParameterStorage:
                        SubDirectoryParameterStorage_AuditLog.Add(new DbStorage_SubDirectoryParameterStorage_AuditLog
                        {
                            Id = new Guid(),

                            SourceId = subDirectoryParameterStorage.Id,
                            //TableName = entry.Metadata.GetTableName(),
                            //EntityName = subDirectoryParameterStorage.GetType().Name,
                            Action = entry.State.ToString(),
                            DateTime = DateTime.UtcNow,
                            UserIdExt = DatabaseSessionParameter_UserId,
                            SoftwareIdExt = DatabaseSessionParameter_SoftwareId,
                            Changes = JsonConvert.SerializeObject(entry.CurrentValues.ToObject())
                        });
                        break;

                    case DbStorage_SubDirectoryParameterStorage_AuditLog subDirectoryParameterStorage_AuditLog:
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
