using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_ConfigFile
    {
        public class DoosanConfig
        {
           
            #region Configurations of all motion controllers ...
            [XmlElement(ElementName = "MotionControllerDevices")]
            public List<ControlDeviceConfig>? ControlDeviceConfigs { get; set; }
            #endregion

 /*
            #region Motion bus controller ..
            [XmlIgnore]
            public MotionBusController? MotionBusController { get; set; }

            [XmlIgnore]
            public Nlc.BusHardwareId? MotionBusHardwareId { get; set; }

            [XmlIgnore]
            public Nlc.DeviceIdVector? MotionBusDeviceIds { get; set; }
            #endregion
 */

            #region Functions ...
            [XmlIgnore]
            public List<Device_EthernetInterface>? GetInterfacesEthernet
            {
                get
                {
                    if (ControlDeviceConfigs != null)
                    {
                        List<ControlDeviceConfig>? elements = ControlDeviceConfigs.OrderBy(item => item.Ethernet.Port).ToList();
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
