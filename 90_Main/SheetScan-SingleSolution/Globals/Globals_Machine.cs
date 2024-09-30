using System;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_Machine
    {
        public Globals_Machine_Control? Control { get; set; } = null;
        public Globals_Machine_Motion? Motion { get; set; } = null;
        public Globals_Machine_PowerSupply? PowerSupply { get; set; } = null;
        public Globals_Machine_Robot? Robot { get; set; } = null;
        public Globals_Machine_Vision? Vision { get; set; } = null;
    }
}
