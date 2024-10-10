using RC.Lib.Motion;
using System.Collections.Generic;

namespace PSGM.SingleSolution.SheetScan
{
    public partial class Globals_Machine
    {
        public class Globals_Machine_Motion
        {
            // List because it is possible to use more than one bus device
            public List<Nanotec_Container>? Nanotec { get; set; } = null;
        }
    }
}
