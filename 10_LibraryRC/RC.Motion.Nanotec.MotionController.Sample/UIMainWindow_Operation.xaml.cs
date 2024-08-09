using RC.Lib.Motion;
using Serilog;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace RC.Motion.Nanotec.Sample
{
    /// <summary>
    /// Interaction logic for UIMainWindows_Operation.xaml
    /// </summary>
    public partial class UIMainWindow_Operation : Window
    {
        private List<RC.Lib.Motion.Nanotec_Container>? _nanotec;
        private Thread _thread;
        private TabItem _tabItem;
        private bool _powerOff;
        private Dictionary<string, int> _homingModes = new Dictionary<string, int>();

        public UIMainWindow_Operation(List<RC.Lib.Motion.Nanotec_Container>? nanotec, Thread thread)
        {
            InitializeComponent();

            _nanotec = nanotec;
            _thread = thread;

            _homingModes.Add("block negative", (int)HomingModes.BlockNegative);
            _homingModes.Add("block positive", (int)HomingModes.BlockPositive);
            _homingModes.Add("current position", (int)HomingModes.CurrentPosition);
            _homingModes.Add("switch negative", (int)HomingModes.SwitchNegative);
            _homingModes.Add("switch positive", (int)HomingModes.SwitchPositive);
            _homingModes.Add("next encoder index to the left", (int)HomingModes.NextEncoderIndexToLeft);
            _homingModes.Add("encoder index after hitting switch negative", (int)HomingModes.EncoderIndexAfterHittingSwitchNegative);
            _homingModes.Add("encoder index after hitting switch positive", (int)HomingModes.EncoderIndexAfterHittingSwitchPositive);
            _homingModes.Add("encoder index after hitting block negative", (int)HomingModes.EncoderIndexAfterHittingBlockNegative);
            _homingModes.Add("encoder index after hitting block positive", (int)HomingModes.EncoderIndexAfterHittingBlockPositive);
        }


        #region Homing
        private void Button_Click_Homing(object sender, RoutedEventArgs e)
        {
            string homingAccelerationText = Dispatcher.Invoke(() => HomingAcceleration.Text);
            string homingSpeedSwitchText = Dispatcher.Invoke(() => HomingSpeedSwitch.Text);
            string homingSpeedZeroText = Dispatcher.Invoke(() => HomingSpeedZero.Text);
            string homingMinCurrentText = Dispatcher.Invoke(() => HomingMinCurrent.Text);
            string HomingBlockTimeText = Dispatcher.Invoke(() => HomingBlockTime.Text);

            int homeOffset = -50;
            int homingSpeedSwitch = int.Parse(homingSpeedSwitchText);
            int homingSpeedZero = int.Parse(homingSpeedZeroText);
            int homingMaxSpeed = 375;
            int homingAcceleration = int.Parse(homingAccelerationText);
            int homingMinCurrent = int.Parse(homingMinCurrentText);
            int homingBlockTime = int.Parse(HomingBlockTimeText);

            string content = "";
            foreach (RadioButton rb in AllModes.Children)
            {
                if (rb.IsChecked == true)
                {
                    content = rb.Content.ToString();
                    break;
                }
            }
            int homingMode = _homingModes[content];


            if (_thread.IsAlive)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        Log.Debug("Start - Homeing");

                        int motionControllerId = 0;

                        _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

                        _nanotec[0].SetupHoming(_nanotec[0].MotionController[motionControllerId].DeviceHandle, homingMode, homeOffset, homingSpeedSwitch, homingSpeedZero, homingMaxSpeed, homingAcceleration, homingMinCurrent, homingBlockTime);

                        _nanotec[0].StartHoming(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

                        // Stop the NanoJ-Program              
                        //_nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);

                        Log.Debug("Finish - Homeing");
                    }
                    catch (Exception ex)
                    {
                        Log.Debug(ex.Message);
                    }
                }));

                _thread.Start();
            }
        }
        #endregion


        #region Positioning
        private void PositionSet_Click(object sender, RoutedEventArgs e)
        {
            if (_powerOff)
            {
                Log.Debug("Power still Off!");
                return;
            }

            string targetPositionText = Dispatcher.Invoke(() => TargetPosition.Text);
            int targetPosition = int.Parse(targetPositionText);

            string minPosRangeText = Dispatcher.Invoke(() => MinPosRange.Text);
            int minPosRange = int.Parse(minPosRangeText);
            string maxPosRangeText = Dispatcher.Invoke(() => MaxPosRange.Text);
            int maxPosRange = int.Parse(maxPosRangeText);
            string minPosText = Dispatcher.Invoke(() => MinPos.Text);
            int minPos = int.Parse(minPosText);
            string maxPosText = Dispatcher.Invoke(() => MaxPos.Text);
            int maxPos = int.Parse(maxPosText);
            string homeOffsetText = Dispatcher.Invoke(() => HomeOffset.Text);
            int homeOffset = int.Parse(homeOffsetText);

            int polarityInverted = (bool)Dispatcher.Invoke(() => PolarityInverted.IsChecked) ? 1 : 0;

            int jerk = (bool)Dispatcher.Invoke(() => !TrapezoidalRampPos.IsChecked) ? 1 : 0;

            // Acceleration and Velocity Limits
            string profileVelocityText = Dispatcher.Invoke(() => ProfileVelocity.Text);
            int profileVelocity = int.Parse(profileVelocityText);
            string endVelocityText = Dispatcher.Invoke(() => EndVelocity.Text);
            int endVelocity = int.Parse(endVelocityText);
            string profileAccelText = Dispatcher.Invoke(() => ProfileAccel.Text);
            int profileAccel = int.Parse(profileAccelText);
            string profileDecelText = Dispatcher.Invoke(() => ProfileDecel.Text);
            int profileDecel = int.Parse(profileDecelText);
            string quickStopDecelText = Dispatcher.Invoke(() => QuickStopDecel.Text);
            int quickStopDecel = int.Parse(quickStopDecelText);
            string maxDecelText = Dispatcher.Invoke(() => MaxDecel.Text);
            int maxDecel = int.Parse(maxDecelText);
            string maxAccelText = Dispatcher.Invoke(() => MaxAccel.Text);
            int maxAccel = int.Parse(maxAccelText);

            int move = 0;
            foreach (RadioButton rb in Move.Children)
            {
                if (rb.IsChecked == true)
                {
                    move = Move.Children.IndexOf(rb) + 1;
                    break;
                }
            }

            bool relative = (bool)relativePosition.IsChecked;
            if (_thread.IsAlive)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        Log.Debug("Start - Position");

                        int motionControllerId1 = 0;
                        int motionControllerId2 = 1;
                        int motionControllerId3 = 2;
                        int motionControllerId4 = 3;

                        _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId1].DeviceHandle);
                        _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId2].DeviceHandle);
                        _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId3].DeviceHandle);
                        _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId4].DeviceHandle);

                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[motionControllerId1].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);
                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[motionControllerId2].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);
                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[motionControllerId3].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);
                        _nanotec[0].SetupRangePositioning(_nanotec[0].MotionController[motionControllerId4].DeviceHandle, relative, move, minPosRange, maxPosRange, minPos, maxPos, homeOffset, polarityInverted);

                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[motionControllerId1].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[motionControllerId2].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[motionControllerId3].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);
                        _nanotec[0].SetAccelVelocityPositioning(_nanotec[0].MotionController[motionControllerId4].DeviceHandle, jerk, profileVelocity, endVelocity, profileAccel, profileDecel, quickStopDecel, maxDecel, maxAccel);

                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[motionControllerId1].DeviceHandle, targetPosition);
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[motionControllerId2].DeviceHandle, targetPosition);
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[motionControllerId3].DeviceHandle, targetPosition);
                        _nanotec[0].SetPositionASync(_nanotec[0].MotionController[motionControllerId4].DeviceHandle, targetPosition);

                        // Stop the NanoJ-Program              
                        //_nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId1].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);
                        //_nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId2].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);
                        //_nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId3].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);
                        //_nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId4].DeviceHandle, 0, new Nlc.OdIndex(0x2300, 0x00), 32);

                        Log.Debug("Finish - Position");
                    }
                    catch (Exception ex)
                    {
                        Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }
        #endregion


        #region Velocity
        private void SetVelocity_Click(object sender, RoutedEventArgs e)
        {
            int jerk = (bool)Dispatcher.Invoke(() => !TrapezoidalRampVelocity.IsChecked) ? 1 : 0;

            string velProfileAccelText = Dispatcher.Invoke(() => VelProfileAccel.Text);
            int velProfileAccel = int.Parse(velProfileAccelText);

            string maxAccelText = Dispatcher.Invoke(() => MaxAccel.Text);
            int maxAccel = int.Parse(maxAccelText);

            string velProfileDecelText = Dispatcher.Invoke(() => VelProfileDecel.Text);
            int velProfileDecel = int.Parse(velProfileDecelText);

            string quickStopDecelText = Dispatcher.Invoke(() => QuickStopDecel.Text);
            int quickStopDecel = int.Parse(quickStopDecelText);

            string maxDecelText = Dispatcher.Invoke(() => MaxDecel.Text);
            int maxDecel = int.Parse(maxDecelText);

            string targetVelocityText = Dispatcher.Invoke(() => TargetVelocity.Text);
            int targetVelocity = int.Parse(targetVelocityText);

            string velWindowText = Dispatcher.Invoke(() => VelWindow.Text);
            int velWindow = int.Parse(velWindowText);

            string velwindowTimeText = Dispatcher.Invoke(() => VelWindowTime.Text);
            int velwindowTime = int.Parse(velwindowTimeText);

            int velPolarityInverted = (bool)Dispatcher.Invoke(() => VelPolarityInverted.IsChecked) ? 1 : 0;

            int positionBased = (bool)Dispatcher.Invoke(() => !VelBasedRamp.IsChecked) ? 1 : 0;

            if (_thread.IsAlive)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        Log.Debug("Start - Velocity");

                        int motionControllerId = 0;

                        _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

                        _nanotec[0].SetupVelocity(_nanotec[0].MotionController[motionControllerId].DeviceHandle, jerk, velProfileAccel, maxAccel, velProfileDecel, quickStopDecel, maxDecel, velWindow, velwindowTime, velPolarityInverted, positionBased);
                        _nanotec[0].SetVelocity(_nanotec[0].MotionController[motionControllerId].DeviceHandle, targetVelocity);
                        Log.Debug("Finish - Velocity");
                    }
                    catch (Exception ex)
                    {
                        Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }
        #endregion


        #region Torque
        private void Torque_Click(object sender, RoutedEventArgs e)
        {
            string targetTorqueText = Dispatcher.Invoke(() => TargetTorque.Text);
            int targetTorque = int.Parse(targetTorqueText);
            string maxTorqueText = Dispatcher.Invoke(() => MaxTorque.Text);
            int maxTorque = int.Parse(maxTorqueText);
            string nominalCurrentText = Dispatcher.Invoke(() => NominalCurrent.Text);
            int nominalCurrent = int.Parse(nominalCurrentText);
            string torqueSlopeText = Dispatcher.Invoke(() => TorqueSlope.Text);
            int torqueSlope = int.Parse(torqueSlopeText);

            int torqueMode = (bool)Dispatcher.Invoke(() => !TorqueMode.IsChecked) ? 1 : 0;

            if (_thread.IsAlive)
            {
                Log.Information("Another thread is already running ...");
            }
            else
            {
                _thread = new Thread(new ThreadStart(delegate ()
                {
                    try
                    {
                        Log.Debug("Start - Torque");

                        int motionControllerId = 0;

                        _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

                        _nanotec[0].SetupTorque(_nanotec[0].MotionController[motionControllerId].DeviceHandle, maxTorque, nominalCurrent, torqueSlope, torqueMode);
                        _nanotec[0].SetTorque(_nanotec[0].MotionController[motionControllerId].DeviceHandle, targetTorque);
                        Log.Debug("Finish - Torque");
                    }
                    catch (Exception ex)
                    {
                        Log.Debug(ex.Message);
                    }
                }));
                _thread.Start();
            }
        }
        #endregion


        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ActivateMode.Content = "Activate Mode: " + (string)((TabItem)e.AddedItems[0]).Header;
        }

        private void PowerOn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Log.Debug("Power on");

                _powerOff = false; // um Threads wieder starten zu können

                int motionControllerId1 = 0;
                int motionControllerId2 = 1;
                int motionControllerId3 = 2;
                int motionControllerId4 = 3;

                _nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId1].DeviceHandle, 7, new Nlc.OdIndex(0x6040, 0), 16);
                _nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId2].DeviceHandle, 7, new Nlc.OdIndex(0x6040, 0), 16);
                _nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId3].DeviceHandle, 7, new Nlc.OdIndex(0x6040, 0), 16);
                _nanotec[0].WriteNumber(_nanotec[0].MotionController[motionControllerId4].DeviceHandle, 7, new Nlc.OdIndex(0x6040, 0), 16);
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
            }
        }

        private void PowerOff_Click(object sender, RoutedEventArgs e)
        {
            Log.Debug("Power off");

            int motionControllerId = 0;

            try
            {
                _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId].DeviceHandle);
                _nanotec[0].Shutdown(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

                _powerOff = true; // um Threads zu stoppen
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
            }
        }

        private void Quickstop_Click(object sender, RoutedEventArgs e)
        {
            int motionControllerId = 0;

            try
            {
                _nanotec[0].QuickStop(_nanotec[0].MotionController[motionControllerId].DeviceHandle);
                _nanotec[0].DeviceDisconnect(_nanotec[0].MotionController[motionControllerId].DeviceHandle);

                _powerOff = true;
            }
            catch (Exception ex)
            {
                Log.Debug(ex.Message);
            }
        }
    }
}
