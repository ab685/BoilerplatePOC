using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoilerplatePOC.Products
{

    /// <summary>
    /// Product Entity
    /// </summary>
    /// <seealso cref="Abp.Domain.Entities.Entity&lt;System.Int32&gt;" />
    public class Product : Entity<int>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        [Required]
        [StringLength(200)]
        [Column(TypeName = "varchar(200)")]
        public string Name { get; set; }


        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        /// <value>
        /// The sku.
        /// </value>
        [Required]
        [Column(TypeName = "varchar(50)")]
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
