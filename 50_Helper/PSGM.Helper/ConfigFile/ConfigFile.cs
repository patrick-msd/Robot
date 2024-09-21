using Newtonsoft.Json;

namespace PSGM.Helper
{
    public partial class ConfigFile
    {
        public string JobDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbJob.db";
        public DatabaseType JobDatabaseType { get; set; } = DatabaseType.SQLite;

        public string MachineDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbMachine.db";
        public DatabaseType MachineDatabaseType { get; set; } = DatabaseType.SQLite;

        public string MainDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbMain.db";
        public DatabaseType MainDatabaseType { get; set; } = DatabaseType.SQLite;

        public string SoftwareDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbSoftware.db";
        public DatabaseType SoftwareDatabaseType { get; set; } = DatabaseType.SQLite;

        public string StorageDataDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbStorageData.db";
        public DatabaseType StorageDataDatabaseType { get; set; } = DatabaseType.SQLite;

        //public string StorageDataRawDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbStorageDataRaw.db";
        //public DatabaseType StorageDataRawDatabaseType  { get; set; }= DatabaseType.SQLite;

        public string StorageStructureDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbStorageStructure.db";
        public DatabaseType StorageStructureDatabaseType { get; set; } = DatabaseType.SQLite;

        public string UserDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbUser.db";
        public DatabaseType UserDatabaseType { get; set; } = DatabaseType.SQLite;

        public string WorkflowDatabaseConnectionString { get; set; } = "Data Source=" + Directory.GetCurrentDirectory() + "\\DbWorkflow.db";
        public DatabaseType WorkflowDatabaseType { get; set; } = DatabaseType.SQLite;

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

            this.JobDatabaseConnectionString = deserializedPerson.JobDatabaseConnectionString;
            this.JobDatabaseType = deserializedPerson.JobDatabaseType;

            this.MachineDatabaseConnectionString = deserializedPerson.MachineDatabaseConnectionString;
            this.MachineDatabaseType = deserializedPerson.MachineDatabaseType;

            this.MainDatabaseConnectionString = deserializedPerson.MainDatabaseConnectionString;
            this.MainDatabaseType = deserializedPerson.MainDatabaseType;

            this.SoftwareDatabaseConnectionString = deserializedPerson.SoftwareDatabaseConnectionString;
            this.SoftwareDatabaseType = deserializedPerson.SoftwareDatabaseType;

            this.StorageDataDatabaseConnectionString = deserializedPerson.StorageDataDatabaseConnectionString;
            this.StorageDataDatabaseType = deserializedPerson.StorageDataDatabaseType;

            //this.StorageDataRawDatabaseConnectionString = deserializedPerson.StorageDataRawDatabaseConnectionString;
            //this.StorageDataRawDatabaseType = deserializedPerson.StorageDataRawDatabaseType;

            this.StorageStructureDatabaseConnectionString = deserializedPerson.StorageStructureDatabaseConnectionString;
            this.StorageStructureDatabaseType = deserializedPerson.StorageStructureDatabaseType;

            this.UserDatabaseConnectionString = deserializedPerson.UserDatabaseConnectionString;
            this.UserDatabaseType = deserializedPerson.UserDatabaseType;

            this.WorkflowDatabaseConnectionString = deserializedPerson.WorkflowDatabaseConnectionString;
            this.WorkflowDatabaseType = deserializedPerson.WorkflowDatabaseType;

            return deserializedPerson;
        }
    }
}
