using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace BoilerplatePOC.Controllers
{
    public abstract class BoilerplatePOCControllerBase: AbpController
    {
        protected BoilerplatePOCControllerBase()
        {
            LocalizationSourceName = BoilerplatePOCConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
