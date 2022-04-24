using AutoMapper;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Domain.Entity;

namespace Shop.API.Core.Application.Mapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            this.CreateMap<Order, OrderListDto>().ReverseMap();

        }
    }
}
