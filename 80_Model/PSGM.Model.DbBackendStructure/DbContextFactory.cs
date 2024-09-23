using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbBackendStructure
{
    public class DbBackendStructure_ContextFactory : IDesignTimeDbContextFactory<DbBackendStructure_Context>
    {
        public DbBackendStructure_Context CreateDbContext(string[] args)
        {
            //return new DbBackendStructure_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbBackendStructure\\DbBackendStructure.db");
            return new DbBackendStructure_Context(DatabaseType.PostgreSQL, "Host=db-clu001.branch31.psgm.at:50001;Database=DbBackendStructure;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V");
        }
    }
}