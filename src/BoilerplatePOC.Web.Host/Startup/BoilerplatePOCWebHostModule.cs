using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using BoilerplatePOC.Configuration;

namespace BoilerplatePOC.Web.Host.Startup
{
    [DependsOn(
       typeof(BoilerplatePOCWebCoreModule))]
    public class BoilerplatePOCWebHostModule: AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public BoilerplatePOCWebHostModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(BoilerplatePOCWebHostModule).GetAssembly());
        }
    }
}
