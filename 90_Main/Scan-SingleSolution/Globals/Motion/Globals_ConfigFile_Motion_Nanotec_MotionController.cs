using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_ConfigFile
    {
        public class MotionControllerDeviceConfig
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
            #endregion


            #region Device information ...
            [XmlElement(ElementName = "DeviceName")]
            public string DeviceName { get; set; } = string.Empty;

            [XmlElement(ElementName = "DeviceManufacturer")]
            public string DeviceManufacturer { get; set; } = string.Empty;

            [XmlElement(ElementName = "DeviceSerialnumber")]
            public string DeviceSerialnumber { get; set; } = string.Empty;
            #endregion


            #region Bus configurations ...
            #region CAN ...
            [XmlElement(ElementName = "CANIsDefault")]
            public bool CanIsDefault { get; set; } = false;

            [XmlElement(ElementName = "CAN")]
            public Device_CanInterface? Can { get; set; }
            #endregion


            #region Serial ...
            [XmlElement(ElementName = "SerialIsDefault")]
            public bool SerialIsDefault { get; set; } = false;

            [XmlElement(ElementName = "Serial")]
            public Device_SerialInterface? Serial { get; set; }
            #endregion


            #region TcpIP / EtherCAT ...
            [XmlElement(ElementName = "TcpIpIsDefault")]
            public bool EthernetIsDefault { get; set; } = false;

            [XmlElement(ElementName = "Etnernet")]
            public Device_EthernetInterface? Ethernet { get; set; }
            #endregion
            #endregion


            #region Bus device settings ...
            [XmlIgnore]
            public Nlc.DeviceId DeviceId { get; set; }

            [XmlIgnore]
            public Nlc.DeviceHandle DeviceHandle { get; set; }
            #endregion
        }
    }
}
