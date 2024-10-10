using System.Windows;

namespace PSGM.SingleSolution.SheetScan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        float DistanceToTurns(float distance)
        {
            return (distance / _leadScrewPitch) * _motorResolution;
        }

        #region Downholder
        public enum downholderPositon : long
        {
            Open = 0L,
            HalfOpen = 500L,
            NearlyClosed = 750L,
            Close = 1000L
        }

        void MoveDownholder(long targetPostion)
        {
            MoveDownholderLeft(targetPostion);
            MoveDownholderRight(targetPostion);
        }

        void MoveDownholder(downholderPositon targetPostion)
        {
            MoveDownholderLeft((long)targetPostion);
            MoveDownholderRight((long)targetPostion);
        }

        void MoveDownholderLeft(downholderPositon targetPostion)
        {
            MoveDownholderLeft((long)targetPostion);
        }

        void MoveDownholderLeft(long targetPostion)
        {
            Serilog.Log.Verbose("Set motor 6 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPosition(_nanotec[0].MotionController[6].DeviceHandle, targetPostion);

            Serilog.Log.Verbose("Set motor 7 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPosition(_nanotec[0].MotionController[7].DeviceHandle, targetPostion);
        }

        void MoveDownholderRight(downholderPositon targetPostion)
        {
            MoveDownholderRight((long)targetPostion);
        }

        void MoveDownholderRight(long targetPostion)
        {
            Serilog.Log.Verbose("Set motor 4 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPosition(_nanotec[0].MotionController[4].DeviceHandle, targetPostion);

            Serilog.Log.Verbose("Set motor 5 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPosition(_nanotec[0].MotionController[5].DeviceHandle, targetPostion);
        }




        void MoveDownholderASync(long targetPostion)
        {
            MoveDownholderLeftASync(targetPostion);
            MoveDownholderRightASync(targetPostion);
        }

        void MoveDownholderASync(downholderPositon targetPostion)
        {
            MoveDownholderLeftASync((long)targetPostion);
            MoveDownholderRightASync((long)targetPostion);
        }

        void MoveDownholderLeftASync(downholderPositon targetPostion)
        {
            MoveDownholderLeftASync((long)targetPostion);
        }

        void MoveDownholderLeftASync(long targetPostion)
        {
            Serilog.Log.Verbose("Set motor 6 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[6].DeviceHandle, targetPostion);

            Serilog.Log.Verbose("Set motor 7 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[7].DeviceHandle, targetPostion);
        }

        void MoveDownholderRightASync(downholderPositon targetPostion)
        {
            MoveDownholderRightASync((long)targetPostion);
        }

        void MoveDownholderRightASync(long targetPostion)
        {
            Serilog.Log.Verbose("Set motor 4 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[4].DeviceHandle, targetPostion);

            Serilog.Log.Verbose("Set motor 5 (downholder) position to {0:0.000} ...", targetPostion);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[5].DeviceHandle, targetPostion);
        }
        #endregion

        #region Cradle
        void MoveCradlesASync(long cradleLeftTargetPosition, long cradleRightTargetPosition)
        {
            MoveCradleLeftASync(cradleLeftTargetPosition);
            MoveCradleRightASync(cradleRightTargetPosition);
        }

        void MoveCradleLeftASync(long cradleLeftTargetPosition)
        {
            Serilog.Log.Verbose("Set motor 1 (cradle left) position to {0:0.000} ...", cradleLeftTargetPosition);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[1].DeviceHandle, cradleLeftTargetPosition);

            Serilog.Log.Verbose("Set motor 2 (cradle left) position to {0:0.000} ...", cradleLeftTargetPosition);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[2].DeviceHandle, cradleLeftTargetPosition);
        }
        void MoveCradleRightASync(long cradleRightTargetPosition)
        {
            Serilog.Log.Verbose("Set motor 0 (cradle right) position to {0:0.000} ...", cradleRightTargetPosition);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[0].DeviceHandle, cradleRightTargetPosition);

            Serilog.Log.Verbose("Set motor 3 (cradle right) position to {0:0.000} ...", cradleRightTargetPosition);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[3].DeviceHandle, cradleRightTargetPosition);
        }
        #endregion

        #region DoublePageSensor
        public enum doublePageSensorPositon : long
        {
            In = 0L,
            Out = 36250L
        }

        void MoveDoublePageSensor(doublePageSensorPositon targetPostion)
        {
            Serilog.Log.Verbose("Set motor 8 (double page sensor) position to {0:0.000} ...", (long)targetPostion);
            _nanotec[0].SetPosition(_nanotec[0].MotionController[8].DeviceHandle, (long)targetPostion);
        }

        void MoveDoublePageSensorASync(doublePageSensorPositon targetPostion)
        {
            Serilog.Log.Verbose("Set motor 8 (double page sensor) position to {0:0.000} ...", (long)targetPostion);
            _nanotec[0].SetPositionASync(_nanotec[0].MotionController[8].DeviceHandle, (long)targetPostion);
        }
        #endregion
    }
}
