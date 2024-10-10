namespace PSGM.Lib.Control.RobotElectronics
{
    public partial class RobotElectronics_Controller
    {
        public class MonitoringObject
        {
            public bool[]? DigitalOutput { get; set; }
            public bool[]? DigitalInput { get; set; }
            public bool[]? AnalogOutput { get; set; }
            public bool[]? AnalogInput { get; set; }
        }

        public class Status
        {
            public byte? ModuleID { get; set; }
            public byte? SystemFirmwareMajo { get; set; }
            public byte? SystemFirmwareMinor { get; set; }
            public byte? ApplicationFirmwareMajor { get; set; }
            public byte? ApplicationFirmwareMinor { get; set; }
            public double? PowerSupplyVolt { get; set; }
            public double? InternalTemperature { get; set; }
        }
    }
}
