using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbBackend;
using PSGM.Model.DbJob;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using PSGM.Model.DbSoftware;
using PSGM.Model.DbStorage;
using PSGM.Model.DbUser;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows;

namespace RC.Scan_SingleSolution
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            #region Initialize golbal variables ...
            string[] _arg = new string[] { "true" };

            Log.Information("Initialize global variables ...");
            Globals.ApplicationPath = Directory.GetCurrentDirectory();

            Globals.ApplicationTitle = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Globals.ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            Globals.SoftwareId = Guid.NewGuid();
            Globals.ComputerId = ComputerInfo.GetComputerUUID();

            Globals.OrganizationId = Guid.Empty;
            Globals.UserId = Guid.Empty;

            Globals.ProjectId = Guid.Empty;
            Globals.DirectoryId = Guid.Empty;
            Globals.UnitId = Guid.Empty;

            Globals.Machine = new Globals_Machine()
            {
                Control = null,
                Motion = null,
                PowerSupply = null,
                Robot = null,
                Vision = null
            };

            Globals.DbBackend_Context = new DbBackend_Context();
            Globals.DbJob_Context = new DbJob_Context();
            Globals.DbMachine_Context = new DbMachine_Context();
            Globals.DbMain_Context = new DbMain_Context();
            Globals.DbSoftware_Context = new DbSoftware_Context();
            Globals.DbStorageData_Context = new DbStorage_Context();
            Globals.DbStorageDataRaw_Context = new DbStorage_Context();
            Globals.DbUser_Context = new DbUser_Context();

            Globals.LokiLabels = new List<LokiLabel>()
            {
                new LokiLabel()
                {
                    Key = "Software",
                    Value = Globals.ApplicationTitle
                },
                new LokiLabel()
                {
                    Key = "Version",
                    Value = Globals.ApplicationVersion.ToString()
                }
            };
            Globals.LokiUri = "http://10.31.40.101:3100";
            Globals.LokiOutputTemplate = "[{Timestamp:dd.MM.yyyy - HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}";
            //Globals.LokiOutputTemplate  = "[{Timestamp:dd.MM.yyyy - HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";
            #endregion

            #region Inizialize logger
            // https://github.com/serilog-contrib/serilog-sinks-richtextbox
            SelfLog.Enable(message => Trace.WriteLine($"INTERNAL ERROR: {message}"));

#if DEBUG
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Debug(outputTemplate: Globals.LokiOutputTemplate)
                                .WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
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

            Log.Information($"Application \"{Globals.ApplicationTitle} V{Globals.ApplicationVersion.ToString()}\" start...");
            #endregion

            #region Read application configuration file ...
            Log.Information("Read application configuration file ...");

            Globals.ConfigFile = new ConfigFile();

            if (Globals.ConfigFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                Globals.ConfigFile.ReadFromFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
            }
            #endregion

            #region Set Software Id ...
            Log.Information("Set Software Id ...");

            Globals.SoftwareId = Guid.NewGuid();
            #endregion

            #region Get Project Id ...
            Log.Information("Get Project Id ...");

            Globals.ProjectId = new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657");
            #endregion

            #region Connect to Backend Database ...
            Log.Information("Connect to Backend Database ...");

            Globals.DbBackend_Context.DatabaseConnectionString = Globals.ConfigFile.DatabaseConnectionString;
            Globals.DbBackend_Context.DatabaseType = Globals.ConfigFile.DatabaseType;

            Globals.DbBackend_Context.DatabaseSessionParameter_SoftwareId = Globals.SoftwareId;
            Globals.DbBackend_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbBackend_Context.DatabaseSessionParameter_UserId = Guid.Empty;

            Globals.DbBackend_Context.Database.OpenConnection();
            #endregion

            #region Get server from Backend Database ...
            Log.Information("Get server from Backend Database ...");

            List<DbBackend_Backend>? backend = Globals.DbBackend_Context.Backends.Where(p => p.Project.ProjectId_Ext == Globals.ProjectId)
                                                                                    .Include(p => p.DatabaseClusters)
                                                                                        .ThenInclude(p => p.DatabaseServers)
                                                                                    .Include(p => p.StorageClusters)
                                                                                        .ThenInclude(p => p.StorageServers)
                                                                                    .ToList();
            #endregion


            #region Printing the arguments to the console ...
            if (e.Args == null)
            {
                Log.Information("No arguments at application Start.");
            }
            else
            {
                if (e.Args.Length > 0)
                {
                    for (int i = 0; i < e.Args.Length; i++)
                    {
                        Log.Information("Application argument #{0}: {1}", i, e.Args[i]);  // TODO: Write to log (file, database, ...)
                    }

                    _arg = e.Args;
                }
                else
                {
                    //_arg = new string[] { "false" };
                }
            }
            #endregion

            base.OnStartup(e);

            #region Run application or create application configuration file ...
            if (_arg[0] == "true") // Run application
            {
                // Initialize splash screen and set it as the application main window
                UISplashScreen splashScreen = new UISplashScreen();
                this.MainWindow = splashScreen;
                splashScreen.ShowDialog();
            }
            else if (string.Equals(e.Args[0], "create and save config file")) // Create application configuration
            {
                Globals.ConfigFile = new ConfigFile()
                {
                    DatabaseType = DatabaseType.PostgreSQL,
                    DatabaseConnectionString = "Host=db-backend-c6e1c3e3-f49d-4edc-b3a2-2ed50174e3c8.branch031.psgm.at:50001;Database=db-backend-c6e1c3e3-f49d-4edc-b3a2-2ed50174e3c8;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V",
                };

                Globals.ConfigFile.WriteToFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
            }
            #endregion
        }
    }
}
