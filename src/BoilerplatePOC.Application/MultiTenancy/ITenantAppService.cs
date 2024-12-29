using Abp.Application.Services;
using BoilerplatePOC.MultiTenancy.Dto;

namespace BoilerplatePOC.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

