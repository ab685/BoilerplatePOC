using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Abp.Application.Services.Dto;
using Abp.AspNetCore.Mvc.Authorization;
using BoilerplatePOC.Authorization;
using BoilerplatePOC.Controllers;
using BoilerplatePOC.Roles;
using BoilerplatePOC.Web.Models.Roles;
using BoilerplatePOC.Products;

namespace BoilerplatePOC.Web.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Products)]
    public class ProductsController : BoilerplatePOCControllerBase
    {
        private readonly IProductsAppService _productsService;

        public ProductsController(IProductsAppService productsService)
        {
            _productsService = productsService;
        }

        public ActionResult Index() => View();

        public async Task<ActionResult> EditModal(int productId)
        {
            var productDto = await _productsService.GetAsync(new EntityDto(productId));
            return PartialView("_EditModal", productDto);
        }
    }
}
