using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for product-related mappings
    /// </summary>
    public class ProductMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderMappings"/> class
        /// </summary>
        public ProductMapping()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();
        }
    }
}
