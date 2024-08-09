using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_ConfigFile
    {
        public class Device_CanInterface
        {
            #region Bus device information ...
            [XmlElement(ElementName = "Manufacturer")]
            public string? Manufacture { get; set; }

            [XmlElement(ElementName = "DeviceName")]
            public string? DeviceName { get; set; }

            [XmlElement(ElementName = "DeviceSpecifier")]
            public string? DeviceSpecifier { get; set; }
            #endregion


            #region Motion controller information ...
            [XmlElement(ElementName = "CanDeviceId")]
            public int CanDeviceId { get; set; } = 0;
            #endregion
        }

        public class Device_SerialInterface
        {
            [XmlElement(ElementName = "Port")]
            public string Port { get; set; } = string.Empty;

            [XmlElement(ElementName = "Baud")]
            public uint Baud { get; set; } = 0;
        }

        public class Device_EthernetInterface
        {
            [XmlElement(ElementName = "IpAddress")]
            public string? IpAddress { get; set; } = string.Empty;

            [XmlElement(ElementName = "Port")]
            public uint Port { get; set; } = 0;
        }
    }
}
