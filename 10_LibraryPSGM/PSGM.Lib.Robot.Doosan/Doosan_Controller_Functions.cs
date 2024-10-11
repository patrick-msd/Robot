using PSGM.Helper;
using PSGMRobotDoosanControl;
using Serilog;

namespace PSGM.Lib.Control.Doosan
{
    public partial class Doosan_Controller
    {
        public void SetEndEffector(Configuration_Robot_Doosan_ToolV1_0_0 tool)
        {
            RobotMode mode = _robot.GetRobotMode();

            _robot.SetRobotMode(RobotMode.ROBOT_MODE_MANUAL);
            Thread.Sleep(250);

            _robot.AddTool(tool.Name, tool.Weight, tool.GetCenterOfGravity(), tool.GetInertialValues());
            Thread.Sleep(125);
            _robot.SetTool(tool.Name);


            _robot.AddTCP(tool.Name, tool.GetCenterPositions());
            Thread.Sleep(125);
            _robot.SetTCP(tool.Name);

            Thread.Sleep(125);

            Log.Information($"Robot {_IdDb}: \" Current Tool: " + _robot.GetTool());
            Log.Information($"Robot {_IdDb}: \" Current TCP: " + _robot.GetTCP());

            Thread.Sleep(250);

            _robot.SetRobotMode(mode);
        }
    }
}
