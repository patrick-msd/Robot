using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
            // Initialize splash screen and set it as the application main window

            #region Inizialize logger
            // https://github.com/serilog-contrib/serilog-sinks-richtextbox
            SelfLog.Enable(message => Trace.WriteLine($"INTERNAL ERROR: {message}"));

            const string outputTemplate = "[{Timestamp:dd.MM.yyyy - HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}";
            //const string outputTemplate = "[{Timestamp:dd.MM.yyyy - HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";

            List<LokiLabel> lokiLabel = new List<LokiLabel>()
            {
                new LokiLabel()
                {
                    Key = "softwware",
                    Value ="motion_nanotec_motioncontroller_sample"
                },
                 new LokiLabel()
                {
                    Key = "version",
                    Value ="0.0.0.1234154"
                }
            };

            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                                                    .WriteTo.GrafanaLoki("http://138.232.125.214:3100", labels: lokiLabel)
                                                    .Enrich.WithThreadId()
                                                    .CreateLogger();

            Log.Information("Application start ...");
            #endregion

            #region Printing the arguments to the console
            if (e.Args == null)
            {
                Log.Information("No arguments at application Start.");
            }
            else
            {
                for (int i = 0; i < e.Args.Length; i++)
                {
                    Log.Information("Application argument #{0}: {1}", i, e.Args[i]);  // TODO: Write to log (file, database, ...)
                }
            }
            #endregion
            base.OnStartup(e);

            #region Initialize golbal variables
            Globals.ApplicationPath = Directory.GetCurrentDirectory();
            Globals.ApplicationPathConfigFile = Path.Combine(Directory.GetCurrentDirectory(), "ApplicationSettings.xml");

            Globals.ApplicationTitle = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name;
            Globals.ApplicationVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            #endregion

            #region Run application or create application configuration file ...
            if (true) // Run application
            {
                // Initialize splash screen and set it as the application main window
                UISplashScreen splashScreen = new UISplashScreen();
                this.MainWindow = splashScreen;
                splashScreen.ShowDialog();
            }
            //else if (string.Equals(e.Args[0], "save config file")) // Create application configuration
            else
            {
                // Write application configuration to XML file
                Globals.ConfigFile = new Globals_ConfigFile();

                #region Create settings for "Motion - Nanotec - MotionController"
                Globals.ConfigFile.Motion = new Globals_ConfigFile.MotionConfig()
                {
                    Nanotec = new Globals_ConfigFile.NanotecConfig()
                    {
                        MotionControllerDeviceConfigs = new List<Globals_ConfigFile.MotionControllerDeviceConfig>()
                        {
                            new Globals_ConfigFile.MotionControllerDeviceConfig()
                            {
                                ApplicationDeviceName = "",
                                ApplicationDeviceLocation = "",

                                InitialzeAtSplashscreen = true,
                                AutoStartAtSplashscreen = false,
                                HomeingDeviceAtSplashscreen = false,

                                DeviceName = "",
                                DeviceManufacturer = "",
                                DeviceSerialnumber = "",

                                CanIsDefault = true,
                                Can = new Globals_ConfigFile.Device_CanInterface()
                                {
                                    Manufacture = "IXXAT",
                                    DeviceName = "USB-to-CAN V2 - Compact",
                                    DeviceSpecifier = "HW630322",

                                    CanDeviceId = 1,
                                },

                                SerialIsDefault= false,
                                Serial = new Globals_ConfigFile.Device_SerialInterface()
                                {
                                    Port = string.Empty,
                                    Baud = 0
                                },

                                EthernetIsDefault = false,
                                Ethernet = new Globals_ConfigFile.Device_EthernetInterface()
                                {
                                    IpAddress = string.Empty,
                                    Port = 0
                                }
                            },

                            //new Globals_ConfigFile.MotionControllerDeviceConfig()
                            //{
                            //    ApplicationDeviceName = "",
                            //    ApplicationDeviceLocation = "",

                            //    InitialzeAtSplashscreen = true,
                            //    AutoStartAtSplashscreen = false,
                            //    HomeingDeviceAtSplashscreen = false,

                            //    DeviceName = "",
                            //    DeviceManufacturer = "",
                            //    DeviceSerialnumber = "",

                            //    CanIsDefault = true,
                            //    Can = new Globals_ConfigFile.Device_CanInterface()
                            //    {
                            //        Manufacture = "IXXAT",
                            //        DeviceName = "USB-to-CAN V2 - Compact",
                            //        DeviceSpecifier = "HW630322",

                            //        CanDeviceId = 100,
                            //    },

                            //    SerialIsDefault= false,
                            //    Serial = new Globals_ConfigFile.Device_SerialInterface()
                            //    {
                            //        Port = string.Empty,
                            //        Baud = 0
                            //    },

                            //    EthernetIsDefault = false,
                            //    Ethernet = new Globals_ConfigFile.Device_EthernetInterface()
                            //    {
                            //        IpAddress = string.Empty,
                            //        Port = 0
                            //    }
                            //},

                            //new Globals_ConfigFile.MotionControllerDeviceConfig()
                            //{
                            //    ApplicationDeviceName = "",
                            //    ApplicationDeviceLocation = "",

                            //    InitialzeAtSplashscreen = true,
                            //    AutoStartAtSplashscreen = false,
                            //    HomeingDeviceAtSplashscreen = false,

                            //    DeviceName = "",
                            //    DeviceManufacturer = "",
                            //    DeviceSerialnumber = "",

                            //    CanIsDefault = true,
                            //    Can = new Globals_ConfigFile.Device_CanInterface()
                            //    {
                            //        Manufacture = "IXXAT",
                            //        DeviceName = "USB-to-CAN V2 - Compact",
                            //        DeviceSpecifier = "HW630322",

                            //        CanDeviceId = 110,
                            //    },

                            //    SerialIsDefault= false,
                            //    Serial = new Globals_ConfigFile.Device_SerialInterface()
                            //    {
                            //        Port = string.Empty,
                            //        Baud = 0
                            //    },

                            //    EthernetIsDefault = false,
                            //    Ethernet = new Globals_ConfigFile.Device_EthernetInterface()
                            //    {
                            //        IpAddress = string.Empty,
                            //        Port = 0
                            //    }
                            //}
                        }
                    }
                };
                #endregion

                #region Create settings for "Robot - Doosan - Controller"
                Globals.ConfigFile.Robot = new Globals_ConfigFile.RobotConfig()
                {
                    Doosan = new Globals_ConfigFile.DoosanConfig()
                    {
                        ControlDeviceConfigs = new List<Globals_ConfigFile.ControlDeviceConfig>()
                        {
                            new Globals_ConfigFile.ControlDeviceConfig()
                            {
                                ApplicationDeviceName = "",
                                ApplicationDeviceLocation = "",

                                InitialzeAtSplashscreen = true,
                                AutoStartAtSplashscreen = false,
                                HomeingDeviceAtSplashscreen = false,

                                DeviceName = "",
                                DeviceManufacturer = "",
                                DeviceSerialnumber = "",

                                EthernetIsDefault = false,
                                Ethernet = new Globals_ConfigFile.Device_EthernetInterface()
                                {
                                    IpAddress = "192.168.137.50",
                                    Port = 12345
                                }
                            },

                            new Globals_ConfigFile.ControlDeviceConfig()
                            {
                                ApplicationDeviceName = "",
                                ApplicationDeviceLocation = "",

                                InitialzeAtSplashscreen = true,
                                AutoStartAtSplashscreen = false,
                                HomeingDeviceAtSplashscreen = false,

                                DeviceName = "",
                                DeviceManufacturer = "",
                                DeviceSerialnumber = "",

                                EthernetIsDefault = false,
                                Ethernet = new Globals_ConfigFile.Device_EthernetInterface()
                                {
                                    IpAddress = "192.168.137.51",
                                    Port = 12345
                                }
                            }
                        }
                    }
                };
                #endregion

                Globals.ConfigFile.Save(Globals.ApplicationPathConfigFile);
            }
            #endregion
        }
    }
}
