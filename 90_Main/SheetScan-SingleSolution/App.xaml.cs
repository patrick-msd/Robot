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
            #region Application initialization ...
            string[] _arg = new string[] { "true" };

#if DEBUG
            Globals.ApplicationId = new Guid("df90e47e-57e8-4278-b838-386c62f34971");
#else
            Globals.ApplicationId = new NewGuid("Replace_ApplicationGuid");
#endif

            Globals.ApplicationPath = Directory.GetCurrentDirectory();
            Globals.ApplicationTitle = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Globals.ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            #endregion






            #region Get Project Id ...
            Log.Information("Get Project Id ...");

            Globals.ProjectId = new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657");
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
