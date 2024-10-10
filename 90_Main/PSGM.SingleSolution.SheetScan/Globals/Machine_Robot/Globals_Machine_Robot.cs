using PSGM.Lib.Control.Doosan;

namespace PSGM.SingleSolution.SheetScan
{
    public partial class Globals_Machine
    {
        public class Globals_Machine_Robot
        {
            public Doosan_Container? Doosan { get; set; } = null;
        }
    }
}
