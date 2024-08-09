using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    public partial class Globals_ConfigFile
    {
        public class MotionConfig
        {
            [XmlElement(ElementName = "Nanotec")]
            public NanotecConfig? Nanotec { get; set; }
        }
    }
}
