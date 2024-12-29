using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerplatePOC.Configuration;
using BoilerplatePOC.EntityFrameworkCore;
using BoilerplatePOC.Migrator.DependencyInjection;

namespace BoilerplatePOC.Migrator
{
    [DependsOn(typeof(BoilerplatePOCEntityFrameworkModule))]
    public class BoilerplatePOCMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public BoilerplatePOCMigratorModule(BoilerplatePOCEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(BoilerplatePOCMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                BoilerplatePOCConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerplatePOCMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
