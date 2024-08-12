using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using RC.Lib.Vision.SVSVistek;
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
        private bool _closeApplication;

        private string _stateName;
        private int _statePercentageCount;
        private int _statePercentageValue;

        private Thread _thrClock;
        private CancellationTokenSource _ctsClock;

        private BackgroundWorker _bgwSplashscreen;

        // Global Hardware
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

            Log.Information("Start splash screen ...");

            _closeApplication = false;

            // Calculate percentage and set progress bar
            Log.Information("Initialize and calculate percentage and set progress bar ...");
            _statePercentageValue = 0;
            _statePercentageCount = 14;

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

            Log.Debug("Initialize global devices (Vision - SvS-Vistek) ...");

            if (Globals.Machine == null)
            {
                Globals.Machine = new Globals_Machine()
                {
                    Vision = new Globals_Machine.Globals_Machine_Vision()
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

            #region Vision - SVSVistek ...
            Log.Debug("Initialize class and devices (Vision - SVSVistek) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.SVSVistek).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.Vision = new Globals_Machine.Globals_Machine_Vision();
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
