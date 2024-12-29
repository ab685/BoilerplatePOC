using Abp.Application.Services.Dto;
using System;

namespace BoilerplatePOC.Products.Dto
{

    /// <summary>
    /// PagedProductResultRequestDto
    /// </summary>
    /// <seealso cref="Abp.Application.Services.Dto.PagedResultRequestDto" />
    public class PagedProductResultRequestDto : PagedResultRequestDto
    {
        /// <summary>
        /// Gets or sets the keyword.
        /// </summary>
        /// <value>
        /// The keyword.
        /// </value>
        public string Keyword { get; set; }
        public bool? IsActive { get; set; }

    }
}
