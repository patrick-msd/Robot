using Newtonsoft.Json;

namespace PSGM.Helper
{
    public partial class ConfigFile
    {
        public DatabaseType DatabaseType { get; set; } = DatabaseType.SQLite;
        public string DatabaseConnectionString { get; set; } = string.Empty;

        public bool ConfigFileExists(string filePath)
        {
            return File.Exists(filePath);
        }

        public void WriteToFile(string filePath)
        {
            string jsonString = JsonConvert.SerializeObject(this, Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
        }

        public ConfigFile ReadFromFile(string filePath)
        {
            string jsonString = File.ReadAllText(filePath);
            var deserializedPerson = JsonConvert.DeserializeObject<ConfigFile>(jsonString);

            this.DatabaseType = deserializedPerson.DatabaseType;
            this.DatabaseConnectionString = deserializedPerson.DatabaseConnectionString;

            return deserializedPerson;
        }
    }
}
