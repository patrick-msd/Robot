using System.Windows;

namespace RC.Scan_SingleSolution
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class UIMainWindow : Window
    {
        void CalculateHeightForCradle()
        {
            Serilog.Log.Verbose("Calculate new height for zero level ...");

            #region Cradle left position calculation ...
            long motorPosition0 = _nanotec[0].GetPosition(_nanotec[0].MotionController[1].DeviceHandle);
            long motorPosition3 = _nanotec[0].GetPosition(_nanotec[0].MotionController[2].DeviceHandle);
            long motorActualPositionLeft = (motorPosition0 + motorPosition3) / 2;
            float hightActualZeroLevelLeft = (_valuesDepthMean[8] - _cradleHeightZeroLevel) / _leadScrewPitch * _motorResolution;
            _cradleLeftZeroLevelPosition = (int)(motorActualPositionLeft + hightActualZeroLevelLeft);

            Serilog.Log.Verbose("Current position motor 0 (cradle right) position to {0:0.000} ...", motorPosition0);
            Serilog.Log.Verbose("Current position motor 3 (cradle right) position to {0:0.000} ...", motorPosition3);
            Serilog.Log.Verbose("Current position average motor 0 & 3 (cradle right) position to {0:0.000} ...", motorActualPositionLeft);
            Serilog.Log.Verbose("Height measured by real sense and transformed to motor position {0:0.000} ...", hightActualZeroLevelLeft);
            Serilog.Log.Verbose("Calculatet position for cradle left {0:0.000} with Standard Deviation of {1:0.000} < {2:0.000}...", _cradleLeftZeroLevelPosition, _valuesDepthStandardDeviation[8], _valuesDepthStandardDeviationMax);
            #endregion

            #region Cradle right position calculation ...
            long motorPosition1 = _nanotec[0].GetPosition(_nanotec[0].MotionController[0].DeviceHandle);
            long motorPosition2 = _nanotec[0].GetPosition(_nanotec[0].MotionController[3].DeviceHandle);
            long motorActualPositionRight = (motorPosition1 + motorPosition2) / 2;
            float hightActualZeroLevelRight = (_valuesDepthMean[9] - _cradleHeightZeroLevel) / _leadScrewPitch * _motorResolution;
            _cradleRightZeroLevelPosition = (int)(motorActualPositionRight + hightActualZeroLevelRight);

            Serilog.Log.Verbose("Current position motor 0 (cradle left) position to {0:0.000} ...", motorPosition1);
            Serilog.Log.Verbose("Current position motor 3 (cradle left) position to {0:0.000} ...", motorPosition2);
            Serilog.Log.Verbose("Current position average motor 0 & 3 (cradle right) position to {0:0.000} ...", motorActualPositionRight);
            Serilog.Log.Verbose("Height measured by real sense and transformed to motor position {0:0.000} ...", hightActualZeroLevelRight);
            Serilog.Log.Verbose("Calculatet position for cradle right {0:0.000}  Standard Deviation of {1:0.000} < {2:0.000} ...", _cradleRightZeroLevelPosition, _valuesDepthStandardDeviation[8], _valuesDepthStandardDeviationMax);
            #endregion
        }






    }
}
