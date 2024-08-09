using RC.Model;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;

namespace RC.Control.RobotElectronics.Sample
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

            Log.Information("Initialize golbal variables ...");
            Globals.ApplicationPath = Directory.GetCurrentDirectory();

            Globals.ApplicationTitle = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Globals.ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            Globals.Context = new RcContext(Globals.ApplicationPath + "\\Application.db");

            Globals.LokiLabels = new List<LokiLabel>()
            {
                new LokiLabel()
                {
                    Key = "Software",
                    Value = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name
                },
                new LokiLabel()
                {
                    Key = "Version",
                    Value = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
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

            Log.Information("Application start ...");
            #endregion

            #region Initialize DB ...
            Log.Information("Initialize DB ...");

            Log.Information("Ensure that the DB is created ...");
            Globals.Context.Database.EnsureCreated();
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
            else
            {
                Log.Information("Save settings to Database...");

                Log.Information("Delete Database ...");
                Globals.Context.Database.EnsureDeleted();

                Log.Information("Create Database ...");
                Globals.Context.Database.EnsureCreated();

                Log.Information("Insert device and config in database ...");
                App_config.AppConfiCreate();

                System.Environment.Exit(0);
            }
            #endregion
        }
    }
}
