using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_ConfigFile
    {
        public class RobotConfig
        {
            [XmlElement(ElementName = "Doosan")]
            public DoosanConfig? Doosan { get; set; }
        }
    }
}
