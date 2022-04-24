using AutoMapper;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Domain.Entity;

namespace Shop.API.Core.Application.Mapping
{
    public class CartItemProfile :Profile
    {
        public CartItemProfile()
        {
            this.CreateMap<CartItem, CartItemListDto>().ReverseMap();

        }
    }
}
