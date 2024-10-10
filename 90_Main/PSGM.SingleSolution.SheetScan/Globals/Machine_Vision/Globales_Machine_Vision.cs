using PSGM.Lib.Vision.Intel;
using PSGM.Lib.Vision.SVSVistek;

namespace PSGM.SingleSolution.SheetScan
{
    public partial class Globals_Machine
    {
        public class Globals_Machine_Vision
        {
            public Intel_Container? Intel { get; set; } = null;
            public SVSVistek_Container? SVSVistek { get; set; } = null;
        }
    }
}
