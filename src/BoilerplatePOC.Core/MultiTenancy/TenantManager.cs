using Abp.Application.Features;
using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using BoilerplatePOC.Authorization.Users;
using BoilerplatePOC.Editions;

namespace BoilerplatePOC.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager,
            IAbpZeroFeatureValueStore featureValueStore) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager,
                featureValueStore)
        {
        }
    }
}
