﻿using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbBackend;
using PSGM.Model.DbMachine;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace PSGM.Sample.Model.DbMachine
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
        private DbMachine_Context _dbMachine_Context;

        Guid _softwareId;
        Guid _computerId;

        Guid _projectId;

        Guid _patrickSchoeneggerId;
        Guid _guenterMuehlbergerId;
        Guid _gertraudZeindlId;
        Guid _christophHaidacherId;

        public MainWindow()
        {
            InitializeComponent();

            _computerId = ComputerInfo.GetComputerUUID();

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
            _computerId = Guid.NewGuid();

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

                _dbBackend_Context.DatabaseSessionParameter_ApplicationId = _softwareId;
                _dbBackend_Context.DatabaseSessionParameter_ComputerId = _computerId;
                _dbBackend_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

                _dbBackend_Context.Database.OpenConnection();
                #endregion

                List<DbBackend_Backend>? backend = _dbBackend_Context.Backends.Where(p => p.Project.ProjectId_Ext == new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657"))
                                                                                .Include(p => p.DatabaseClusters)
                                                                                    .ThenInclude(p => p.DatabaseServers)
                                                                                .Include(p => p.StorageClusters)
                                                                                    .ThenInclude(p => p.StorageServers)
                                                                                .ToList();

                DbBackend_Database_Cluster? databaseMain = backend.Where(p => p.BackendType == BackendType.Machine).FirstOrDefault().DatabaseClusters.FirstOrDefault();

                _dbMachine_Context = new DbMachine_Context();

                _dbMachine_Context.DatabaseConnectionString = databaseMain.GetDatabaseConnection(true);
                _dbMachine_Context.DatabaseType = databaseMain.DatabaseType;

                _dbMachine_Context.DatabaseSessionParameter_ApplicationId = _softwareId;
                _dbMachine_Context.DatabaseSessionParameter_ComputerId = _computerId;
                _dbMachine_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

                if (_dbMachine_Context.Database.EnsureCreated())
                {
                    _dbMachine_Context.Database.OpenConnection();
                }
                //_dbMachine_Context.Database.EnsureDeleted();
                //_dbMachine_Context.Database.EnsureCreated();
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
            #region Initialize Databases
            if (_configFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                #region Backend
                _dbBackend_Context = new DbBackend_Context();

                _dbBackend_Context.DatabaseConnectionString = _configFile.DatabaseConnectionString;
                _dbBackend_Context.DatabaseType = _configFile.DatabaseType;

                _dbBackend_Context.DatabaseSessionParameter_ApplicationId = _softwareId;
                _dbBackend_Context.DatabaseSessionParameter_ComputerId = _computerId;
                _dbBackend_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

                _dbBackend_Context.Database.OpenConnection();
                #endregion

                List<DbBackend_Backend>? backend = _dbBackend_Context.Backends.Where(p => p.Project.ProjectId_Ext == new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657"))
                                                                                .Include(p => p.DatabaseClusters)
                                                                                    .ThenInclude(p => p.DatabaseServers)
                                                                                .Include(p => p.StorageClusters)
                                                                                    .ThenInclude(p => p.StorageServers)
                                                                                .ToList();

                DbBackend_Database_Cluster? databaseMain = backend.Where(p => p.BackendType == BackendType.Machine).FirstOrDefault().DatabaseClusters.FirstOrDefault();

                _dbMachine_Context = new DbMachine_Context();

                _dbMachine_Context.DatabaseConnectionString = databaseMain.GetDatabaseConnection(true);
                _dbMachine_Context.DatabaseType = databaseMain.DatabaseType;

                _dbMachine_Context.DatabaseSessionParameter_ApplicationId = _softwareId;
                _dbMachine_Context.DatabaseSessionParameter_ComputerId = _computerId;
                _dbMachine_Context.DatabaseSessionParameter_UserId = _patrickSchoeneggerId;

                _dbMachine_Context.Database.EnsureDeleted();
                _dbMachine_Context.Database.EnsureCreated();
                _dbMachine_Context.Database.OpenConnection();
            }
            #endregion
        }

        private void btnDbGenerateData_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();

            #region Add project ...
            DbMachine_Project projects1 = Generate_Project1(new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657"));
            _dbMachine_Context.Projects.AddRange(projects1);
            _dbMachine_Context.SaveChanges();
            #endregion

            #region Add structure ...
            DbMachine_Machine machine1 = Generate_Machine1(projects1);
            _dbMachine_Context.Machines.Add(machine1);
            _dbMachine_Context.SaveChanges();
            #endregion

            //for (int h = 0; h < 10; h++)
            //{
            //    #region Add project ...
            //    List<DbBackendStructure_Project> projects2 = Generate_Project2(250);
            //    _dbBackendStructure_Context.Projects.AddRange(projects2);
            //    _dbBackendStructure_Context.SaveChanges();
            //    #endregion

            //    #region Add structure ...
            //    List<DbBackendStructure_Structure> subDirectories2 = Generate_Structure2(10000, projects2);
            //    _dbBackendStructure_Context.Structures.AddRange(subDirectories2);
            //    _dbBackendStructure_Context.SaveChanges();
            //    #endregion
            //}
        }

        private void btnDbReadData1_Click(object sender, RoutedEventArgs e)
        {
            ;


            //var asd = _dbBackend_Context.Projects.Include(p => p.Cluster)
            //                                        .ThenInclude(p => p.Server)
            //                                        .ToList();


            //var asdasd = _dbStorage_Data_Context.Files.ToList();

            //var asd = _dbBackendStructure_Context.Files.Where(f => f.ExtId3.Contains("e"))
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

            //var asdasd = _dbStorage_Data_Context.Files.Where(p => p.AuthorizationUserLinks.Any(p => p.AuthorizationUser.UserIdExt == Guid.Parse("aa4590f8-5ce6-4e95-aa78-0dda009d629b")))
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



            //var asd2 = _dbBackendStructure_Context.RootDirectories.ToList();
            //var asdasd2 = _dbBackendStructure_Context.SubDirectories.OrderBy(item => item.Id)
            //                                                    .Take(100)
            //                                                    .ToList();

            //var asdsad = _dbBackendStructure_Context.Files.ToList();

            ;
        }
    }
}
