using Microsoft.EntityFrameworkCore;
using Nlc;
using PSGM.Helper;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using RC.Lib.Motion;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Windows;

namespace RC.Motion.Nanotec.Sample
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
        private List<Nanotec_Container>? _nanotec;

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
            Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            txbApplicationName.Text = Globals.ApplicationTitle;
            txbApplicationVersion.Text = "V" + Globals.ApplicationVersion.ToString();

            Log.Information("Start splash screen ...");

            // Calculate percentage and set progress bar
            Log.Information("Initialize and calculate percentage and set progress bar ...");
            _statePercentageValue = 0;
            _statePercentageCount = 6;

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
            UpdateUI("Load config from DB ...");
            LoadDataFromDB();
            Thread.Sleep(125);

            // Step #2
            UpdateUI("Initialize variables ...");
            InitializeVariables();
            Thread.Sleep(125);

            // Step #3
            UpdateUI("Motion: Initialize and connect bus devices (USB-to-CAN, USB-to-Serial, PICe, ...) ...");
            MotionBusDeviceInitializeAndConnect();
            Thread.Sleep(125);

            // Step #4
            UpdateUI("Motion: Discover devices on the bus (CAN, ...) ...");
            MotionDevicesOnTheBusDiscovery();
            Thread.Sleep(125);

            // Step #5
            UpdateUI("Motion: Connect to the devices on the bus ...");
            MotionDevicesOnTheBusInitializeAndConnect();
            Thread.Sleep(125);

            // Step #6
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
            _dbMain_Projects = Globals.DbMain_Context.Projects.Where(p => p.Machines_ExtString.Contains(Globals.Machine.MachineId.ToString()))
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

            Log.Debug("Initialize global devices (Motion - Nanotec) ...");

            if (Globals.Machine == null)
            {
                Globals.Machine = new Globals_Machine()
                {
                    Motion = new Globals_Machine.Globals_Machine_Motion()
                    {
                        Nanotec = null
                    },
                };
            }
            #endregion

            #region Initialize class and interfaces
            Log.Debug("Initialize classes and interfaces ...");
            int devicesCount = 0;
            int interfaceCount = 0;

            List<DbMachine_Device> devicesList = new List<DbMachine_Device>();

            List<DbMachine_Device> devicesAll = _dbMachine_Machine[0].DeviceGroups.SelectMany(p => p.Devices).ToList();

            #region Motion - Nanotec ...
            Log.Debug("Initialize class and devices (Motion - Nanotec) ...");
            interfaceCount = devicesAll.Where(p => p.DeviceManufacturer == DeviceManufacturer.IXXAT).ToList().Count();
            devicesList = devicesAll.Where(p => p.DeviceManufacturer == DeviceManufacturer.IXXAT).ToList();

            if (interfaceCount > 0)
            {
                Globals.Machine.Motion = new Globals_Machine.Globals_Machine_Motion();
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
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            Log.Debug("Link variables to get shorter variable names (Motion - Nanotec) ...");
            if (Globals.Machine.Motion != null)
            {
                if (Globals.Machine.Motion.Nanotec != null)
                {
                    _nanotec = Globals.Machine.Motion.Nanotec;
                }
            }
            #endregion
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
                        #endregion
                    }
                    else
                    {
                        // ToDo: ...
                    }
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
        #endregion
    }
}
