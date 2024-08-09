using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_ConfigFile
    {
        public class ControlDeviceConfig
        {
            #region Application information for the device ...
            [XmlElement(ElementName = "ApplicationDeviceName")]
            public string ApplicationDeviceName { get; set; } = string.Empty;

            [XmlElement(ElementName = "ApplicationDeviceLocation")]
            public string ApplicationDeviceLocation { get; set; } = string.Empty;

            [XmlElement(ElementName = "InitialzeDeviceAtSplashscreen")]
            public bool InitialzeAtSplashscreen { get; set; } = false;

            [XmlElement(ElementName = "AutoStartDeviceAtSplashscreen")]
            public bool AutoStartAtSplashscreen { get; set; } = false;

            [XmlElement(ElementName = "HomeingDeviceAtSplashscreen")]
            public bool HomeingDeviceAtSplashscreen { get; set; } = false;

            [XmlElement(ElementName = "AxisDirectionX")]
            public float AxisDirectionX { get; set; } = 1.00f;

            [XmlElement(ElementName = "AxisDirectionY")]
            public float AxisDirectionY { get; set; } = 1.00f;

            [XmlElement(ElementName = "AxisDirectionZ")]
            public float AxisDirectionZ { get; set; } = 1.00f;

            [XmlElement(ElementName = "AxisDirectionA")]
            public float AxisDirectionA { get; set; } = 1.00f;

            [XmlElement(ElementName = "AxisDirectionB")]
            public float AxisDirectionB { get; set; } = 1.00f;

            [XmlElement(ElementName = "AxisDirectionC")]
            public float AxisDirectionC { get; set; } = 1.00f;

            #endregion


            #region Device information ...
            [XmlElement(ElementName = "DeviceName")]
            public string DeviceName { get; set; } = string.Empty;

            [XmlElement(ElementName = "DeviceManufacturer")]
            public string DeviceManufacturer { get; set; } = string.Empty;

            [XmlElement(ElementName = "DeviceSerialnumber")]
            public string DeviceSerialnumber { get; set; } = string.Empty;
            #endregion


            #region Controller ...
            [XmlIgnore]
            public RCRobotDoosanControl.Doosan? Control { get; set; }
            #endregion


            #region Bus configurations ...
            #region TcpIP / EtherCAT ...
            [XmlElement(ElementName = "TcpIpIsDefault")]
            public bool EthernetIsDefault { get; set; } = false;

            [XmlElement(ElementName = "Etnernet")]
            public Device_EthernetInterface? Ethernet { get; set; }
            #endregion

            #region Functions ...


            #endregion
            #endregion
        }
    }
}
