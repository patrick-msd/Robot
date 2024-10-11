using PSGM.Helper;
using System;
using System.IO;
using System.Windows;

namespace PSGM.Vision.Intel.Sample
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            #region Application initialization ...
            string[] _arg = new string[] { "Start" };

#if DEBUG
            Globals.ApplicationId = new Guid("df90e47e-57e8-4278-b838-386c62f34971");
#else
            // Replae GuiD at CICD pipeline
            Globals.ApplicationId = new NewGuid("Replace_ApplicationGuid");
#endif

            Globals.ApplicationPath = Directory.GetCurrentDirectory();
            Globals.ApplicationTitle = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Globals.ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            #endregion

            #region Printing the arguments to the console ...
            if (e.Args == null)
            {
                Serilog.Log.Information("No arguments at application Start.");
            }
            else
            {
                if (e.Args.Length > 0)
                {
                    for (int i = 0; i < e.Args.Length; i++)
                    {
                        Serilog.Log.Information("Application argument #{0}: {1}", i, e.Args[i]);  // TODO: Write to log (file, database, ...)
                    }

                    _arg = e.Args;
                }
                else
                {
                    _arg = new string[] { "CreateAndSaveConfigFile" };
                }
            }
            #endregion

            base.OnStartup(e);

            #region Run application or create application configuration file ...
            if (_arg[0] == "Start") // Run application
            {
                UISplashScreen splashScreen = new UISplashScreen();
                this.MainWindow = splashScreen;
                splashScreen.ShowDialog();
            }
            else if (string.Equals(_arg[0], "CreateAndSaveConfigFile")) // Create and save application configuration file
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
