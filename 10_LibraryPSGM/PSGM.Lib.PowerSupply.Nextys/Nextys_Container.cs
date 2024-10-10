using Serilog;

namespace PSGM.Lib.PowerSupply
{
    public partial class Nextys_Container
    {
        #region Global variables
        // Device
        private List<Nextys_DcDcConverter> _dcDcConverters;
        public List<Nextys_DcDcConverter> DcDcConverters { get { return _dcDcConverters; } set { _dcDcConverters = value; } }
        #endregion

        public Nextys_Container()
        {
            Log.Information("Initialize Nextys class ...");

            _dcDcConverters = new List<Nextys_DcDcConverter>();
        }

        ~Nextys_Container()
        {
            _dcDcConverters.Clear();
        }
    }
}
