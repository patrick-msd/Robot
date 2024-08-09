namespace RC.Lib.PowerSupply
{
    public partial class Nextys_DcDcConverter
    {
        public class MonitoringObject
        {
            public double MaximalOutputCurrent { get; set; }
            public double NominalOutputVoltage { get; set; }
            public double OutputVoltage { get; set; }
            public double OutputCurrent { get; set; }
            public double OutputPower { get; set; }
            public double InputVoltage { get; set; }
            public bool DcOk { get; set; }
            public bool OutputDisabled { get; set; }
            public bool OutputShortCircuit { get; set; }
            public bool OutputOverload { get; set; }
            public bool UsbPowered { get; set; }
            public bool OverTemperatureWarning { get; set; }
            public bool OverTemperatureError { get; set; }
            public bool OutputOverVoltageError { get; set; }
        }
    }
}
