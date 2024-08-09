using RC.Motion.Nanotec.MotionController;
using Serilog;
using Serilog.Sinks.Grafana.Loki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;

namespace RC.Scan_SingleSolution
{
    /// <summary>
    /// Interaction logic for UISplashScreen.xaml
    /// </summary>
    public partial class UISplashScreen : Window
    {
        // SplashScreen examples:
        // https://riptutorial.com/wpf/example/25400/creating-splash-screen-window-with-progress-reporting
        // https://www.youtube.com/watch?v=XM_I1y1mh7k&ab_channel=CodeCraks

        #region Global variables
        private string _stateName;
        private int _statePercentageCount;
        private int _statePercentageValue;

        private Globals_ConfigFile.NanotecConfig? _Nanotec;
        private Nlc.BusHWIdVector _busHardwareIds;

        private Globals_ConfigFile.DoosanConfig? _Doosan;

        private Thread _thrClock;
        private CancellationTokenSource _ctsClock;

        private BackgroundWorker _bgwSplashscreen;
        #endregion

        public UISplashScreen()
        {
            InitializeComponent();
        }

        #region Event functions ...
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            txbApplicationName.Text = Globals.ApplicationTitle;
            txbApplicationVersion.Text = "V" + Globals.ApplicationVersion.ToString();

            #region Initialize logger ...
            // https://github.com/serilog-contrib/serilog-sinks-richtextbox

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

#if DEBUG
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                                                    .WriteTo.Debug(outputTemplate: outputTemplate)
                                                    .WriteTo.GrafanaLoki("http://138.232.125.214:3100", labels: lokiLabel)
                                                    .Enrich.WithThreadId()
                                                    .CreateLogger();
#else
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                                                    .WriteTo.GrafanaLoki("http://138.232.125.214:3100", labels: lokiLabel)
                                                    .Enrich.WithThreadId()
                                                    .CreateLogger();
#endif

            Log.Information("Start spash screen ...");
            #endregion

            // Calculate percentage and set progress bar
            _statePercentageValue = 0;
            _statePercentageCount = 7;

            pgbLoading.Minimum = _statePercentageValue;
            pgbLoading.Maximum = _statePercentageCount;

            txbDateTime.Text = DateTime.UtcNow.ToString("dd.MM.yyyy - HH:mm:ss");

            // Thread clock
            _ctsClock = new CancellationTokenSource();
            _thrClock = new Thread(ThreadFuction_Clock);
            _thrClock.Start();

            // Worker splashscreen
            _bgwSplashscreen = new BackgroundWorker();
            _bgwSplashscreen.WorkerReportsProgress = true;
            _bgwSplashscreen.DoWork += worker_DoWork;
            _bgwSplashscreen.ProgressChanged += worker_ProgressChanged;
            _bgwSplashscreen.RunWorkerAsync();
        }
        #endregion

        #region Thread functions ...
        private void ThreadFuction_Clock()
        {
            while (!_ctsClock.IsCancellationRequested)
            {
                this.Dispatcher.Invoke(() => { txbDateTime.Text = DateTime.UtcNow.ToString("dd.MM.yyyy - HH:mm:ss"); });

                Thread.Sleep(125);
            }
        }
        #endregion

        #region Worker functions ...
        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Step #1
            UpdateUI("Load config file ...");
            LoadConfigFile();

            // Step #2
            UpdateUI("Initialize variables ...");
            InitializeVariables();

            // Step #3
            UpdateUI("Analyze config and variables ...");
            AnalyzeConfigAndVariables();

            // Step #4
            UpdateUI("Connect to the bus devices (USB-to-CAN, USB-toSerial, ...) ...");
            InitializeBusDevice();

            // Step #5
            UpdateUI("Connect to the devices on the bus ...");
            InitializeDevicesOnTheBus();

            // Step #6
            UpdateUI("Ronnect to robots ...");
            ConnectAndInitializeRobotDevice();

            // Step #7
            UpdateUI("Finish splashcreen and open main application ...");
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbLoading.Value = _statePercentageValue;
            txbState.Text = _stateName;

