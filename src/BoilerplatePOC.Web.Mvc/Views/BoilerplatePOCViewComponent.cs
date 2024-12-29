using Abp.AspNetCore.Mvc.ViewComponents;

namespace BoilerplatePOC.Web.Views
{
    public abstract class BoilerplatePOCViewComponent : AbpViewComponent
    {
        protected BoilerplatePOCViewComponent()
        {
            LocalizationSourceName = BoilerplatePOCConsts.LocalizationSourceName;
        }
    }
}
