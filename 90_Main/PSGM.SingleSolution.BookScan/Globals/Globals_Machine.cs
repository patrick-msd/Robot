using System;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_Machine
    {
        public Guid? MachineId { get; set; } = Guid.Empty;

        public Guid? OrganizationIdInUse { get; set; } = Guid.Empty;
        public Guid? ProjectIdInUse { get; set; } = Guid.Empty;
        public Guid? DirectoryIdInUse { get; set; } = Guid.Empty;
        public Guid? UserIdInUse { get; set; } = Guid.Empty;
        public Guid? SoftwareIdInUse { get; set; } = Guid.Empty;

        public Globals_Machine_Control? Control { get; set; } = null;
        public Globals_Machine_Motion? Motion { get; set; } = null;
        public Globals_Machine_PowerSupply? PowerSupply { get; set; } = null;
        public Globals_Machine_Robot? Robot { get; set; } = null;
        public Globals_Machine_Vision? Vision { get; set; } = null;
    }
}
