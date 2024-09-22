using Emgu.CV;
using Emgu.CV.Structure;
using Intel.RealSense;
using Microsoft.EntityFrameworkCore;
using OpenCvSharp.Extensions;
using PSGM.Helper;
using PSGM.Helper.Workflow;
using PSGM.Model.DbMain;
using PSGM.Model.DbStorage;
using RC.Lib.Control.Doosan;
using RC.Lib.Control.RobotElectronics;
using RC.Lib.Motion;
using RC.Lib.PowerSupply;
using RC.Lib.Vision.SVSVistek;
using RC.Vision.Intel.RealSense;
using RCRobotDoosanControl;
using SendGrid;
using SendGrid.Helpers.Mail;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.RichTextBox.Themes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace RC.Scan_SingleSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        #region Global variables
        #region Hardware ...
        private RobotElectronics_Container? _robotElectronics;
        private List<Nanotec_Container>? _nanotec;
        private Nextys_Container? _nextys;
        private Doosan_Container? _doosan;
        private SVSVistek_Container? _svsVistek;

        private RealSense _realSense = new RealSense();
        #endregion

        #region Thread and tasks ...
        private Thread? _thread;

        Task _taskMain;
        CancellationTokenSource _cancellationTokenSourceMain;
        CancellationToken _tokenMain;

        Task _taskCheck;
        CancellationTokenSource _cancellationTokenSourceCheck;
        CancellationToken _tokenCheck;

        Task[] _taskWorker;
        CancellationTokenSource[] _cancellationTokenSourceWorker;
        CancellationToken[] _tokenWorker;

        Task _taskPicture;
        CancellationTokenSource _cancellationTokenSourcePicture;
        CancellationToken _tokenPicture;

        #endregion

        #region Robot definitions ...
        private float[] _pose = new float[] { 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };
        private float[] _poseCurrent = new float[] { 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

        private float[] _poseStartRobot_Horitzontal = new float[] { -200.000f, 6.250f, 575.000f, 0, 90.000f, 180.000f };            // --   (1)

        private float[] _poseCenterRobot_Horizontal = new float[] { 0.000f, 6.250f, 600.000f, 0.000f, 90.000f, 180.000f };          // --   (3)
        //private float[] _poseCenterRobot_Horizontal = new float[] { 0.000f, 6.250f, 575.000f, 0.000f, 90.000f, 180.000f };          // --   (3)
        //private float[] _poseCenterRobot_Vertical = new float[] { 0.000f, 6.250f, 700.000f, 0.000f, 0.000f, 180.000f };             // |    (4)

        //private float[] _poseDownRobot_Vertical = new float[] { 200.000f, 6.250f, 775.000f, 0.000f, 0.000f, 180.000f };             // |    (2)
        private float[] _poseDownRobot_Vertical = new float[] { 222.500f, 6.250f, 775.000f, 0.000f, 0.000f, 180.000f };             // |    (2)
        #endregion

        #region Cradle definitions ...
        private int _leadScrewPitch = 4;
        private float _motorResolution = 4096;

        private float _cradleHeightLimitTray = 495.000f;
        private float _cradleHeightZeroLevel = 505.000f;

        private int _cradleLeftZeroLevelPosition = 0;
        private int _cradleLeftDownToFan = 51200;           // 5cm

        private int _cradleRightZeroLevelPosition = 0;
        private int _cradleRightDownToFan = 51200;          // 5cm

        private int _cradleDownBeforePicture = 51200;       // 5cm
        #endregion

        #region Runtime information for scanning ...
        string _sourcePath = $"C:\\WorkDir_RoboticScanner\\Aufnahmen";
        string _destinationPath = $"S:\\original_new\\";

        private int _sheet = 0;
        private int _sheetsToDigitalis = 0;

        private int _sheetError = 0;

        private int _sheetErrorSolved1 = 0;
        private int _sheetErrorSolved2 = 0;
        private int _sheetErrorSolved3 = 0;
        private int _sheetErrorSolved = 0;
        public int SheetErrorSolved { get { return _sheetErrorSolved1 + _sheetErrorSolved2 + _sheetErrorSolved3; } set { _sheetErrorSolved = value; } }

        public bool _ignoreDoublepageSensor = false;
        public bool _preparedPage = false;
        public bool _replacedPage = false;
        public bool _scanFinish = false;
        #endregion

        #region Common ...
        private static readonly object _syncRoot = new object();

        bool _sheetControl = false;

        private float[] _valuesDepthMean;
        private float[] _valuesDepthStandardDeviation;
        private float _valuesDepthStandardDeviationMax = 20.000f;

        Stopwatch _timer;

        Image<Bgr, Byte> _imageLeft;
        Image<Bgr, Byte> _imageRight;

        GraphicalCode[] _imageLeft_GraphicalCode;
        #endregion
        #endregion

        public UIMainWindow()
        {
            InitializeComponent();

            Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            Serilog.Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Sink((ILogEventSink)Serilog.Log.Logger)
                                //.WriteTo.Debug(outputTemplate: Globals.LokiOutputTemplate)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels, textFormatter: new ExpressionTemplate("{ {@t, @mt, @l:u3}, @i, @x, @p} }\n"))
                                .WriteTo.RichTextBox(rtbLogger, outputTemplate: Globals.LokiOutputTemplate, syncRoot: _syncRoot, theme: RichTextBoxConsoleTheme.Colored)
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();

            Serilog.Log.Information("Start main window ...");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Inizialize variables ...
            _robotElectronics = Globals.Machine.Control.RobotElectronics;
            _nanotec = Globals.Machine.Motion.Nanotec;
            _nextys = Globals.Machine.PowerSupply.Nextys;
            _doosan = Globals.Machine.Robot.Doosan;
            _svsVistek = Globals.Machine.Vision.SVSVistek;
            #endregion

            #region Inizialize threads and tasks ...
            _thread = new Thread(new ThreadStart(delegate () { }));

            _taskMain = new Task(() => { });
            _cancellationTokenSourceMain = new CancellationTokenSource();
            _tokenMain = _cancellationTokenSourceMain.Token;

            _taskCheck = new Task(() => { });
            _cancellationTokenSourceCheck = new CancellationTokenSource();
            _tokenCheck = _cancellationTokenSourceCheck.Token;

            //_taskWorker = new Task(() => { });
            //_cancellationTokenSourceWorker = new CancellationTokenSource();
            //_tokenWorker = _cancellationTokenSourceWorker.Token;

            _taskWorker = new Task[_svsVistek.Cameras.Count];
            _cancellationTokenSourceWorker = new CancellationTokenSource[_svsVistek.Cameras.Count];
            _tokenWorker = new CancellationToken[_svsVistek.Cameras.Count];

            for (int i = 0; i < _taskWorker.Count(); i++)
            {
                _taskWorker[i] = new Task(() => { });
                _cancellationTokenSourceWorker[i] = new CancellationTokenSource();
                _tokenWorker[i] = _cancellationTokenSourceWorker[i].Token;
            }

            _taskPicture = new Task(() => { });
            _cancellationTokenSourcePicture = new CancellationTokenSource();
            _tokenPicture = _cancellationTokenSourcePicture.Token;
            #endregion



            // Real Sense
            _valuesDepthMean = new float[10];
            _valuesDepthStandardDeviation = new float[10];
            _realSense = new RealSense();

            var devices = _realSense.GetDevices();

            _realSense.ConnectToDevice(devices[0].Info.GetInfo(CameraInfo.SerialNumber));

            // Write device information
            Serilog.Log.Debug("\nUsing selected device, an {0}", _realSense.Device.Info[CameraInfo.Name]);
            Serilog.Log.Debug("Serial number: {0}", _realSense.Device.Info[CameraInfo.SerialNumber]);
            Serilog.Log.Debug("Firmware version: {0}", _realSense.Device.Info[CameraInfo.FirmwareVersion]);

            // Initialize Senosors            
            _realSense.InitializeStreamingProfileDepthSensor(0);
            _realSense.InitializeStreamingProfileColorSensor(0);
            //_realSense.InitializeStreamingProfileOfBothSensors(0, 0);

            // Config Streaming
            _realSense.StreamingConfigurationApply();

            // Start pipeline with streaming configuration
            _realSense.StreamingStart();

            _realSense.Function1Start();

            _realSense._updateColor += MonitoringColor;
            _realSense._updateDepth += MonitoringDepth;
            _realSense._updateDepthColorized += MonitoringDepthColorized;




            _timer = new Stopwatch();





            SetEndeffectors();





            _doosan.Controllers[0].SetAnalogOutput(GpioCtrlboxAnalogIndex.GPIO_CTRLBOX_ANALOG_INDEX_1, 0.000f);
            _doosan.Controllers[0].SetAnalogOutput(GpioCtrlboxAnalogIndex.GPIO_CTRLBOX_ANALOG_INDEX_2, 0.000f);


            foreach (Nextys_DcDcConverter dcDcConverter in _nextys.DcDcConverters)
            {
                //if (item.Control != null)
                //{
                //    if (!item.Control.IsConnected)
                //    {
                //        item.Control = new NextysModbus(item.Serial.PortName, item.Serial.BaudRate, item.Serial.Parity, item.Serial.StopBit, item.Serial.Handshake, item.Serial.ReadTimeout, item.Serial.WriteTimeout, item.Serial.MonitoringInterval, 0x01);
                //        item.Control.Connect();
                //    }
                //}

                // Disable Output
                dcDcConverter.OutputDisable();

                // Set values
                dcDcConverter._minOutputVoltage = (int)(4.500f * 1000);
                dcDcConverter._maxOutputVoltage = (int)(24.000f * 1000);
                dcDcConverter.SetNominalOutputVoltage((int)(4.500f * 1000));

                dcDcConverter._minOutputCurrent = (int)(1.000f * 1000);
                dcDcConverter._maxOutputCurrent = (int)(1.2500f * 1000);
                dcDcConverter.SetMaximalOutputCurrent((int)(1.250f * 1000));
            }



            Slider.Value = 25;



            #region Sendgrid
            var apiKey = "SheetScanner";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("heja@msd.tirol", "Heja");
            var subject = "Information";
            var to = new EmailAddress("it@msd.tirol", "Patrick Schönegger");
            var plainTextContent = "Scan started ...";
            var htmlContent = "<strong>from Heja</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);

            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            //var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            //var response = await client.SendEmailAsync(msg);

            #endregion
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region Close control devices
            Serilog.Log.Information("Cotnrol: Close devices and clean up variabels ...");

            try
            {
                if (_robotElectronics != null)
                {
                    for (int i = 0; i < _robotElectronics.Controllers.Count; i++)
                    {
                        _robotElectronics.Controllers[i].Disconnect();
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
            }
            #endregion

            #region Close motion devices
            Serilog.Log.Information("Motion: Close devices and clean up variabels ...");

            try
            {
                if (_nanotec != null)
                {
                    for (int i = 0; i < _nanotec.Count; i++)
                    {
                        _nanotec[i].CloseBusHardware();

                        _nanotec[i].MotionController.Clear();

                        _nanotec[i].BusHardwareId = null;
                        _nanotec[i].BusHardwareId = null;
                        _nanotec[i].BusHardwareVector = null;

                        _nanotec[i].BusDeviceVector = null;
                    }
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
            }
            #endregion

            #region Close power supply devices
            Serilog.Log.Information("Power Supply: Close devices and clean up variabels ...");

            try
            {
                if (_nextys.DcDcConverters.Count > 0)
                {
                    foreach (Nextys_DcDcConverter device in _nextys.DcDcConverters)
                    {
                        device.Disconnect();
                    }

                    Thread.Sleep(250);

                    _nextys.DcDcConverters.Clear();
                    //_nextys = null;
                }
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
            }
            #endregion

            #region Close robot devices
            Serilog.Log.Information("Robot: Close devices and clean up variabels ...");

            try
            {
                foreach (Doosan_Controller cotnroller in _doosan.Controllers)
                {
                    Serilog.Log.Information($"Close connection robot #{cotnroller.IdDb}");
                    cotnroller.CloseConnection();
                }

                Thread.Sleep(250);

                _doosan.Controllers.Clear();
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
            }
            #endregion

            #region Close vison devices
            Serilog.Log.Information("Vision: Close devices and clean up variabels ...");

            try
            {
                //cam.CloseCameraAll();

                if (_svsVistek.Cameras != null)
                {
                    for (int i = 0; i < _svsVistek.Cameras.Count; i++)
                    {
                        Serilog.Log.Debug($"Closing Cam {_svsVistek.Cameras[i].DeviceInfo.DeviceInfo.serialNumber}");

                        _svsVistek.Cameras[i].AcquisitionStop();
                        _svsVistek.Cameras[i].StreamingChannelClose();
                        _svsVistek.Cameras[i].closeConnection();

                        //_svsVistek.Cameras[i].Distroy();

                        //_svsVistek.Cameras.Remove(_svsVistek.Cameras[i]);

                        Thread.Sleep(125);
                    }

                    _svsVistek.Cameras.Clear();
                }

                _svsVistek = null;
            }
            catch (Exception ex)
            {
                Serilog.Log.Error(ex.Message);
            }
            #endregion

            //#region Close hardware connections
            //Serilog.Log.Information("################################# Close hardware connections #################################");

            //#region Close Robot conecttions
            //for (int i = 0; i < _robots.Controllers.Count; i++)
            //{
            //    Serilog.Log.Information("Close connection robot #{0}", i);
            //    _robots.Controllers[i].Control.CloseConnection();
            //    //_Robots.ControlDeviceConfigs[i].Control.Dispose();
            //    //_robots.ControlDeviceConfigs[i] = null;
            //}
            //#endregion

            //#region Close Motion controller connections
            //if (_nanotec != null)
            //{
            //    foreach (Globals_Device.Globals_Device_Motion_Nanotec_MotionController item in _nanotec.MotionControllers)
            //    {
            //        _nanotec.MotionBusController.DeviceDisconnect(item.DeviceHandle);
            //    }

            //    if (_nanotec.MotionBusHardwareId != null)
            //    {
            //        _nanotec.MotionBusController.CloseBusHardware(_nanotec.MotionBusHardwareId);
            //    }

            //    _nanotec.MotionBusDeviceIds = null;
            //    _nanotec.MotionBusHardwareId = null;
            //    _nanotec.MotionBusController = null;
            //}
            //#endregion
            //#endregion
        }

        #region GUI functions ...
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (_taskMain.Status == TaskStatus.Running)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _cancellationTokenSourceMain = new CancellationTokenSource();
                _tokenMain = _cancellationTokenSourceMain.Token;

                _taskMain = Task.Run(() =>
                {
                    Serilog.Log.Information("Start ...");

                    float[] targetVel = new float[] { 500.000f, 125.000f };
                    float[] targetVelSlow = new float[] { 10.000f, 5.000f };
                    float[] targetVelFast = new float[] { 750.000f, 250.000f };
                    float[] targetAcc = new float[] { 50.000f, 50.000f };
                    float[] targetAccSlow = new float[] { 2.500f, 2.500f };
                    float[] targetAccFast = new float[] { 500.000f, 250.000f };

                    float targetTime = 0.0f;
                    MoveMode moveMode = MoveMode.MOVE_MODE_ABSOLUTE;
                    MoveReference moveReference = MoveReference.MOVE_REFERENCE_BASE;
                    BlendingSpeedType blendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE;


                    //_Robots.ControlDeviceConfigs[0].Control.SetRobotMode(RobotMode.ROBOT_MODE_AUTONOMOUS);

                    //_poseCurrent = _Robots.ControlDeviceConfigs[0].Control.GetCurrentPosx()._fTargetPos;
                    //_poseCurrent[4] = -90.000f;
                    //_Robots.ControlDeviceConfigs[0].Control.MoveL(_poseCenterRobotLeft_Vertical, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);


                    //_poseCurrent = _Robots.ControlDeviceConfigs[0].Control.GetCurrentPosx()._fTargetPos;
                    //_poseCurrent[4] = 0.000f;
                    //_Robots.ControlDeviceConfigs[0].Control.MoveL(_poseStartRobotLeft_Horitzontal, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);

                    //_poseCurrent = _Robots.ControlDeviceConfigs[0].Control.GetCurrentPosx()._fTargetPos;
                    //_poseCurrent[4] = 0.000f;
                    //_Robots.ControlDeviceConfigs[0].Control.MoveL(_poseCenterRobotLeft_Vertical, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                }, _tokenMain);
            }
        }

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (_taskMain.Status == TaskStatus.Running || _taskMain.Status == TaskStatus.WaitingForActivation)
            {
                //_thread.Interrupt();
                _cancellationTokenSourceMain.Cancel();
                _cancellationTokenSourceCheck.Cancel();

                //_Nanotec.MotionBusController.DeviceDisconnect(_deviceHandle);
                _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (SVSVistek_Camera cam in _svsVistek.Cameras)
                {
                    Serilog.Log.Debug("Save Picture - Cam " + cam.DeviceInfo.DeviceInfo.serialNumber);
                    cam.GrabImageHdrAsync(new long[] { 2500, 7500, 15000, 32500, 45000 });

                    Thread.Sleep(25);
                }

            }
            catch (Exception ex)
            {
                Serilog.Log.Debug(ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int targetPosition = 0;

            int minPosRange = 0;
            int maxPosRange = 0;
            int minPos = -476750;
            int maxPos = 0;

            int polarityInverted = 0;
            int jerk = 0;

            int profileVelocity = 5000;
            int endVelocity = 0;
            int profileAccel = 1000;
            int profileDecel = 1000;
            int quickStopDecel = 5000;
            int maxDecel = 1000;
            int maxAccel = 1000;

            bool relative = false;

            int move = 1;

            int homingMode = (int)HomingModes.BlockPositive;
            int homeOffset = -0;            // Specifies the offset in encoder increments from the switch to the zero pulse.   
            int homingSpeedSwitch = 500;    // Specifies the speed in rpm that the motor is to reach during the search for the switch.
            int homingSpeedZero = 250;      // Specifies the speed in rpm that the motor is to reach during the search for the zero pulse.
            int homingMaxSpeed = 375;       // Specifies the maximum speed in rpm that the motor is to reach during the search for the zero pulse.
            int homingAcceleration = 250;   // Specifies the acceleration in rpm/s that the motor is to reach during the search for the zero pulse.
            int homingMinCurrent = 250;     // Specifies the minimum current in mA that the motor must draw during block detection.
            int homingBlockTime = 125;      // Specifies the time in ms that the motor is to continue to run against the block after block detection.

            Serilog.Log.Debug("Start - Homeing (Move a little bit)");
            for (int i = 0; i <= 3; i++)
            {
                _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);

                long curentPosistion = _nanotec[0].GetPosition(_nanotec[0].MotionController[i].DeviceHandle);

                _nanotec[0].SetPosition(_nanotec[0].MotionController[i].DeviceHandle, curentPosistion - 2500);
            }

            targetPosition = 0;

            minPosRange = 0;
            maxPosRange = 0;
            minPos = 0;
            maxPos = 1000;
            homeOffset = 0;

            polarityInverted = 0;
            jerk = 0;

            profileVelocity = 5000;
            endVelocity = 0;
            profileAccel = 1000;
            profileDecel = 1000;
            quickStopDecel = 5000;
            maxDecel = 1000;
            maxAccel = 1000;

            relative = false;

            move = 1;

            for (int i = 4; i <= 7; i++)
            {
                _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);

                long curentPosistion = _nanotec[0].GetPosition(_nanotec[0].MotionController[i].DeviceHandle);

                _nanotec[0].SetPosition(_nanotec[0].MotionController[i].DeviceHandle, curentPosistion - 500);
            }

            targetPosition = 0;

            minPosRange = 0;
            maxPosRange = 0;
            minPos = 0;
            maxPos = 36250;
            homeOffset = 0;

            polarityInverted = 0;
            jerk = 0;

            profileVelocity = 25000;
            endVelocity = 0;
            profileAccel = 10000;
            profileDecel = 10000;
            quickStopDecel = 10000;
            maxDecel = 10000;
            maxAccel = 10000;

            relative = false;

            move = 1;

            for (int i = 8; i <= 8; i++)
            {
                _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);

                long curentPosistion = _nanotec[0].GetPosition(_nanotec[0].MotionController[i].DeviceHandle);

                _nanotec[0].SetPosition(_nanotec[0].MotionController[i].DeviceHandle, curentPosistion + 10000);
            }
            Serilog.Log.Debug("Finish - Homeing (Move a little bit)");

            Serilog.Log.Debug("Start - Homeing");
            for (int i = 0; i <= 3; i++)
            {
                homingMode = (int)HomingModes.BlockPositive;
                homeOffset = 0;
                homingSpeedSwitch = 500;
                homingSpeedZero = 250;
                homingMaxSpeed = 500;
                homingAcceleration = 250;
                homingMinCurrent = 250;
                homingBlockTime = 125;

                _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                _nanotec[0].SetupHoming(_nanotec[0].MotionController[i].DeviceHandle, homingMode, homeOffset, homingSpeedSwitch, homingSpeedZero, homingMaxSpeed, homingAcceleration, homingMinCurrent, homingBlockTime);

                _nanotec[0].StartHomingASync(_nanotec[0].MotionController[i].DeviceHandle);
            }

            for (int i = 4; i <= 7; i++)
            {
                homingMode = (int)HomingModes.BlockNegative;
                homeOffset = 0;
                homingSpeedSwitch = 25;
                homingSpeedZero = 25;
                homingMaxSpeed = 25;
                homingAcceleration = 25;
                homingMinCurrent = 500;
                homingBlockTime = 125;

                _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                _nanotec[0].SetupHoming(_nanotec[0].MotionController[i].DeviceHandle, homingMode, homeOffset, homingSpeedSwitch, homingSpeedZero, homingMaxSpeed, homingAcceleration, homingMinCurrent, homingBlockTime);

                _nanotec[0].StartHomingASync(_nanotec[0].MotionController[i].DeviceHandle);
            }

            for (int i = 8; i <= 8; i++)
            {
                homingMode = (int)HomingModes.BlockNegative;
                homeOffset = 0;
                homingSpeedSwitch = 100;
                homingSpeedZero = 100;
                homingMaxSpeed = 100;
                homingAcceleration = 50;
                homingMinCurrent = 500;
                homingBlockTime = 125;

                _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                _nanotec[0].SetupHoming(_nanotec[0].MotionController[i].DeviceHandle, homingMode, homeOffset, homingSpeedSwitch, homingSpeedZero, homingMaxSpeed, homingAcceleration, homingMinCurrent, homingBlockTime);

                _nanotec[0].StartHoming(_nanotec[0].MotionController[i].DeviceHandle);
            }
            Serilog.Log.Debug("Finish - Homeing");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        int targetPosition = 0;

                        int minPosRange = 0;
                        int maxPosRange = 0;
                        int minPos = 0;
                        int maxPos = 1000;
                        int homeOffset = 0;

                        int polarityInverted = 0;
                        int jerk = 0;

                        int profileVelocity = 5000;
                        int endVelocity = 0;
                        int profileAccel = 1000;
                        int profileDecel = 1000;
                        int quickStopDecel = 5000;
                        int maxDecel = 1000;
                        int maxAccel = 1000;

                        bool relative = false;

                        int move = 1;

                        Serilog.Log.Debug("");
                        Serilog.Log.Debug("################################# Run - Position #################################");

                        for (int i = 4; i <= 7; i++)
                        {
                            _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                            _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                            _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        }

                        for (int j = 0; j < 10; j++)
                        {
                            for (int i = 4; i <= 7; i++)
                            {
                                if (j % 2 == 0)
                                {
                                    targetPosition = 0;
                                }
                                else
                                {
                                    targetPosition = 1000;
                                }

                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[i].DeviceHandle, targetPosition);

                                Thread.Sleep(10);
                            }

                            Thread.Sleep(2500);
                        }

                        Serilog.Log.Debug("################################# Finished - Position #################################");
                        Serilog.Log.Debug("");
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        int targetPosition = 0;

                        int minPosRange = 0;
                        int maxPosRange = 0;
                        int minPos = -476750;
                        int maxPos = 0;
                        int homeOffset = 0;

                        int polarityInverted = 0;
                        int jerk = 0;

                        int profileVelocity = 5000;
                        int endVelocity = 0;
                        int profileAccel = 1000;
                        int profileDecel = 1000;
                        int quickStopDecel = 5000;
                        int maxDecel = 1000;
                        int maxAccel = 1000;

                        bool relative = false;

                        int move = 1;

                        Serilog.Log.Debug("");
                        Serilog.Log.Debug("################################# Run - Position #################################");

                        for (int i = 0; i <= 3; i++)
                        {
                            _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                            _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                            _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        }

                        for (int j = 0; j < 4; j++)
                        {
                            for (int i = 0; i <= 3; i++)
                            {
                                if (j % 2 == 0)
                                {
                                    targetPosition = -250;
                                }
                                else
                                {
                                    targetPosition = -25000;
                                }

                                _nanotec[0].SetPositionASync(_nanotec[0].MotionController[i].DeviceHandle, targetPosition);
                            }

                            Thread.Sleep(5000);
                        }

                        Serilog.Log.Debug("################################# Finished - Position #################################");
                        Serilog.Log.Debug("");
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        int targetPosition = 0;

                        int minPosRange = 0;
                        int maxPosRange = 0;
                        int minPos = 0;
                        int maxPos = 36250;
                        int homeOffset = 0;

                        int polarityInverted = 0;
                        int jerk = 0;

                        int profileVelocity = 25000;
                        int endVelocity = 0;
                        int profileAccel = 10000;
                        int profileDecel = 10000;
                        int quickStopDecel = 10000;
                        int maxDecel = 10000;
                        int maxAccel = 10000;

                        bool relative = false;

                        int move = 1;

                        Serilog.Log.Debug("");
                        Serilog.Log.Debug("################################# Run - Position #################################");

                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[8].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[8].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);

                        for (int j = 0; j < 4; j++)
                        {
                            if (j % 2 == 0)
                            {
                                targetPosition = 0;
                            }
                            else
                            {
                                targetPosition = 36250;
                            }

                            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[8].DeviceHandle, targetPosition);

                            Thread.Sleep(5000);
                        }

                        Serilog.Log.Debug("################################# Finished - Position #################################");
                        Serilog.Log.Debug("");
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        int targetPositionLeft = 0;
                        int targetPositionRight = 0;

                        int minPosRange = 0;
                        int maxPosRange = 0;
                        int minPos = -476750;
                        int maxPos = 0;
                        int homeOffset = 0;

                        int polarityInverted = 0;
                        int jerk = 0;

                        int profileVelocity = 5000;
                        int endVelocity = 0;
                        int profileAccel = 1000;
                        int profileDecel = 1000;
                        int quickStopDecel = 5000;
                        int maxDecel = 1000;
                        int maxAccel = 1000;

                        bool relative = false;

                        int move = 1;

                        Dispatcher.Invoke(() =>
                        {
                            targetPositionLeft = (int)Convert.ToDouble(txtSheetZ_Copy1.Text.Replace(".", ","));
                            targetPositionRight = (int)Convert.ToDouble(txtSheetZ_Copy2.Text.Replace(".", ","));
                        });

                        Serilog.Log.Debug("");
                        Serilog.Log.Debug("################################# Run - Position #################################");

                        for (int i = 0; i <= 3; i++)
                        {
                            _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                            _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        }

                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[1].DeviceHandle, targetPositionLeft);
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[2].DeviceHandle, targetPositionLeft);
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[0].DeviceHandle, targetPositionRight);
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[3].DeviceHandle, targetPositionRight);

                        Serilog.Log.Debug("################################# Finished - Position #################################");
                        Serilog.Log.Debug("");
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        int targetPosition = 0;

                        int minPosRange = 0;
                        int maxPosRange = 0;
                        int minPos = 0;
                        int maxPos = 1000;
                        int homeOffset = 0;

                        int polarityInverted = 0;
                        int jerk = 0;

                        int profileVelocity = 5000;
                        int endVelocity = 0;
                        int profileAccel = 1000;
                        int profileDecel = 1000;
                        int quickStopDecel = 5000;
                        int maxDecel = 1000;
                        int maxAccel = 1000;

                        bool relative = false;

                        int move = 1;

                        Serilog.Log.Debug("");
                        Serilog.Log.Debug("################################# Run - Position #################################");

                        for (int i = 4; i <= 7; i++)
                        {
                            _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                            _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        }


                        for (int i = 4; i <= 7; i++)
                        {
                            targetPosition = 0;

                            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[i].DeviceHandle, targetPosition);

                            Thread.Sleep(10);
                        }

                        Serilog.Log.Debug("################################# Finished - Position #################################");
                        Serilog.Log.Debug("");
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        int targetPosition = 0;

                        int minPosRange = 0;
                        int maxPosRange = 0;
                        int minPos = 0;
                        int maxPos = 1000;
                        int homeOffset = 0;

                        int polarityInverted = 0;
                        int jerk = 0;

                        int profileVelocity = 5000;
                        int endVelocity = 0;
                        int profileAccel = 1000;
                        int profileDecel = 1000;
                        int quickStopDecel = 5000;
                        int maxDecel = 1000;
                        int maxAccel = 1000;

                        bool relative = false;

                        int move = 1;

                        Serilog.Log.Debug("");
                        Serilog.Log.Debug("################################# Run - Position #################################");

                        for (int i = 4; i <= 7; i++)
                        {
                            _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                            _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        }


                        for (int i = 4; i <= 7; i++)
                        {
                            targetPosition = 1000;

                            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[i].DeviceHandle, targetPosition);

                            Thread.Sleep(10);
                        }

                        Serilog.Log.Debug("################################# Finished - Position #################################");
                        Serilog.Log.Debug("");
                    }
                    catch (Exception ex)
                    {
                        Serilog.Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }
        #endregion

        #region Functions ...
        void SetEndeffectors()
        {
            string Tool = "Tool1";
            string TCP = "TCP1";

            //float[] toolCenterPosition = { 0.000f, 0.000f, 125.000f, 0.000f, 0.000f, 0.000f };
            float[] toolCenterPosition = { 0.000f, 0.000f, 90.000f, 0.000f, 0.000f, 0.000f };

            float ToolWeight = 0.000f;

            float[] ToolCenterOfGravitiy = { 0.000f, 0.000f, 0.000f };
            float[] ToolInertiaValue = { 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

            if (_doosan.Controllers.Count > 0)
            {
                for (int i = 0; i < _doosan.Controllers.Count; i++)
                {
                    RobotMode mode = _doosan.Controllers[i].GetRobotMode();

                    Thread.Sleep(250);

                    _doosan.Controllers[i].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                    Thread.Sleep(250);

                    _doosan.Controllers[i].AddTool(Tool, ToolWeight, ToolCenterOfGravitiy, ToolInertiaValue);
                    Thread.Sleep(50);
                    _doosan.Controllers[i].SetTool(Tool);


                    _doosan.Controllers[i].AddTCP(TCP, toolCenterPosition);
                    Thread.Sleep(50);
                    _doosan.Controllers[i].SetTCP(TCP);

                    Thread.Sleep(50);

                    string asd = _doosan.Controllers[i].GetTool();
                    string asdsa = _doosan.Controllers[i].GetTCP();


                    Serilog.Log.Information("Robot \" Current Tool: " + _doosan.Controllers[i].GetTool());
                    Serilog.Log.Information("Robot \" Current TCP: " + _doosan.Controllers[i].GetTCP());

                    Thread.Sleep(250);

                    _doosan.Controllers[i].SetRobotMode(mode);
                }
            }
        }

        void SetupCradleMotors()
        {
            try
            {
                int minPosRange = 0;
                int maxPosRange = 0;
                int minPos = -476750;
                int maxPos = 0;
                int homeOffset = 0;

                int polarityInverted = 0;
                int jerk = 0;

                int profileVelocity = 5000;
                int endVelocity = 0;
                int profileAccel = 1000;
                int profileDecel = 1000;
                int quickStopDecel = 5000;
                int maxDecel = 1000;
                int maxAccel = 1000;

                bool relative = false;

                int move = 1;

                Serilog.Log.Debug("");
                Serilog.Log.Debug("################################# Start - Setup Cradle Motors #################################");

                for (int i = 0; i <= 3; i++)
                {
                    _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                    _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                }

                Serilog.Log.Debug("################################# Finished - Setup Cradle Motors  #################################");
                Serilog.Log.Debug("");
            }
            catch (Exception ex)
            {
                Serilog.Log.Debug(ex.Message);
            }
        }

        void SetupDownholderMotors()
        {
            try
            {
                int minPosRange = 0;
                int maxPosRange = 0;
                int minPos = 0;
                int maxPos = 1000;
                int homeOffset = 0;

                int polarityInverted = 0;
                int jerk = 0;

                int profileVelocity = 5000;
                int endVelocity = 0;
                int profileAccel = 1000;
                int profileDecel = 1000;
                int quickStopDecel = 5000;
                int maxDecel = 1000;
                int maxAccel = 1000;

                bool relative = false;

                int move = 1;

                Serilog.Log.Debug("");
                Serilog.Log.Debug("################################# Start - Setup Downholder Motors #################################");

                for (int i = 4; i <= 7; i++)
                {
                    _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                    _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                }

                Serilog.Log.Debug("################################# Finished - Setup Downholder Motors  #################################");
                Serilog.Log.Debug("");
            }
            catch (Exception ex)
            {
                Serilog.Log.Debug(ex.Message);
            }
        }

        void SetupDoublePageMotor()
        {
            try
            {
                int minPosRange = 0;
                int maxPosRange = 0;
                int minPos = 0;
                int maxPos = 36250;
                int homeOffset = 0;

                int polarityInverted = 0;
                int jerk = 0;

                int profileVelocity = 25000;
                int endVelocity = 0;
                int profileAccel = 10000;
                int profileDecel = 10000;
                int quickStopDecel = 10000;
                int maxDecel = 10000;
                int maxAccel = 10000;

                bool relative = false;

                int move = 1;

                Serilog.Log.Debug("");
                Serilog.Log.Debug("################################# Start - Setup Double Page Motors #################################");

                for (int i = 8; i <= 8; i++)
                {
                    _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                    _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                }

                Serilog.Log.Debug("################################# Finished - Setup Double Page Motors  #################################");
                Serilog.Log.Debug("");
            }
            catch (Exception ex)
            {
                Serilog.Log.Debug(ex.Message);
            }
        }
        #endregion

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            _doosan.Controllers[0].ChangeOperationSpeed((float)(e.OriginalSource as Slider).Value);
            lblSheetZ_Copy1.Content = "Percentage: " + (e.OriginalSource as Slider).Value.ToString("0.00") + "%";
        }

        private void rtbLogger_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtbLogger.ScrollToEnd();
        }






        async Task Worker(int number)
        {
            int runs = 0;

            bool currentValue = false;
            bool previousValue = false;

            Workflow workflow;

            Guid machineId = MachineInfo.GetMachineUUID();
            Guid patrickSchoeneggerId = Globals.DbUser_Context.Users.Where(u => u.LoginName == "patrick.schoenegger").FirstOrDefault().Id;
            Guid softwareId = new Guid();

            List<DbMain_Project> projects = Globals.DbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(machineId))
                                                                              .Include(p => p.ProjectParameter)
                                                                              .Include(p => p.Organization)
                                                                              .Include(p => p.Contributors)
                                                                              //.Include(p => p.Locations)
                                                                              .ToList();

            List<DbStorage_RootDirectory> storage = Globals.DbStorage_Context.RootDirectories.Where(p => p.Id == projects.FirstOrDefault().Id)
                                                                                                .Include(p => p.SubDirectories)
                                                                                                    .ThenInclude(d => d.Files)
                                                                                                        .ThenInclude(f => f.QrCode)
                                                                                                .Include(p => p.Files)
                                                                                                    .ThenInclude(f => f.QrCode)
                                                                                                .ToList();

            DbMain_Project projectSelected = projects.FirstOrDefault();                                                             // To specified (Select box)
            DbStorage_SubDirectory? dataSubdirectorySelected = storage.FirstOrDefault().SubDirectories.FirstOrDefault();            // To specified (Select box)

            workflow = new Workflow(projectSelected.WorkflowIdExt, patrickSchoeneggerId, machineId, softwareId, Globals.DbMain_Context.ConnectionStringSQLite, Globals.DbMain_Context.DatabaseType, projectSelected.Id, Globals.DbWorkflow_Context.ConnectionStringSQLite, Globals.DbWorkflow_Context.DatabaseType);

            while (!_tokenWorker[number].IsCancellationRequested)
            {
                if (previousValue && !currentValue)
                {
                    List<ImageHelper> imagesHelper = new List<ImageHelper>();
                    List<Bitmap> imagesHelperBitmap = new List<Bitmap>();

                    for (int j = 0; j < _svsVistek.Cameras[number].ImagesRgbCount; j++)
                    {
                        imagesHelper.Add(new ImageHelper() { FileId = Guid.NewGuid(), FileRawIds = null, ExposureTime = _svsVistek.Cameras[number].ImagesRgbExposureTime[j], DateDigitized = DateTime.UtcNow, CameraDeviceId = _svsVistek.Cameras[number].IdDb });
                        imagesHelperBitmap.Add(_svsVistek.Cameras[number].ImagesRgb[j]);
                    }

                    #region Run workflow
                    workflow.RunWithCapturedImages(imagesHelper, imagesHelperBitmap, "C:/tmp", dataSubdirectorySelected.Id, "Meldezettel TLA / UIBK", null);
                    #endregion

                    // Write values to GUI
                    if (number == 0)
                    {
                        _imageRight = workflow.Image_Data.Image.ToBitmap().ToImage<Bgr, byte>();

                        this.Dispatcher.Invoke((Action)(() =>
                        {
                            imgImage_Copy.Source = ToBitmapSource(_imageRight);
                        }));
                    }

                    if (number == 1)
                    {
                        _imageLeft = workflow.Image_Data.Image.ToBitmap().ToImage<Bgr, byte>();

                        this.Dispatcher.Invoke((Action)(() =>
                        {
                            imgImage_Copy1.Source = ToBitmapSource(_imageLeft);
                        }));
                    }

                    imagesHelper.RemoveAll(x => true);
                    imagesHelperBitmap.RemoveAll(x => true);

                    break;
                }

                if (runs >= 100)
                {
                    Serilog.Log.Error($"Waiting too long for image from camera {_svsVistek.Cameras[number].GetDeviceSerialNumber}...");
                    break;
                }

                await Task.Delay(25);

                runs++;

                previousValue = currentValue;
                currentValue = _svsVistek.Cameras[number].IsGrabbingImage;
            }
        }




        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            #region 
            bool FistStartLeft = false;
            bool FistStartRight = false;

            // Read values from GUI
            FistStartLeft = (bool)chkFistStart_left.IsChecked;
            FistStartRight = (bool)chkFistStart_right.IsChecked;

            if (FistStartRight)
            {
                if (_taskWorker[0].Status == TaskStatus.Running)
                {
                    Serilog.Log.Information("Another thread is already running ...");
                }
                else
                {
                    _cancellationTokenSourceWorker[0] = new CancellationTokenSource();
                    _tokenWorker[0] = _cancellationTokenSourceWorker[0].Token;

                    Thread.Sleep(25);

                    _taskWorker[0] = Task.Run(() => Worker(0), _tokenWorker[0]);
                }
            }

            if (FistStartLeft)
            {
                if (_taskWorker[1].Status == TaskStatus.Running)
                {
                    Serilog.Log.Information("Another thread is already running ...");
                }
                else
                {
                    _cancellationTokenSourceWorker[1] = new CancellationTokenSource();
                    _tokenWorker[1] = _cancellationTokenSourceWorker[1].Token;

                    Thread.Sleep(25);

                    _taskWorker[1] = Task.Run(() => Worker(1), _tokenWorker[1]);
                }
            }
            #endregion

            #region 
            if (_taskPicture.Status == TaskStatus.Running)
            {
                Serilog.Log.Information("Another thread is already running ...");
            }
            else
            {
                _cancellationTokenSourcePicture = new CancellationTokenSource();
                _tokenPicture = _cancellationTokenSourcePicture.Token;

                _taskPicture = Task.Run(async () =>
                {
                    bool FistStartLeft = false;
                    bool FistStartRight = false;

                    // Read values from GUI
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        FistStartLeft = (bool)chkFistStart_left.IsChecked;
                        FistStartRight = (bool)chkFistStart_right.IsChecked;
                    }));

                    if (FistStartRight)
                    {
                        Serilog.Log.Debug("Save Picture - Cam " + _svsVistek.Cameras[0].DeviceInfo.DeviceInfo.serialNumber);

                        _svsVistek.Cameras[0].GrabImageHdrAsync(new long[] { 7500, 10000, 15000, 20000, 27500 });
                    }

                    if (FistStartLeft)
                    {
                        Serilog.Log.Debug("Save Picture - Cam " + _svsVistek.Cameras[1].DeviceInfo.DeviceInfo.serialNumber);

                        _svsVistek.Cameras[1].GrabImageHdrAsync(new long[] { 7500, 10000, 15000, 20000, 27500 });
                    }
                }, _tokenPicture);
            }
            #endregion
        }
    }
}