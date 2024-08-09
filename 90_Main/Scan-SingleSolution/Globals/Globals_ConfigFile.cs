using System.IO;
using System.Xml.Serialization;

namespace RC.Scan_SingleSolution
{
    [XmlRoot(ElementName = "ApplicationSettings")]
    public partial class Globals_ConfigFile
    {

        #region XML - Root
        [XmlElement(ElementName = "Motion")]
        public MotionConfig? Motion { get; set; }

        [XmlElement(ElementName = "Robot")]
        public RobotConfig? Robot { get; set; }
        #endregion

        //#region Constructor
        //public Globals_ConfigFile()
        //{
        //    Motion = new MotionConfig()
        //    {
        //        Nanotec = new NanotecConfig()
        //        {
        //            MotionController = new MotionController(),
        //            MotionControllerConfigs = new List<MotionControllerConfig>()
        //        }
        //    };
        //}
        //#endregion

        #region Helper
        public void Save(string configFilePath)
        {
            // Create a new Serializer
            XmlSerializer serializer = new XmlSerializer(typeof(Globals_ConfigFile));

            // Create a new StreamWriter
            TextWriter writer = new StreamWriter(configFilePath);

            // Serialize the file
            serializer.Serialize(writer, this);

            // Close the writer
            writer.Close();
        }

        public void Load(string configFilePath)
        {
            // Create a new serializer
            XmlSerializer serializer = new XmlSerializer(typeof(Globals_ConfigFile));

            // Create a StreamReader
            TextReader reader = new StreamReader(configFilePath);

            // Deserialize the file
            Globals_ConfigFile temp = (Globals_ConfigFile)serializer.Deserialize(reader);

            // Close the reader
            reader.Close();

            // Write to class
            Motion = temp.Motion;
            Robot = temp.Robot;
        }
        #endregion
    }
}
