using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbStorage
{
    public class DBStorage_ContextFactory : IDesignTimeDbContextFactory<DbStorage_Context>
    {
        public DbStorage_Context CreateDbContext(string[] args)
        {
            //return new DbStorage_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbStorage\\DbStorage.db");
            return new DbStorage_Context(DatabaseType.PostgreSQL, "Host=db-clu001.branch31.psgm.at:50001;Database=DbStorage;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V");  
        }
    }
}
