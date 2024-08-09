using Microsoft.EntityFrameworkCore;
using Nlc;
using RC.Lib.Motion;
using RC.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
        private string _stateName;
        private int _statePercentageCount;
        private int _statePercentageValue;

        private Thread _thrClock;
        private CancellationTokenSource _ctsClock;

        private BackgroundWorker _bgwSplashscreen;

        // Global Hardware
        private List<Nanotec_Container>? _nanotec;
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

            Log.Information("Start spash screen ...");

            // Calculate percentage and set progress bar
            Log.Information("Initialize and calculate percentage and set progress bar ...");
            _statePercentageValue = 0;
            _statePercentageCount = 7;

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
            UpdateUI("Load config from DB ...");
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
            UpdateUI("Motion: Initialize and connect bus devices (USB-to-CAN, USB-to-Serial, PICe, ...) ...");
            MotionBusDeviceInitializeAndConnect();
            Thread.Sleep(125);

            // Step #5
            UpdateUI("Motion: Discover devices on the bus (CAN, ...) ...");
            MotionDevicesOnTheBusDiscovery();
            Thread.Sleep(125);

            // Step #6
            UpdateUI("Motion: Connect to the devices on the bus ...");
            MotionDevicesOnTheBusInitializeAndConnect();
            Thread.Sleep(125);

            // Step #7
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
            Log.Information("Initialize global devices ...");

            if (Globals.Device == null)
            {
                Globals.Device = new Globals_Device()
                {
                    Motion = new Globals_Device.Globals_Device_Motion()
                    {
                        Nanotec = null
                    }
                };
            }
            #endregion

            #region Initialize class and devices ...
            Log.Debug("Initialize class and devices ...");

            int interfaceCount = Globals.Context.Devices.Where(p => p.InterfaceManufacturer == InterfaceManufacturers.IXXAT).ToList().Count();
            List<Device> devices = Globals.Context.Devices.Where(p => p.InterfaceManufacturer == InterfaceManufacturers.IXXAT)
                                                        .Include(p => p.Interfaces_Can)
                                                        .ThenInclude(p => p.CanDevices)
                                                        .ToList();

            if (interfaceCount > 0)
            {
                Globals.Device.Motion.Nanotec = new List<Nanotec_Container>();

                // Initialize devices on bus
                foreach (Device item in devices)
                {
                    if (item.Interfaces_Can.CanDevices.Count() > 0)
                    {
                        Globals.Device.Motion.Nanotec.Add(new Nanotec_Container()
                        {
                            IdDb = item.Id,
                            MotionController = new List<Nanotec_MotionController>()
                        });
                    }
                    else
                    {
                        Log.Error("No CAN device found in database ...");

                        Globals.Device.Motion.Nanotec.Add(new Nanotec_Container()
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

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            if (Globals.Device.Motion != null)
            {
                if (Globals.Device.Motion.Nanotec != null)
                {
                    _nanotec = Globals.Device.Motion.Nanotec;
                }
            }
            #endregion
        }

        private void AnalyzeConfigAndVariables()
        {
            Thread.Sleep(125);
        }

        private void MotionBusDeviceInitializeAndConnect()
        {
            Log.Debug("Initialize and connect bus devices ...");

            if (_nanotec != null)
            {
                foreach (Nanotec_Container busInteface in _nanotec)
                {
                    List<Device> devices = Globals.Context.Devices.Where(p => p.Id == busInteface.IdDb)
                                                .OrderBy(p => p.Id)
                                                .Include(p => p.Interfaces_Can)
                                                    .ThenInclude(p => p.CanDevices)
                                                .ToList();

                    if (devices.Count == 1)
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

                        busInteface.SetBusHardwareDevice(devices[0].InterfaceManufacturer.ToString(), devices[0].InterfaceSerialnumber);

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
                    List<Device> devices = Globals.Context.Devices.Where(p => p.Id == busInteface.IdDb)
                                                .Include(p => p.Interfaces_Can)
                                                    .ThenInclude(p => p.CanDevices)
                                                .OrderBy(p => p.Id)
                                                .ToList();

                    if (devices.Count == 1)
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
                    #endregion
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
                    // Get items form database
                    List<Device> devices = Globals.Context.Devices.Where(p => p.Id == item.IdDb)
                                                .Include(p => p.Interfaces_Can)
                                                    .ThenInclude(p => p.CanDevices)
                                                .OrderBy(p => p.Id)
                                                .ToList();

                    if (devices.Count == 1)
                    {
                        var canDeviceOrderBy = devices[0].Interfaces_Can.CanDevices.OrderBy(p => p.CanDeviceId).ToList();

                        try
                        {
                            foreach (Interface_CanDevice device in canDeviceOrderBy)
                            {
                                // Check if can device was found at device discovery
                                List<DeviceId> canDevice = item.BusDeviceVector.Where(p => p.getDeviceId() == device.CanDeviceId).ToList();

                                if (canDevice.Count == 1)
                                {
                                    if (devices[0].InitialzeAtSplashscreen)
                                    {
                                        item.AddMotionController(device.CanDeviceId, device.Id);

                                        item.DeviceConnect(device.CanDeviceId);
                                    }

                                    if (devices[0].AutoStartAtSplashscreen)
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
    }
}
