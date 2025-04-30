using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for orderProduct-related mappings
    /// </summary>
    public class OrderProductMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderMappings"/> class
        /// </summary>
        public OrderProductMapping()
        {
            CreateMap<OrderProduct, OrderProductDto>();
            CreateMap<OrderProductDto, OrderProduct>();
        }
    }
}
