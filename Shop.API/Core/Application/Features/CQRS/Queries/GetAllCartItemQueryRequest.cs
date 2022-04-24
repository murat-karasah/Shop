using MediatR;
using Shop.API.Core.Application.Dto;

namespace Shop.API.Core.Application.Features.CQRS.Queries
{
    public class GetAllCartItemQueryRequest : IRequest<List<CartItemListDto>>
    {
    }
}
