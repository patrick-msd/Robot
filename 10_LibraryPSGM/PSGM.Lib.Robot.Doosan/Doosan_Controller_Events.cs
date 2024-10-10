using PSGMRobotDoosanControl;
using Serilog;

namespace PSGM.Lib.Control.Doosan
{
    public partial class Doosan_Controller
    {
        ////////////////////////////////////////////////////////////////////////////
        // Callback operation                                                     //
        ////////////////////////////////////////////////////////////////////////////
        public void OnHommingCompleted()
        {
            // Only work within 50msec.
            Log.Information("Homming completed ...");
        }






        public void OnTpInitializingCompleted()
        {
            //RobotControlDeviceConfig robot = Globals.ConfigFile.Robot.Doosan.ControlDeviceConfigs[id];

            // Request control after Tp initialization.
            _robot._tpInitailizingComplted = true;
            _robot.ManageAccessControll(ManageAccessControl.MANAGE_ACCESS_CONTROL_FORCE_REQUEST);

            Log.Information("Initializing completed and access control set to \"Force Request\" ...");
        }





        public void OnDisconnected()
        {
            //RobotControlDeviceConfig robot = Globals.ConfigFile.Robot.Doosan.ControlDeviceConfigs[id];

            while (!_robot.OpenConnection(_ipAddress, (uint)_port))
            {
                Thread.Sleep(1000);
            }

            Log.Information("Program Robot stopped ...");
        }

        



        // C# callback function
        public void MyCallback(string message)
        {
            Log.Error($"C# callback received message: {message}");
        }

        // C# callback functions
        public void UpdateProgress(int progress)
        {
            Log.Information($"Progress: {progress}%");
        }

        public void UpdateStatus(string status)
        {
            Log.Information($"Status: {status}");
        }
    }
}
