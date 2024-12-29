using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerplatePOC.Authorization;

namespace BoilerplatePOC
{
    [DependsOn(
        typeof(BoilerplatePOCCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class BoilerplatePOCApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<BoilerplatePOCAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(BoilerplatePOCApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
