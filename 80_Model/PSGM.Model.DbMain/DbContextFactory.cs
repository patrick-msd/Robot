using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public class DBMain_ContextFactory : IDesignTimeDbContextFactory<DbMain_Context>
    {
        public DbMain_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DBMainContext> optionsBuilder = new DbContextOptionsBuilder<DbMainContext>();

            //string envDatabaseType = Environment.GetEnvironmentVariable("PSGM_DBMAIN_DATABSETYPE");

            //string connectionStringSQLite = "Data Source=C:\\ProgramData\\PSGM\\Test\\DbMain.db";

            //string connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";

            //string connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
            //#endregion

            //if (Enum.TryParse(envDatabaseType, out DatabaseType databaseType))
            //{
            //    switch (databaseType)
            //    {
            //        case DatabaseType.SQLite:
            //            //return new DBMainContext(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DBMainContext(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DBMainContext(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DBMainContext(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            return new DbMain_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbMain\\DbMain.db");
            //return new DBMainContext(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbMain\\DbMain.db");

            //return new DBMainContext(Directory.GetCurrentDirectory() + "\\DBMain.db");

            //return new DBMainContext("db-clu001.branch31.psgm.at:50001", "DBMain", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");
        }
    }
}
