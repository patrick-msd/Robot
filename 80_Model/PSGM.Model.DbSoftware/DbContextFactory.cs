using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbSoftware
{
    public class DbUserContextContextFactory : IDesignTimeDbContextFactory<DbSoftware_Context>
    {
        public DbSoftware_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DBSoftware_Context> optionsBuilder = new DbContextOptionsBuilder<DBSoftware_Context>();

            //string envDatabaseType = Environment.GetEnvironmentVariable("PSGM_DBSOFTWARE_DATABSETYPE");

            //string connectionStringSQLite = "Data Source=C:\\ProgramData\\PSGM\\Test\\DBSoftware.db";

            //string connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";

            //string connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
            //#endregion

            //if (Enum.TryParse(envDatabaseType, out DatabaseType databaseType))
            //{
            //    switch (databaseType)
            //    {
            //        case DatabaseType.SQLite:
            //            //return new DBSoftware_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DBSoftware_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DBSoftware_Context(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DBSoftware_Context(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            return new DbSoftware_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbSoftware\\DbSoftware.db");
            //return new DBSoftware_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbSoftware\\DbSoftware.db");

            //return new DBSoftware_Context(Directory.GetCurrentDirectory() + "\\DbSoftware.db");

            //return new DBSoftware_Context("db-clu001.branch31.psgm.at:50001", "DbSoftware", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");
        }
    }
}
