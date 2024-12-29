using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Collections.Extensions;
using Abp.Domain.Repositories;
using Abp.Extensions;
using BoilerplatePOC.Authorization;
using BoilerplatePOC.Authorization.Roles;
using BoilerplatePOC.Authorization.Users;
using BoilerplatePOC.MultiTenancy.Dto;
using BoilerplatePOC.Products.Dto;
using BoilerplatePOC.Roles.Dto;
using BoilerplatePOC.Users.Dto;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BoilerplatePOC.Products
{
    /// <summary>
    /// ProductsAppService
    /// </summary>
    /// <seealso cref="BoilerplatePOC.Products.IProductsAppService" />
    [AbpAuthorize(PermissionNames.Pages_Products)]

    public class ProductsAppService : AsyncCrudAppService<Product, ProductDto, int, PagedProductResultRequestDto, CreateProductDto, UpdateProductDto>, IProductsAppService
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsAppService"/> class.
        /// </summary>
        /// <param name="repository">The repository.</param>
        public ProductsAppService(
            IRepository<Product> repository
           )
            : base(repository)
        {

        }

        /// <summary>
        /// This method should create <see cref="T:System.Linq.IQueryable`1" /> based on given input.
        /// It should filter query if needed, but should not do sorting or paging.
        /// Sorting should be done in <see cref="M:Abp.Application.Services.CrudAppServiceBase`6.ApplySorting(System.Linq.IQueryable{`0},`3)" /> and paging should be done in <see cref="M:Abp.Application.Services.CrudAppServiceBase`6.ApplyPaging(System.Linq.IQueryable{`0},`3)" />
        /// methods.
        /// </summary>
        /// <param name="input">The input.</param>
        /// <returns></returns>
        protected override IQueryable<Product> CreateFilteredQuery(PagedProductResultRequestDto input)
        {
            var query = Repository.GetAll(); // Start with the repository's IQueryable

            // Apply the keyword filter if the input keyword is not null or empty
            if (!input.Keyword.IsNullOrWhiteSpace())
            {
                query = query.Where(x =>
                    x.Name.Contains(input.Keyword) ||
                    x.SKU.Contains(input.Keyword) ||
                    x.Description.Contains(input.Keyword) ||
                    x.Price.ToString().Contains(input.Keyword) ||  // Search in Price
                    x.StockQuantity.ToString().Contains(input.Keyword)  // Search in StockQuantity
                );
            }

            // Apply the IsActive filter if the input IsActive value is provided
            if (input.IsActive.HasValue)
            {
                query = query.Where(x => x.IsActive == input.IsActive);
            }

            return query;
        }

       

    }
}

