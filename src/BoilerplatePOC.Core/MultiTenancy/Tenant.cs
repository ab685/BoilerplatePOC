using Abp.MultiTenancy;
using BoilerplatePOC.Authorization.Users;

namespace BoilerplatePOC.MultiTenancy
{
    public class Tenant : AbpTenant<User>
    {
        public Tenant()
        {            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
