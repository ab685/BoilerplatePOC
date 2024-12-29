using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace BoilerplatePOC.EntityFrameworkCore
{
    public static class BoilerplatePOCDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<BoilerplatePOCDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<BoilerplatePOCDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
