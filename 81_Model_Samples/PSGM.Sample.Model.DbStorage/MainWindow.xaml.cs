using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbStorage;
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

        private DbStorage_Context _dbStorage_Data_Context;

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

            _configFile = new ConfigFile();

            if (_configFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                _configFile.ReadFromFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
            }

            #region Initialize Databases
            if (_configFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                _dbStorage_Data_Context = new DbStorage_Context();
                _dbStorage_Data_Context.ConnectionString = _configFile.StorageStructureDatabaseConnectionString;
                _dbStorage_Data_Context.DatabaseType = _configFile.StorageStructureDatabaseType;
                if (_dbStorage_Data_Context.Database.EnsureCreated())
                {
                    _dbStorage_Data_Context.Database.OpenConnection();
                }
                //_dbStorage_Data_Context.Database.EnsureDeleted();
                //_dbStorage_Data_Context.Database.EnsureCreated();
            }
            #endregion
        }

        private void btnDbCreateConfigFile_Click(object sender, RoutedEventArgs e)
        {
            _configFile = new ConfigFile()
            {
                StorageStructureDatabaseConnectionString = "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorage;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",
                StorageStructureDatabaseType = DatabaseType.PostgreSQL,
            };

            _configFile.WriteToFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
        }

        private void btnDbReadConfigFileAndInit_Click(object sender, RoutedEventArgs e)
        {
            _dbStorage_Data_Context = new DbStorage_Context();
            _dbStorage_Data_Context.ConnectionString = _configFile.StorageStructureDatabaseConnectionString;
            _dbStorage_Data_Context.DatabaseType = _configFile.StorageStructureDatabaseType;
            _dbStorage_Data_Context.Database.EnsureDeleted();
            _dbStorage_Data_Context.Database.EnsureCreated();
            _dbStorage_Data_Context.Database.OpenConnection();
        }

        private void btnDbGenerateData_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            #region Add root directories ...
            List<DbStorage_RootDirectory> rootDirectory = Create_RootDirectories(_dbStorage_Data_Context, 25);
            _dbStorage_Data_Context.RootDirectories.AddRange(rootDirectory);
            _dbStorage_Data_Context.SaveChanges();
            #endregion

            #region Add sub directories ...
            List<DbStorage_SubDirectory> subDirectories = Create_SubDirectories(1000, rootDirectory);
            _dbStorage_Data_Context.SubDirectories.AddRange(subDirectories);
            _dbStorage_Data_Context.SaveChanges();
            #endregion

            #region Add sub sub directories ...
            List<DbStorage_SubDirectory> subsubDirectories = Create_SubSubDirectories(50, rootDirectory);
            _dbStorage_Data_Context.SubDirectories.AddRange(subsubDirectories);
            _dbStorage_Data_Context.SaveChanges();
            #endregion

            #region Add files ...
            for (int i = 0; i < 1000; i++)
            {
                List<DbStorage_File> files1 = Create_Files1(1000, rootDirectory, subDirectories);
                _dbStorage_Data_Context.Files.AddRange(files1);
                _dbStorage_Data_Context.SaveChanges();
            }
            for (int i = 0; i < 10; i++)
            {
                List<DbStorage_File> files2 = Create_Files2(100, rootDirectory, subsubDirectories);
                _dbStorage_Data_Context.Files.AddRange(files2);
                _dbStorage_Data_Context.SaveChanges();
            }
            #endregion
        }

        private void btnDbReadData1_Click(object sender, RoutedEventArgs e)
        {
            ;

            //var asdasd = _dbStorage_Data_Context.Files.ToList();

            var asd = _dbStorage_Data_Context.Files.Where(f => f.ExtId3.Contains("e"))
                                                    .Include(p => p.SubDirectory)
                                                        .ThenInclude(p => p.RootDirectory)
                                                    .Include(p => p.RootDirectory)
                                                    .Include(p => p.MetadataLinks)
                                                        .ThenInclude(p => p.Metadata)
                                                    .Include(p => p.QrCode)
                                                    .ToList();

            //var asdsa = asd[0].Authorization_UsersIdExt;
            //var asddsdfsa = asd[0].NotificationUserGroupIdsExt;
            //var asadfdsa = asd[0].JobIdsExt;
            ////var asdadssa = asd[0].GetLastModificationChanges();

            var asdasd = _dbStorage_Data_Context.Files.Where(p=> p.AuthorizationUserLinks.Any(p => p.AuthorizationUser.UserIdExt == Guid.Parse("aa4590f8-5ce6-4e95-aa78-0dda009d629b")))
                                                        .Include(p => p.SubDirectory)
                                                            .ThenInclude(p => p.RootDirectory)
                                                        .Include(p => p.RootDirectory)
                                                        .Include(p => p.MetadataLinks)
                                                            .ThenInclude(p => p.Metadata)
                                                        .Include(p => p.QrCode)
                                                        .Include(p => p.Quality)
                                                        .Include(p => p.AuthorizationUserLinks)
                                                            .ThenInclude(p => p.AuthorizationUser)
                                                        .Include(p => p.AuthorizationUserGroupLinks)
                                                            .ThenInclude(p => p.AuthorizationUserGroup)
                                                        .Include(p => p.NotificationUserLinks)
                                                            .ThenInclude(p => p.NotificationUser)
                                                        .Include(p => p.NotificationUserGroupLinks)
                                                            .ThenInclude(p => p.NotificationUserGroup)
                                                        .ToList();



            var asd2 = _dbStorage_Data_Context.RootDirectories.ToList();
            var asdasd2 = _dbStorage_Data_Context.SubDirectories.OrderBy(item => item.Id)
                                                                .Take(100)
                                                                .ToList();

            var asdsad = _dbStorage_Data_Context.Files.ToList();

            ;
        }
    }
}
