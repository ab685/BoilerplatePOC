using Abp.Application.Services;
using BoilerplatePOC.MultiTenancy.Dto;
using BoilerplatePOC.Products.Dto;

namespace BoilerplatePOC.Products
{
    /// <summary>
    /// IProductsAppService
    /// </summary>
    /// <seealso cref="Abp.Application.Services.IAsyncCrudAppService{ProductDto, int, PagedProductResultRequestDto, CreateProductDto, UpdateProductDto}" />
    public interface IProductsAppService : IAsyncCrudAppService<ProductDto, int, PagedProductResultRequestDto, CreateProductDto, UpdateProductDto>
    {
    }
}

