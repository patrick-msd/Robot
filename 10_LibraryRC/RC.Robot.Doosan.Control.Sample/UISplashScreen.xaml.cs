using Microsoft.EntityFrameworkCore;
using RC.Lib.Control.Doosan;
using RC.Model;
using RCRobotDoosanControl;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace RC.Robot.Doosan.Sample
{
    /// <summary>
    /// Interaction logic for UISplashScreen.xaml
    /// </summary>
    public partial class UISplashScreen : Window
    {
        #region Global variables
        private string _stateName;
        private int _statePercentageCount;
        private int _statePercentageValue;

        private Thread _thrClock;
        private CancellationTokenSource _ctsClock;

        private BackgroundWorker _bgwSplashscreen;

        // Global Hardware
        private Doosan_Container? _doosan;
        #endregion









        public delegate void MyDelegate(string message);
        public delegate void ProgressDelegate(int progress);
        public delegate void StatusDelegate(string status);









        public UISplashScreen()
        {
            InitializeComponent();
        }

        #region Event functions ...
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            txbApplicationName.Text = Globals.ApplicationTitle;
            txbApplicationVersion.Text = "V" + Globals.ApplicationVersion.ToString();

            Log.Information("Start spash screen ...");

            // Calculate percentage and set progress bar
            Log.Information("Initialize and calculate percentage and set progress bar ...");
            _statePercentageValue = 0;
            _statePercentageCount = 5;

            pgbLoading.Minimum = _statePercentageValue;
            pgbLoading.Maximum = _statePercentageCount;

            txbDateTime.Text = DateTime.UtcNow.ToString("dd.MM.yyyy - HH:mm:ss");

            // Thread clock
            Log.Information("Initiaize Thread clock ...");
            _ctsClock = new CancellationTokenSource();
            _thrClock = new Thread(ThreadFuction_Clock);
            _thrClock.Start();

            // Worker splashscreen
            Log.Information("Initiaize Worker splashscreen ...");
            _bgwSplashscreen = new BackgroundWorker();
            _bgwSplashscreen.WorkerReportsProgress = true;
            _bgwSplashscreen.DoWork += WorkerSplashscreen_Function;
            _bgwSplashscreen.ProgressChanged += WorkerSpashscreen_ProgressChanged;
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
        void WorkerSplashscreen_Function(object sender, DoWorkEventArgs e)
        {
            // Step #1
            UpdateUI("Load config file ...");
            LoadConfigFromDB();
            Thread.Sleep(125);

            // Step #2
            UpdateUI("Initialize variables ...");
            InitializeVariables();
            Thread.Sleep(125);

            // Step #3
            UpdateUI("Analyze config and variables ...");
            AnalyzeConfigAndVariables();
            Thread.Sleep(125);

            // Step #4
            UpdateUI("Robot: Initialize and connect devices (Ethernet) ...");
            RobotInitializeAndConnect();
            Thread.Sleep(125);

            // Step #5
            UpdateUI("Finish splashcreen and open main application ...");
            Thread.Sleep(125);
        }

        void WorkerSpashscreen_ProgressChanged(object sender, ProgressChangedEventArgs e)
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

            Log.Information(stateName);
            _bgwSplashscreen.ReportProgress(_statePercentageValue);
        }

        private void LoadConfigFromDB()
        {
            if (File.Exists(Globals.ApplicationPath + "\\Application.db") && Globals.Context.Devices.ToList().Count() > 0)
            {
                MessageBoxResult result = MessageBox.Show("Should config be loaded from database?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Log.Debug("Entities loaded from database ...");
                    Globals.Context?.Devices.Load();
                }
                else
                {
                    Log.Information("Entities NOT loaded from database ...");
                }
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("No database found, schould it be created?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    Log.Information("Save settings to Database...");

                    Log.Information("Delete Database ...");
                    Globals.Context.Database.EnsureDeleted();

                    Log.Information("Create Database ...");
                    Globals.Context.Database.EnsureCreated();

                    Log.Information("Insert device and config in database ...");
                    App_Config.AppConfiCreate();
                    Globals.Context.SaveChanges();
                }
                else
                {
                    Log.Information("Database not created ...");
                }
            }
        }

        private void InitializeVariables()
        {
            #region Initialize global devices ...
            Log.Debug("Initialize global devices ...");

            if (Globals.Device == null)
            {
                Globals.Device = new Globals_Device()
                {
                    Robot = new Globals_Device.Globals_Device_Robot()
                    {
                        Doosan = null
                    }
                };
            }
            #endregion

            #region Initialize class and devices ...
            Log.Debug("Initialize class and devices ...");

            int devicesCount = Globals.Context.Devices.Where(i => i.DeviceManufacturer == DeviceManufacturers.Doosan).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Device.Robot.Doosan = new Doosan_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            if (Globals.Device.Robot != null)
            {
                if (Globals.Device.Robot.Doosan != null)
                {
                    _doosan = Globals.Device.Robot.Doosan;
                }
            }
            #endregion
        }

        private void AnalyzeConfigAndVariables()
        {
            Thread.Sleep(125);
        }

        private void RobotInitializeAndConnect()
        {
            Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            if (_doosan.Controllers != null)
            {
                List<Device> devices = Globals.Context.Devices.Where(p => p.DeviceManufacturer == DeviceManufacturers.Doosan && p.DeviceType == DeviceTypes.Robot)
                                                                                .Include(p => p.Interfaces_Ethernet)
                                                                                .ToList();

                foreach (Device device in devices)
                {
                    try
                    {
                        List<Doosan_Controller> controller = new List<Doosan_Controller>();

                        if (device.InitialzeAtSplashscreen)
                        {
                            Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
                            _doosan.Controllers.Add(new Doosan_Controller());

                            // Link Hardware with DbContext
                            _doosan.Controllers.Last().IdDb = device.Id;
                        }

                        controller = _doosan.Controllers.Where(p => p.IdDb == device.Id).ToList();

                        if (device.ConnectAtSplashscreen && controller.Count == 1)
                        {
                            Log.Debug($"Define C# callback function´s for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
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

                            ////Register the callback
                            //controller[0].ManagedTOnHommingCompletedCBHandler += Events.OnHommingCompleted;
                            //////_robot.ManagedTOnMonitoringDataCBHandler += OnMonitoringDataCB1;
                            //////_robot.ManagedTOnMonitoringDataExCBHandler += OnMonitoringDataExCB1;
                            //////_robot.ManagedTOnMonitoringCtrlIOCBHandler += OnMonitoringCtrlIOCB1;
                            //////_robot.ManagedTOnMonitoringCtrlIOExCBHandler += OnMonitoringCtrlIOExCB1;
                            //////_robot.ManagedTOnMonitoringStateCBHandler += OnMonitoringStateCB1;
                            //////_robot.ManagedTOnMonitoringAccessControlCBHandler += OnMonitoingAccessControlCB1;
                            //controller[0].ManagedTOnTpInitializingCompletedCBHandler += Events.OnTpInitializingCompleted;
                            //////_robot.ManagedTOnLogAlarmCBHandler += OnLogAlarm1;
                            //////_robot.ManagedTOnProgramStoppedCBHandler += OnProgramStopped1;
                            //controller[0].ManagedTOnDisconnectedCBHandler += Events.OnDisconnected;
                            controller[0].RegisterEvents();
                            Thread.Sleep(250);

                            Log.Debug($"Open connection for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            controller[0].OpenConnection(device.Interfaces_Ethernet.IpAddress, device.Interfaces_Ethernet.Port);
                            Log.Information($"Connect to Robot: {device.Interfaces_Ethernet.IpAddress}:{device.Interfaces_Ethernet.Port}");
                            Thread.Sleep(250);

                            Log.Debug($"Get information of robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");

                            // Change monitoring data version
                            SystemVersion systemVersion = controller[0].GetSystemVersion();
                            Log.Information("System Version: " + systemVersion._szController);
                            controller[0].SetupMonitoringVersion(1);
                            controller[0].SetRobotControl(RobotControl.CONTROL_SERVO_ON);

                            Log.Information("Library Version: " + controller[0].GetLibraryVersion());
                            Thread.Sleep(250);

                            // Wait for robot state change
                            //while ((controller[0].GetRobotState() != RobotState.STATE_STANDBY) || !controller[0].HasControlAuthority)
                            //{
                            //    Thread.Sleep(250);
                            //}

                            // Manual mode setting
                            controller[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                            controller[0].SetRobotSystem(RobotSystem.ROBOT_SYSTEM_REAL);

                            Thread.Sleep(250);


                            //_Doosan.ControlDeviceConfigs[i].SetAxisDirection(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f);

                            //_robot.SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_10, true);

                        }
                        else
                        {
                            // ToDo: ...
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
