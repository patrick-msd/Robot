using RCRobotDoosanControl;
using Serilog;
using System;
using System.Threading;

namespace RC.Scan_SingleSolution
{
    public static partial class Events
    {
        ////////////////////////////////////////////////////////////////////////////
        // Callback operation                                                     //
        ////////////////////////////////////////////////////////////////////////////
        public static void OnHommingCompleted()
        {
            //// Only work within 50msec.
            //Serilog.Log.Information("Homming completed ...");
        }






        public static void OnTpInitializingCompleted(int id)
        {
            //Globals_Device.Globals_Device_Robot_Doosan_Controller robot = Globals.Device.Robot.Doosan.Controllers[id];

            //// Request control after Tp initialization.
            //robot.Control._tpInitailizingComplted = true;
            //robot.Control.ManageAccessControll(ManageAccessControl.MANAGE_ACCESS_CONTROL_FORCE_REQUEST);

            //Serilog.Log.Information("Initializing completed and access control set to \"Force Request\" ...");
        }





        public static void OnDisconnected(int id)
        {
            //Globals_Device.Globals_Device_Robot_Doosan_Controller robot = Globals.Device.Robot.Doosan.Controllers[id];

            //while (!robot.Control.OpenConnection(robot.Ethernet.IpAddress, robot.Ethernet.Port))
            //{
            //    Thread.Sleep(1000);
            //}

            //Serilog.Log.Information("Program Robot stopped ...");
        }





        // C# callback function
        public static void MyCallback(string message)
        {
            //Serilog.Log.Error($"C# callback received message: {message}");
        }

        // C# callback functions
        public static void UpdateProgress(int progress)
        {
            //Console.WriteLine($"Progress: {progress}%");
        }

        public static void UpdateStatus(string status)
        {
            //Console.WriteLine($"Status: {status}");
        }
    }
}
