using Microsoft.EntityFrameworkCore;
using Nlc;
using PSGM.Helper;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using RC.Lib.Control.Doosan;
using RC.Lib.Control.RobotElectronics;
using RC.Lib.Motion;
using RC.Lib.PowerSupply;
using RC.Lib.Vision.SVSVistek;
using RCRobotDoosanControl;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
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

        private BackgroundWorker _bgwSplashscreen;

        // Global Hardware
        private RobotElectronics_Container? _robotElectronics;
        private List<Nanotec_Container>? _nanotec;
        private Nextys_Container? _nextys;
        private Doosan_Container? _doosan;
        //private Intel_Container? _intel;
        private SVSVistek_Container? _svsVistek;

        // Global database
        List<DbMachine_Machine>? _dbMachine_Machine;
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

            Log.Information("Start spash screen ...");

            _closeApplication = false;

            // Calculate percentage and set progress bar
            Log.Information("Initialize and calculate percentage and set progress bar ...");
            _statePercentageValue = 0;
            _statePercentageCount = 14;

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
            UpdateUI("Load data from DB ...");
            LoadDataFromDB();
            Thread.Sleep(125);

            // Step #2
            UpdateUI("Initialize variables ...");
            InitializeVariables();
            Thread.Sleep(125);

            // Step #3
            UpdateUI("Initialize storage ...");
            InitializeStorage();
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

            Log.Debug("Initialize global devices (Control - Robot Electronics) ...");
            Log.Debug("Initialize global devices (Motion - Nanotec) ...");
            Log.Debug("Initialize global devices (Power Supply - Nextys) ...");
            Log.Debug("Initialize global devices (Robot - Doosan) ...");
            Log.Debug("Initialize global devices (Vision - SvS-Vistek) ...");

            if (Globals.Machine == null)
            {
                Globals.Machine = new Globals_Machine()
                {
                    Control = new Globals_Machine.Globals_Device_Control()
                    {
                        RobotElectronics = null
                    },

                    Motion = new Globals_Machine.Globals_Device_Motion()
                    {
                        Nanotec = null
                    },

                    PowerSupply = new Globals_Machine.Globals_Device_PowerSupply()
                    {
                        Nextys = null
                    },

                    Robot = new Globals_Machine.Globals_Device_Robot()
                    {
                        Doosan = null
                    },

                    Vision = new Globals_Machine.Globals_Device_Vision()
                    {
                        SVSVistek = null
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

            #region Control - Robot Electronics ...
            Log.Debug("Initialize class and devices (Control - Robot Electronics) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.RobotElectronics).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.Control = new Globals_Machine.Globals_Device_Control();
                Globals.Machine.Control.RobotElectronics = new RobotElectronics_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion

            #region Motion - Nanotec ...
            Log.Debug("Initialize class and devices (Motion - Nanotec) ...");
            interfaceCount = devicesAll.Where(p => p.DeviceManufacturer == DeviceManufacturer.IXXAT).ToList().Count();
            devicesList = devicesAll.Where(p => p.DeviceManufacturer == DeviceManufacturer.IXXAT).ToList();

            if (interfaceCount > 0)
            {
                Globals.Machine.Motion = new Globals_Machine.Globals_Device_Motion();
                Globals.Machine.Motion.Nanotec = new List<Nanotec_Container>();

                // Initialize devices on bus
                foreach (DbMachine_Device item in devicesList)
                {
                    if (item.Interfaces_Can.Interface_CanDevices.Count() > 0)
                    {
                        Globals.Machine.Motion.Nanotec.Add(new Nanotec_Container()
                        {
                            IdDb = item.Id,
                            MotionController = new List<Nanotec_MotionController>()
                        });
                    }
                    else
                    {
                        Log.Error("No CAN device found in database ...");

                        Globals.Machine.Motion.Nanotec.Add(new Nanotec_Container()
                        {
                            IdDb = item.Id,
                            MotionController = null
                        });
                    }
                }
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion

            #region Power Supply - Nextys ...
            Log.Debug("Initialize class and devices (Power Supply - Nextys) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.Nextys).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.PowerSupply = new Globals_Machine.Globals_Device_PowerSupply();
                Globals.Machine.PowerSupply.Nextys = new Nextys_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion

            #region Robot - Doosan ...
            Log.Debug("Initialize class and devices (Robot - Doosan) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.Doosan).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.Robot = new Globals_Machine.Globals_Device_Robot();
                Globals.Machine.Robot.Doosan = new Doosan_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion

            #region Vision - SVSVistek ...
            Log.Debug("Initialize class and devices (Vision - SVSVistek) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.SVSVistek).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.Vision = new Globals_Machine.Globals_Device_Vision();
                Globals.Machine.Vision.SVSVistek = new SVSVistek_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            Log.Debug("Link variables to get shorter variable names (Control - Robot Electronics) ...");
            if (Globals.Machine.Control != null)
            {
                if (Globals.Machine.Control.RobotElectronics != null)
                {
                    _robotElectronics = Globals.Machine.Control.RobotElectronics;
                }
            }

            Log.Debug("Link variables to get shorter variable names (Motion - Nanotec) ...");
            if (Globals.Machine.Motion != null)
            {
                if (Globals.Machine.Motion.Nanotec != null)
                {
                    _nanotec = Globals.Machine.Motion.Nanotec;
                }
            }

            Log.Debug("Link variables to get shorter variable names (Power Supply - Nextys) ...");
            if (Globals.Machine.PowerSupply != null)
            {
                if (Globals.Machine.PowerSupply.Nextys != null)
                {
                    _nextys = Globals.Machine.PowerSupply.Nextys;
                }
            }

            Log.Debug("Link variables to get shorter variable names (Robot - Doosan) ...");
            if (Globals.Machine.Robot != null)
            {
                if (Globals.Machine.Robot.Doosan != null)
                {
                    _doosan = Globals.Machine.Robot.Doosan;
                }
            }

            Log.Debug("Link variables to get shorter variable names (Vision - SVSVistek) ...");
            if (Globals.Machine.Vision != null)
            {
                if (Globals.Machine.Vision.SVSVistek != null)
                {
                    _svsVistek = Globals.Machine.Vision.SVSVistek;
                }
            }
            #endregion
        }

        private void InitializeStorage()
        {
            //Globals.Storage = new Globals_Storage()
            //{
            //    S3 = new List<Globals_Storage_S3>()
            //    {
            //        new Globals_Storage_S3()
            //        {
            //            Endpoint = _dbMain_Projects[0].ProjectParameter.StorageDataUrl,
            //            AccessKey = _dbMain_Projects[0].ProjectParameter.StorageDataAccessKey,
            //            SecretKey = _dbMain_Projects[0].ProjectParameter.StorageDataSecretKey,
            //            Secure = _dbMain_Projects[0].ProjectParameter.StorageDataSecure,
            //            Region = _dbMain_Projects[0].ProjectParameter.StorageDataLocation,

            //            BucketName = _dbMain_Projects[0].ProjectParameter.StorageDataBucketName
            //        },
            //        new Globals_Storage_S3()
            //        {
            //            Endpoint = _dbMain_Projects[0].ProjectParameter.StorageThumbnailUrl,
            //            AccessKey = _dbMain_Projects[0].ProjectParameter.StorageThumbnailAccessKey,
            //            SecretKey = _dbMain_Projects[0].ProjectParameter.StorageThumbnailSecretKey,
            //            Secure = _dbMain_Projects[0].ProjectParameter.StorageThumbnailSecure,
            //            Region = _dbMain_Projects[0].ProjectParameter.StorageThumbnailLocation,

            //            BucketName = _dbMain_Projects[0].ProjectParameter.StorageThumbnailBucketName
            //        },
            //        new Globals_Storage_S3()
            //        {
            //            Endpoint = _dbMain_Projects[0].ProjectParameter.StorageDataRawUrl,
            //            AccessKey = _dbMain_Projects[0].ProjectParameter.StorageDataRawAccessKey,
            //            SecretKey = _dbMain_Projects[0].ProjectParameter.StorageDataRawSecretKey,
            //            Secure = _dbMain_Projects[0].ProjectParameter.StorageDataRawSecure,
            //            Region = _dbMain_Projects[0].ProjectParameter.StorageDataRawLocation,

            //            BucketName = _dbMain_Projects[0].ProjectParameter.StorageDataRawBucketName
            //        },
            //    }
            //};





            Globals.Storage = new Globals_Storage();
            Globals.Storage.S3 = new List<Globals_Storage_S3>();

            foreach (var item in _dbMain_Projects[0].ProjectParameter.Storages)
            {
                Globals.Storage.S3.Add(new Globals_Storage_S3()
                {
                    Endpoint = item.StorageS3Endpoint,
                    AccessKey = item.StorageS3AccessKey,
                    SecretKey = item.StorageS3SecretKey,
                    Secure = item.StorageS3Secure,
                    Region = item.StorageS3Region,

                    BucketName = item.StorageS3BucketName,
                });
            }

            // Initialize the client with access credentials.
            foreach (var item in Globals.Storage.S3)
            {
                item.InitilizeMinIoClient();
            }
        }


        private void ControlInitializeAndConnect()
        {
            Log.Debug("Initialize and connect Nextys (Power Supplies) ...");

            if (_robotElectronics.Controllers != null)
            {
                List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                        .Where(p => p.DeviceManufacturer == DeviceManufacturer.RobotElectronics && p.DeviceType == DeviceType.DS2408)
                                                        .ToList()
                                                        .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
                                                        .ToList();

                foreach (DbMachine_Device device in devicesAll)
                {
                    try
                    {
                        List<RobotElectronics_Controller> controller;

                        if (device.InitializeAtSplashscreen)
                        {
                            //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            DbMachine_Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
                            _robotElectronics.Controllers.Add(new RobotElectronics_Controller(ethernet.IpAddress, ethernet.Port, ethernet.Timeout, 500));

                            // Link Hardware with DbContext
                            _robotElectronics.Controllers.Last().IdDb = device.Id;
                        }

                        controller = _robotElectronics.Controllers.Where(p => p.IdDb == device.Id).ToList();

                        if (device.ConnectAtSplashscreen && controller.Count > 0)
                        {
                            //Log.Debug($"Connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            controller[0].Connect();
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

        private void MotionBusDeviceInitializeAndConnect()
        {
            Log.Debug("Initialize and connect bus devices ...");

            if (_nanotec != null)
            {
                foreach (Nanotec_Container busInteface in _nanotec)
                {
                    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                                                            .Where(p => p.Id == busInteface.IdDb)
                                                                                            .OrderBy(p => p.Id)
                                                                                            .ToList();

                    if (devicesAll.Count == 1)
                    {
                        // Set the logging level
                        busInteface.SetLoggingLevel(Nlc.LogLevel.Info);

                        #region Get and list all hardware available, and print out available hardware ...
                        // Get and list all hardware available
                        busInteface.DiscoverBusHardwareDevices();

                        if (busInteface.BusHardwareVector.Count() <= 0)
                        {
                            Log.Error("No bus device found!");
                            return;
                        }

                        busInteface.SetBusHardwareDevice(devicesAll[0].DeviceManufacturer.ToString(), devicesAll[0].Serialnumber);

                        if (busInteface.BusHardwareId == null)
                        {
                            Log.Information("No or invalid bus hardware selection!");
                        }
                        #endregion

                        #region Create bus hardware and open the hardware itself ... 
                        if (busInteface.BusHardwareId != null)
                        {
                            // Create bus hardware options for opening the hardware
                            busInteface.CreateBusHardwareOptions();

                            // Now able to open the hardware itself
                            busInteface.OpenBusHardware();
                        }
                    }
                    else
                    {
                        // ToDo: ...
                    }
                    #endregion
                }
            }
        }

        private void MotionDevicesOnTheBusDiscovery()
        {
            Log.Debug("Discover devices on the bus ...");

            if (_nanotec != null)
            {
                foreach (Nanotec_Container busInteface in _nanotec)
                {
                    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                                        .Where(p => p.Id == busInteface.IdDb)
                                                                        .OrderBy(p => p.Id)
                                                                        .ToList();

                    if (devicesAll.Count == 1)
                    {
                        #region Scan for devices, and print out available devices ...
                        Log.Information("Scanning for devices...");

                        // Scan the whole bus for devices (in case the bus supports scanning)
                        busInteface.ScanBusForDevices();

                        if (busInteface.BusDeviceVector.Count == 0)
                        {
                            MessageBoxResult result = MessageBox.Show("No devices found. ...", "Info", MessageBoxButton.OK, MessageBoxImage.Error);
                            Log.Error("No bus devices found!");
                            return;
                        }

                        // Print out all available bus devices
                        foreach (Nlc.DeviceId id in busInteface.BusDeviceVector)
                        {
                            Log.Debug($"Found bus device with ID: {id.getDeviceId()} Device name: {id.getDescription()} Bus Hardware: {id.getBusHardwareId().getName()}");
                        }
                        #endregion
                    }
                    else
                    {
                        // ToDo: ...
                    }
                }
            }
        }

        private void MotionDevicesOnTheBusInitializeAndConnect()
        {
            Log.Debug("Initialize and connect devices on the bus ...");

            if (_nanotec != null)
            {
                foreach (Nanotec_Container item in _nanotec)
                {
                    List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                               .Where(p => p.Id == item.IdDb)
                                                               .OrderBy(p => p.Id)
                                                               .ToList();

                    if (devicesAll.Count == 1)
                    {
                        var canDeviceOrderBy = devicesAll[0].Interfaces_Can.Interface_CanDevices.OrderBy(p => p.CanDeviceId).ToList();

                        try
                        {
                            foreach (DbMachine_Interface_CanDevice device in canDeviceOrderBy)
                            {
                                // Check if can device was found at device discovery
                                List<DeviceId> canDevice = item.BusDeviceVector.Where(p => p.getDeviceId() == device.CanDeviceId).ToList();

                                if (canDevice.Count == 1)
                                {
                                    if (devicesAll[0].InitializeAtSplashscreen)
                                    {
                                        item.AddMotionController(device.CanDeviceId, device.Id);

                                        item.DeviceConnect(device.CanDeviceId);
                                    }

                                    if (devicesAll[0].AutoStartAtSplashscreen)
                                    {
                                        // No autostart for motion controllers at the moment ...
                                    }
                                }
                                else
                                {
                                    // ToDo: ...
                                    //Log.Error($"To many or to less devices for Id {busDeviceId} found!");
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            //Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            break;
                        }
                    }
                    else
                    {
                        // ToDo: ...
                    }
                }
            }
        }

        private void PowerSupplyInitializeAndConnect()
        {
            Log.Debug("Initialize and connect Nextys (Power Supplies) ...");

            if (_nextys.DcDcConverters != null)
            {
                List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                                        .Where(p => p.DeviceManufacturer == DeviceManufacturer.Nextys && p.DeviceType == DeviceType.NDW240)
                                                                        .ToList()
                                                                        .OrderBy(p => p.Interfaces_Serial.PortName)
                                                                        .ToList();

                foreach (DbMachine_Device device in devicesAll)
                {
                    try
                    {
                        List<Nextys_DcDcConverter> dcDcConverter;

                        if (device.InitializeAtSplashscreen)
                        {
                            //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            DbMachine_Interface_Serial? serial = device.Interfaces_Serial;
                            _nextys.DcDcConverters.Add(new Nextys_DcDcConverter(serial.PortName, serial.BaudRate, (Parity)serial.Parity, (System.IO.Ports.StopBits)serial.StopBits, (Handshake)serial.Handshake, serial.ReadTimeout, serial.WriteTimeout, serial.MonitoringInterval, 0x01));

                            // Link Hardware with DbContext
                            _nextys.DcDcConverters.Last().IdDb = device.Id;
                        }

                        dcDcConverter = _nextys.DcDcConverters.Where(p => p.IdDb == device.Id).ToList();

                        if (device.ConnectAtSplashscreen && dcDcConverter.Count == 1)
                        {
                            //Log.Debug($"Connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            dcDcConverter[0].Connect();
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

        private void CameraInitializeSdk()
        {
            Log.Debug("Initialize SVSVistek (Vision) SDK ...");

            if (_svsVistek != null)
            {
                _svsVistek.InitSDK();
            }
        }

        private void CameraDiscovery()
        {
            Log.Debug("Discover SVS-Vistek cameras ...");
            _svsVistek.DeviceDiscovery();

            if (_svsVistek.DeviceInfoList != null)
            {
                foreach (SVSVistek_DeviceInfo cam in _svsVistek.DeviceInfoList)
                {
                    Log.Debug("Camera Name:" + cam.DeviceInfo.displayName + " Model:" + cam.DeviceInfo.model + " Serialnumber:" + cam.DeviceInfo.serialNumber + " found.");
                }
            }
            else
            {
               Log.Error("No camera found!");
            }
        }

        private void CameraInitializeAndConnect()
        {
            Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            if (_svsVistek.Cameras != null)
            {
                List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                                        .Where(p => p.DeviceManufacturer == DeviceManufacturer.SVSVistek && p.DeviceType == DeviceType.HR455CXGE)
                                                                        .ToList()
                                                                        .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
                                                                        .ToList();

                List<SVSVistek_DeviceInfo> deviceInfo = null;

                foreach (DbMachine_Device device in devicesAll)
                {
                    try
                    {
                        deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.Serialnumber).ToList();

                        if (deviceInfo.Count == 1)
                        {
                            List<SVSVistek_Camera> cam = new List<SVSVistek_Camera>();

                            if (device.InitializeAtSplashscreen)
                            {
                                //Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                DbMachine_Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
                                _svsVistek.Cameras.Add(new SVSVistek_Camera(deviceInfo[0]));

                                // Link Hardware with DbContext
                                _svsVistek.Cameras.Last().IdDb = device.Id;
                            }

                            cam = _svsVistek.Cameras.Where(p => p.IdDb == device.Id).ToList();

                            if (device.ConnectAtSplashscreen && cam.Count == 1)
                            {
                                //Log.Debug($"Open connection for camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                cam[0].OpenConnection();

                                Thread.Sleep(125);

                                //Log.Debug($"Initialize camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                SVSVistek_Camera_Config config = SVSVistek_Camera_Config.ToJson(device.ConfigurationString);

                                // ToDO: cam.DeviceReset();
                                //Thread.Sleep(5000);

                                // ToDo: All settings from DB 
                                cam[0].SetFan(config.DevieControl.FanControl);

                                cam[0].SetSensorPixelSize(config.ImageFormatControl.SensorPixelSize);
                                cam[0].SetPixelFormat(config.ImageFormatControl.PixelFormat);
                                cam[0].SetOffsetX(config.ImageFormatControl.XOffset);
                                cam[0].SetOffsetY(config.ImageFormatControl.YOffset);
                                cam[0].SetWidth(config.ImageFormatControl.Width);
                                cam[0].SetHeight(config.ImageFormatControl.Height);

                                cam[0].SetExposureTime(config.AcquisitionControl.ExposureTime);

                                cam[0].SetGain(config.AnalogControl.Gain);
                                cam[0].SetWhiteBalance(config.AnalogControl.BalanceWhiteRatioRed, config.AnalogControl.BalanceWhiteRatioGreen, config.AnalogControl.BalanceWhiteRatioBlue);
                            }
                            else
                            {
                                // ToDo: ...
                            }
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

        private void CameraStartAcquision()
        {
            Log.Debug("Start acquision for the cameras ...");

            if (_svsVistek.Cameras != null)
            {
                List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices)
                                                                        .Where(p => p.DeviceManufacturer == DeviceManufacturer.SVSVistek && p.DeviceType == DeviceType.HR455CXGE)
                                                                        .ToList()
                                                                        .OrderBy(p => p.Interfaces_Ethernet.IpAddress)
                                                                        .ToList();

                List<SVSVistek_DeviceInfo> deviceInfo = null;

                foreach (DbMachine_Device device in devicesAll)
                {
                    try
                    {
                        deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.Serialnumber).ToList();

                        if (deviceInfo.Count == 1)
                        {
                            if (device.AutoStartAtSplashscreen)
                            {
                                List<SVSVistek_Camera> cam = _svsVistek.Cameras.Where(p => p.DeviceInfo.DeviceInfo.serialNumber == device.Serialnumber).ToList();

                                if (deviceInfo.Count == 1)
                                {
                                    //Log.Debug($"Start camera acquision {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                    cam[0].StartAcquisionContinuously();

                                    Thread.Sleep(1250);
                                }
                                else
                                {
                                    // ToDo: ...
                                }
                            }
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
