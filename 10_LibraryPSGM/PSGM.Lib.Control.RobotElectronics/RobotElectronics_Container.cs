using Serilog;

namespace PSGM.Lib.Control.RobotElectronics
{
    public partial class RobotElectronics_Container
    {
        #region Global variables
        // Device
        private List<RobotElectronics_Controller> _controllers;
        public List<RobotElectronics_Controller> Controllers { get { return _controllers; } set { _controllers = value; } }
        #endregion

        public RobotElectronics_Container()
        {
            Log.Information("Initialize robot electronics container class ...");

            _controllers = new List<RobotElectronics_Controller>();
        }

        ~RobotElectronics_Container()
        {
            _controllers.Clear();
        }
    }
}
