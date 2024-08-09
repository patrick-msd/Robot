using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbWorkflow
{
    public class DbWorkflowContextFactory : IDesignTimeDbContextFactory<DbWorkflow_Context>
    {
        public DbWorkflow_Context CreateDbContext(string[] args)
        {
            // ToDo: Securit in Vault, Azure ... than it should work ...
            //#region Variables
            //DbContextOptionsBuilder<DBJobContext> optionsBuilder = new DbContextOptionsBuilder<DBJobContext>();

            //string envDatabaseType = Environment.GetEnvironmentVariable("PSGM_DBWORKFLOW_DATABSETYPE");

            //string connectionStringSQLite = "Data Source=C:\\ProgramData\\PSGM\\Test\\DBWorkflow.db";

            //string connectionStringPostgreSQL = "Host=server;Database=database;Username=user;Password=password";

            //string connectionStringSQLServer = "Server=(localdb)\\mssqllocaldb;Database=database;Trusted_Connection=True;";
            //#endregion

            //if (Enum.TryParse(envDatabaseType, out DatabaseType databaseType))
            //{
            //    switch (databaseType)
            //    {
            //        case DatabaseType.SQLite:
            //            //return new DbWorkflow_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);
            //            return new DbWorkflow_Context(optionsBuilder.UseSqlite(connectionStringSQLite).Options);

            //        case DatabaseType.PostgreSQL:
            //            return new DbWorkflow_Context(optionsBuilder.UseNpgsql(connectionStringPostgreSQL).Options);

            //        //case DatabasType.SQLServer:
            //        //    return new DbWorkflow_Context(optionsBuilder.UseSqlServer(connectionStringSQLServer).Options);

            //        default:
            //            throw new Exception("Unsupported database type");
            //    }
            //}
            //else
            //{
            //    throw new Exception($"Invalid database type: {databaseType}");
            //}


            return new DbWorkflow_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbWorkflow\\DbWorkflow.db");
            //return new DbWorkflow_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\PSGM\\PSGM_-_PSGM.Model\\80_Model\\PSGM.Model.DbWorkflow\\DbWorkflow.db");

            //return new DbWorkflow_Context(Directory.GetCurrentDirectory() + "\\DbWorkflow.db");

            //return new DbWorkflow_Context("db-clu001.branch31.psgm.at:50001", "DbWorkflow", "ef.core", "Ulexxubih4LOdKuhC8Hx33d4zA4");
        }
    }
}