using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbStorageStructure
{
    public class DbStorageStructure_ContextFactory : IDesignTimeDbContextFactory<DbStorageStructure_Context>
    {
        public DbStorageStructure_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DbStorageStructure_Context> optionsBuilder = new DbContextOptionsBuilder<DbStorageStructure_Context>();

            //string envDatabaseType = Environment.GetEnvironmentVariable("PSGM_DBJOB_DATABSETYPE");

            //string connectionStringSQLite = "Data Source=C:\\ProgramData\\PSGM\\Test\\DbJob.db";

            //string connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";

            //string connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
            //#endregion

            //if (Enum.TryParse(envDatabaseType, out DatabaseType databaseType))
            //{
            //    switch (databaseType)
            //    {
            //        case DatabaseType.SQLite:
            //            //return new DbStorageStructure_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DbStorageStructure_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DbStorageStructure_Context(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DbStorageStructure_Context(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            return new DbStorageStructure_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbStorageStructure\\DbStorageStructure.db");
            //return new DbStorageStructure_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbStorageStructure\\DbStorageStructure.db");

            //return new DbStorageStructure_Context(Directory.GetCurrentDirectory() + "\\DbStorageStructure_Context.db");

            //return new DbStorageStructure_Context("db-clu001.branch31.psgm.at:50001", "DbStorageStructure_Context", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");
        }
    }
}