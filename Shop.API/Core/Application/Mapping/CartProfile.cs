using AutoMapper;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Domain.Entity;

namespace Shop.API.Core.Application.Mapping
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            this.CreateMap<Cart, CartListDto>().ReverseMap();

        }
    }
}
