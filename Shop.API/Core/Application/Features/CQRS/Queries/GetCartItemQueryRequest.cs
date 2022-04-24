using MediatR;
using Shop.API.Core.Application.Dto;

namespace Shop.API.Core.Application.Features.CQRS.Queries
{
    public class GetCartItemQueryRequest : IRequest<CartItemListDto>
    {
        public int Id { get; set; }
        public GetCartItemQueryRequest(int id)
        {
            Id = id;
        }
    }
}
