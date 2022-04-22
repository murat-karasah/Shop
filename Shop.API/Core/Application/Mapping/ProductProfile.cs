using AutoMapper;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Domain.Entity;

namespace Shop.API.Core.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            this.CreateMap<Product, ProductListDto>().ReverseMap(); 
        }
    }
}
