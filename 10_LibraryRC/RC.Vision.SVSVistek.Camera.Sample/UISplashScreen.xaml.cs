using Microsoft.EntityFrameworkCore;
using RC.Lib.Vision.SVSVistek;
using RC.Model;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows;

namespace RC.Vision.SVSVistek.Sample
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
        private SVSVistek_Container? _svsVistek;
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
            _statePercentageCount = 8;

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
            UpdateUI("Camera: Initialize SDKs ...");
            CameraInitializeSdk();
            Thread.Sleep(125);

            // Step #5
            UpdateUI("Camera: Discover cameras ...");
            CameraDiscovery();
            Thread.Sleep(125);

            // Step #6
            UpdateUI("Camera: Initialize and connect to cameras (Ethernet) ...");
            CameraInitializeAndConnect();
            Thread.Sleep(125);

            // Step #7
            UpdateUI("Camera: Start acquision of the cameras ...");
            CameraStartAcquision();
            Thread.Sleep(125);

            // Step #8
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
                    Vision = new Globals_Device.Globals_Device_Vision()
                    {
                        SVSVistek = null
                    }
                };
            }
            #endregion

            #region Initialize class and devices ...
            Log.Debug("Initialize class and devices ...");

            int devicesCount = Globals.Context.Devices.Where(i => i.DeviceManufacturer == DeviceManufacturers.SVSVistek).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Device.Vision.SVSVistek = new SVSVistek_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            if (Globals.Device.Vision != null)
            {
                if (Globals.Device.Vision.SVSVistek != null)
                {
                    _svsVistek = Globals.Device.Vision.SVSVistek;
                }
            }
            #endregion
        }

        private void AnalyzeConfigAndVariables()
        {
            Thread.Sleep(125);
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
        }

        private void CameraInitializeAndConnect()
        {
            Log.Debug("Initialize and connect SVS-Vistek (Cameras) ...");

            if (_svsVistek.Cameras != null)
            {
                List<Device> devices = Globals.Context.Devices.Where(p => p.DeviceManufacturer == DeviceManufacturers.SVSVistek && p.DeviceType == DeviceTypes.Vision)
                                                                                .Include(p => p.Interfaces_Ethernet)
                                                                                .ToList();
                List<SVSVistek_DeviceInfo> deviceInfo = null;

                foreach (Device device in devices)
                {
                    try
                    {
                        deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.DeviceSerialnumber).ToList();

                        if (deviceInfo.Count == 1)
                        {
                            List<SVSVistek_Camera> cam = new List<SVSVistek_Camera>();

                            if (device.InitialzeAtSplashscreen)
                            {
                                Log.Debug($"Inizialize device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                Interface_Ethernet? ethernet = device.Interfaces_Ethernet;
                                _svsVistek.Cameras.Add(new SVSVistek_Camera(deviceInfo[0]));

                                // Link Hardware with DbContext
                                _svsVistek.Cameras.Last().IdDb = device.Id;
                            }

                            cam = _svsVistek.Cameras.Where(p => p.IdDb == device.Id).ToList();

                            if (device.ConnectAtSplashscreen && cam.Count == 1)
                            {
                                Log.Debug($"Open connection for camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                cam[0].OpenConnection();

                                Thread.Sleep(125);

                                Log.Debug($"Initialize camera {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                                SVSVistek_Camera_Config config = SVSVistek_Camera_Config.ToJson(device.DeviceConfiguration);

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
                        Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
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
                List<Device> devices = Globals.Context.Devices.Where(p => p.DeviceManufacturer == DeviceManufacturers.SVSVistek && p.DeviceType == DeviceTypes.Vision)
                                                                                .Include(p => p.Interfaces_Ethernet)
                                                                                .ToList();
                List<SVSVistek_DeviceInfo> deviceInfo = null;

                foreach (Device device in devices)
                {
                    try
                    {
                        deviceInfo = _svsVistek.DeviceInfoList.Where(p => p.DeviceInfo.serialNumber == device.DeviceSerialnumber).ToList();

                        if (deviceInfo.Count == 1)
                        {
                            if (device.AutoStartAtSplashscreen)
                            {
                                List<SVSVistek_Camera> cam = _svsVistek.Cameras.Where(p => p.DeviceInfo.DeviceInfo.serialNumber == device.DeviceSerialnumber).ToList();

                                if (deviceInfo.Count == 1)
                                {
                                    Log.Debug($"Start camera acquision {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
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
                        Log.Error($"Couldn't initialize/connect to device {device.ApplicationDeviceName} ({device.ApplicationDeviceLocation}) --> {device.DeviceManufacturer} ({device.DeviceType} - {device.DeviceName}) --> {device.DeviceSerialnumber} --> {device.Id}!");
                        break;
                    }
                }
            }
        }
        #endregion
    }
}
