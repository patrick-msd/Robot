using Serilog;

namespace PSGM.Lib.Vision.Sony
{
    public partial class Sony_Container
    {
        #region Global variables
        // Device
        private List<Sony_Camera> _cameras;
        public List<Sony_Camera> Cameras { get { return _cameras; } set { _cameras = value; } }
        #endregion

        public Sony_Container()
        {
            Log.Information("Initialize robot electronics container class ...");

            _cameras = new List<Sony_Camera>();
        }

        ~Sony_Container()
        {
            _cameras.Clear();
        }
    }
}
