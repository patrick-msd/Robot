using RC.Lib.Motion;
using Serilog;
using Serilog.Core;
using Serilog.Sinks.RichTextBox.Themes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Windows;

namespace RC.Motion.Nanotec.Sample
{
    /// <summary>
    /// Interaction logic for UIMainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        #region Global variables
        private List<Nanotec_Container>? _nanotec;

        private static readonly object _syncRoot = new object();

        private Thread? _thread;
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
            _nanotec = Globals.Machine.Motion.Nanotec;
            #endregion

            _thread = new Thread(new ThreadStart(delegate () { }));
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
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
        }

        #region GUI functions ...
        private void Button_Click_Homeing(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Log.Warning("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
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

                    Log.Debug("Start - Homeing (Move a little bit)");
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
                    Log.Debug("Finish - Homeing (Move a little bit)");

                    Log.Debug("Start - Homeing");
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

                        // Stop the NanoJ-Program
                        //_nanotec.MotionBusController.WriteNumber(_nanotec.MotionControllerDeviceConfigs[i].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);
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

                        // Stop the NanoJ-Program
                        //_nanotec.MotionBusController.WriteNumber(_nanotec.MotionControllerDeviceConfigs[i].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);
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

                        // Stop the NanoJ-Program
                        //_nanotec.MotionBusController.WriteNumber(_nanotec.MotionControllerDeviceConfigs[i].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);
                    }
                    Log.Debug("Finish - Homeing");
                }));
                _thread.Start();
            }
        }

        private void Button_Click_Move1(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    long targetPosition = 0;

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
                        targetPosition = (long)Convert.ToDouble(textMove1.Text.Replace(".", ","));
                    });

                    Log.Debug("Start - Move 1-4");
                    for (int i = 0; i <= 3; i++)
                    {
                        _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                    }

                    for (int i = 0; i <= 3; i++)
                    {
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[i].DeviceHandle, targetPosition);
                    }
                    Log.Debug("Finish - Move 1-4");
                }));
                _thread.Start();
            }
        }

        private void Button_Click_Move2(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    long targetPosition = 0;

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

                    Dispatcher.Invoke(() =>
                    {
                        targetPosition = (long)Convert.ToDouble(textMove2.Text.Replace(".", ","));
                    });

                    Log.Debug("Start - Move 11-14");
                    for (int i = 4; i <= 7; i++)
                    {
                        _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                    }

                    for (int i = 4; i <= 7; i++)
                    {
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[i].DeviceHandle, targetPosition);
                    }
                    Log.Debug("Finish - Move 11-14");
                }));
                _thread.Start();
            }
        }

        private void Button_Click_Move3(object sender, RoutedEventArgs e)
        {
            if (_thread.IsAlive)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    long targetPosition = 0;

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

                    Dispatcher.Invoke(() =>
                    {
                        targetPosition = (long)Convert.ToDouble(textMove3.Text.Replace(".", ","));
                    });

                    Log.Debug("Start - Move 21-21");
                    for (int i = 8; i <= 8; i++)
                    {
                        _nanotec[0].QuickStop(_nanotec[0].MotionController[i].DeviceHandle);

                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[i].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[i].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                    }

                    for (int i = 8; i <= 8; i++)
                    {
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[i].DeviceHandle, targetPosition);
                    }
                    Log.Debug("Finish - Move 21-21");
                }));
                _thread.Start();
            }
        }


        private void Button_Click_MoveSync(object sender, RoutedEventArgs e)
        {
            //...
        }

        private void Button_Click_TEST(object sender, RoutedEventArgs e)
        {
            long RotationDegree = 0;
            long PosX = 0;
            long PosZ = 0;

            long steps_RotationDegree = 0;
            long steps_PosX = 0;
            long steps_PosZ = 0;

            long nullPosDistance = 200;

            long timeToReach = 2; // in seconds

            long rotationVelocity = 0;
            long posXVelocity = 0;
            long posZVelocity = 0;

            long rotationAccel = 0;
            long posXAccel = 0;
            long posZAccel = 0;

            Dispatcher.Invoke(() =>
            {
                RotationDegree = (long)Convert.ToDouble(textMoveSyncDegree.Text.Replace(".", ","));
                PosX = (long)Convert.ToDouble(textMoveSyncX.Text.Replace(".", ","));
                PosZ = (long)Convert.ToDouble(textMoveSyncZ.Text.Replace(".", ","));
            });


            steps_RotationDegree = (long)((RotationDegree * (4096/360))/12);
            steps_PosX = (long)((PosX + Math.Abs(nullPosDistance * Math.Cos(RotationDegree))) * (4096 / 4));
            steps_PosZ = (long)((PosZ + Math.Abs(nullPosDistance * Math.Sin(RotationDegree))) * (4096 / 4));

            rotationVelocity = (long)(steps_RotationDegree / timeToReach);
            posXVelocity = (long)(steps_PosX / timeToReach);
            posZVelocity = (long)(steps_PosZ / timeToReach);

            rotationAccel = (long)(rotationVelocity / timeToReach);
            posXAccel = (long)(posXVelocity / timeToReach);
            posZAccel = (long)(posZVelocity / timeToReach);

           
        }


        private void Button_Click_Operation(object sender, RoutedEventArgs e)
        {
            UIMainWindow_Operation operationWindow = new UIMainWindow_Operation(_nanotec, _thread);
            operationWindow.Owner = this;
            operationWindow.Show();
        }

        private void Button_Click_ObjectDirectory(object sender, RoutedEventArgs e)
        {
            UIMainWindow_ObjectDirectory objectDirectoryWindow = new UIMainWindow_ObjectDirectory(_nanotec, _thread);
            objectDirectoryWindow.Owner = this;
            objectDirectoryWindow.Show();
        }

        #endregion

        #region Functions ...



        #endregion


    }
}
