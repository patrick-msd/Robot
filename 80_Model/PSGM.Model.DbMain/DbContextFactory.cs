using Microsoft.EntityFrameworkCore.Design;
using PSGM.Helper;

namespace PSGM.Model.DbMain
{
    public class DBMain_ContextFactory : IDesignTimeDbContextFactory<DbMain_Context>
    {
        public DbMain_Context CreateDbContext(string[] args)
        {
            //return new DbMain_Context(DatabaseType.ConnectionString, "Data Source=C:\\Git\\MSD\\Robot\\80_Model\\PSGM.Model.DbMain\\DbMain.db");
            return new DbMain_Context(DatabaseType.PostgreSQL, "Host=db-clu001.branch31.psgm.at:50001;Database=DbMain;Username=postgres;Password=fU5fUXXNzBMWB0BZ2fvwPdnO9lp4twG7P6DC2V");
        }
    }
}
