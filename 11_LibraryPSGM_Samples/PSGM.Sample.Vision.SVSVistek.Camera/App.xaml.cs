using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace RC.Vision.SVSVistek.Sample
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

            Globals.Machine = new Globals_Machine()
            {
                MachineId = ComputerInfo.GetComputerUUID(),

                Vision = null
            };

            Globals.DbMachine_Context = new PSGM.Model.DbMachine.DbMachine_Context();
            Globals.DbMain_Context = new PSGM.Model.DbMain.DbMain_Context();
            Globals.DbSoftware_Context = new PSGM.Model.DbSoftware.DbSoftware_Context();
            Globals.DbStorage_Context = new PSGM.Model.DbStorage.DbStorage_Context();
            Globals.DbStorageRaw_Context = new PSGM.Model.DbStorage.DbStorage_Context();
            Globals.DbUser_Context = new PSGM.Model.DbUser.DbUser_Context();
            Globals.DbWorkflow_Context = new PSGM.Model.DbWorkflow.DbWorkflow_Context();

            string path = "C:\\Git\\MSD\\Robot\\90_Main\\PSGM.MultiTestApp2\\bin\\Debug\\net8.0-windows10.0.22621.0";

            Globals.DbMachine_Context.ConnectionStringSQLite = $"Data Source={path}\\DbMachine.db";
            Globals.DbMain_Context.ConnectionStringSQLite = $"Data Source={path}\\DbMain.db";
            Globals.DbSoftware_Context.ConnectionStringSQLite = $"Data Source={path}\\DbSoftware.db";
            Globals.DbStorage_Context.ConnectionStringSQLite = $"Data Source={path}\\DbStorage.db";
            Globals.DbStorageRaw_Context.ConnectionStringSQLite = $"Data Source={path}\\DbStorageRaw.db";
            Globals.DbUser_Context.ConnectionStringSQLite = $"Data Source={path}\\DbUser.db";
            Globals.DbWorkflow_Context.ConnectionStringSQLite = $"Data Source={path}\\DbWorkflow.db";

            Globals.DbMachine_Context.DatabaseType = DatabaseType.SQLite;
            Globals.DbMain_Context.DatabaseType = DatabaseType.SQLite;
            Globals.DbSoftware_Context.DatabaseType = DatabaseType.SQLite;
            Globals.DbStorage_Context.DatabaseType = DatabaseType.SQLite;
            Globals.DbStorageRaw_Context.DatabaseType = DatabaseType.SQLite;
            Globals.DbUser_Context.DatabaseType = DatabaseType.SQLite;
            Globals.DbWorkflow_Context.DatabaseType = DatabaseType.SQLite;

            Globals.DbMachine_Context.Database.OpenConnection();
            Globals.DbMain_Context.Database.OpenConnection();
            Globals.DbSoftware_Context.Database.OpenConnection();
            Globals.DbStorage_Context.Database.OpenConnection();
            Globals.DbStorageRaw_Context.Database.OpenConnection();
            Globals.DbUser_Context.Database.OpenConnection();
            Globals.DbWorkflow_Context.Database.OpenConnection();

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

            #region Initialize Db ...
            Log.Information("Ensure that the DB is created or migrate ...");
            //Globals.DBDevice_Context.Database.EnsureCreated();
            //Globals.DBJob_Context.Database.EnsureCreated();
            //Globals.DBMain_Context.Database.EnsureCreated();
            //Globals.DBSoftware_Context.Database.EnsureCreated();
            //Globals.DBStorage_Context.Database.EnsureCreated();
            //Globals.DBStorageRaw_Context.Database.EnsureCreated();
            //Globals.DBUser_Context.Database.EnsureCreated();

            Log.Information("Migrate DB  ...");
            //Globals.DBDevice_Context..Database.Migrate();
            //Globals.DBJob_Context..Database.Migrate();
            //Globals.DBMain_Context..Database.Migrate();
            //Globals.DBSoftware_Context..Database.Migrate();
            //Globals.DBStorage_Context..Database.Migrate();
            //Globals.DBStorageRaw_Context..Database.Migrate();
            //Globals.DbUser_Context..Database.Migrate();
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
            //else if (string.Equals(e.Args[0], "save config file")) // Create application configuration
            //{
            //
            //}
            #endregion
        }
    }
}
