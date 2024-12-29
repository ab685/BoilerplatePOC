using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using BoilerplatePOC.Authorization.Roles;
using BoilerplatePOC.Authorization.Users;
using BoilerplatePOC.MultiTenancy;
using BoilerplatePOC.Products;

namespace BoilerplatePOC.EntityFrameworkCore
{
    public class BoilerplatePOCDbContext : AbpZeroDbContext<Tenant, Role, User, BoilerplatePOCDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Product> Products { get; set; }
        public BoilerplatePOCDbContext(DbContextOptions<BoilerplatePOCDbContext> options)
            : base(options)
        {
        }
    }
}
