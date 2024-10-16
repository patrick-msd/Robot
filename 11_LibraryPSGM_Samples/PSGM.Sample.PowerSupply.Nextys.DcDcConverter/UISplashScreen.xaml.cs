﻿using Microsoft.EntityFrameworkCore;
using PSGM.Helper;
using PSGM.Model.DbMachine;
using PSGM.Model.DbMain;
using RC.Lib.PowerSupply;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Threading;
using System.Windows;

namespace RC.PowerSupply.Nextys.Sample
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
        private Nextys_Container? _nextys;

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
            UpdateUI("Power Supply: Initialize and connect devices (COM) ...");
            PowerSupplyInitializeAndConnect();
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

            Log.Debug("Initialize global devices (Power Supply - Nextys) ...");

            if (Globals.Machine == null)
            {
                Globals.Machine = new Globals_Machine()
                {
                    PowerSupply = new Globals_Machine.Globals_Machine_PowerSupply()
                    {
                        Nextys = null
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

            #region Power Supply - Nextys ...
            Log.Debug("Initialize class and devices (Power Supply - Nextys) ...");
            devicesCount = devicesAll.Where(i => i.DeviceManufacturer == DeviceManufacturer.Nextys).ToList().Count();
            if (devicesCount > 0)
            {
                Globals.Machine.PowerSupply = new Globals_Machine.Globals_Machine_PowerSupply();
                Globals.Machine.PowerSupply.Nextys = new Nextys_Container();
            }
            else
            {
                Log.Error("No device found in database ...");
            }
            #endregion
            #endregion

            #region Link variables to get shorter variable names ...
            Log.Debug("Link variables to get shorter variable names ...");

            Log.Debug("Link variables to get shorter variable names (Power Supply - Nextys) ...");
            if (Globals.Machine.PowerSupply != null)
            {
                if (Globals.Machine.PowerSupply.Nextys != null)
                {
                    _nextys = Globals.Machine.PowerSupply.Nextys;
                }
            }
            #endregion
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
        #endregion
    }
}
