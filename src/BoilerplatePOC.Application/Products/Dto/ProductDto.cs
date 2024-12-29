using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using BoilerplatePOC.MultiTenancy;

namespace BoilerplatePOC.Products.Dto
{
    /// <summary>
    /// Product Dto
    /// </summary>
    /// <seealso cref="EntityDto" />
    [AutoMapFrom(typeof(Product))]
    public class ProductDto : EntityDto<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
       
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>
        /// The sku.
        /// </value>
       
        public string SKU { get; set; }

        /// <summary>
        /// Gets or sets the stock quantity.
        /// </summary>
        /// <value>
        /// The stock quantity.
        /// </value>
        public int StockQuantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is active.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is active; otherwise, <c>false</c>.
        /// </value>
        public bool IsActive { get; set; }
    }
}
