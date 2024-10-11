using Emgu.CV;
using Emgu.CV.Structure;
using Intel.RealSense;
using PSGM.Lib.Control.Doosan;
using PSGM.Lib.Control.RobotElectronics;
using PSGM.Lib.Motion;
using PSGM.Lib.PowerSupply;
using PSGM.Lib.Vision.Intel;
using PSGM.Lib.Vision.SVSVistek;
using PSGMRobotDoosanControl;
using Serilog;
using Serilog.Sinks.Grafana.Loki;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;

namespace PSGM.SingleSolution.SheetScan
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
        //private Intel_Container? _intel;
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

        Task[] _taskWorkflow;
        CancellationTokenSource[] _cancellationTokenSourceWorkflow;
        CancellationToken[] _tokenWorkflow;

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

        public bool _ignoreDoublePageSensor = false;
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

#if DEBUG
            Serilog.Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Debug(outputTemplate: Globals.LokiOutputTemplate)
                                .WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels, textFormatter: new ExpressionTemplate("{ {@t, @mt, @l:u3}, @i, @x, @p} }\n"))
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();
#else
            Serilog.Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();
#endif

            Serilog.Log.Information("Start main window ...");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Initialize global variables ...
            Serilog.Log.Information("Initialize global variables ...");

            _robotElectronics = Globals.Machine.Control.RobotElectronics;
            _nanotec = Globals.Machine.Motion.Nanotec;
            _nextys = Globals.Machine.PowerSupply.Nextys;
            _doosan = Globals.Machine.Robot.Doosan;
            //_intel = Globals.Machine.Vision.Intel;
            _svsVistek = Globals.Machine.Vision.SVSVistek;

            _timer = new Stopwatch();
            #endregion

            #region Initialize Gui elements ...
            Serilog.Log.Information("Initialize Gui elements ...");

            Slider.Value = 25;

            foreach (var robot in _doosan.Controllers)
            {
                robot.ChangeOperationSpeed((float)Slider.Value);
            }
            #endregion

            #region Initialize threads and tasks ...
            Serilog.Log.Information("Initialize threads and tasks ...");

            _thread = new Thread(new ThreadStart(delegate () { }));

            _taskMain = new Task(() => { });
            _cancellationTokenSourceMain = new CancellationTokenSource();
            _tokenMain = _cancellationTokenSourceMain.Token;

            _taskCheck = new Task(() => { });
            _cancellationTokenSourceCheck = new CancellationTokenSource();
            _tokenCheck = _cancellationTokenSourceCheck.Token;

            _taskWorkflow = new Task[_svsVistek.Cameras.Count];
            _cancellationTokenSourceWorkflow = new CancellationTokenSource[_svsVistek.Cameras.Count];
            _tokenWorkflow = new CancellationToken[_svsVistek.Cameras.Count];

            for (int i = 0; i < _taskWorkflow.Count(); i++)
            {
                _taskWorkflow[i] = new Task(() => { });
                _cancellationTokenSourceWorkflow[i] = new CancellationTokenSource();
                _tokenWorkflow[i] = _cancellationTokenSourceWorkflow[i].Token;
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

            // Initialize Sensors            
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
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region Close hardware connections
            #region Close control devices
            Serilog.Log.Information("Control: Close devices and clean up variables ...");

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
            Serilog.Log.Information("Motion: Close devices and clean up variables ...");

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
            Serilog.Log.Information("Power Supply: Close devices and clean up variables ...");

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
            Serilog.Log.Information("Robot: Close devices and clean up variables ...");

            try
            {
                foreach (Doosan_Controller? controller in _doosan.Controllers)
                {
                    Serilog.Log.Information($"Close connection robot #{controller.IdDb}");
                    //controller.CloseConnection();
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
            Serilog.Log.Information("Vision: Close devices and clean up variables ...");

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
            #endregion
        }

        #region GUI functions ...
        private void Button_CancelThreads(object sender, RoutedEventArgs e)
        {
            _cancellationTokenSourceMain.Cancel();
            _cancellationTokenSourceCheck.Cancel();
            _cancellationTokenSourcePicture.Cancel();
            foreach (var token in _cancellationTokenSourceWorkflow)
            {
                token.Cancel();
            }

            _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
        }

        private void Button_SavePictures(object sender, RoutedEventArgs e)
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

        private void Button_Homing(object sender, RoutedEventArgs e)
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

        private void Button_Move1(object sender, RoutedEventArgs e)
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

        private void Button_Move2(object sender, RoutedEventArgs e)
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

        private void Button_Move3(object sender, RoutedEventArgs e)
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

        private void Button_Move4(object sender, RoutedEventArgs e)
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

        private void Button_OpenDownholder(object sender, RoutedEventArgs e)
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

        private void Button_CloseDownholder(object sender, RoutedEventArgs e)
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
            //int runs = 0;

            //bool currentValue = false;
            //bool previousValue = false;

            //Workflow workflow;

            //Guid machineId = ComputerInfo.GetComputerUUID();
            //Guid patrickSchoeneggerId = Globals.DbUser_Context.Users.Where(u => u.LoginName == "patrick.schoenegger").FirstOrDefault().Id;
            //Guid softwareId = new Guid();

            //List<DbMain_Project> projects = Globals.DbMain_Context.Projects.Where(p => p.Machines_Ext.Contains(machineId))
            //                                                                  .Include(p => p.ProjectParameter)
            //                                                                  .Include(p => p.Organization)
            //                                                                  .Include(p => p.Contributors)
            //                                                                  //.Include(p => p.Locations)
            //                                                                  .ToList();

            //List<DbStorage_RootDirectory> storage = Globals.DbStorageData_Context.RootDirectories.Where(p => p.Id == projects.FirstOrDefault().Id)
            //                                                                                    .Include(p => p.SubDirectories)
            //                                                                                        .ThenInclude(d => d.Files)
            //                                                                                            .ThenInclude(f => f.QrCode)
            //                                                                                    .Include(p => p.Files)
            //                                                                                        .ThenInclude(f => f.QrCode)
            //                                                                                    .ToList();

            //DbMain_Project projectSelected = projects.FirstOrDefault();                                                             // To specified (Select box)
            //DbStorage_SubDirectory? dataSubdirectorySelected = storage.FirstOrDefault().SubDirectories.FirstOrDefault();            // To specified (Select box)

            //workflow = new Workflow(projectSelected.WorkflowIdExt, patrickSchoeneggerId, machineId, softwareId, Globals.DbMain_Context.ConnectionStringSQLite, Globals.DbMain_Context.DatabaseType, projectSelected.Id, Globals.DbWorkflow_Context.ConnectionStringSQLite, Globals.DbWorkflow_Context.DatabaseType);

            //while (!_tokenWorker[number].IsCancellationRequested)
            //{
            //    if (previousValue && !currentValue)
            //    {
            //        List<ImageHelper> imagesHelper = new List<ImageHelper>();
            //        List<Bitmap> imagesHelperBitmap = new List<Bitmap>();

            //        for (int j = 0; j < _svsVistek.Cameras[number].ImagesRgbCount; j++)
            //        {
            //            imagesHelper.Add(new ImageHelper() { FileId = Guid.NewGuid(), FileRawIds = null, ExposureTime = _svsVistek.Cameras[number].ImagesRgbExposureTime[j], DateDigitized = DateTime.UtcNow, CameraDeviceId = _svsVistek.Cameras[number].IdDb });
            //            imagesHelperBitmap.Add(_svsVistek.Cameras[number].ImagesRgb[j]);
            //        }

            //        #region Run workflow
            //        workflow.RunWithCapturedImages(imagesHelper, imagesHelperBitmap, "C:/tmp", dataSubdirectorySelected.Id, "Meldezettel TLA / UIBK", null);
            //        #endregion

            //        // Write values to GUI
            //        if (number == 0)
            //        {
            //            _imageRight = workflow.Image_Data.Image.ToBitmap().ToImage<Bgr, byte>();

            //            this.Dispatcher.Invoke((Action)(() =>
            //            {
            //                imgImage_Copy.Source = ToBitmapSource(_imageRight);
            //            }));
            //        }

            //        if (number == 1)
            //        {
            //            _imageLeft = workflow.Image_Data.Image.ToBitmap().ToImage<Bgr, byte>();

            //            this.Dispatcher.Invoke((Action)(() =>
            //            {
            //                imgImage_Copy1.Source = ToBitmapSource(_imageLeft);
            //            }));
            //        }

            //        imagesHelper.RemoveAll(x => true);
            //        imagesHelperBitmap.RemoveAll(x => true);

            //        break;
            //    }

            //    if (runs >= 100)
            //    {
            //        Serilog.Log.Error($"Waiting too long for image from camera {_svsVistek.Cameras[number].GetDeviceSerialNumber}...");
            //        break;
            //    }

            //    await Task.Delay(25);

            //    runs++;

            //    previousValue = currentValue;
            //    currentValue = _svsVistek.Cameras[number].IsGrabbingImage;
            //}
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
                if (_taskWorkflow[0].Status == TaskStatus.Running)
                {
                    Serilog.Log.Information("Another thread is already running ...");
                }
                else
                {
                    _cancellationTokenSourceWorkflow[0] = new CancellationTokenSource();
                    _tokenWorkflow[0] = _cancellationTokenSourceWorkflow[0].Token;

                    Thread.Sleep(25);

                    _taskWorkflow[0] = Task.Run(() => Worker(0), _tokenWorkflow[0]);
                }
            }

            if (FistStartLeft)
            {
                if (_taskWorkflow[1].Status == TaskStatus.Running)
                {
                    Serilog.Log.Information("Another thread is already running ...");
                }
                else
                {
                    _cancellationTokenSourceWorkflow[1] = new CancellationTokenSource();
                    _tokenWorkflow[1] = _cancellationTokenSourceWorkflow[1].Token;

                    Thread.Sleep(25);

                    _taskWorkflow[1] = Task.Run(() => Worker(1), _tokenWorkflow[1]);
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