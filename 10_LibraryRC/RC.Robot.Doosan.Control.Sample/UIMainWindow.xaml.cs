using RC.Lib.Control.Doosan;
using RCRobotDoosanControl;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.RichTextBox.Themes;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace RC.Robot.Doosan.Sample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        #region Global variables
        private Doosan_Container? _doosan;

        private static readonly object _syncRoot = new object();

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

            Title = Globals.ApplicationTitle + " - V" + Globals.ApplicationVersion.ToString();

            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Verbose()
                                .WriteTo.Sink((ILogEventSink)Log.Logger)
                                //.WriteTo.Debug(outputTemplate: Globals.LokiOutputTemplate)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels)
                                //.WriteTo.GrafanaLoki(Globals.LokiUri, labels: Globals.LokiLabels, textFormatter: new ExpressionTemplate("{ {@t, @mt, @l:u3}, @i, @x, @p} }\n"))
                                .WriteTo.RichTextBox(rtbLogger, outputTemplate: Globals.LokiOutputTemplate, syncRoot: _syncRoot, theme: RichTextBoxConsoleTheme.Colored)
                                .Enrich.WithThreadId()
                                .Enrich.WithThreadName()
                                .CreateLogger();

            Log.Information("Start main window ...");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            #region Inizialize variables ...
            _doosan = Globals.Device.Robot.Doosan;
            #endregion

            #region Inizialize variables ...
            _thread = new Thread(new ThreadStart(delegate () { }));
            _task = new Task(() => { });

            _cancellationTokenSource = new CancellationTokenSource();
            _token = _cancellationTokenSource.Token;
            #endregion


            string Tool = "Camera";

            float[] _toolCenterPosition = { 30.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };        // Niederstreifer Neu mit Rollen

            float ToolWeight = 0.00f;

            float[] ToolCenterOfGravitiy = { 0.000f, 0.000f, 0.000f };
            float[] ToolInertiaValue = { 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

            foreach (Doosan_Controller cotnroller in _doosan.Controllers)
            {
                cotnroller.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                Thread.Sleep(250);

                cotnroller.AddTool(Tool, ToolWeight, ToolCenterOfGravitiy, ToolInertiaValue);
                cotnroller.SetTool(Tool);

                cotnroller.AddTCP(Tool, _toolCenterPosition);
                cotnroller.SetTCP(Tool);

                //Console.WriteLine("Robot \"" + _Robots.ControlDeviceConfigs[i].DeviceName + "\" Current Tool: " + cotnroller.GetTool());
                //Console.WriteLine("Robot \"" + _Robots.ControlDeviceConfigs[i].DeviceName + "\" Current Tool: " + cotnroller.GetTCP());
                Console.WriteLine("Robot \" Current Tool: " + cotnroller.GetTool());
                Console.WriteLine("Robot \" Current Tool: " + cotnroller.GetTCP());
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            #region Close robot devices
            Log.Information("Robot: Close devices and clean up variabels ...");

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
                Log.Error(ex.Message);
            }
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

                    float r1 = 10.000f;          // Radius Artifact
                    float r2 = 385.000f;         // Raius Roboter

                    float beta = -90.000f;
                    float betaAbschnitt = 25.00f;

                    int delay = 1;

                    int umdrehung_Anzahl = 4;
                    int schritteProUmdrehung_Anzahl = 20;
                    int schritteKamera_Anzahl = 4;

                    // Start beta berechnen
                    beta = beta + betaAbschnitt;

                    _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_AUTONOMOUS);

                    for (int umdrehung = 1; umdrehung <= umdrehung_Anzahl; umdrehung = umdrehung + 1)
                    {
                        Log.Information("Umdrehung #{0}", umdrehung);

                        float[] pose = Coordinates(r1, r2, beta);
                        Log.Information("Pose #{0}: x={1}, y={2}, z={3}, a={4}, b={5}, c={6}", umdrehung, pose[0], pose[1], pose[2], pose[3], pose[4], pose[5]);
                        //_Robots.ControlDeviceConfigs[0].Control.MoveL(pose, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);

                        for (int schrittProUmdrehung = 0; schrittProUmdrehung < schritteProUmdrehung_Anzahl; schrittProUmdrehung = schrittProUmdrehung + 1)
                        {
                            float winkel = (360 / schritteProUmdrehung_Anzahl) * schrittProUmdrehung;
                            Log.Information("Umdrehung #{0} & Schritt #{1} --> Winkel: {2}° mit {3} steps", umdrehung, schrittProUmdrehung + 1, winkel, 123);
                            // Move Stepper

                            await Task.Delay(delay);

                            // IO setzen

                            await Task.Delay(delay);
                        }

                        beta = beta + ((180 - (2 * betaAbschnitt)) / (umdrehung_Anzahl - 1));

                        Log.Information("");
                    }

                    _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
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

                    float[] targetVel = new float[] { 125.00f, 125.00f };
                    float[] targetAcc = new float[] { 25.00f, 25.00f };

                    float targetTime = 0.0f;
                    MoveMode moveMode = MoveMode.MOVE_MODE_ABSOLUTE;
                    MoveReference moveReference = MoveReference.MOVE_REFERENCE_BASE;
                    BlendingSpeedType blendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE;

                    float r1 = 10.000f;          // Radius artifact
                    float r2 = 365.000f;         // Radius robot --> OLD 375

                    float beta = 0.000f;
                    float distance = 0.000f;
                    float stepLength = 0.000f;
                    float pictures = 0.000f;
                    float count = 0.000f;


                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        r2 = (float)Convert.ToDouble(txtTestProgram2_Radius1.Text.Replace(",", "."));
                        beta = (float)Convert.ToDouble(txtTestProgram2_Angle.Text.Replace(",", "."));
                        distance = (float)Convert.ToDouble(txtTestProgram2_Distance.Text.Replace(",", "."));
                        stepLength = (float)Convert.ToDouble(txtTestProgram2_Steps.Text.Replace(",", "."));
                        //pictures = (float)Convert.ToDouble(txtTestProgram2_Pictures.Text.Replace(",", "."));
                    }));

                    // New r2
                    r2 = r2 + (distance / 2);

                    count = distance / stepLength;

                    this.Dispatcher.Invoke((Action)(() =>
                    {
                        txtTestProgram2_Pictures.Text = string.Format("{0}", count);
                    }));

                    _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_AUTONOMOUS);

                    float[] poseStart = Coordinates(r1, r2 - stepLength, beta);
                    _doosan.Controllers[0].MoveL(poseStart, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                    await Task.Delay(125);
                    float[] poseRobott = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                    Log.Information("Pose calculated #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000} --> Pose Robot: x={7:000.000}, y={8:000.000}, z={9:000.000}, a={10:000.000}, b={11:000.000}, c={12:000.000}", 0, poseStart[0], poseStart[1], poseStart[2], poseStart[3], poseStart[4], poseStart[5], poseRobott[0], poseRobott[1], poseRobott[2], poseRobott[3], poseRobott[4], poseRobott[5]);


                    await Task.Delay(2500);

                    for (int i = 0; i < count; i = i + 1)
                    {
                        if (!_token.IsCancellationRequested)
                        {
                            r2 = r2 - stepLength;

                            float[] pose = Coordinates(r1, r2, beta);
                            //Log.Information("Pose #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000}", i + 1, pose[0], pose[1], pose[2], pose[3], pose[4], pose[5]);
                            _doosan.Controllers[0].MoveL(pose, targetVel, targetAcc, targetTime, moveMode, moveReference, 0, blendingSpeedType);
                            await Task.Delay(125);
                            float[] poseRobot = _doosan.Controllers[0].GetCurrentPosx()._fTargetPos;
                            //Log.Information("Pose #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000}", i + 1, pose[0], pose[1], pose[2], pose[3], pose[4], pose[5]);
                            Log.Information("Pose calculated #{0}: x={1:000.000}, y={2:000.000}, z={3:000.000}, a={4:000.000}, b={5:000.000}, c={6:000.000} --> Pose Robot: x={7:000.000}, y={8:000.000}, z={9:000.000}, a={10:000.000}, b={11:000.000}, c={12:000.000}", i + 1, pose[0], pose[1], pose[2], pose[3], pose[4], pose[5], poseRobot[0], poseRobot[1], poseRobot[2], poseRobot[3], poseRobot[4], poseRobot[5]);


                            await Task.Delay(125);
                            _doosan.Controllers[0].SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1, true);
                            await Task.Delay(500);
                            _doosan.Controllers[0].SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1, false);

                            await Task.Delay(1000);
                        }
                        else
                        {
                            return;
                        }
                    }

                    _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                }, _token);
                //_thread.Start();
            }
        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            Log.Information("");
            Log.Information(_doosan.Controllers[0].GetCurrentPosj()._fPosition[0].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosj()._fPosition[1].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosj()._fPosition[2].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosj()._fPosition[3].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosj()._fPosition[4].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosj()._fPosition[5].ToString());
            Log.Information("");
            Log.Information(_doosan.Controllers[0].GetCurrentPosx()._fTargetPos[0].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosx()._fTargetPos[1].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosx()._fTargetPos[2].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosx()._fTargetPos[3].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosx()._fTargetPos[4].ToString());
            Log.Information(_doosan.Controllers[0].GetCurrentPosx()._fTargetPos[5].ToString());


            if (_task.Status == TaskStatus.Running)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _cancellationTokenSource = new CancellationTokenSource();
                _token = _cancellationTokenSource.Token;

                _task = Task.Run(async () =>
                {
                    Log.Information("Start ...");

                    float[] targetVel = new float[] { 10.00f, 10.00f };
                    float[] targetAcc = new float[] { 10.00f, 10.00f };

                    float targetTime = 0.0f;
                    MoveReference moveReference = MoveReference.MOVE_REFERENCE_BASE;
                    BlendingSpeedType blendingSpeedType = BlendingSpeedType.BLENDING_SPEED_TYPE_DUPLICATE;

                    _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_AUTONOMOUS);







                    /* 
                     // Testing - MoveL
                       float[] pose = new float[] { 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f};
                       Log.Debug(pose[0] + " " + pose[1] + " " + pose[2]);
                       _Robots.ControlDeviceConfigs[1].Control.MoveL(pose, targetVel, targetAcc, targetTime, MoveMode.MOVE_MODE_RELATIVE, moveReference, 0, blendingSpeedType);

                    // Testing - MoveJ
                        float[] pose = new float[] { 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f};
                       _Robots.ControlDeviceConfigs[1].Control.MoveJ(pose, targetVel[0], targetAcc[0], targetTime,  MoveMode.MOVE_MODE_RELATIVE); 


                    // Testing - MoveJX
                       // moves weird - wont stop?
                         float[] pose = new float[] { 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f };
                        _Robots.ControlDeviceConfigs[1].Control.MoveJX(pose, 2, targetVel[0], targetAcc[0], targetTime, MoveMode.MOVE_MODE_RELATIVE, moveReference, 0, blendingSpeedType);

                    // Testing - MoveC
                    float[][] pose = new float[2][];
                    pose[0] = new float[] { 2.0f, 2.0f, 2.0f, 0.0f, 0.0f, 0.0f };
                    pose[1] = new float[] { 5.0f, 5.0f, 1.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveC(pose, targetVel, targetAcc,0, MoveMode.MOVE_MODE_RELATIVE);

                    // Testing - MoveSJ
                    float[][] pose = new float[100][];
                    pose[0] = new float[] { -2.0f, -2.0f, -2.0f, 0.0f, 0.0f, 0.0f };
                    pose[1] = new float[] { 5.0f, 5.0f, 5.0f, 0.0f, 0.0f, 0.0f };
                    pose[2] = new float[] { 0.0f, 0.0f, -15.0f, 0.0f, 0.0f, 0.0f };

                    _Robots.ControlDeviceConfigs[1].Control.MoveSJ(pose, 3, targetVel[0], targetAcc[0],0, MoveMode.MOVE_MODE_RELATIVE);

                    // Testing - MoveSX
                    float[][] pose = new float[100][];
                    pose[0] = new float[] { -2.0f, -2.0f, -2.0f, 0.0f, 0.0f, 0.0f };
                    pose[1] = new float[] { 5.0f, 5.0f, 5.0f, 0.0f, 0.0f, 0.0f };
                    pose[2] = new float[] { 0.0f, 0.0f, -15.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveSX(pose, 3, targetVel, targetAcc, 0, MoveMode.MOVE_MODE_RELATIVE, moveReference);

                    // Testing - MoveB -TODO

                    // Testing - MoveSpiral
                    _Robots.ControlDeviceConfigs[1].Control.MoveSpiral(TaskAxis.TASK_AXIS_Z, 3f, 10f, 15f, targetVel,targetAcc);

                    // Testing - MovePeriodic
                    float[] amp = { 50, 50, 0, 0, 0, 0 };
                    float[] period = { 3, 1.5f, 0, 0, 0, 0 };
                    _Robots.ControlDeviceConfigs[1].Control.MovePeriodic(amp,period, 0.3f, 2);

                    // Testing - MoveLAsync
                    float[] pose = new float[] { 5.0f, 5.0f, 1.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveLAsync(pose, targetVel, targetAcc, targetTime, MoveMode.MOVE_MODE_RELATIVE, moveReference, blendingSpeedType);
                    _Robots.ControlDeviceConfigs[1].Control.MoveWait();

                    // Testing - MoveJAsync
                    float[] pose = new float[] { 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveJAsync(pose, targetVel[0], targetAcc[0], targetTime, MoveMode.MOVE_MODE_RELATIVE);
                    _Robots.ControlDeviceConfigs[1].Control.MoveWait();

                    // Testing - MoveJXAsync
                    // doesnt do anything ??
                    float[] pose = new float[] { 1.0f, 1.0f, 1.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveJXAsync(pose, 2, targetVel[0], targetAcc[0], targetTime,  MoveMode.MOVE_MODE_RELATIVE, moveReference, blendingSpeedType);

                    // Testing - MoveCAsync
                    float[][] pose = new float[2][];
                    pose[0] = new float[] { 2.0f, 2.0f, 2.0f, 0.0f, 0.0f, 0.0f };
                    pose[1] = new float[] { 5.0f, 5.0f, 1.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveCAsync(pose, targetVel, targetAcc,0, MoveMode.MOVE_MODE_RELATIVE);
                    _Robots.ControlDeviceConfigs[1].Control.MoveWait();

                    // Testing - MoveSJAsync
                    float[][] pose = new float[100][];
                    pose[0] = new float[] { -2.0f, -2.0f, -2.0f, 0.0f, 0.0f, 0.0f };
                    pose[1] = new float[] { 5.0f, 5.0f, 5.0f, 0.0f, 0.0f, 0.0f };
                    pose[2] = new float[] { 0.0f, 0.0f, -15.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveSJAsync(pose, 3, targetVel[0], targetAcc[0], 0, MoveMode.MOVE_MODE_RELATIVE);
                    _Robots.ControlDeviceConfigs[1].Control.MoveWait();

                    // Testing - MoveSXAsync
                    float[][] pose = new float[100][];
                    pose[0] = new float[] { -2.0f, -2.0f, -2.0f, 0.0f, 0.0f, 0.0f };
                    pose[1] = new float[] { 5.0f, 5.0f, 5.0f, 0.0f, 0.0f, 0.0f };
                    pose[2] = new float[] { 0.0f, 0.0f, -15.0f, 0.0f, 0.0f, 0.0f };
                    _Robots.ControlDeviceConfigs[1].Control.MoveSXAsync(pose, 3, targetVel, targetAcc, 0, MoveMode.MOVE_MODE_RELATIVE, moveReference);
                    _Robots.ControlDeviceConfigs[1].Control.MoveWait();

                    // Testing - MoveSpiralAsync
                    _Robots.ControlDeviceConfigs[1].Control.MoveSpiralAsync(TaskAxis.TASK_AXIS_Z, 3f, 10f, 15f, targetVel, targetAcc);
                    _Robots.ControlDeviceConfigs[1].Control.MoveWait();

                    // Testing - MovePeriodicAsync
                    float[] amp = { 50, 50, 0, 0, 0, 0 };
                    float[] period = { 3, 1.5f, 0, 0, 0, 0 };
                    _Robots.ControlDeviceConfigs[1].Control.MovePeriodicAsync(amp, period, 0.3f, 2);
                    _Robots.ControlDeviceConfigs[1].Control.MoveWait();
                    */

                    _doosan.Controllers[0].SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
                    Log.Information("Stop ...");


                }, _token);
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
            }
            else if (beta < zeroRefAngle)
            {
                yDiff = Math.Abs((float)Math.Sin(ConvertToRadians(beta)) * r2);
                zDiff = Math.Abs((float)Math.Cos(ConvertToRadians(beta)) * r2);
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
                _doosan.Controllers[0].SetDigitalOutput(GpioCtrlboxDigitalIndex.GPIO_CTRLBOX_DIGITAL_INDEX_1, false);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string Tool = "Tool1";
            string TCP = "TCP1";

            // Niederstreifer Neu mit Rolle ausgefahren
            float[] toolCenterPositionNewAusgefahren = { 0.000f, 0.000f, 145.000f, 0.000f, 0.000f, 0.000f };
            // Niederstreifer Neu mit Rolle eingefahren
            //float[] toolCenterPositionNewEingefahren = { 0.000f, 0.000f, 112.500f, 0.000f, 0.000f, 0.000f };
            // Niederstreifer Neu mit Rolle eingefahren
            float[] toolCenterPositionNewEingefahren = { 0.000f, 0.000f, 125.000f, 0.000f, 0.000f, 0.000f };

            float ToolWeight = -2.50f;

            float[] ToolCenterOfGravitiy = { 10.000f, 10.000f, 10.000f };
            float[] ToolInertiaValue = { 0.000f, 0.000f, 0.000f, 0.000f, 0.000f, 0.000f };

            // Read values from GUI
            this.Dispatcher.Invoke((Action)(() =>
            {
                ToolWeight = (float)Convert.ToDouble(txtTestProgram2_Pictures_Copy.Text.Replace(".", ","));
            }));

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


                    _doosan.Controllers[i].AddTCP(TCP, toolCenterPositionNewEingefahren);
                    Thread.Sleep(50);
                    _doosan.Controllers[i].SetTCP(TCP);

                    Thread.Sleep(50);

                    string asd = _doosan.Controllers[i].GetTool();
                    string asdsa = _doosan.Controllers[i].GetTCP();


                    Serilog.Log.Information("Robot \" Current Tool: " + _doosan.Controllers[i].GetTool());
                    Serilog.Log.Information("Robot \" Current TCP: " + _doosan.Controllers[i].GetTCP());
                    //Serilog.Log.Information("Robot \"" + _doosan.Controllers[i].DeviceName + "\" Current Tool: " + _doosan.Controllers[i].GetTool());
                    //Serilog.Log.Information("Robot \"" + _doosan.Controllers[i].DeviceName + "\" Current TCP: " + _doosan.Controllers[i].GetTCP());

                    Thread.Sleep(250);

                    _doosan.Controllers[i].SetRobotMode(mode);
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            float[] forces = new float[] { 0.00f, 0.00f, 0.00f, 0.00f, 0.00f, 0.00f };
            forces = _doosan.Controllers[0].GetToolForce()._fForce;
            Serilog.Log.Debug($"Force: {forces[0]}, {forces[1]}, {forces[2]}, {forces[3]}, {forces[4]}, {forces[5]}");

        }
    }
}
