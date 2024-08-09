using RC.Lib.Motion;
using System.Collections.Generic;

namespace RC.Motion.Nanotec.Sample
{
    public partial class Globals_Device
    {
        public class Globals_Device_Motion
        {
            // List because it is possible to use more than one bus device
            public List<Nanotec_Container>? Nanotec { get; set; } = null;
        }
    }
}
