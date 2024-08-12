using System;

namespace RC.PowerSupply.Nextys.Sample
{
    public partial class Globals_Machine
    {
        public Guid? MachineId { get; set; } = Guid.Empty;

        public Guid? OrganizationIdInUse { get; set; } = Guid.Empty;
        public Guid? ProjectIdInUse { get; set; } = Guid.Empty;
        public Guid? DirectoryIdInUse { get; set; } = Guid.Empty;
        public Guid? UserIdInUse { get; set; } = Guid.Empty;
        public Guid? SoftwareIdInUse { get; set; } = Guid.Empty;

        public Globals_Machine_PowerSupply? PowerSupply { get; set; } = null;
    }
}
