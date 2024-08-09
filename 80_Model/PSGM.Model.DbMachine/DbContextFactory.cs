using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbMachine
{
    public class DBMachineContextFactory : IDesignTimeDbContextFactory<DbMachine_Context>
    {
        public DbMachine_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DBMachine_Context> optionsBuilder = new DbContextOptionsBuilder<DbMachine_Context>();

            //string envDatabaseType = Environment.GetEnvironmentVariable("PSGM_DBMachine_DATABSETYPE");

            //string connectionStringSQLite = "Data Source=C:\\ProgramData\\PSGM\\Test\\DbMachine.db";

            //string connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";

            //string connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
            //#endregion

            //if (Enum.TryParse(envDatabaseType, out DatabaseType databaseType))
            //{
            //    switch (databaseType)
            //    {
            //        case DatabaseType.SQLite:
            //            //return new DBMachine_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DBMachine_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DBMachine_Context(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DBMachine_Context(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            return new DbMachine_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbMachine\\DbMachine.db");
            //return new DBMachine_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbMachine\\DbMachine.db");

            //return new DBMachine_Context(Directory.GetCurrentDirectory() + "\\DbMachine.db");

            //return new DBMachine_Context("db-clu001.branch31.psgm.at:50001", "DbMachine", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");
        }
    }
}