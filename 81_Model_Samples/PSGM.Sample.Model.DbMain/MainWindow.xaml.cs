using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbBackend;
using PSGM.Model.DbMain;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace PSGM.Sample.Model.DbStorage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<LokiLabel> _lokiLabels;
        string _lokiUri;
        string _lokiOutputTemplate;

        ConfigFile _configFile;

        private DbBackend_Context _dbBackend_Context;
        private DbMain_Context _dbMain_Context;

        Guid _softwareId;
        Guid _machineId;

        Guid _projectId;

        Guid _patrickSchoeneggerId;
        Guid _guenterMuehlbergerId;
        Guid _gertraudZeindlId;
        Guid _christophHaidacherId;

        public MainWindow()
        {
            InitializeComponent();

            _machineId = MachineInfo.GetMachineUUID();

            #region Initialize golbal variables ...

            //LokiLabels = new List<LokiLabel>()
            //{
            //    new LokiLabel()
            //    {
            //        Key = "Software",
            //        Value = Globals.ApplicationTitle
            //    },
            //    new LokiLabel()
            //    {
            //        Key = "Version",
            //        Value = Globals.ApplicationVersion.ToString()
            //    }
            //};
            _lokiUri = "http://10.31.40.101:3100";
            _lokiOutputTemplate = "[{Timestamp:dd.MM.yyyy - HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}";
            //_lokiOutputTemplate  = "[{Timestamp:dd.MM.yyyy - HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";
            #endregion

            #region Inizialize logger
            // https://github.com/serilog-contrib/serilog-sinks-richtextbox
            SelfLog.Enable(message => Trace.WriteLine($"INTERNAL ERROR: {message}"));

#if DEBUG
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Debug(outputTemplate: _lokiOutputTemplate)
                                .WriteTo.GrafanaLoki(_lokiUri, labels: _lokiLabels)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels, textFormatter: new ExpressionTemplate("{ {@t, @mt, @l:u3}, @i, @x, @p} }\n"))
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();
#else
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();
#endif

            //Log.Information($"Application \"{Globals.ApplicationTitle} V{Globals.ApplicationVersion.ToString()}\" start...");
            #endregion

            _softwareId = Guid.NewGuid();
            _machineId = Guid.NewGuid();

            _projectId = Guid.NewGuid();

            _patrickSchoeneggerId = Guid.NewGuid();
            _guenterMuehlbergerId = Guid.NewGuid();
            _gertraudZeindlId = Guid.NewGuid();
            _christophHaidacherId = Guid.NewGuid();

            _configFile = new ConfigFile();

            if (_configFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                _configFile.ReadFromFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
            }

            #region Initialize Databases
            if (_configFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                #region Backend
                _dbBackend_Context = new DbBackend_Context();

                _dbBackend_Context.DatabaseConnectionString = _configFile.DatabaseConnectionString;
                _dbBackend_Context.DatabaseType = _configFile.DatabaseType;

                _dbBackend_Context.DatabaseSessionParameter_SoftwareId = _softwareId;
                _dbBackend_Context.DatabaseSessionParameter_MachineId = _machineId;
                _dbBackend_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

                _dbBackend_Context.Database.OpenConnection();
                #endregion

                List<DbBackend_Backend>? backend = _dbBackend_Context.Backends.Where(p => p.Project.ProjectId_Ext == new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657"))
                                                                                .Include(p => p.DatabaseClusters)
                                                                                    .ThenInclude(p => p.DatabaseServers)
                                                                                .Include(p => p.StorageClusters)
                                                                                    .ThenInclude(p => p.StorageServers)
                                                                                .ToList();

                DbBackend_Database_Cluster? databaseMain = backend.Where(p => p.BackendType == BackendType.Main).FirstOrDefault().DatabaseClusters.FirstOrDefault();

                _dbMain_Context = new DbMain_Context();
                
                _dbMain_Context.DatabaseConnectionString = databaseMain.GetDatabaseConnection(true);
                _dbMain_Context.DatabaseType = databaseMain.DatabaseType;

                _dbMain_Context.DatabaseSessionParameter_SoftwareId = _softwareId;
                _dbMain_Context.DatabaseSessionParameter_MachineId = _machineId;
                _dbMain_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

                if (_dbMain_Context.Database.EnsureCreated())
                {
                    _dbMain_Context.Database.OpenConnection();
                }
                //_dbMain_Context.Database.EnsureDeleted();
                //_dbMain_Context.Database.EnsureCreated();
            }
            #endregion
        }

        private void btnDbCreateConfigFile_Click(object sender, RoutedEventArgs e)
        {
            _configFile = new ConfigFile()
            {
                DatabaseType = DatabaseType.PostgreSQL,
                DatabaseConnectionString = "Host=db-backend-c6e1c3e3-f49d-4edc-b3a2-2ed50174e3c8.branch031.psgm.at:50001;Database=db-backend-c6e1c3e3-f49d-4edc-b3a2-2ed50174e3c8;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",
            };

            _configFile.WriteToFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
        }

        private void btnDbReadConfigFileAndInit_Click(object sender, RoutedEventArgs e)
        {
            #region Backend
            _dbBackend_Context = new DbBackend_Context();

            _dbBackend_Context.DatabaseConnectionString = _configFile.DatabaseConnectionString;
            _dbBackend_Context.DatabaseType = _configFile.DatabaseType;

            _dbBackend_Context.DatabaseSessionParameter_SoftwareId = _softwareId;
            _dbBackend_Context.DatabaseSessionParameter_MachineId = _machineId;
            _dbBackend_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

            _dbBackend_Context.Database.OpenConnection();
            #endregion

            List<DbBackend_Backend>? backend = _dbBackend_Context.Backends.Where(p => p.Project.ProjectId_Ext == new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657"))
                                                                            .Include(p => p.DatabaseClusters)
                                                                                .ThenInclude(p => p.DatabaseServers)
                                                                            .Include(p => p.StorageClusters)
                                                                                .ThenInclude(p => p.StorageServers)
                                                                            .ToList();

            DbBackend_Database_Cluster? databaseMain = backend.Where(p => p.BackendType == BackendType.Main).FirstOrDefault().DatabaseClusters.FirstOrDefault();

            _dbMain_Context = new DbMain_Context();

            _dbMain_Context.DatabaseConnectionString = databaseMain.GetDatabaseConnection(true);
            _dbMain_Context.DatabaseType = databaseMain.DatabaseType;

            _dbMain_Context.DatabaseSessionParameter_SoftwareId = _softwareId;
            _dbMain_Context.DatabaseSessionParameter_MachineId = _machineId;
            _dbMain_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

            _dbMain_Context.Database.EnsureDeleted();
            _dbMain_Context.Database.EnsureCreated();
            _dbMain_Context.Database.OpenConnection();
        }

        private void btnDbGenerateData_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            #region Add addresses ...
            List<DbMain_Address> addresses1 = Generate_Addresses1();
            _dbMain_Context.Addresses.AddRange(addresses1);
            _dbMain_Context.SaveChanges();
            #endregion

            #region Add locations ...
            List<DbMain_Location> locations1 = Generate_Locations1(addresses1);
            _dbMain_Context.Locations.AddRange(locations1);
            _dbMain_Context.SaveChanges();
            #endregion

            #region Add organizations ...
            List<DbMain_Organization> organization1 = Generate_Organization1(locations1);
            _dbMain_Context.Organizations.AddRange(organization1);
            _dbMain_Context.SaveChanges();
            #endregion

            #region Add projects ...
            List<DbMain_Project> projects1 = Generate_Project1(locations1, organization1);
            _dbMain_Context.Projects.AddRange(projects1);
            _dbMain_Context.SaveChanges();
            #endregion

            addresses1.RemoveAll(p => true);
            locations1.RemoveAll(p => true);
            organization1.RemoveAll(p => true);
            projects1.RemoveAll(p => true);

            for (int h = 0; h < 10; h++)
            {
                //#region Add addresses ...
                //List<DbMain_Address> addresses2 = Generate_Addresses2(25);
                //_dbMain_Context.Addresses.AddRange(addresses2);
                //_dbMain_Context.SaveChanges();
                //#endregion

                //#region Add locations ...
                //List<DbMain_Location> locations2 = Generate_Locations2(25, addresses2);
                //_dbMain_Context.Locations.AddRange(locations2);
                //_dbMain_Context.SaveChanges();
                //#endregion

                //#region Add rganizations ...
                //List<DbMain_Organization> organization2 = Generate_Organization2(250, locations2);
                //_dbMain_Context.Organizations.AddRange(organization2);
                //_dbMain_Context.SaveChanges();
                //#endregion

                //#region Add projects ...
                //List<DbMain_Project> projects2 = Generate_Project2(250, locations2);
                //_dbMain_Context.Projects.AddRange(projects2);
                //_dbMain_Context.SaveChanges();
                //#endregion

                //addresses2.RemoveAll(p => true);
                //locations2.RemoveAll(p => true);
                //organization2.RemoveAll(p => true);
                //projects2.RemoveAll(p => true);

                // Clear the ChangeTracker to reduce memory usage
                _dbMain_Context.ChangeTracker.Clear();

                //_dbMain_Context.Database.CloseConnection();
                //_dbMain_Context.Dispose();
                //_dbMain_Context = null;

                //_dbMain_Context = new DbMain_Context();

                //_dbMain_Context.ConnectionString = _configFile.MainDatabaseConnectionString;
                //_dbMain_Context.DatabaseType = _configFile.MainDatabaseType;

                //_dbMain_Context.DatabaseSessionParameter_SoftwareId = _softwareId;
                //_dbMain_Context.DatabaseSessionParameter_MachineId = _machineId;
                //_dbStorage_Data_dbMain_Context_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

                //_dbMain_Context.Database.OpenConnection();
            }
        }

        private void btnDbReadData1_Click(object sender, RoutedEventArgs e)
        {
            ;

            //var asdasd = _dbMain_Context.Files.ToList();

            //var asd = _dbMain_Context.Files.Where(f => f.ExtId3.Contains("e"))
            //                                        .Include(p => p.SubDirectory)
            //                                            .ThenInclude(p => p.RootDirectory)
            //                                        .Include(p => p.RootDirectory)
            //                                        .Include(p => p.MetadataLinks)
            //                                            .ThenInclude(p => p.Metadata)
            //                                        .Include(p => p.QrCode)
            //                                        .ToList();

            //var asdsa = asd[0].Authorization_UsersIdExt;
            //var asddsdfsa = asd[0].NotificationUserGroupIdsExt;
            //var asadfdsa = asd[0].JobIdsExt;
            ////var asdadssa = asd[0].GetLastModificationChanges();

            //var asdasd = _dbMain_Context.Files.Where(p => p.AuthorizationUserLinks.Any(p => p.AuthorizationUser.UserIdExt == Guid.Parse("aa4590f8-5ce6-4e95-aa78-0dda009d629b")))
            //                                            .Include(p => p.SubDirectory)
            //                                                .ThenInclude(p => p.RootDirectory)
            //                                            .Include(p => p.RootDirectory)
            //                                            .Include(p => p.MetadataLinks)
            //                                                .ThenInclude(p => p.Metadata)
            //                                            .Include(p => p.QrCode)
            //                                            .Include(p => p.Quality)
            //                                            .Include(p => p.AuthorizationUserLinks)
            //                                                .ThenInclude(p => p.AuthorizationUser)
            //                                            .Include(p => p.AuthorizationUserGroupLinks)
            //                                                .ThenInclude(p => p.AuthorizationUserGroup)
            //                                            .Include(p => p.NotificationUserLinks)
            //                                                .ThenInclude(p => p.NotificationUser)
            //                                            .Include(p => p.NotificationUserGroupLinks)
            //                                                .ThenInclude(p => p.NotificationUserGroup)
            //                                            .ToList();



            //var asd2 = _dbMain_Context.RootDirectories.ToList();
            //var asdasd2 = _dbMain_Context.SubDirectories.OrderBy(item => item.Id)
            //                                                    .Take(100)
            //                                                    .ToList();

            //var asdsad = _dbMain_Context.Files.ToList();

            ;
        }
    }
}
