using Microsoft.EntityFrameworkCore;
using RC.Lib.Control.RobotElectronics;
using RC.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace RC.Control.RobotElectronics.Sample
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
        private RobotElectronics_Container? _robotElectronics;
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
            UpdateUI("Control: Initialize and connect devices (USB) ...");
            ControlInitializeAndConnect();
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

                    App_config.AppConfiCreate();
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
                    Control = new Globals_Device.Globals_Device_Control()
                    {
                        RobotElectronics = null
                    }
                };
            }
            #endregion

            #region Initialize class and devices ...
            Log.Debug("Initialize class and devices ...");

            int devicesCount = Globals.Context.Devices.Where(i => i.DeviceManufacturer == DeviceManufacturers.RobotElectronics).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Device.Control.RobotElectronics = new RobotElectronics_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            if (Globals.Device.Control != null)
            {
                if (Globals.Device.Control.RobotElectronics != null)
                {
                    _robotElectronics = Globals.Device.Control.RobotElectronics;
                }
            }
            #endregion
        }

        private void AnalyzeConfigAndVariables()
        {
            Thread.Sleep(125);
        }

        private void ControlInitializeAndConnect()
        {
            Log.Debug("Initialize and connect Nextxs (Power Supplies) ...");

            if (_robotElectronics.Controllers != null)
            {
                List<Device> devices = Globals.Context.Devices.Where(p => p.DeviceManufacturer == DeviceManufacturers.RobotElectronics && p.DeviceType == DeviceTypes.Controller)
                                                                .Include(p => p.Interfaces_Ethernet)
                                                                .ToList();

                foreach (Device device in devices)
                {
                    try
                    {
                        List<RobotElectronics_Controller> controller;

                        if (device.InitialzeAtSplashscreen)
                        {
                            Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
                            _robotElectronics.Controllers.Add(new RobotElectronics_Controller(ethernet.IpAddress, ethernet.Port, ethernet.Timeout, 500));

                            // Link Hardware with DbContext
                            _robotElectronics.Controllers.Last().IdDb = device.Id;
                        }

                        controller = _robotElectronics.Controllers.Where(p => p.IdDb == device.Id).ToList();

                        if (device.ConnectAtSplashscreen && controller.Count > 0)
                        {
                            Log.Debug($"Connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                            controller[0].Connect();
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
