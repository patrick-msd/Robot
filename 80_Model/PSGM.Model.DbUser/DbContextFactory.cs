using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbUser
{
    public class DbUser_ContextFactory : IDesignTimeDbContextFactory<DbUser_Context>
    {
        public DbUser_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DbUser_Context> optionsBuilder = new DbContextOptionsBuilder<DbUser_Context>();

            //string envDatabaseType = Environment.GetEnvironmentVariable("PSGM_DBUser_DATABSETYPE");

            //string connectionStringSQLite = "Data Source=C:\\ProgramData\\PSGM\\Test\\DBUser.db";

            //string connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";

            //string connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
            //#endregion

            //if (Enum.TryParse(envDatabaseType, out DatabaseType databaseType))
            //{
            //    switch (databaseType)
            //    {
            //        case DatabaseType.SQLite:
            //            //return new DbUser_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DbUser_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DbUser_Context(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DbUser_Context(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            return new DbUser_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbUser\\DbUser.db");
            //return new DbUser_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbUser\\DbUser.db");

            //return new DbUser_Context(Directory.GetCurrentDirectory() + "\\DbUser.db");

            //return new DbUser_Context("db-clu001.branch31.psgm.at:50001", "DbUser", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");
        }
    }
}
