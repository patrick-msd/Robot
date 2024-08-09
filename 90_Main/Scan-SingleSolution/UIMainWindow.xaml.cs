using RC.Motion.Nanotec.MotionController;
using RCRobotDoosanControl;
using Serilog;
using Serilog.Sinks.Grafana.Loki;
using Serilog.Sinks.RichTextBox.Themes;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RC.Scan_SingleSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        #region Global variables
        private static readonly object _syncRoot = new object();

        private Globals_ConfigFile.DoosanConfig? _Robots;

        private Globals_ConfigFile.NanotecConfig? _Nanotec;
        Nlc.DeviceHandle _deviceHandle;

        Thread _thread;

        Task _task;
        CancellationTokenSource _cancellationTokenSource;
        CancellationToken _token;

        float _yDistance = -785.000f;
        float _zDistance = 320.000f;
        #endregion

        public UIMainWindow()
        {
            InitializeComponent();

            #region Initialize logger ...
            // https://github.com/serilog-contrib/serilog-sinks-richtextbox
            //SelfLog.Enable(message => Trace.WriteLine($"INTERNAL ERROR: {message}"));

            const string outputTemplate = "[{Timestamp:HH:mm:ss.ffff} {Level:u3}] {Message:lj}{NewLine}{Exception}";
            //const string outputTemplate = "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties:j}{NewLine}{Exception}";

            List<LokiLabel> lokiLabel = new List<LokiLabel>()
            {
                new LokiLabel()
                {
                    Key = "softwware",
                    Value ="motion_nanotec_motioncontroller_sample"
                },
                 new LokiLabel()
                {
                    Key = "version",
                    Value ="0.0.0.1234154"
                }
            };

#if DEBUG
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                                                    .WriteTo.GrafanaLoki("http://138.232.125.214:3100", labels: lokiLabel)
                                                    .WriteTo.RichTextBox(rtbLogger, outputTemplate: outputTemplate, syncRoot: _syncRoot, theme: RichTextBoxConsoleTheme.Colored)
                                                    .Enrich.WithThreadId()
                                                    .CreateLogger();
#else
            Log.Logger = new LoggerConfiguration().MinimumLevel.Verbose()
                                                    .WriteTo.GrafanaLoki("http://138.232.125.214:3100", labels: lokiLabel)
                                                    .Enrich.WithThreadId()
                                                    .CreateLogger();
#endif

            Log.Information("Start main window ...");
            #endregion 
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            #region Inizialize variables ...
            _Robots = Globals.ConfigFile.Robot.Doosan;
            _Nanotec = Globals.ConfigFile.Motion.Nanotec;

            _thread = new Thread(new ThreadStart(delegate () { }));
            _task = new Task(() => { });

            _cancellationTokenSource = new CancellationTokenSource();
            _token = _cancellationTokenSource.Token;
            #endregion

            SetEndeffectors();

            _deviceHandle = _Nanotec.MotionControllerDeviceConfigs[0].DeviceHandle;
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region Close hardware connections
            Log.Information("################################# Close hardware connections #################################");

            for (int i = 0; i < _Robots.ControlDeviceConfigs.Count; i++)
            {
                Log.Information("Close connection robot #{0}", i);
                _Robots.ControlDeviceConfigs[i].Control.CloseConnection();
                //_Robots.ControlDeviceConfigs[i].Control.Dispose();
                _Robots.ControlDeviceConfigs[i] = null;
            }

            if (_Nanotec.MotionBusHardwareId != null)
            {
                _Nanotec.MotionBusController.CloseBusHardware(_Nanotec.MotionBusHardwareId);
            }

            _Nanotec.MotionBusDeviceIds = null;
            _Nanotec.MotionBusHardwareId = null;
            _Nanotec.MotionBusController = null;
            #endregion
        }




        #region GUI functions ...
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (_task.Status == TaskStatus.Running)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _token = _cancellationTokenSource.Token;

                //_thread = new Thread(new ThreadStart(delegate ()
                _task = Task.Run(async () =>
                {
                    Log.Information("Start ...");

                    float[] targetVel = new float[] { 250.00f, 250.00f };
                    float[] targetAcc = new float[] { 50.00f, 50.00f };

                    float targetTime = 0.0f;
                    MoveMode moveMode = MoveMode.MOVE_MODE_ABSOLUTE;
                    MoveReference moveReference = MoveReference.MOVE_REFERENCE_BASE;
                    BlendingSpeedType blendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE;

                    float motorResolution = 4096;

                    float r1 = 10.000f;                     // Radius Artifact
                    float r2 = 385.000f;                    // Raius Roboter
                    float r2_original = 385.000f;           // Raius Roboter

                    float beta = 0.000f;
                    float beta_original = 0.000f;
                    float betaAbschnittOben = 45.000f;    // 40.000f;    110.000f;     // 25.000f
                    float betaAbschnittUnten = 55.000f; // 50.000f;   70.000f;   // 65.000f;   // 50.000f

                    float camSteps = 0.000f;

                    float camDepthField = 0.000f;
                    float CamDepthFieldSteps = 0.000f;
                    float camDepthFieldResolution = 0.000f;

                    float motorTurns = 0.000f;
                    float motorStepsPerTurn = 0.000f;

                    float picture = 1.00f;
                    float pictures = 0.000f;

                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        r2_original = (float)Convert.ToDouble(txtTestProgram1_Radius2.Text.Replace(",", "."));

                        camSteps = (float)Convert.ToDouble(txtTestProgram1_CamSteps.Text.Replace(",", "."));

                        camDepthField = (float)Convert.ToDouble(txtTestProgram1_CamDepthField.Text.Replace(",", "."));
                        camDepthFieldResolution = (float)Convert.ToDouble(txtTestProgram1_CamDepthFieldResolution.Text.Replace(",", "."));

                        motorTurns = (float)Convert.ToDouble(txtTestProgram1_MotorTurns.Text.Replace(",", "."));
                        motorStepsPerTurn = (float)Convert.ToDouble(txtTestProgram1_MotorStepsPerTurn.Text.Replace(",", "."));
                    }));

                    if (camDepthField == 0)
                    {
                        CamDepthFieldSteps = 1.000f;
                    }
                    else
                    {
                        CamDepthFieldSteps = camDepthField / camDepthFieldResolution;
                    }

                    // Start beta berechnen
                    beta = beta - betaAbschnittOben;

                    pictures = (motorTurns * motorStepsPerTurn) * CamDepthFieldSteps;
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        pgbProgress.Minimum = 0;
                        pgbProgress.Maximum = pictures;
                    }));








                    _Nanotec.MotionBusController.DeviceConnect(_deviceHandle);
                    _Nanotec.MotionBusController.QuickStop(_deviceHandle);

                    // Set the Mode to Profile Position
                    _Nanotec.MotionBusController.OperationMode(_deviceHandle, MotionBusController.OperationModeType.Position);


                    // Switch to Operation Enabled
                    _Nanotec.MotionBusController.EnableOperation(_deviceHandle);

                    // Set to absolute movement
                    _Nanotec.MotionBusController.SetAbsolutMovement(_deviceHandle);

                    // Set to relative movement
                    //_Nanotec.MotionController.SetRelativMovement(_deviceHandle);

                    // Change setpoint immediately
                    _Nanotec.MotionBusController.ChangeSetPointImmediately(_deviceHandle, true);

                    // Start position
                    _Nanotec.MotionBusController.WriteNumber(_deviceHandle, 0, new Nlc.OdIndex(0x607A, 0x00), 32);
                    _Nanotec.MotionBusController.NewSetPointTrigger(_deviceHandle);




                    _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_AUTONOMOUS);

                    float[] poseStart1 = Coordinates(r1, r2_original, -90);
                    _Robots.ControlDeviceConfigs[1].Control.MoveL(poseStart1, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                    await Task.Delay(125);
                    float[] poseRobott = _Robots.ControlDeviceConfigs[1].Control.GetCurrentPosx()._fTargetPos;
                    Log.Information("Pose calculated #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000} --> current: x={7:000.000}, y={8:000.000}, z={9:000.000}, a={10:000.000}, b={11:000.000}, c={12:000.000}", 0, poseStart1[0], poseStart1[1], poseStart1[2], poseStart1[3], poseStart1[4], poseStart1[5], poseRobott[0], poseRobott[1], poseRobott[2], poseRobott[3], poseRobott[4], poseRobott[5]);

                    float[] poseStart2 = Coordinates(r1, r2_original, beta);
                    _Robots.ControlDeviceConfigs[1].Control.MoveL(poseStart2, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                    await Task.Delay(125);
                    float[] poseRobottt = _Robots.ControlDeviceConfigs[1].Control.GetCurrentPosx()._fTargetPos;
                    Log.Information("Pose calculated #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000} --> current: x={7:000.000}, y={8:000.000}, z={9:000.000}, a={10:000.000}, b={11:000.000}, c={12:000.000}", 0, poseStart2[0], poseStart2[1], poseStart2[2], poseStart2[3], poseStart2[4], poseStart2[5], poseRobottt[0], poseRobottt[1], poseRobottt[2], poseRobottt[3], poseRobottt[4], poseRobottt[5]);




                    await Task.Delay(2500);




                    // Wie oft soll das Artifakt aufgenommen werden (Anzahl der Umdrehungen)
                    for (int motorTurn = 1; motorTurn <= motorTurns; motorTurn = motorTurn + 1)
                    {
                        if (!_token.IsCancellationRequested)
                        {
                            Log.Information("Umdrehung #{0}", motorTurn);

                            // Start position
                            _Nanotec.MotionBusController.EnableOperation(_deviceHandle);
                            _Nanotec.MotionBusController.WriteNumber(_deviceHandle, 0, new Nlc.OdIndex(0x607A, 0x00), 32);
                            _Nanotec.MotionBusController.NewSetPointTrigger(_deviceHandle);
                            await Task.Delay(2500);
                            _Nanotec.MotionBusController.QuickStop(_deviceHandle);

                            float[] pose1 = Coordinates(r1, r2_original, beta);
                            _Robots.ControlDeviceConfigs[1].Control.MoveL(pose1, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                            await Task.Delay(125);
                            float[] pose1Robot = _Robots.ControlDeviceConfigs[1].Control.GetCurrentPosx()._fTargetPos;
                            Log.Information("Pose1 calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", pose1[0], pose1[1], pose1[2], pose1[3], pose1[4], pose1[5], pose1Robot[0], pose1Robot[1], pose1Robot[2], pose1Robot[3], pose1Robot[4], pose1Robot[5]);

                            // Wie detailiert soll das Artifakt aufgenommen werden (Schritte pro Umdrehung)
                            for (int motorStep = 0; motorStep < motorStepsPerTurn; motorStep = motorStep + 1)
                            {
                                if (!_token.IsCancellationRequested)
                                {
                                    // Start position for taking a photo
                                    r2 = r2_original + (camDepthField / 2);

                                    float angle = (360 / motorStepsPerTurn) * motorStep;
                                    long steps = (long)((motorResolution / 360) * angle);
                                    _Nanotec.MotionBusController.EnableOperation(_deviceHandle);
                                    _Nanotec.MotionBusController.WriteNumber(_deviceHandle, steps, new Nlc.OdIndex(0x607A, 0x00), 32);
                                    _Nanotec.MotionBusController.NewSetPointTrigger(_deviceHandle);
                                    await Task.Delay(250);
                                    _Nanotec.MotionBusController.QuickStop(_deviceHandle);
                                    Log.Information("Umdrehung #{0} & Schritt #{1} --> Winkel: {2}° mit {3} steps", motorTurn, motorStep + 1, angle, steps);

                                    for (int depthStep = 0; depthStep < CamDepthFieldSteps; depthStep++)
                                    {
                                        if (!_token.IsCancellationRequested)
                                        {
                                            this.Dispatcher.Invoke((Action)(() =>
                                            {
                                                lblProgress.Content = string.Format("{0} / {1}", picture, pictures);
                                                pgbProgress.Value = picture;
                                            }));

                                            if (CamDepthFieldSteps > 1)
                                            {
                                                float[] pose2 = Coordinates(r1, r2, beta);
                                                _Robots.ControlDeviceConfigs[1].Control.MoveL(pose2, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                                                await Task.Delay(125);
                                                float[] pose2Robot = _Robots.ControlDeviceConfigs[1].Control.GetCurrentPosx()._fTargetPos;
                                                Log.Information("Pose2 calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", pose2[0], pose2[1], pose2[2], pose2[3], pose2[4], pose2[5], pose2Robot[0], pose2Robot[1], pose2Robot[2], pose2Robot[3], pose2Robot[4], pose2Robot[5]);
                                            }

                                            await Task.Delay(125);
                                            _Robots.ControlDeviceConfigs[1].Control.SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1, true);
                                            await Task.Delay(755);
                                            _Robots.ControlDeviceConfigs[1].Control.SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1, false);

                                            await Task.Delay(1000);

                                            r2 = r2 - camDepthFieldResolution;
                                            picture++;
                                        }
                                        else
                                        {
                                            _Nanotec.MotionBusController.DeviceDisconnect(_deviceHandle);
                                            _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                                            return;
                                        }
                                    }
                                }
                                else
                                {
                                    _Nanotec.MotionBusController.DeviceDisconnect(_deviceHandle);
                                    _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                                    return;
                                }
                            }

                            beta = beta - (((180 - (betaAbschnittOben + betaAbschnittUnten)) / (motorTurns - 1)));

                            Log.Information("");
                        }
                        else
                        {
                            _Nanotec.MotionBusController.DeviceDisconnect(_deviceHandle);
                            _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                            return;
                        }
                    }
                }, _token);
                //_thread.Start();
            }
        }

        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (_task.Status == TaskStatus.Running)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _token = _cancellationTokenSource.Token;

                //_thread = new Thread(new ThreadStart(delegate ()
                _task = Task.Run(async () =>
                {
                    Log.Information("Start ...");





                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        _yDistance = (float)Convert.ToDouble(txtTestProgram2_PositionZ_Copy.Text.Replace(",", "."));
                        _zDistance = (float)Convert.ToDouble(txtTestProgram2_PositionZ_Copy1.Text.Replace(",", "."));
                    }));





                    float[] targetVel = new float[] { 250.00f, 250.00f };
                    float[] targetAcc = new float[] { 50.00f, 50.00f };

                    float targetTime = 0.0f;
                    MoveMode moveMode = MoveMode.MOVE_MODE_ABSOLUTE;
                    MoveReference moveReference = MoveReference.MOVE_REFERENCE_BASE;
                    BlendingSpeedType blendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE;

                    float motorResolution = 4096;

                    float r1 = 10.000f;                     // Radius Artifact
                    float r2 = 385.000f;                    // Raius Roboter
                    float r2_original = 385.000f;           // Raius Roboter

                    float beta = 0.000f;
                    float beta_original = 0.000f;

                    float camAngle = 0.000f;

                    float camDepthField = 0.000f;
                    float CamDepthFieldSteps = 0.000f;
                    float camDepthFieldResolution = 0.000f;

                    float picture = 1.00f;
                    float pictures = 0.000f;


                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        r2_original = (float)Convert.ToDouble(txtTestProgram2_Radius2.Text.Replace(",", "."));

                        camAngle = (float)Convert.ToDouble(txtTestProgram2_CamAngle.Text.Replace(",", "."));

                        camDepthField = (float)Convert.ToDouble(txtTestProgram2_CamDepthField.Text.Replace(",", "."));
                        camDepthFieldResolution = (float)Convert.ToDouble(txtTestProgram2_CamDepthFieldResolution.Text.Replace(",", "."));
                    }));

                    if (camDepthField == 0)
                    {
                        CamDepthFieldSteps = 1.000f;
                    }
                    else
                    {
                        CamDepthFieldSteps = camDepthField / camDepthFieldResolution;
                    }


                    // Start beta berechnen
                    beta = camAngle;

                    pictures = CamDepthFieldSteps;
                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        pgbProgress.Minimum = 0;
                        pgbProgress.Maximum = pictures;
                    }));







                    _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_AUTONOMOUS);

                    //float[] poseStart1 = Coordinates(r1, r2_original, -90);
                    //_Robots.ControlDeviceConfigs[1].Control.MoveL(poseStart1, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                    //await Task.Delay(125);
                    //float[] poseRobott = _Robots.ControlDeviceConfigs[1].Control.GetCurrentPosx()._fTargetPos;
                    //Log.Information("Pose calculated #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000} --> current: x={7:000.000}, y={8:000.000}, z={9:000.000}, a={10:000.000}, b={11:000.000}, c={12:000.000}", 0, poseStart1[0], poseStart1[1], poseStart1[2], poseStart1[3], poseStart1[4], poseStart1[5], poseRobott[0], poseRobott[1], poseRobott[2], poseRobott[3], poseRobott[4], poseRobott[5]);

                    float[] poseStart2 = Coordinates(r1, r2_original, beta);
                    poseStart2[2] = poseStart2[2];
                    _Robots.ControlDeviceConfigs[1].Control.MoveL(poseStart2, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                    await Task.Delay(125);
                    float[] poseRobottt = _Robots.ControlDeviceConfigs[1].Control.GetCurrentPosx()._fTargetPos;
                    Log.Information("Pose calculated #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000} --> current: x={7:000.000}, y={8:000.000}, z={9:000.000}, a={10:000.000}, b={11:000.000}, c={12:000.000}", 0, poseStart2[0], poseStart2[1], poseStart2[2], poseStart2[3], poseStart2[4], poseStart2[5], poseRobottt[0], poseRobottt[1], poseRobottt[2], poseRobottt[3], poseRobottt[4], poseRobottt[5]);




                    await Task.Delay(2500);





                    // Start position for taking a photo
                    r2 = r2_original + (camDepthField / 2);


                    for (int depthStep = 0; depthStep < CamDepthFieldSteps; depthStep++)
                    {
                        if (!_token.IsCancellationRequested)
                        {
                            this.Dispatcher.Invoke((Action)(() =>
                            {
                                lblProgress.Content = string.Format("{0} / {1}", picture, pictures);
                                pgbProgress.Value = picture;
                            }));

                            if (CamDepthFieldSteps > 1)
                            {
                                float[] pose2 = Coordinates(r1, r2, beta);
                                pose2[2] = pose2[2];
                                _Robots.ControlDeviceConfigs[1].Control.MoveL(pose2, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                                await Task.Delay(125);
                                float[] pose2Robot = _Robots.ControlDeviceConfigs[1].Control.GetCurrentPosx()._fTargetPos;
                                Log.Information("Pose2 calculated: x={0:000.000}, y={1:000.000}, z={2:000.000}, a={3:000.000}, b={4:000.000}, c={5:000.000} --> current: x={6:000.000}, y={7:000.000}, z={8:000.000}, a={9:000.000}, b={10:000.000}, c={11:000.000}", pose2[0], pose2[1], pose2[2], pose2[3], pose2[4], pose2[5], pose2Robot[0], pose2Robot[1], pose2Robot[2], pose2Robot[3], pose2Robot[4], pose2Robot[5]);
                            }

                            await Task.Delay(125);
                            _Robots.ControlDeviceConfigs[1].Control.SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1, true);
                            await Task.Delay(500);
                            _Robots.ControlDeviceConfigs[1].Control.SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1, false);

                            await Task.Delay(1000);

                            r2 = r2 - camDepthFieldResolution;
                            picture++;
                        }
                        else
                        {
                            _Nanotec.MotionBusController.DeviceDisconnect(_deviceHandle);
                            _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                            return;
                        }
                    }

                    _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                }, _token);
                //_thread.Start();
            }
        }




        #endregion



        #region Functions ...

        float[] Coordinates(float r1, float r2, float beta)
        {
            float yDiff = 0.000f;
            float zDiff = 0.000f;

            float x = 0.000f;
            float y = 0.000f;
            float z = 0.000f;
            float a = 0.000f;
            float b = 0.000f;
            float c = 0.000f;

            float zeroRefAngle = -90.000f;

            if (beta == zeroRefAngle)
            {
                yDiff = r2;
                zDiff = 0;
            }
            else if (beta > zeroRefAngle)
            {
                yDiff = Math.Abs((float)Math.Sin(ConvertToRadians(beta)) * r2);
                zDiff = -Math.Abs((float)Math.Cos(ConvertToRadians(beta)) * r2);

                //float zCorrection = (-0.2222222222222f) * beta - 20.000f;
                //zDiff = zDiff - zCorrection;
            }
            else if (beta < zeroRefAngle)
            {
                yDiff = Math.Abs((float)Math.Sin(ConvertToRadians(beta)) * r2);
                zDiff = Math.Abs((float)Math.Cos(ConvertToRadians(beta)) * r2);

                //float zCorrection = (-0.5237f) * beta - 49.215f;
                //zDiff = zDiff - zCorrection;
            }

            x = 6.250f;
            y = _yDistance + yDiff;
            z = _zDistance + zDiff;
            a = 90.000f;                 // ???
            b = beta;
            c = 180.000f;                 // ???

            float[] pose = { x, y, z, a, b, c };

            return pose;
        }

        public float ConvertToRadians(float angle)
        {
            return (float)(Math.PI / 180) * angle;
        }
        #endregion

        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (_task.Status == TaskStatus.Running || _task.Status == TaskStatus.WaitingForActivation)
            {
                //_thread.Interrupt();
                _cancellationTokenSource.Cancel();

                _Nanotec.MotionBusController.DeviceDisconnect(_deviceHandle);
                _Robots.ControlDeviceConfigs[1].Control.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
            }
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            SetEndeffectors();
        }








        void SetEndeffectors()
        {
            string Tool = "Camera";

            float[] _toolCenterPosition = { (float)Convert.ToDouble(txtTestProgram2_PositionZ_Copy2.Text.Replace(",", ".")), 0.000f, (float)Convert.ToDouble(txtTestProgram2_PositionZ_Copy3.Text.Replace(",", ".")), 0.000f, 0.000f, 0.000f };

            float ToolWeight = 0.00f;

            float[] ToolCenterOfGravitiy = { 0.000f, 0.000f, 0.000f };
            float[] ToolInertiaValue = { 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

            if (_Robots.ControlDeviceConfigs.Count > 0)
            {
                for (int i = 0; i < _Robots.ControlDeviceConfigs.Count; i++)
                {
                    _Robots.ControlDeviceConfigs[i].Control.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                    Thread.Sleep(250);

                    bool asd = _Robots.ControlDeviceConfigs[i].Control.AddTool(Tool, ToolWeight, ToolCenterOfGravitiy, ToolInertiaValue);
                    Thread.Sleep(125);
                    bool aasdssd = _Robots.ControlDeviceConfigs[i].Control.SetTool(Tool);

                    bool afdasd = _Robots.ControlDeviceConfigs[i].Control.AddTCP(Tool, _toolCenterPosition);
                    Thread.Sleep(125);
                    bool aasdsd = _Robots.ControlDeviceConfigs[i].Control.SetTCP(Tool);

                    Log.Information("Robot \"" + _Robots.ControlDeviceConfigs[i].DeviceName + "\" Current Tool: " + _Robots.ControlDeviceConfigs[i].Control.GetTool());
                    Log.Information("Robot \"" + _Robots.ControlDeviceConfigs[i].DeviceName + "\" Current Tool: " + _Robots.ControlDeviceConfigs[i].Control.GetTCP());
                }
            }
        }

    }
}
