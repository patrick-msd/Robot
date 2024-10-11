using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Lib.Vision.Intel;
using PSGM.Model.DbBackend;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using Serilog;
using Serilog.Debugging;
using Serilog.Sinks.Grafana.Loki;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace PSGM.Vision.Intel.Sample
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

        // Threads and workers
        private Thread _thrClock;
        private CancellationTokenSource _ctsClock;

        private BackgroundWorker _bgwSplashScreen;

        // Global Hardware
        private Intel_Container? _intel;

        // Global database
        private List<DbBackend_Backend> _backend;
        DbMachine_Machine? _dbMachine_Machine;
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

            Log.Information("Start splash screen ...");

            _closeApplication = false;

            // Calculate percentage and set progress bar
            Log.Information("Initialize and calculate percentage and set progress bar ...");
            _statePercentageValue = 0;
            _statePercentageCount = 28;

            pgbLoading.Minimum = _statePercentageValue;
            pgbLoading.Maximum = _statePercentageCount;

            txbDateTime.Text = DateTime.Now.ToString("dd.MM.yyyy - HH:mm:ss");

            // Thread clock
            Log.Information("Initialize Thread clock ...");
            _ctsClock = new CancellationTokenSource();
            _thrClock = new Thread(ThreadFuction_Clock);
            _thrClock.Start();

            // Worker splash screen
            Log.Information("Initialize Worker splash screen ...");
            _bgwSplashScreen = new BackgroundWorker();
            _bgwSplashScreen.WorkerReportsProgress = true;
            _bgwSplashScreen.DoWork += WorkerSplashScreen_Function;
            _bgwSplashScreen.ProgressChanged += WorkerSplashScreen_ProgressChanged;
            _bgwSplashScreen.RunWorkerAsync();
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
        void WorkerSplashScreen_Function(object sender, DoWorkEventArgs e)
        {
            // Step #1
            UpdateUI("Application: Initialize global variables ...");
            InitializeGlobalVariables();
            Thread.Sleep(125);

            // Step #2
            UpdateUI("Application: Initialize local variables ...");
            InitializeLocalVariables();
            Thread.Sleep(125);

            // Step #3
            UpdateUI("Application: Read application configuration file ...");
            ReadApplicationConfigurationFile();
            Thread.Sleep(125);

            // Step #4
            UpdateUI("Application: User login ...");
            UserLogin();
            Thread.Sleep(125);

            // Step #5
            UpdateUI("Application: Get machine id and project id...");
            GetMachineIdAndProjectId();
            Thread.Sleep(125);

            // Step #6
            UpdateUI("Application: Get backend configuration ...");
            GetBackendConfiguration();
            Thread.Sleep(125);

            // Step #7
            UpdateUI("Application: Initialize logging ...");
            InitializeLogging();
            Thread.Sleep(125);

            // Step #8
            UpdateUI("Application: Initialize SendGrid ...");
            InitializeSendGrid();
            Thread.Sleep(125);

            // Step #9
            UpdateUI("Application: Connect to all backend databases ...");
            ConnectToAllBackendDatabases();
            Thread.Sleep(125);

            // Step #10
            UpdateUI("Application: Connect to all backend servers ...");
            ConnectToAllBackendServers();
            Thread.Sleep(125);

            // Step #11
            UpdateUI("Application: Connect to all backend storages ...");
            ConnectToAllBackendStorages();
            Thread.Sleep(125);

            // Step #12
            UpdateUI("Application: Initialize machine and device variables ...");
            InitializeMachineAndDeviceVariables();
            Thread.Sleep(125);

            // Step #13
            UpdateUI("Application: Load project workflow ...");
            LoadProjectWorkflow();
            Thread.Sleep(125);

            // Step #20
            UpdateUI("Camera: Initialize SDKs ...");
            CameraInitializeSdk();
            Thread.Sleep(125);

            // Step #21
            UpdateUI("Camera: Discover cameras ...");
            CameraDiscovery();
            Thread.Sleep(125);

            // Step #22
            UpdateUI("Camera: Initialize and connect to cameras (Ethernet) ...");
            CameraInitializeAndConnect();
            Thread.Sleep(125);

            // Step #23
            UpdateUI("Camera: Start acquisition of the cameras ...");
            CameraStartAcquisition();
            Thread.Sleep(125);







            // Step #27
            UpdateUI("Camera: Set default or startup values for devices ...");
            SetDefaultOrStartupValuesForCameras();
            Thread.Sleep(125);

            // Step #28
            UpdateUI("Finish splash screen and open main application ...");
            Thread.Sleep(125);
        }

        void WorkerSplashScreen_ProgressChanged(object sender, ProgressChangedEventArgs e)
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
            _bgwSplashScreen.ReportProgress(_statePercentageValue);
        }

        private void InitializeGlobalVariables()
        {
            // Allready initialized in App.xaml.cs
            //Globals.ApplicationId = Guid.Empty;
            //Globals.ApplicationPath = string.Empty;
            //Globals.ApplicationTitle = string.Empty;
            //Globals.ApplicationVersion = null;

            Globals.LokiLabels = new List<LokiLabel>();
            Globals.LokiUri = string.Empty;
            Globals.LokiOutputTemplate = string.Empty;

            Globals.ComputerId = ComputerInfo.GetComputerUUID();

            Globals.MachineId = Guid.Empty;

            Globals.OrganizationId = Guid.Empty;
            Globals.UserId = Guid.Empty;

            Globals.ProjectId = Guid.Empty;
            Globals.DirectoryId = Guid.Empty;
            Globals.UnitId = Guid.Empty;

            Globals.ConfigFile = new ConfigFile();

            Globals.DbBackend_Context = new DbBackend_Context();
            Globals.DbMachine_Context = new DbMachine_Context();
            Globals.DbMain_Context = new DbMain_Context();

            Globals.Machine = new Globals_Machine()
            {
                Vision = null
            };
        }

        private void InitializeLocalVariables()
        {
            _backend = new List<DbBackend_Backend>();

            _intel = new Intel_Container();

            _dbMachine_Machine = new DbMachine_Machine();
        }

        private void ReadApplicationConfigurationFile()
        {
            if (Globals.ConfigFile.ConfigFileExists(Directory.GetCurrentDirectory() + "\\ConfigFile.json"))
            {
                Globals.ConfigFile.ReadFromFile(Directory.GetCurrentDirectory() + "\\ConfigFile.json");
            }
        }

        private void UserLogin()
        {
            // ToDO: ....
            //= Globals.UserId;
            ;
        }

        private void GetMachineIdAndProjectId()
        {
            // ToDo: Get Machine Id form Backend API ...
            // Currently hard coded EF Core DB backend for Machin ID request ...

            Globals.DbMachine_Context.DatabaseType = DatabaseType.PostgreSQL;
            Globals.DbMachine_Context.DatabaseConnectionString = "Host=db-machine-50c221c0-715a-4b62-b85e-fbff5ea22697.branch031.psgm.at:50001;Database=db-machine-50c221c0-715a-4b62-b85e-fbff5ea22697;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V";

            Globals.DbMachine_Context.DatabaseSessionParameter_UserId = Globals.UserId;
            Globals.DbMachine_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbMachine_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;

            List<DbMachine_Computer> machine = Globals.DbMachine_Context.Computers.Where(p => p.ComputerUUID == Globals.ComputerId)
                                                                                    .Include(p => p.Machine)
                                                                                        .ThenInclude(p => p.ProjectLinks)
                                                                                            .ThenInclude(p => p.Project)
                                                                                    .Include(p => p.Machine)
                                                                                        .ThenInclude(p => p.DeviceGroups)
                                                                                            .ThenInclude(p => p.Devices)
                                                                                                .ThenInclude(p => p.Interfaces_Serial)
                                                                                    .Include(p => p.Machine)
                                                                                        .ThenInclude(p => p.DeviceGroups)
                                                                                            .ThenInclude(p => p.Devices)
                                                                                                .ThenInclude(p => p.Interfaces_Can)
                                                                                                    .ThenInclude(p => p.Interface_CanDevices)
                                                                                    .Include(p => p.Machine)
                                                                                        .ThenInclude(p => p.DeviceGroups)
                                                                                            .ThenInclude(p => p.Devices)
                                                                                                .ThenInclude(p => p.Interfaces_Ethernet)
                                                                                    .ToList();

            if (machine is null)
            {
                Log.Error("No machine found in database for this computer ...");

                MessageBoxResult result = MessageBox.Show("No machine found in database for this computer!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                _closeApplication = true;

                return;
            }
            else if (machine.Count <= 0 || machine.Count > 1)
            {
                Log.Error("More than one or lass than zero machines found in database ...");

                MessageBoxResult result = MessageBox.Show("More than one machine found in database!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                _closeApplication = true;

                return;
            }
            else
            {
                Globals.MachineId = machine[0].Machine.Id;
                _dbMachine_Machine = machine[0].Machine;

                if (machine[0].Machine.ProjectLinks is null)
                {
                    Log.Error("No project found in database for this machine ...");

                    MessageBoxResult result = MessageBox.Show("No project found in database for this machine!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    _closeApplication = true;

                    return;
                }
                else if (machine[0].Machine.ProjectLinks.Count <= 0 || machine[0].Machine.ProjectLinks.Count > 1)
                {
                    Log.Error("More than one or lass than zero projects found in database ...");

                    MessageBoxResult result = MessageBox.Show("More than one or lass than zero projects found in database!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                    _closeApplication = true;

                    //Globals.ProjectId = ...

                    return;
                }
                else
                {
                    Globals.ProjectId = machine[0].Machine.ProjectLinks.ToList()[0].Project.Id;
                }
            }
        }

        private void GetBackendConfiguration()
        {
            Globals.DbBackend_Context.DatabaseType = Globals.ConfigFile.DatabaseType;
            Globals.DbBackend_Context.DatabaseConnectionString = Globals.ConfigFile.DatabaseConnectionString;

            Globals.DbBackend_Context.DatabaseSessionParameter_UserId = Globals.UserId;
            Globals.DbBackend_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbBackend_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;

            Globals.DbBackend_Context.Database.OpenConnection();

            _backend = Globals.DbBackend_Context.Backends.Where(p => p.Project.ProjectId_Ext == Globals.ProjectId)
                                                            .Include(p => p.DatabaseClusters)
                                                                .ThenInclude(p => p.DatabaseServers)
                                                            .Include(p => p.StorageClusters)
                                                                .ThenInclude(p => p.StorageServers)
                                                            .Include(p => p.ServerClusters)
                                                                .ThenInclude(p => p.ServerServers)
                                                            .ToList();
        }

        private void InitializeLogging()
        {
            // ToDo: Check if Loki is available, right server only one cluster, ...
            List<DbBackend_Backend> loki = _backend.Where(p => p.ServerClusters.Where(p => p.ServerType == ServerType.Loki).Count() > 0).ToList();
            List<DbBackend_Server_Cluster> lokiClusters = loki[0].ServerClusters.Where(p => p.ServerType == ServerType.Loki).ToList();
            DbBackend_Server_Cluster lokiCluster = lokiClusters[0];

            Globals.LokiLabels = new List<LokiLabel>()
            {
                new LokiLabel()
                {
                    Key = "Name",
                    Value = Globals.ApplicationTitle
                },
                new LokiLabel()
                {
                    Key = "Version",
                    Value = Globals.ApplicationVersion.ToString()
                },
                new LokiLabel()
                {
                    Key = "GUID",
                    Value =  Globals.ApplicationId.ToString()
                },
                new LokiLabel()
                {
                    Key = "Computer",
                    Value =  Globals.ComputerId.ToString()
                }
            };

            Globals.LokiUri = lokiCluster.GetServerConnection(true);
            Globals.LokiOutputTemplate = lokiCluster.Configuration;

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

            Log.Information($"Application \"{Globals.ApplicationTitle} V{Globals.ApplicationVersion.ToString()}\" start (Spash Screen) ...");
            #endregion
        }

        private void InitializeSendGrid()
        {
        }

        private void ConnectToAllBackendDatabases()
        {
            // ToDo: Check on all database connections if there are more than one cluster and if the cluster is available

            #region Machine database
            Log.Information($"Connect to machine database ...");

            List<DbBackend_Backend> backendsMachine = _backend.Where(p => p.BackendType == BackendType.Machine).ToList();
            if (backendsMachine.Count > 0)
            {
                DbBackend_Backend backendMachine = backendsMachine[0];

                Globals.DbMachine_Context.DatabaseType = backendMachine.DatabaseClusters.ToList()[0].DatabaseType;
                Globals.DbMachine_Context.DatabaseConnectionString = backendMachine.DatabaseClusters.ToList()[0].GetDatabaseConnection(true);

                Globals.DbMachine_Context.DatabaseSessionParameter_UserId = Globals.UserId;
                Globals.DbMachine_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
                Globals.DbMachine_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;
            }
            else
            {
                Log.Error("No machine database found in backend ...");

                MessageBoxResult result = MessageBox.Show("No machine database found in backend!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                _closeApplication = true;
                return;
            }
            #endregion

            #region Main database
            Log.Information($"Connect to main database ...");

            List<DbBackend_Backend> backendsMain = _backend.Where(p => p.BackendType == BackendType.Main).ToList();
            if (backendsMain.Count > 0)
            {
                DbBackend_Backend backendMain = backendsMain[0];
                Globals.DbMain_Context.DatabaseType = backendMain.DatabaseClusters.ToList()[0].DatabaseType;
                Globals.DbMain_Context.DatabaseConnectionString = backendMain.DatabaseClusters.ToList()[0].GetDatabaseConnection(true);

                Globals.DbMain_Context.DatabaseSessionParameter_UserId = Globals.UserId;
                Globals.DbMain_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
                Globals.DbMain_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;
            }
            else
            {
                Log.Error("No main database found in backend ...");

                MessageBoxResult result = MessageBox.Show("No main database found in backend!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                _closeApplication = true;
                return;
            }
            #endregion
        }

        private void ConnectToAllBackendServers()
        {
        }

        private void ConnectToAllBackendStorages()
        {
        }

        private void InitializeMachineAndDeviceVariables()
        {
            #region Initialize devices ...
            Log.Debug("Initialize devices ...");

            Log.Debug("Initialize devices (Vision - Intel) ...");

            if (Globals.Machine == null)
            {
                Globals.Machine = new Globals_Machine()
                {
                    Vision = new Globals_Machine.Globals_Machine_Vision()
                    {
                        Intel = null
                    }
                };
            }
            #endregion

            #region Initialize class and interfaces
            Log.Debug("Initialize classes and interfaces ...");
            int devicesCount = 0;
            int interfaceCount = 0;

            List<DbMachine_Device> devicesList = new List<DbMachine_Device>();

            List<DbMachine_Device> devicesAll = _dbMachine_Machine.DeviceGroups.SelectMany(p => p.Devices).ToList();

            #region Vision - Intel ...
            Log.Debug("Initialize class and devices (Vision - SVSVistek) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.Intel).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.Vision = new Globals_Machine.Globals_Machine_Vision();
                Globals.Machine.Vision.Intel = new Intel_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            Log.Debug("Link variables to get shorter variable names (Vision - Intel) ...");
            if (Globals.Machine.Vision != null)
            {
                if (Globals.Machine.Vision.Intel != null)
                {
                    _intel = Globals.Machine.Vision.Intel;
                }
            }
            #endregion
        }

        private void LoadProjectWorkflow()
        {
        }

        private void CameraInitializeSdk()
        {
            Log.Debug("Initialize Intel (Vision) SDK ...");

            //if (_svsVistek != null)
            //{
            //    _svsVistek.InitSDK();
            //}
        }

        private void CameraDiscovery()
        {
            Log.Debug("Discover SVS-Vistek cameras ...");
            //_svsVistek.DeviceDiscovery();

            //if (_svsVistek.DeviceInfoList != null)
            //{
            //    foreach (SVSVistek_DeviceInfo cam in _svsVistek.DeviceInfoList)
            //    {
            //        Log.Debug("Camera Name:" + cam.DeviceInfo.displayName + " Model:" + cam.DeviceInfo.model + " Serialnumber:" + cam.DeviceInfo.serialNumber + " found.");
            //    }
            //}
            //else
            //{
            //    Log.Error("No camera found!");
            //}
        }

        private void CameraInitializeAndConnect()
        {
            Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            //if (_svsVistek.Cameras != null)
            //{
            //    List<DbMachine_Device> devicesAll = _dbMachine_Machine.DeviceGroups.SelectMany(p => p.Devices)
            //                                                            .Where(p => p.DeviceManufacturer == DeviceManufacturer.SVSVistek && p.DeviceType == DeviceType.HR455CXGE)
            //                                                            .ToList()
            //                                                            .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
            //                                                            .ToList();

            //    List<SVSVistek_DeviceInfo> deviceInfo = null;

            //    foreach (DbMachine_Device device in devicesAll)
            //    {
            //        try
            //        {
            //            deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.SerialNumber).ToList();

            //            if (deviceInfo.Count == 1)
            //            {
            //                List<SVSVistek_Camera> cam = new List<SVSVistek_Camera>();

            //                if (device.InitializeAtSplashScreen)
            //                {
            //                    //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                    DbMachine_Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
            //                    _svsVistek.Cameras.Add(new SVSVistek_Camera(deviceInfo[0]));

            //                    // Link Hardware with DbContext
            //                    _svsVistek.Cameras.Last().IdDb = device.Id;
            //                }

            //                cam = _svsVistek.Cameras.Where(p => p.IdDb == device.Id).ToList();

            //                if (device.ConnectAtSplashScreen && cam.Count == 1)
            //                {
            //                    //Log.Debug($"Open connection for camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                    cam[0].OpenConnection();

            //                    Thread.Sleep(125);

            //                    //Log.Debug($"Initialize camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                    SVSVistek_Camera_Config config = SVSVistek_Camera_Config.ToJson(device.ConfigurationString);

            //                    // ToDO: cam.DeviceReset();
            //                    //Thread.Sleep(5000);

            //                    // ToDo: All settings from DB 
            //                    cam[0].SetFan(config.DevieControl.FanControl);

            //                    cam[0].SetSensorPixelSize(config.ImageFormatControl.SensorPixelSize);
            //                    cam[0].SetPixelFormat(config.ImageFormatControl.PixelFormat);
            //                    cam[0].SetOffsetX(config.ImageFormatControl.XOffset);
            //                    cam[0].SetOffsetY(config.ImageFormatControl.YOffset);
            //                    cam[0].SetWidth(config.ImageFormatControl.Width);
            //                    cam[0].SetHeight(config.ImageFormatControl.Height);

            //                    cam[0].SetExposureTime(config.AcquisitionControl.ExposureTime);

            //                    cam[0].SetGain(config.AnalogControl.Gain);
            //                    cam[0].SetWhiteBalance(config.AnalogControl.BalanceWhiteRatioRed, config.AnalogControl.BalanceWhiteRatioGreen, config.AnalogControl.BalanceWhiteRatioBlue);
            //                }
            //                else
            //                {
            //                    // ToDo: ...
            //                }
            //            }
            //            else
            //            {
            //                // ToDo: ...
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            //Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //            break;
            //        }
            //    }
            //}
        }
        private void CameraStartAcquisition()
        {
            Log.Debug("Start acquisition  for the cameras ...");

            //if (_svsVistek.Cameras != null)
            //{
            //    List<DbMachine_Device> devicesAll = _dbMachine_Machine.DeviceGroups.SelectMany(p => p.Devices)
            //                                                                        .Where(p => p.DeviceManufacturer == DeviceManufacturer.SVSVistek && p.DeviceType == DeviceType.HR455CXGE)
            //                                                                        .ToList()
            //                                                                        .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
            //                                                                        .ToList();

            //    List<SVSVistek_DeviceInfo> deviceInfo = null;

            //    foreach (DbMachine_Device device in devicesAll)
            //    {
            //        try
            //        {
            //            deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.SerialNumber).ToList();

            //            if (deviceInfo.Count == 1)
            //            {
            //                if (device.AutoStartAtSplashScreen)
            //                {
            //                    List<SVSVistek_Camera> cam = _svsVistek.Cameras.Where(p => p.DeviceInfo.DeviceInfo.serialNumber == device.SerialNumber).ToList();

            //                    if (deviceInfo.Count == 1)
            //                    {
            //                        //Log.Debug($"Start camera acquisition {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                        cam[0].StartAcquisionContinuously();

            //                        Thread.Sleep(1250);
            //                    }
            //                    else
            //                    {
            //                        // ToDo: ...
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                // ToDo: ...
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            //Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //            break;
            //        }
            //    }
            //}
        }

        private void SetDefaultOrStartupValuesForCameras()
        {
            // ToDo: ...
        }
        #endregion
    }
}
