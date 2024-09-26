using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbMachine
{
    public class DBMachine_ContextFactory : IDesignTimeDbContextFactory<DbMachine_Context>
    {
        public DbMachine_Context CreateDbContext(string[] args)
        {
            //return new DbMachine_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbMachine\\DbMachine.db");
            return new DbMachine_Context(DatabaseType.PostgreSQL, "Host=db-clu001.branch31.psgm.at:50001;Database=DbMachine;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V");
        }
    }
}