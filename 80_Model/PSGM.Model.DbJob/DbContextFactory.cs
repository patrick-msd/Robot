using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbJob
{
    public class DBJob_ContextFactory : IDesignTimeDbContextFactory<DbJob_Context>
    {
        public DbJob_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DBJobContext> optionsBuilder = new DbContextOptionsBuilder<DbJobContext>();

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
            //            //return new DBJobContext(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DBJobContext(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DBJobContext(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DBJobContext(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            return new DbJob_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbJob\\DbJob.db");
            //return new DBJobContext(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbJob\\DbJob.db");

            //return new DBJobContext(Directory.GetCurrentDirectory() + "\\DbJob.db");

            //return new DBJobContext("db-clu001.branch31.psgm.at:50001", "DbJob", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");
        }
    }
}