using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbStorage
{
    public class DBStorage_ContextFactory : IDesignTimeDbContextFactory<DbStorage_Context>
    {
        public DbStorage_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DBStorageContext> optionsBuilder = new DbContextOptionsBuilder<DBStorageContext>();

            //string envDatabaseType = Environment.GetEnvironmentVariable("PSGM_DBSTORAGE_DATABSETYPE");

            //string connectionStringSQLite = "Data Source=C:\\ProgramData\\PSGM\\Test\\DBStorage.db";

            //string connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";

            //string connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
            //#endregion

            //if (Enum.TryParse(envDatabaseType, out DatabaseType databaseType))
            //{
            //    switch (databaseType)
            //    {
            //        case DatabaseType.SQLite:
            //            //return new DBStorageContext(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DBStorageContext(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DBStorageContext(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DBStorageContext(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            //return new DbStorage_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbStorage\\DbStorage.db");

            return new DbStorage_Context(DatabaseType.PostgreSQL, "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorage;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V");

            //return new DBStorageContext(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbStorage\\DbStorage.db");

            //return new DBStorageContext(Directory.GetCurrentDirectory() + "\\DbStorage.db");

            //return new DBStorageContext("db-clu001.branch31.psgm.at:50001", "DbStorage", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");

           

            
        }
    }
}