            if (_statePercentageValue >= _statePercentageCount)
            {
                // Set Splasscree as top most
                this.Topmost = true;

                // Thread clock stop
                _ctsClock.Cancel();
                _thrClock.Join();

                // Open main windows
                UIMainWindow uiMainWindow = new UIMainWindow();
                this.Close();
                uiMainWindow.ShowDialog();
            }
        }
        #endregion

        #region Functions ...
        private void UpdateUI(string stateName)
        {
            _statePercentageValue++;
            _stateName = stateName;

            _bgwSplashscreen.ReportProgress(_statePercentageValue);
        }


        private void LoadConfigFile()
        {
            MessageBoxResult result = MessageBox.Show("Config file found.\n\rShould it be loaded?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Globals.ConfigFile = new Globals_ConfigFile();
                Globals.ConfigFile.Load(Globals.ApplicationPathConfigFile);
            }
        }

        private void InitializeVariables()
        {
            #region Create Config file if null ...
            if (Globals.ConfigFile == null)
            {
                Globals.ConfigFile = new Globals_ConfigFile()
                {
                    Motion = new Globals_ConfigFile.MotionConfig()
                    {
                        Nanotec = new Globals_ConfigFile.NanotecConfig()
                        {

                        }
                    },
                    Robot = new Globals_ConfigFile.RobotConfig()
                    {
                        Doosan = new Globals_ConfigFile.DoosanConfig()
                        {

                        }
                    }
                };
            }
            #endregion

            #region Initialize variables ...
            Globals.ConfigFile.Motion.Nanotec.MotionBusController = new MotionBusController();
            //Globals.ConfigFile.Robot.Doosan.MotionBusController = new MotionBusController();
            #endregion

            #region Link variables to get shorter variable names ...
            _Nanotec = Globals.ConfigFile.Motion.Nanotec;
            _Doosan = Globals.ConfigFile.Robot.Doosan;
            #endregion
        }

        private void AnalyzeConfigAndVariables()
        {
            if (_Nanotec.GetInterfacesCan.Count >= 2)
            {
                MessageBoxResult result = MessageBox.Show("There is more than one CAN interface configured in the config file ...", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeBusDevice()
        {
            _Nanotec.MotionBusController.Setup(Nlc.LogLevel.Debug);

            // Its possible to set the logging level to a different level
            _Nanotec.MotionBusController.SetLoggingLevel(Nlc.LogLevel.Off);

            #region Get and list all hardware available, and print out available hardware ...
            // Get and list all hardware available
            //_Nanotec.BusHardwareIds = _Nanotec.MotionController.GetBusHardware();
            _busHardwareIds = _Nanotec.MotionBusController.GetBusHardware();

            if (_busHardwareIds.Count() <= 0)
            //if (_Nanotec.BusHardwareIds.Count() <= 0)
            {
                Log.Error("No bus hardware found");
                return;
            }

            Log.Information("");
            Log.Information("Available bus hardware:");

            uint lineNum = 0;

            // Just for better overview: print out available hardware
            foreach (Nlc.BusHardwareId adapter in _busHardwareIds)
            //foreach (Nlc.BusHardwareId adapter in _Nanotec.BusHardwareIds)
            {
                Log.Information("Nr. {0} - Name: {1} Bus Hardware: {2} Hardware Specifier: {3} Extra Hardware Specifier: {4} --> Protocol: {5}", lineNum, adapter.getName(), adapter.getBusHardware(), adapter.getHardwareSpecifier(), adapter.getExtraHardwareSpecifier(), adapter.getProtocol());

                if (string.Equals(adapter.getBusHardware(), _Nanotec.GetInterfacesCan.First().Manufacture) && string.Equals(adapter.getHardwareSpecifier(), _Nanotec.GetInterfacesCan.First().DeviceSpecifier))
                {
                    Log.Information("Selected: Nr. {0} - Name: {1} Bus Hardware: {2} Hardware Specifier: {3} Extra Hardware Specifier: {4} --> Protocol: {5}", lineNum, adapter.getName(), adapter.getBusHardware(), adapter.getHardwareSpecifier(), adapter.getExtraHardwareSpecifier(), adapter.getProtocol());

                    // Select bus hardware ...
                    // Let's select the first one
                    //Nlc.BusHardwareId busHwId = busHwIds[(int)lineNum];                               // Do not do this !!!!
                    //Nlc.BusHardwareId busHwId = new Nlc.BusHardwareId(busHwIds[(int)lineNum]);        // Very important step in the C# version of NanoLib

                    // Create a copy of every object, which is returned in a vector, because when the vector goes out of scope,
                    // the contained objects will be destroyed. Or just copy the vector into an array
                    _Nanotec.MotionBusHardwareId = _busHardwareIds.ToArray()[lineNum];
                    //_Nanotec.BusHardwareId = _Nanotec.BusHardwareIds.ToArray()[lineNum];
                }
                else
                {
                    Log.Information("Not selected: Nr. {0} - Name: {1} Bus Hardware: {2} Hardware Specifier: {3} Extra Hardware Specifier: {4} --> Protocol: {5}", lineNum, adapter.getName(), adapter.getBusHardware(), adapter.getHardwareSpecifier(), adapter.getExtraHardwareSpecifier(), adapter.getProtocol());
                }

                lineNum++;
            }

            if (_Nanotec.MotionBusHardwareId == null)
            {
                Log.Information("");
                Log.Information("No or invalid bus hardware selection!");
            }
            #endregion

            #region Create bus hardware and open the hardware itself ... 
            if (_Nanotec.MotionBusHardwareId != null)
            {
                // Create bus hardware options for opening the hardware
                Nlc.BusHardwareOptions busHwOptions = _Nanotec.MotionBusController.CreateBusHardwareOptions(_Nanotec.MotionBusHardwareId);

                // Now able to open the hardware itself
                _Nanotec.MotionBusController.OpenBusHardware(_Nanotec.MotionBusHardwareId, busHwOptions);

                #region Scan for devices, and print out available devices ...
                Log.Information("");

                Log.Information("Scanning for devices...");

                // Either scan the whole bus for devices (in case the bus supports scanning)
                _Nanotec.MotionBusDeviceIds = _Nanotec.MotionBusController.ScanBus(_Nanotec.MotionBusHardwareId);

                if (_Nanotec.MotionBusDeviceIds.Count == 0)
                {
                    MessageBoxResult result = MessageBox.Show("No devices found. ...", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                    Log.Error("No devices found.");
                    return;
                }

                // Just for better overview: print out available devices
                foreach (Nlc.DeviceId id in _Nanotec.MotionBusDeviceIds)
                {
                    Log.Information("Found device with ID: {0} Device name: {1} Bus Hardware: {2}", id.getDeviceId(), id.getDescription(), id.getBusHardwareId().getName());
                }
                #endregion
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Connectet to no bus hardware ...", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            #endregion
        }

        private void InitializeDevicesOnTheBus()
        {
            for (int i = 0; i < _Nanotec.MotionControllerDeviceConfigs.Count; i++)
            {
                if (_Nanotec.MotionControllerDeviceConfigs[i].InitialzeAtSplashscreen)
                {
                    if (_Nanotec.MotionControllerDeviceConfigs[i].Can.CanDeviceId != 0)
                    {
                        int id = -1;

                        for (int j = 0; j < _Nanotec.MotionBusDeviceIds.Count; j++)
                        {
                            if (_Nanotec.MotionBusDeviceIds[j].getDeviceId() == _Nanotec.MotionControllerDeviceConfigs[i].Can.CanDeviceId)
                            {
                                id = j;
                                break;
                            }
                        }

                        if (id != -1)
                        {
                            // Create a copy of every object, which is returned in a vector, because when the vector goes out of scope,
                            // the contained objects will be destroyed. Or just copy the vector into an array
                            _Nanotec.MotionControllerDeviceConfigs[i].DeviceId = _Nanotec.MotionBusDeviceIds.ToArray()[id];

                            _Nanotec.MotionControllerDeviceConfigs[i].DeviceHandle = _Nanotec.MotionBusController.CreateDevice(_Nanotec.MotionControllerDeviceConfigs[i].DeviceId);
                        }
                        else
                        {
                            Log.Information("CAN device with ID: {0} not inizialized ...", _Nanotec.MotionBusDeviceIds[i].getDeviceId());
                        }
                    }
                }

                if (_Nanotec.MotionControllerDeviceConfigs[i].AutoStartAtSplashscreen)
                {
                    // No autostart for motion controllers at the moment ...
                }
            }
        }

        private void ConnectAndInitializeRobotDevice()
        {
            for (int i = 0; i < _Doosan.ControlDeviceConfigs.Count; i++)
            {
                try
                {
                    _Doosan.ControlDeviceConfigs[i].Control = new RCRobotDoosanControl.Doosan();

                    _Doosan.ControlDeviceConfigs[i].Control._robterId = i;
                    //_Doosan.ControlDeviceConfigs[i].SetAxisDirection(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f);


                    //// Define a C# callback function
                    //RCRobotDoosanControl.Doosan.MyDelegate myDelegate = Globals.MyCallback;

                    //_Doosan.ControlDeviceConfigs[i].Control.SetupCallbackk(myDelegate);





                    //// Define C# callback functions
                    //RCRobotDoosanControl.Doosan.ProgressDelegate progressDelegate = Globals.UpdateProgress;
                    //RCRobotDoosanControl.Doosan.StatusDelegate statusDelegate = Globals.UpdateStatus;


                    // Pass the delegates to the C++/CLI DLL
                    //_Doosan.ControlDeviceConfigs[i].Control.SetupCallback(progressDelegate, statusDelegate);


                    //_Doosan.ControlDeviceConfigs[i].Control._robterId = i;


                    //_Doosan.ControlDeviceConfigs[i].Control.ManagedTOnTpInitializingCompletedCBHandler1 += Globals.OnTpInitializingCompleted1;

                    //_Doosan.ControlDeviceConfigs[i].Control.ManagedTOnTpInitializingCompletedCBHandler2 += Globals.OnTpInitializingCompleted2;






                    // Register the callback
                    _Doosan.ControlDeviceConfigs[i].Control.ManagedTOnHommingCompletedCBHandler += Events.OnHommingCompleted;
                    ////_robot.ManagedTOnMonitoringDataCBHandler += OnMonitoringDataCB1;
                    ////_robot.ManagedTOnMonitoringDataExCBHandler += OnMonitoringDataExCB1;
                    ////_robot.ManagedTOnMonitoringCtrlIOCBHandler += OnMonitoringCtrlIOCB1;
                    ////_robot.ManagedTOnMonitoringCtrlIOExCBHandler += OnMonitoringCtrlIOExCB1;
                    ////_robot.ManagedTOnMonitoringStateCBHandler += OnMonitoringStateCB1;
                    ////_robot.ManagedTOnMonitoringAccessControlCBHandler += OnMonitoingAccessControlCB1;
                    _Doosan.ControlDeviceConfigs[i].Control.ManagedTOnTpInitializingCompletedCBHandler += Events.OnTpInitializingCompleted;
                    ////_robot.ManagedTOnLogAlarmCBHandler += OnLogAlarm1;
                    ////_robot.ManagedTOnProgramStoppedCBHandler += OnProgramStopped1;
                    _Doosan.ControlDeviceConfigs[i].Control.ManagedTOnDisconnectedCBHandler += Events.OnDisconnected;

                    Thread.Sleep(250);

                    // Establish a connection
                    _Doosan.ControlDeviceConfigs[i].Control.OpenConnection(_Doosan.ControlDeviceConfigs[i].Ethernet.IpAddress, _Doosan.ControlDeviceConfigs[i].Ethernet.Port);
                    Log.Information("Connect to Robot: {0}:{1}", _Doosan.ControlDeviceConfigs[i].Ethernet.IpAddress, _Doosan.ControlDeviceConfigs[i].Ethernet.Port);
                    Thread.Sleep(250);

                    // Change monitoring data version
                    RCRobotDoosanControl.SystemVersion systemVersion = _Doosan.ControlDeviceConfigs[i].Control.GetSystemVersion();
                    Log.Information("System Version: " + systemVersion._szController);
                    _Doosan.ControlDeviceConfigs[i].Control.SetupMonitoringVersion(1);
                    _Doosan.ControlDeviceConfigs[i].Control.SetRobotControl(RCRobotDoosanControl.RobotControl.CONTROL_SERVO_ON);
                    //_robot.SetDigitalOutput(RCRobotDoosanControl.GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_10, true);
                    Log.Information("Library Version: " + _Doosan.ControlDeviceConfigs[i].Control.GetLibraryVersion());
                    Thread.Sleep(250);

                    //// Wait for robot state change
                    //while ((_robot.GetRobotState() != RCRobotDoosanControl.RobotState.STATE_STANDBY) || !_robot._hasControlAuthority)
                    //{
                    //    Thread.Sleep(250);
                    //}

                    // Manual mode setting
                    _Doosan.ControlDeviceConfigs[i].Control.SetRobotMode(RCRobotDoosanControl.RobotMode.ROBOT_MODE_MANUAL);
                    _Doosan.ControlDeviceConfigs[i].Control.SetRobotSystem(RCRobotDoosanControl.RobotSystem.ROBOT_SYSTEM_REAL);

                    Thread.Sleep(250);











                    //Thread.Sleep(5000);

                    //_Doosan.ControlDeviceConfigs[i].Control.CloseConnection();

                    ;
                }
                catch (Exception ex)
                {
                    Log.Error("Exception: " + ex.Message);
                }
            }
        }
        #endregion
    }
}
