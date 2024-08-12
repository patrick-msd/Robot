using Serilog;

namespace RC.Lib.Control.Doosan
{
    public partial class Doosan_Container
    {
        #region Global variables
        // Device
        private List<Doosan_Controller> _controllers;
        public List<Doosan_Controller> Controllers { get { return _controllers; } set { _controllers = value; } }
        #endregion

        public Doosan_Container()
        {
            Log.Information("Initialize robot electronics container class ...");

            _controllers = new List<Doosan_Controller>();
        }

        ~Doosan_Container()
        {
            _controllers.Clear();
        }
    }
}
