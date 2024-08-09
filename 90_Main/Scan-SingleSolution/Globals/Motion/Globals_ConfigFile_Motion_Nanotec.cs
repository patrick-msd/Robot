using RC.Motion.Nanotec.MotionController;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_ConfigFile
    {
        public class NanotecConfig
        {
            #region Configurations of all motion controllers ...
            [XmlElement(ElementName = "MotionControllerDevices")]
            public List<MotionControllerDeviceConfig>? MotionControllerDeviceConfigs { get; set; }
            #endregion


            #region Motion bus controller ..
            [XmlIgnore]
            public MotionBusController? MotionBusController { get; set; }

            [XmlIgnore]
            public Nlc.BusHardwareId? MotionBusHardwareId { get; set; }

            [XmlIgnore]
            public Nlc.DeviceIdVector? MotionBusDeviceIds { get; set; }
            #endregion


            #region Functions ...
            [XmlIgnore]
            public List<Device_CanInterface>? GetInterfacesCan
            {
                get
                {
                    if (MotionControllerDeviceConfigs != null)
                    {
                        List<MotionControllerDeviceConfig>? elements = MotionControllerDeviceConfigs.OrderBy(item => item.Can.DeviceSpecifier).ToList();
                        List<Device_CanInterface>? tmp = new List<Device_CanInterface>();

                        if (elements != null)
                        {
                            tmp.Add(elements[0].Can);

                            for (int i = 1; i < elements.Count; i++)
                            {
                                if (elements[i - 1] == elements[i])
                                {
                                    tmp.Add(elements[i].Can);
                                }
                            }
                        }

                        return tmp;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            [XmlIgnore]
            public List<Device_SerialInterface>? GetInterfacesSerial
            {
                get
                {
                    if (MotionControllerDeviceConfigs != null)
                    {
                        List<MotionControllerDeviceConfig>? elements = MotionControllerDeviceConfigs.OrderBy(item => item.Serial.Port).ToList();
                        List<Device_SerialInterface>? tmp = new List<Device_SerialInterface>();

                        if (elements != null)
                        {
                            tmp.Add(elements[0].Serial);

                            for (int i = 1; i < elements.Count; i++)
                            {
                                if (elements[i - 1] == elements[i])
                                {
                                    tmp.Add(elements[i].Serial);
                                }
                            }
                        }

                        return tmp;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            [XmlIgnore]
            public List<Device_EthernetInterface>? GetInterfacesEthernet
            {
                get
                {
                    if (MotionControllerDeviceConfigs != null)
                    {
                        List<MotionControllerDeviceConfig>? elements = MotionControllerDeviceConfigs.OrderBy(item => item.Ethernet.Port).ToList();
                        List<Device_EthernetInterface>? tmp = new List<Device_EthernetInterface>();

                        if (elements != null)
                        {
                            tmp.Add(elements[0].Ethernet);

                            for (int i = 1; i < elements.Count; i++)
                            {
                                if (elements[i - 1] == elements[i])
                                {
                                    tmp.Add(elements[i].Ethernet);
                                }
                            }
                        }

                        return tmp;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            #endregion
        }
    }
}
