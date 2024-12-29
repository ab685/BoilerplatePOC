using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using BoilerplatePOC.Controllers;

namespace BoilerplatePOC.Web.Controllers
{
    [AbpMvcAuthorize]
    public class AboutController : BoilerplatePOCControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}
