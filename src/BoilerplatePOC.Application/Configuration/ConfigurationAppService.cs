using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using BoilerplatePOC.Configuration.Dto;

namespace BoilerplatePOC.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : BoilerplatePOCAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
