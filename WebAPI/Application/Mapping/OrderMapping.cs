using Application.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    /// <summary>
    /// AutoMapper profile for order-related mappings
    /// </summary>
    public class OrderMapping : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderMappings"/> class
        /// </summary>
        public OrderMapping()
        {
            CreateMap<Order, OrderDto>()
                .ForMember(x => x.Status, y => 
                    y.MapFrom(z => z.Status.ToString()));

            CreateMap<OrderDto, Order>()
                .ForMember(x => x.Status.ToString(), y =>
                    y.MapFrom(z => z.Status));
        }
    }
}
