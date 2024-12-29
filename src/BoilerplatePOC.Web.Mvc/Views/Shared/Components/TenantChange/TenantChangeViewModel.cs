using Abp.AutoMapper;
using BoilerplatePOC.Sessions.Dto;

namespace BoilerplatePOC.Web.Views.Shared.Components.TenantChange
{
    [AutoMapFrom(typeof(GetCurrentLoginInformationsOutput))]
    public class TenantChangeViewModel
    {
        public TenantLoginInfoDto Tenant { get; set; }
    }
}
