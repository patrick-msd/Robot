using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbBackend
{
    public class DbBackend_ContextFactory : IDesignTimeDbContextFactory<DbBackend_Context>
    {
        public DbBackend_Context CreateDbContext(string[] args)
        {
            //return new DbBackend_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbBackend\\DbBackend.db");
            return new DbBackend_Context(DatabaseType.PostgreSQL, "Host=db-clu001.branch31.psgm.at:50001;Database=DbBackend;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V");
        }
    }
}