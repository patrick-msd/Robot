using RC.Lib.Motion;
using System.Collections.Generic;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_Machine
    {
        public class Globals_Device_Motion
        {
            // List because it is possible to use more than one bus device
            public List<Nanotec_Container>? Nanotec { get; set; } = null;
        }
    }
}
