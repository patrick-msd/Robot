using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbBackend;
using PSGM.Model.DbJob;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using PSGM.Model.DbSoftware;
using PSGM.Model.DbStorage;
using PSGM.Model.DbUser;
using RC.Lib.Control.Doosan;
using RC.Lib.Control.RobotElectronics;
using RC.Lib.Motion;
using RC.Lib.PowerSupply;
using RC.Lib.Vision.SVSVistek;
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

namespace RC.Scan_SingleSolution
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

        private BackgroundWorker _bgwSplashScreen;

        private List<DbBackend_Backend> _backend;

        // Global Hardware
        private RobotElectronics_Container? _robotElectronics;
        private List<Nanotec_Container>? _nanotec;
        private Nextys_Container? _nextys;
        private Doosan_Container? _doosan;
        //private Intel_Container? _intel;
        private SVSVistek_Container? _svsVistek;

        // Global database
        DbMachine_Machine? _dbMachine_Machine;
        List<DbMain_Project>? _dbMain_Projects;
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
            _statePercentageCount = 14;

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
            UpdateUI("Initialize global variables ...");
            InitializeGlobalVariables();
            Thread.Sleep(125);

            // Step #2
            UpdateUI("Initialize local variables ...");
            InitializeLocalVariables();
            Thread.Sleep(125);

            // Step #3
            UpdateUI("Read application configuration file ...");
            ReadApplicationConfigurationFile();
            Thread.Sleep(125);

            // Step #4
            UpdateUI("User login ...");
            UserLogin();
            Thread.Sleep(125);

            // Step #5
            UpdateUI("Get machine ID and Project ID...");
            GetMachineIdAndProjectId();
            Thread.Sleep(125);

            // Step #6
            UpdateUI("Get backend configuration ...");
            GetBackendConfiguration();
            Thread.Sleep(125);

            // Step #7
            UpdateUI("Initialize logging ...");
            InitializeLogging();
            Thread.Sleep(125);

            // Step #8
            UpdateUI("Connect to all backend databases ...");
            ConnectToAllBackendDatabases();
            Thread.Sleep(125);

            // Step #9
            UpdateUI("Connect to all backend servers ...");
            ConnectToAllBackendServers();
            Thread.Sleep(125);

            // Step #10
            UpdateUI("Connect to all backend storages ...");
            ConnectToAllBackendStorages();
            Thread.Sleep(125);









            #region Get Project Id ...
            Log.Information("Get Project Id ...");

            Globals.ProjectId = new Guid("79A0FD7A-5D68-4095-A309-F4E92426E657");
            #endregion











            // Step #2
            UpdateUI("Initialize variables ...");
            InitializeVariables();
            Thread.Sleep(125);


            // Step #4
            UpdateUI("Control: Initialize and connect devices (USB) ...");
            ControlInitializeAndConnect();
            Thread.Sleep(125);

            // Step #5
            UpdateUI("Motion: Initialize and connect bus devices (USB-to-CAN, USB-to-Serial, PICe, ...) ...");
            MotionBusDeviceInitializeAndConnect();
            Thread.Sleep(125);

            // Step #6
            UpdateUI("Motion: Discover devices on the bus (CAN, ...) ...");
            MotionDevicesOnTheBusDiscovery();
            Thread.Sleep(125);

            // Step #7
            UpdateUI("Motion: Connect to the devices on the bus ...");
            MotionDevicesOnTheBusInitializeAndConnect();
            Thread.Sleep(125);

            // Step #8
            UpdateUI("Power Supply: Initialize and connect devices (COM) ...");
            PowerSupplyInitializeAndConnect();
            Thread.Sleep(125);

            // Step #9
            UpdateUI("Robot: Initialize and connect devices (Ethernet) ...");
            RobotInitializeAndConnect();
            Thread.Sleep(125);

            // Step #10
            UpdateUI("Camera: Initialize SDKs ...");
            CameraInitializeSdk();
            Thread.Sleep(125);

            // Step #11
            UpdateUI("Camera: Discover cameras ...");
            CameraDiscovery();
            Thread.Sleep(125);

            // Step #12
            UpdateUI("Camera: Initialize and connect to cameras (Ethernet) ...");
            CameraInitializeAndConnect();
            Thread.Sleep(125);

            // Step #13
            UpdateUI("Camera: Start acquision of the cameras ...");
            CameraStartAcquision();
            Thread.Sleep(125);

            // Step #14
            UpdateUI("Finish splashcreen and open main application ...");
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
            Globals.ComputerId = PSGM.Helper.ComputerInfo.GetComputerUUID();

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

            Globals.ConfigFile = new ConfigFile();

            Globals.DbBackend_Context = new DbBackend_Context();
            Globals.DbJob_Context = new DbJob_Context();
            Globals.DbMachine_Context = new DbMachine_Context();
            Globals.DbMain_Context = new DbMain_Context();
            Globals.DbSoftware_Context = new DbSoftware_Context();
            Globals.DbStorageData_Context = new DbStorage_Context();
            Globals.DbStorageDataRaw_Context = new DbStorage_Context();
            Globals.DbUser_Context = new DbUser_Context();
        }

        private void InitializeLocalVariables()
        {
            _backend = new List<DbBackend_Backend>();

            _robotElectronics = new RobotElectronics_Container();
            _nanotec = new List<Nanotec_Container>();
            _nextys = new Nextys_Container();
            _doosan = new Doosan_Container();
            _svsVistek = new SVSVistek_Container();

            _dbMachine_Machine = new DbMachine_Machine();
            _dbMain_Projects = new List<DbMain_Project>();
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

            Log.Information($"Application \"{Globals.ApplicationTitle} V{Globals.ApplicationVersion.ToString()}\" start...");
            #endregion
        }

        private void ConnectToAllBackendDatabases()
        {
            // ToDo: Check on all database connections if there are more than one cluster and if the cluster is available

            #region Machine database
            Log.Information($"Connect to machine database ...");

            List<DbBackend_Backend> backendMachine = _backend.Where(p => p.BackendType == BackendType.Machine).ToList();

            Globals.DbMachine_Context.DatabaseType = backendMachine[0].DatabaseClusters.ToList()[0].DatabaseType;
            Globals.DbMachine_Context.DatabaseConnectionString = backendMachine[0].DatabaseClusters.ToList()[0].GetDatabaseConnection(true);

            Globals.DbMachine_Context.DatabaseSessionParameter_UserId = Globals.UserId;
            Globals.DbMachine_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbMachine_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;
            #endregion

            #region Main database
            Log.Information($"Connect to main database ...");

            List<DbBackend_Backend> backendMain = _backend.Where(p => p.BackendType == BackendType.Main).ToList();

            Globals.DbMain_Context.DatabaseType = backendMain[0].DatabaseClusters.ToList()[0].DatabaseType;
            Globals.DbMain_Context.DatabaseConnectionString = backendMain[0].DatabaseClusters.ToList()[0].GetDatabaseConnection(true);

            Globals.DbMain_Context.DatabaseSessionParameter_UserId = Globals.UserId;
            Globals.DbMain_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbMain_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;
            #endregion

            #region Storage data database
            Log.Information($"Connect to storage data databases ...");

            List<DbBackend_Backend> backendStorageData = _backend.Where(p => p.BackendType == BackendType.Storage).ToList().Where(p => p.StorageClusters.Where(p => p.StorageClass == StorageClass.Data).Count() > 0).ToList();

            Globals.DbStorageData_Context.DatabaseType = backendStorageData[0].DatabaseClusters.ToList()[0].DatabaseType;
            Globals.DbStorageData_Context.DatabaseConnectionString = backendStorageData[0].DatabaseClusters.ToList()[0].GetDatabaseConnection(true);

            Globals.DbStorageData_Context.DatabaseSessionParameter_UserId = Globals.UserId;
            Globals.DbStorageData_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbStorageData_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;
            #endregion

            #region Storage data raw database
            Log.Information($"Connect to storage data databases ...");

            List<DbBackend_Backend> backendStorageDataRaw = _backend.Where(p => p.BackendType == BackendType.Storage).ToList().Where(p => p.StorageClusters.Where(p => p.StorageClass == StorageClass.DataRaw).Count() > 0).ToList();

            Globals.DbStorageData_Context.DatabaseType = backendStorageDataRaw[0].DatabaseClusters.ToList()[0].DatabaseType;
            Globals.DbStorageData_Context.DatabaseConnectionString = backendStorageDataRaw[0].DatabaseClusters.ToList()[0].GetDatabaseConnection(true);

            Globals.DbStorageData_Context.DatabaseSessionParameter_UserId = Globals.UserId;
            Globals.DbStorageData_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbStorageData_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;
            #endregion

            #region Transcription database
            Log.Information($"Connect to storage data databases ...");

            List<DbBackend_Backend> backendTranscription = _backend.Where(p => p.BackendType == BackendType.Transcription).ToList();

            Globals.DbStorageData_Context.DatabaseType = backendTranscription[0].DatabaseClusters.ToList()[0].DatabaseType;
            Globals.DbStorageData_Context.DatabaseConnectionString = backendTranscription[0].DatabaseClusters.ToList()[0].GetDatabaseConnection(true);

            Globals.DbStorageData_Context.DatabaseSessionParameter_UserId = Globals.UserId;
            Globals.DbStorageData_Context.DatabaseSessionParameter_ComputerId = Globals.ComputerId;
            Globals.DbStorageData_Context.DatabaseSessionParameter_ApplicationId = Globals.ApplicationId;
            #endregion
        }
        private void ConnectToAllBackendServers()
        {
            // ToDo: ...
        }

        private void ConnectToAllBackendStorages()
        {


            //Globals.Storage = new Globals_Storage();
            //Globals.Storage.S3 = new List<Globals_Storage_S3>();

            //foreach (var item in _dbMain_Projects[0].ProjectParameter.Storages)
            //{
            //    Globals.Storage.S3.Add(new Globals_Storage_S3()
            //    {
            //        Endpoint = item.StorageS3Endpoint,
            //        AccessKey = item.StorageS3AccessKey,
            //        SecretKey = item.StorageS3SecretKey,
            //        Secure = item.StorageS3Secure,
            //        Region = item.StorageS3Region,

            //        BucketName = item.StorageS3BucketName,
            //    });
            //}

            //// Initialize the client with access credentials.
            //foreach (var item in Globals.Storage.S3)
            //{
            //    item.InitilizeMinIoClient();
            //}





        }




        private void LoadDataFromDatabase()
        {
            List<DbMachine_Computer> computers = Globals.DbMachine_Context.Computers.Where(p => p.Id == Globals.ComputerId)
                                                                                    .Include(p => p.Machine)
                                                                                    .Include(p => p.Machine.DeviceGroups)
                                                                                        .ThenInclude(p => p.Devices)
                                                                                            .ThenInclude(p => p.Interfaces_Can)
                                                                                                .ThenInclude(p => p.Interface_CanDevices)
                                                                                    .Include(p => p.Machine.DeviceGroups)
                                                                                        .ThenInclude(p => p.Devices)
                                                                                                .ThenInclude(p => p.Interfaces_Ethernet)
                                                                                    .Include(p => p.Machine.DeviceGroups)
                                                                                        .ThenInclude(p => p.Devices)
                                                                                                .ThenInclude(p => p.Interfaces_Serial)
                                                                                    .Include(p => p.Machine.LocationLinks)
                                                                                        .ThenInclude(p => p.Location)
                                                                                            .ThenInclude(p => p.AddressLink)
                                                                                                .ThenInclude(p => p.Address)
                                                                                    //.Include(p => p.Machine.Project)
                                                                                    .ToList();

            if (computers.Count <= 0 || computers.Count > 1)
            {
                Log.Error("More than one computer found in database ...");

                MessageBoxResult result = MessageBox.Show("More than one computer found in database!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                _closeApplication = true;
            }
            else if (computers[0].Machine is not null)
            {
                Log.Error("No machine found in database for this computer ...");

                MessageBoxResult result = MessageBox.Show("No machine found in database for this computer!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                _closeApplication = true;
            }
            else
            {
                _dbMachine_Machine = computers[0].Machine;

                //_dbMain_Projects = Globals.DbMain_Context.Projects.Where(p => p.mac.Machines_ExtString.Contains(Globals.Machine.MachineId.ToString()))
                //                                                    .Include(p => p.ProjectParameter)
                //                                                        .ThenInclude(p => p.Storages)
                //                                                    .Include(p => p.Organization)
                //                                                    .Include(p => p.Contributors)
                //                                                    .ToList();


                //if (_dbMain_Projects != null && _dbMachine_Machine != null)
                //{
                //    if (_dbMain_Projects.Count() == 1 && _dbMachine_Machine.Count() == 1)
                //    {
                //        MessageBoxResult result = MessageBox.Show($"Should the data for this device and the project \"{_dbMain_Projects[0].Name}\" from the organization \"{_dbMain_Projects[0].Organization.Name}\" be loaded from database?", "Info", MessageBoxButton.YesNo, MessageBoxImage.Question);

                //        if (result == MessageBoxResult.Yes)
                //        {
                //            Log.Debug("Entities loaded from database ...");

                //            Globals.Machine.ProjectIdInUse = _dbMain_Projects[0].Id;
                //            Globals.Machine.OrganizationIdInUse = _dbMain_Projects[0].Organization.Id;
                //            //Globals.Machine.DirectoryIdInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                //            //Globals.Machine.UserInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                //            //Globals.Machine.SoftwareInUse = _dbMain_Projects[0].ExtSoftware[0].SoftwareId;
                //        }
                //        else
                //        {
                //            Log.Error("User canceled loading form database ...");

                //            _closeApplication = true;
                //        }
                //    }
                //    else
                //    {
                //        Log.Error($"No project/machine or too much projects/machines are found in database \"{_dbMain_Projects.Count()}\" ...");

                //        //Globals.Machine.ProjectInUse = _dbMain_Projects[0].ProjectId;
                //        //Globals.Machine.OrganizationInUse = _dbMain_Projects[0].Organization.OrganizationId;
                //        //Globals.Machine.DirectoryIdInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                //        //Globals.Machine.UserInUse = _dbMain_Projects[0].ExtUsers[0].UserId;
                //        //Globals.Machine.SoftwareInUse = _dbMain_Projects[0].ExtSoftware[0].SoftwareId;
                //    }
                //}
                //else
                //{
                //    Log.Error("No project or machine found in database NULL ...");

                //    MessageBoxResult result = MessageBox.Show("No project or machine found in database!\nClose Application!!!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);

                //    _closeApplication = true;
                //}
            }
        }


























        private void InitializeVariables()
        {
            //#region Initialize global devices ...
            //Log.Debug("Initialize global devices ...");

            //Log.Debug("Initialize global devices (Control - Robot Electronics) ...");
            //Log.Debug("Initialize global devices (Motion - Nanotec) ...");
            //Log.Debug("Initialize global devices (Power Supply - Nextys) ...");
            //Log.Debug("Initialize global devices (Robot - Doosan) ...");
            //Log.Debug("Initialize global devices (Vision - SvS-Vistek) ...");

            //if (Globals.Machine == null)
            //{
            //    Globals.Machine = new Globals_Machine()
            //    {
            //        Control = new Globals_Machine.Globals_Machine_Control()
            //        {
            //            RobotElectronics = null
            //        },

            //        Motion = new Globals_Machine.Globals_Machine_Motion()
            //        {
            //            Nanotec = null
            //        },

            //        PowerSupply = new Globals_Machine.Globals_Machine_PowerSupply()
            //        {
            //            Nextys = null
            //        },

            //        Robot = new Globals_Machine.Globals_Machine_Robot()
            //        {
            //            Doosan = null
            //        },

            //        Vision = new Globals_Machine.Globals_Machine_Vision()
            //        {
            //            SVSVistek = null
            //        }
            //    };
            //}
            //#endregion

            //#region Initialize class and interfaces
            //Log.Debug("Initialize classes and interfaces ...");
            //int devicesCount = 0;
            //int interfaceCount = 0;

            //List<DbMachine_Device> devicesList = new List<DbMachine_Device>();

            //List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices).ToList();

            //#region Control - Robot Electronics ...
            //Log.Debug("Initialize class and devices (Control - Robot Electronics) ...");
            //devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.RobotElectronics).ToList().Count();
            //if (devicesCount > 0)
            //{
            //    Globals.Machine.Control = new Globals_Machine.Globals_Machine_Control();
            //    Globals.Machine.Control.RobotElectronics = new RobotElectronics_Container();
            //}
            //else
            //{
            //    Log.Error("No device found in database ...");
            //}
            //#endregion

            //#region Motion - Nanotec ...
            //Log.Debug("Initialize class and devices (Motion - Nanotec) ...");
            //interfaceCount = devicesAll.Where(p => p.DeviceManufacturer == DeviceManufacturer.IXXAT).ToList().Count();
            //devicesList = devicesAll.Where(p => p.DeviceManufacturer == DeviceManufacturer.IXXAT).ToList();

            //if (interfaceCount > 0)
            //{
            //    Globals.Machine.Motion = new Globals_Machine.Globals_Machine_Motion();
            //    Globals.Machine.Motion.Nanotec = new List<Nanotec_Container>();

            //    // Initialize devices on bus
            //    foreach (DbMachine_Device item in devicesList)
            //    {
            //        if (item.Interfaces_Can.Interface_CanDevices.Count() > 0)
            //        {
            //            Globals.Machine.Motion.Nanotec.Add(new Nanotec_Container()
            //            {
            //                IdDb = item.Id,
            //                MotionController = new List<Nanotec_MotionController>()
            //            });
            //        }
            //        else
            //        {
            //            Log.Error("No CAN device found in database ...");

            //            Globals.Machine.Motion.Nanotec.Add(new Nanotec_Container()
            //            {
            //                IdDb = item.Id,
            //                MotionController = null
            //            });
            //        }
            //    }
            //}
            //else
            //{
            //    Log.Error("No device found in database ...");
            //}
            //#endregion

            //#region Power Supply - Nextys ...
            //Log.Debug("Initialize class and devices (Power Supply - Nextys) ...");
            //devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.Nextys).ToList().Count();
            //if (devicesCount > 0)
            //{
            //    Globals.Machine.PowerSupply = new Globals_Machine.Globals_Machine_PowerSupply();
            //    Globals.Machine.PowerSupply.Nextys = new Nextys_Container();
            //}
            //else
            //{
            //    Log.Error("No device found in database ...");
            //}
            //#endregion

            //#region Robot - Doosan ...
            //Log.Debug("Initialize class and devices (Robot - Doosan) ...");
            //devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.Doosan).ToList().Count();
            //if (devicesCount > 0)
            //{
            //    Globals.Machine.Robot = new Globals_Machine.Globals_Machine_Robot();
            //    Globals.Machine.Robot.Doosan = new Doosan_Container();
            //}
            //else
            //{
            //    Log.Error("No device found in database ...");
            //}
            //#endregion

            //#region Vision - SVSVistek ...
            //Log.Debug("Initialize class and devices (Vision - SVSVistek) ...");
            //devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.SVSVistek).ToList().Count();
            //if (devicesCount > 0)
            //{
            //    Globals.Machine.Vision = new Globals_Machine.Globals_Machine_Vision();
            //    Globals.Machine.Vision.SVSVistek = new SVSVistek_Container();
            //}
            //else
            //{
            //    Log.Error("No device found in database ...");
            //}
            //#endregion
            //#endregion

            //#region Link variables to get shorter variable names ...
            //Log.Debug("Link variables to get shorter variable names ...");

            //Log.Debug("Link variables to get shorter variable names (Control - Robot Electronics) ...");
            //if (Globals.Machine.Control != null)
            //{
            //    if (Globals.Machine.Control.RobotElectronics != null)
            //    {
            //        _robotElectronics = Globals.Machine.Control.RobotElectronics;
            //    }
            //}

            //Log.Debug("Link variables to get shorter variable names (Motion - Nanotec) ...");
            //if (Globals.Machine.Motion != null)
            //{
            //    if (Globals.Machine.Motion.Nanotec != null)
            //    {
            //        _nanotec = Globals.Machine.Motion.Nanotec;
            //    }
            //}

            //Log.Debug("Link variables to get shorter variable names (Power Supply - Nextys) ...");
            //if (Globals.Machine.PowerSupply != null)
            //{
            //    if (Globals.Machine.PowerSupply.Nextys != null)
            //    {
            //        _nextys = Globals.Machine.PowerSupply.Nextys;
            //    }
            //}

            //Log.Debug("Link variables to get shorter variable names (Robot - Doosan) ...");
            //if (Globals.Machine.Robot != null)
            //{
            //    if (Globals.Machine.Robot.Doosan != null)
            //    {
            //        _doosan = Globals.Machine.Robot.Doosan;
            //    }
            //}

            //Log.Debug("Link variables to get shorter variable names (Vision - SVSVistek) ...");
            //if (Globals.Machine.Vision != null)
            //{
            //    if (Globals.Machine.Vision.SVSVistek != null)
            //    {
            //        _svsVistek = Globals.Machine.Vision.SVSVistek;
            //    }
            //}
            //#endregion
        }

        private void InitializeStorage()
        {

        }

        private void ControlInitializeAndConnect()
        {
            //Log.Debug("Initialize and connect Nextys (Power Supplies) ...");

            //if (_robotElectronics.Controllers != null)
            //{
            //    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                            .Where(p => p.DeviceManufacturer == DeviceManufacturer.RobotElectronics && p.DeviceType == DeviceType.DS2408)
            //                                            .ToList()
            //                                            .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
            //                                            .ToList();

            //    foreach (DbMachine_Device device in devicesAll)
            //    {
            //        try
            //        {
            //            List<RobotElectronics_Controller> controller;

            //            if (device.InitializeAtSplashscreen)
            //            {
            //                //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                DbMachine_Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
            //                _robotElectronics.Controllers.Add(new RobotElectronics_Controller(ethernet.IpAddress, ethernet.Port, ethernet.Timeout, 500));

            //                // Link Hardware with DbContext
            //                _robotElectronics.Controllers.Last().IdDb = device.Id;
            //            }

            //            controller = _robotElectronics.Controllers.Where(p => p.IdDb == device.Id).ToList();

            //            if (device.ConnectAtSplashscreen && controller.Count > 0)
            //            {
            //                //Log.Debug($"Connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                controller[0].Connect();
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

        private void MotionBusDeviceInitializeAndConnect()
        {
            //Log.Debug("Initialize and connect bus devices ...");

            //if (_nanotec != null)
            //{
            //    foreach (Nanotec_Container busInteface in _nanotec)
            //    {
            //        List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                                                                .Where(p => p.Id == busInteface.IdDb)
            //                                                                                .OrderBy(p => p.Id)
            //                                                                                .ToList();

            //        if (devicesAll.Count == 1)
            //        {
            //            // Set the logging level
            //            busInteface.SetLoggingLevel(Nlc.LogLevel.Info);

            //            #region Get and list all hardware available, and print out available hardware ...
            //            // Get and list all hardware available
            //            busInteface.DiscoverBusHardwareDevices();

            //            if (busInteface.BusHardwareVector.Count() <= 0)
            //            {
            //                Log.Error("No bus device found!");
            //                return;
            //            }

            //            busInteface.SetBusHardwareDevice(devicesAll[0].DeviceManufacturer.ToString(), devicesAll[0].Serialnumber);

            //            if (busInteface.BusHardwareId == null)
            //            {
            //                Log.Information("No or invalid bus hardware selection!");
            //            }
            //            #endregion

            //            #region Create bus hardware and open the hardware itself ... 
            //            if (busInteface.BusHardwareId != null)
            //            {
            //                // Create bus hardware options for opening the hardware
            //                busInteface.CreateBusHardwareOptions();

            //                // Now able to open the hardware itself
            //                busInteface.OpenBusHardware();
            //            }
            //            #endregion
            //        }
            //        else
            //        {
            //            // ToDo: ...
            //        }
            //    }
            //}
        }

        private void MotionDevicesOnTheBusDiscovery()
        {
            //Log.Debug("Discover devices on the bus ...");

            //if (_nanotec != null)
            //{
            //    foreach (Nanotec_Container busInteface in _nanotec)
            //    {
            //        List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                                            .Where(p => p.Id == busInteface.IdDb)
            //                                                            .OrderBy(p => p.Id)
            //                                                            .ToList();

            //        if (devicesAll.Count == 1)
            //        {
            //            #region Scan for devices, and print out available devices ...
            //            Log.Information("Scanning for devices...");

            //            // Scan the whole bus for devices (in case the bus supports scanning)
            //            busInteface.ScanBusForDevices();

            //            if (busInteface.BusDeviceVector.Count == 0)
            //            {
            //                MessageBoxResult result = MessageBox.Show("No devices found. ...", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
            //                Log.Error("No bus devices found!");
            //                return;
            //            }

            //            // Print out all available bus devices
            //            foreach (Nlc.DeviceId id in busInteface.BusDeviceVector)
            //            {
            //                Log.Debug($"Found bus device with ID: {id.getDeviceId()} Device name: {id.getDescription()} Bus Hardware: {id.getBusHardwareId().getName()}");
            //            }
            //            #endregion
            //        }
            //        else
            //        {
            //            // ToDo: ...
            //        }
            //    }
            //}
        }

        private void MotionDevicesOnTheBusInitializeAndConnect()
        {
            //Log.Debug("Initialize and connect devices on the bus ...");

            //if (_nanotec != null)
            //{
            //    foreach (Nanotec_Container item in _nanotec)
            //    {
            //        List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                                   .Where(p => p.Id == item.IdDb)
            //                                                   .OrderBy(p => p.Id)
            //                                                   .ToList();

            //        if (devicesAll.Count == 1)
            //        {
            //            var canDeviceOrderBy = devicesAll[0].Interfaces_Can.Interface_CanDevices.OrderBy(p => p.CanDeviceId).ToList();

            //            try
            //            {
            //                foreach (DbMachine_Interface_CanDevice device in canDeviceOrderBy)
            //                {
            //                    // Check if can device was found at device discovery
            //                    List<DeviceId> canDevice = item.BusDeviceVector.Where(p => p.getDeviceId() == device.CanDeviceId).ToList();

            //                    if (canDevice.Count == 1)
            //                    {
            //                        if (devicesAll[0].InitializeAtSplashscreen)
            //                        {
            //                            item.AddMotionController(device.CanDeviceId, device.Id);

            //                            item.DeviceConnect(device.CanDeviceId);
            //                        }

            //                        if (devicesAll[0].AutoStartAtSplashscreen)
            //                        {
            //                            // No autostart for motion controllers at the moment ...
            //                        }
            //                    }
            //                    else
            //                    {
            //                        // ToDo: ...
            //                        //Log.Error($"To many or to less devices for Id {busDeviceId} found!");
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                //Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                break;
            //            }
            //        }
            //        else
            //        {
            //            // ToDo: ...
            //        }
            //    }
            //}
        }

        private void PowerSupplyInitializeAndConnect()
        {
            //Log.Debug("Initialize and connect Nextys (Power Supplies) ...");

            //if (_nextys.DcDcConverters != null)
            //{
            //    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                                            .Where(p => p.DeviceManufacturer == DeviceManufacturer.Nextys && p.DeviceType == DeviceType.NDW240)
            //                                                            .ToList()
            //                                                            .OrderBy(p => p.Interfaces_Serial.PortName)
            //                                                            .ToList();

            //    foreach (DbMachine_Device device in devicesAll)
            //    {
            //        try
            //        {
            //            List<Nextys_DcDcConverter> dcDcConverter;

            //            if (device.InitializeAtSplashscreen)
            //            {
            //                //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                DbMachine_Interface_Serial? serial = device.Interfaces_Serial;
            //                _nextys.DcDcConverters.Add(new Nextys_DcDcConverter(serial.PortName, serial.BaudRate, (Parity)serial.Parity, (System.IO.Ports.StopBits)serial.StopBits, (Handshake)serial.Handshake, serial.ReadTimeout, serial.WriteTimeout, serial.MonitoringInterval, 0x01));

            //                // Link Hardware with DbContext
            //                _nextys.DcDcConverters.Last().IdDb = device.Id;
            //            }

            //            dcDcConverter = _nextys.DcDcConverters.Where(p => p.IdDb == device.Id).ToList();

            //            if (device.ConnectAtSplashscreen && dcDcConverter.Count == 1)
            //            {
            //                //Log.Debug($"Connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                dcDcConverter[0].Connect();
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

        private void RobotInitializeAndConnect()
        {
            //Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            //if (_doosan.Controllers != null)
            //{
            //    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                                                            .Where(p => p.DeviceManufacturer == DeviceManufacturer.Doosan && p.DeviceType == DeviceType.M0609)
            //                                                                            .ToList()
            //                                                                            .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
            //                                                                            .ToList();

            //    foreach (DbMachine_Device device in devicesAll)
            //    {
            //        try
            //        {
            //            List<Doosan_Controller> controller = new List<Doosan_Controller>();

            //            if (device.InitializeAtSplashscreen)
            //            {
            //                //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                DbMachine_Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
            //                _doosan.Controllers.Add(new Doosan_Controller());

            //                // Link Hardware with DbContext
            //                _doosan.Controllers.Last().IdDb = device.Id;
            //            }

            //            controller = _doosan.Controllers.Where(p => p.IdDb == device.Id).ToList();

            //            if (device.ConnectAtSplashscreen && controller.Count == 1)
            //            {
            //                //Log.Debug($"Define C# callback function´s for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                //RCRobotDoosanControl.Doosan.MyDelegate myDelegate = Globals.MyCallback;

            //                //_Doosan.ControlDeviceConfigs[i].Control.SetupCallbackk(myDelegate);

            //                //// Define C# callback functions
            //                //RCRobotDoosanControl.Doosan.ProgressDelegate progressDelegate = Globals.UpdateProgress;
            //                //RCRobotDoosanControl.Doosan.StatusDelegate statusDelegate = Globals.UpdateStatus;

            //                // Pass the delegates to the C++/CLI DLL
            //                //_Doosan.ControlDeviceConfigs[i].Control.SetupCallback(progressDelegate, statusDelegate);

            //                //_Doosan.ControlDeviceConfigs[i].Control._robterId = i;

            //                //_Doosan.ControlDeviceConfigs[i].Control.ManagedTOnTpInitializingCompletedCBHandler1 += Globals.OnTpInitializingCompleted1;

            //                //_Doosan.ControlDeviceConfigs[i].Control.ManagedTOnTpInitializingCompletedCBHandler2 += Globals.OnTpInitializingCompleted2;

            //                ////Register the callback
            //                //controller[0].ManagedTOnHommingCompletedCBHandler += Events.OnHommingCompleted;
            //                //////_robot.ManagedTOnMonitoringDataCBHandler += OnMonitoringDataCB1;
            //                //////_robot.ManagedTOnMonitoringDataExCBHandler += OnMonitoringDataExCB1;
            //                //////_robot.ManagedTOnMonitoringCtrlIOCBHandler += OnMonitoringCtrlIOCB1;
            //                //////_robot.ManagedTOnMonitoringCtrlIOExCBHandler += OnMonitoringCtrlIOExCB1;
            //                //////_robot.ManagedTOnMonitoringStateCBHandler += OnMonitoringStateCB1;
            //                //////_robot.ManagedTOnMonitoringAccessControlCBHandler += OnMonitoingAccessControlCB1;
            //                //controller[0].ManagedTOnTpInitializingCompletedCBHandler += Events.OnTpInitializingCompleted;
            //                //////_robot.ManagedTOnLogAlarmCBHandler += OnLogAlarm1;
            //                //////_robot.ManagedTOnProgramStoppedCBHandler += OnProgramStopped1;
            //                //controller[0].ManagedTOnDisconnectedCBHandler += Events.OnDisconnected;
            //                controller[0].RegisterEvents();
            //                Thread.Sleep(250);

            //                //Log.Debug($"Open connection for robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                controller[0].OpenConnection(device.Interfaces_Ethernet.IpAddress, device.Interfaces_Ethernet.Port);
            //                Log.Information($"Connect to Robot: {device.Interfaces_Ethernet.IpAddress}:{device.Interfaces_Ethernet.Port}");
            //                Thread.Sleep(250);

            //                //Log.Debug($"Get information of robot {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");

            //                // Change monitoring data version
            //                SystemVersion systemVersion = controller[0].GetSystemVersion();
            //                Log.Information("System Version: " + systemVersion._szController);
            //                controller[0].SetupMonitoringVersion(1);
            //                controller[0].SetRobotControl(RobotControl.CONTROL_SERVO_ON);

            //                Log.Information("Library Version: " + controller[0].GetLibraryVersion());
            //                Thread.Sleep(250);

            //                // Wait for robot state change
            //                //while ((controller[0].GetRobotState() != RobotState.STATE_STANDBY) || !controller[0].HasControlAuthority)
            //                //{
            //                //    Thread.Sleep(250);
            //                //}

            //                // Manual mode setting
            //                controller[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
            //                controller[0].SetRobotSystem(RobotSystem.ROBOT_SYSTEM_REAL);

            //                Thread.Sleep(250);


            //                //_Doosan.ControlDeviceConfigs[i].SetAxisDirection(1.0f, 1.0f, 1.0f, 1.0f, 1.0f, 1.0f);

            //                //_robot.SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_10, true);

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

        private void CameraInitializeSdk()
        {
            //Log.Debug("Initialize SVSVistek (Vision) SDK ...");

            //if (_svsVistek != null)
            //{
            //    _svsVistek.InitSDK();
            //}
        }

        private void CameraDiscovery()
        {
            //Log.Debug("Discover SVS-Vistek cameras ...");
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
            //Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            //if (_svsVistek.Cameras != null)
            //{
            //    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                                            .Where(p => p.DeviceManufacturer == DeviceManufacturer.SVSVistek && p.DeviceType == DeviceType.HR455CXGE)
            //                                                            .ToList()
            //                                                            .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
            //                                                            .ToList();

            //    List<SVSVistek_DeviceInfo> deviceInfo = null;

            //    foreach (DbMachine_Device device in devicesAll)
            //    {
            //        try
            //        {
            //            deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.Serialnumber).ToList();

            //            if (deviceInfo.Count == 1)
            //            {
            //                List<SVSVistek_Camera> cam = new List<SVSVistek_Camera>();

            //                if (device.InitializeAtSplashscreen)
            //                {
            //                    //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
            //                    DbMachine_Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
            //                    _svsVistek.Cameras.Add(new SVSVistek_Camera(deviceInfo[0]));

            //                    // Link Hardware with DbContext
            //                    _svsVistek.Cameras.Last().IdDb = device.Id;
            //                }

            //                cam = _svsVistek.Cameras.Where(p => p.IdDb == device.Id).ToList();

            //                if (device.ConnectAtSplashscreen && cam.Count == 1)
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
        private void CameraStartAcquision()
        {
            //Log.Debug("Start acquision for the cameras ...");

            //if (_svsVistek.Cameras != null)
            //{
            //    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
            //                                                            .Where(p => p.DeviceManufacturer == DeviceManufacturer.SVSVistek && p.DeviceType == DeviceType.HR455CXGE)
            //                                                            .ToList()
            //                                                            .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
            //                                                            .ToList();

            //    List<SVSVistek_DeviceInfo> deviceInfo = null;

            //    foreach (DbMachine_Device device in devicesAll)
            //    {
            //        try
            //        {
            //            deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.Serialnumber).ToList();

            //            if (deviceInfo.Count == 1)
            //            {
            //                if (device.AutoStartAtSplashscreen)
            //                {
            //                    List<SVSVistek_Camera> cam = _svsVistek.Cameras.Where(p => p.DeviceInfo.DeviceInfo.serialNumber == device.Serialnumber).ToList();

            //                    if (deviceInfo.Count == 1)
            //                    {
            //                        //Log.Debug($"Start camera acquision {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
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
        #endregion
    }
}
