using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace BoilerplatePOC.Web.Views
{
    public abstract class BoilerplatePOCRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected BoilerplatePOCRazorPage()
        {
            LocalizationSourceName = BoilerplatePOCConsts.LocalizationSourceName;
        }
    }
}
