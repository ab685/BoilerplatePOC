using System.Threading.Tasks;
using BoilerplatePOC.Configuration.Dto;

namespace BoilerplatePOC.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
