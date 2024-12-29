using System.Threading.Tasks;
using Abp.Application.Services;
using BoilerplatePOC.Sessions.Dto;

namespace BoilerplatePOC.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
