using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using RC.Lib.Control.Doosan;
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
        private bool _closeApplication;

        private string _stateName;
        private int _statePercentageCount;
        private int _statePercentageValue;

        private Thread _thrClock;
        private CancellationTokenSource _ctsClock;

        private BackgroundWorker _bgwSplashscreen;

        // Global Hardware
        private Doosan_Container? _doosan;

        // Global database
        List<DbMachine_Machine>? _dbMachine_Machine;
        List<DbMain_Project>? _dbMain_Projects;
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
            this.Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            txbApplicationName.Text = Globals.ApplicationTitle;
            txbApplicationVersion.Text = "V" + Globals.ApplicationVersion.ToString();

            Log.Information("Start splash screen ...");

            _closeApplication = false;

            // Calculate percentage and set progress bar
            Log.Information("Initialize and calculate percentage and set progress bar ...");
            _statePercentageValue = 0;
            _statePercentageCount = 4;

            pgbLoading.Minimum = _statePercentageValue;
            pgbLoading.Maximum = _statePercentageCount;

            txbDateTime.Text = DateTime.UtcNow.ToString("dd.MM.yyyy - HH:mm:ss");

            // Thread clock
            Log.Information("Initialize Thread clock ...");
            _ctsClock = new CancellationTokenSource();
            _thrClock = new Thread(ThreadFuction_Clock);
            _thrClock.Start();

            // Worker splash screen
            Log.Information("Initialize Worker splash screen ...");
            _bgwSplashscreen = new BackgroundWorker();
            _bgwSplashscreen.WorkerReportsProgress = true;
            _bgwSplashscreen.DoWork += WorkerSplashscreen_Function;
            _bgwSplashscreen.ProgressChanged += WorkerSplashscreen_ProgressChanged;
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
            LoadDataFromDB();
            Thread.Sleep(125);

            // Step #2
            UpdateUI("Initialize variables ...");
            InitializeVariables();
            Thread.Sleep(125);

            // Step #3
            UpdateUI("Robot: Initialize and connect devices (Ethernet) ...");
            RobotInitializeAndConnect();
            Thread.Sleep(125);

            // Step #4
            UpdateUI("Finish splashcreen and open main application ...");
            Thread.Sleep(125);
        }

        void WorkerSplashscreen_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pgbLoading.Value = _statePercentageValue;
            txbState.Text = _stateName;

            if (_statePercentageValue >= _statePercentageCount)
            {
                // Set Splash screen as top most
                this.Topmost = true;

                // Thread clock stop
                _ctsClock.Cancel();
                _thrClock.Join();

                if (_closeApplication)
                {
                    Log.Error("Close application ...");

                    this.Close();
                }
                else
                {
                    // Open main windows
                    UIMainWindow uiMainWindow = new UIMainWindow();
                    this.Close();
                    uiMainWindow.ShowDialog();
                }
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

        private void LoadDataFromDB()
        {
            _dbMain_Projects = Globals.DbMain_Context.Projects.Where(p => p.MachinesExtString.Contains(Globals.Machine.MachineId.ToString()))
                                                                .Include(p => p.ProjectParameter)
                                                                    .ThenInclude(p => p.Storages)
                                                                .Include(p => p.Organization)
                                                                .Include(p => p.Contributors)
                                                                .ToList();

            _dbMachine_Machine = Globals.DbMachine_Context.Machines.Where(p => p.Id == Globals.Machine.MachineId)
                                                                    .Include(p => p.DeviceGroups)
                                                                        .ThenInclude(p => p.Devices)
                                                                            .ThenInclude(p => p.Interfaces_Can)
                                                                            .ThenInclude(p => p.Interface_CanDevices)
                                                                     .Include(p => p.DeviceGroups)
                                                                        .ThenInclude(p => p.Devices)
                                                                            .ThenInclude(p => p.Interfaces_Ethernet)
                                                                     .Include(p => p.DeviceGroups)
                                                                        .ThenInclude(p => p.Devices)
                                                                            .ThenInclude(p => p.Interfaces_Serial)
                                                                    .Include(p => p.Location)
                                                                        .ThenInclude(p => p.Address)
                                                                    .ToList();

            if (_dbMain_Projects != null && _dbMachine_Machine != null)
            {
                if (_dbMain_Projects.Count() == 1 && _dbMachine_Machine.Count() == 1)
                {
                    MessageBoxResult result = MessageBox.Show($"Should the data for this device and the project \"{_dbMain_Projects[0].Name}\" from the organization \"{_dbMain_Projects[0].Organization.Name}\" be loaded from database?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result == MessageBoxResult.Yes)
                    {
                        Log.Debug("Entities loaded from database ...");

                        Globals.Machine.ProjectIdInUse = _dbMain_Projects[0].Id;
                        Globals.Machine.OrganizationIdInUse = _dbMain_Projects[0].Organization.Id;
                        //Globals.Machine.DirectoryIdInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                        //Globals.Machine.UserInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                        //Globals.Machine.SoftwareInUse = _dbMain_Projects[0].ExtSoftware[0].SoftwareId;
                    }
                    else
                    {
                        Log.Error("User canceled loading form database ...");

                        _closeApplication = true;
                    }
                }
                else
                {
                    Log.Error($"No project/machine or too much projects/machines are found in database \"{_dbMain_Projects.Count()}\" ...");

                    //Globals.Machine.ProjectInUse = _dbMain_Projects[0].ProjectId;
                    //Globals.Machine.OrganizationInUse = _dbMain_Projects[0].Organization.OrganizationId;
                    //Globals.Machine.DirectoryIdInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                    //Globals.Machine.UserInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                    //Globals.Machine.SoftwareInUse = _dbMain_Projects[0].ExtSoftware[0].SoftwareId;
                }
            }
            else
            {
                Log.Error("No project or machine found in database NULL ...");

                MessageBoxResult result = MessageBox.Show("No project or machine found in database!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                _closeApplication = true;
            }
        }

        private void InitializeVariables()
        {
            #region Initialize global devices ...
            Log.Debug("Initialize global devices ...");

            Log.Debug("Initialize global devices (Robot - Doosan) ...");

            if (Globals.Machine == null)
            {
                Globals.Machine = new Globals_Machine()
                {
                    Robot = new Globals_Machine.Globals_Machine_Robot()
                    {
                        Doosan = null
                    }
                };
            }
            #endregion

            #region Initialize class and interfaces
            Log.Debug("Initialize classes and interfaces ...");
            int devicesCount = 0;
            int interfaceCount = 0;

            List<DbMachine_Device> devicesList = new List<DbMachine_Device>();

            List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices).ToList();

            #region Robot - Doosan ...
            Log.Debug("Initialize class and devices (Robot - Doosan) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.Doosan).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.Robot = new Globals_Machine.Globals_Machine_Robot();
                Globals.Machine.Robot.Doosan = new Doosan_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");


            Log.Debug("Link variables to get shorter variable names (Robot - Doosan) ...");
            if (Globals.Machine.Robot != null)
            {
                if (Globals.Machine.Robot.Doosan != null)
                {
                    _doosan = Globals.Machine.Robot.Doosan;
                }
            }
            #endregion
        }

        //private void RobotInitializeAndConnect()
        //{
        //    Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

        //    if (_doosan.Controllers != null)
        //    {
        //        List<Device> devices = Globals.Context.Devices.Where(p => p.DeviceManufacturer == DeviceManufacturers.Doosan && p.DeviceType == DeviceTypes.Robot)
        //                                                                        .Include(p => p.Interfaces_Ethernet)
        //                                                                        .ToList();

        //        foreach (Device device in devices)
        //        {
        //            try
        //            {
        //                List<Doosan_Controller> controller = new List<Doosan_Controller>();

        //                if (device.InitialzeAtSplashscreen)
        //                {
        //                    Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
        //                    Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
        //                    _doosan.Controllers.Add(new Doosan_Controller());

        //                    // Link Hardware with DbContext
        //                    _doosan.Controllers.Last().IdDb = device.Id;
        //                }

        //                controller = _doosan.Controllers.Where(p => p.IdDb == device.Id).ToList();

        //                if (device.ConnectAtSplashscreen && controller.Count == 1)
        //                {
        //                    Log.Debug($"Define C# callback function´s for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
        //                    //RCRobotDoosanControl.Doosan.MyDelegate myDelegate = Globals.MyCallback;

        //                    //_Doosan.ControlDeviceConfigs[i].Control.SetupCallbackk(myDelegate);

        //                    //// Define C# callback functions
        //                    //RCRobotDoosanControl.Doosan.ProgressDelegate progressDelegate = Globals.UpdateProgress;
        //                    //RCRobotDoosanControl.Doosan.StatusDelegate statusDelegate = Globals.UpdateStatus;

        //                    // Pass the delegates to the C++/CLI DLL
        //                    //_Doosan.ControlDeviceConfigs[i].Control.SetupCallback(progressDelegate, statusDelegate);

        //                    //_Doosan.ControlDeviceConfigs[i].Control._robterId = i;

        //                    //_Doosan.ControlDeviceConfigs[i].Control.ManagedTOnTpInitializingCompletedCBHandler1 += Globals.OnTpInitializingCompleted1;

        //                    //_Doosan.ControlDeviceConfigs[i].Control.ManagedTOnTpInitializingCompletedCBHandler2 += Globals.OnTpInitializingCompleted2;

        //                    ////Register the callback
        //                    //controller[0].ManagedTOnHommingCompletedCBHandler += Events.OnHommingCompleted;
        //                    //////_robot.ManagedTOnMonitoringDataCBHandler += OnMonitoringDataCB1;
        //                    //////_robot.ManagedTOnMonitoringDataExCBHandler += OnMonitoringDataExCB1;
        //                    //////_robot.ManagedTOnMonitoringCtrlIOCBHandler += OnMonitoringCtrlIOCB1;
        //                    //////_robot.ManagedTOnMonitoringCtrlIOExCBHandler += OnMonitoringCtrlIOExCB1;
        //                    //////_robot.ManagedTOnMonitoringStateCBHandler += OnMonitoringStateCB1;
        //                    //////_robot.ManagedTOnMonitoringAccessControlCBHandler += OnMonitoingAccessControlCB1;
        //                    //controller[0].ManagedTOnTpInitializingCompletedCBHandler += Events.OnTpInitializingCompleted;
        //                    //////_robot.ManagedTOnLogAlarmCBHandler += OnLogAlarm1;
        //                    //////_robot.ManagedTOnProgramStoppedCBHandler += OnProgramStopped1;
        //                    //controller[0].ManagedTOnDisconnectedCBHandler += Events.OnDisconnected;
        //                    controller[0].RegisterEvents();
        //                    Thread.Sleep(250);

        //                    Log.Debug($"Open connection for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
        //                    controller[0].OpenConnection(device.Interfaces_Ethernet.IpAddress, device.Interfaces_Ethernet.Port);
        //                    Log.Information($"Connect to Robot: {device.Interfaces_Ethernet.IpAddress}:{device.Interfaces_Ethernet.Port}");
        //                    Thread.Sleep(250);

        //                    Log.Debug($"Get information of robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");

        //                    // Change monitoring data version
        //                    SystemVersion systemVersion = controller[0].GetSystemVersion();
        //                    Log.Information("System Version: " + systemVersion._szController);
        //                    controller[0].SetupMonitoringVersion(1);
        //                    controller[0].SetRobotControl(RobotControl.CONTROL_SERVO_ON);

        //                    Log.Information("Library Version: " + controller[0].GetLibraryVersion());
        //                    Thread.Sleep(250);

        //                    // Wait for robot state change
        //                    //while ((controller[0].GetRobotState() != RobotState.STATE_STANDBY) || !controller[0].HasControlAuthority)
        //                    //{
        //                    //    Thread.Sleep(250);
        //                    //}

        //                    // Manual mode setting
        //                    controller[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
        //                    controller[0].SetRobotSystem(RobotSystem.ROBOT_SYSTEM_REAL);

        //                    Thread.Sleep(250);


        //                    //_Doosan.ControlDeviceConfigs[i].SetAxisDirection(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f);

        //                    //_robot.SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_10, true);

        //                }
        //                else
        //                {
        //                    // ToDo: ...
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
        //                break;
        //            }
        //        }
        //    }
        //}

        private void RobotInitializeAndConnect()
        {
            Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            if (_doosan.Controllers != null)
            {
                List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                                                        .Where(p => p.DeviceManufacturer == DeviceManufacturer.Doosan && p.DeviceType == DeviceType.M0609)
                                                                                        .ToList()
                                                                                        .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
                                                                                        .ToList();

                foreach (DbMachine_Device device in devicesAll)
                {
                    try
                    {
                        List<Doosan_Controller> controller = new List<Doosan_Controller>();

                        if (device.InitializeAtSplashscreen)
                        {
                            //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            DbMachine_Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
                            _doosan.Controllers.Add(new Doosan_Controller());

                            // Link Hardware with DbContext
                            _doosan.Controllers.Last().IdDb = device.Id;
                        }

                        controller = _doosan.Controllers.Where(p => p.IdDb == device.Id).ToList();

                        if (device.ConnectAtSplashscreen && controller.Count == 1)
                        {
                            //Log.Debug($"Define C# callback function´s for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
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

                            //Log.Debug($"Open connection for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            controller[0].OpenConnection(device.Interfaces_Ethernet.IpAddress, device.Interfaces_Ethernet.Port);
                            Log.Information($"Connect to Robot: {device.Interfaces_Ethernet.IpAddress}:{device.Interfaces_Ethernet.Port}");
                            Thread.Sleep(250);

                            //Log.Debug($"Get information of robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");

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
                        //Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
