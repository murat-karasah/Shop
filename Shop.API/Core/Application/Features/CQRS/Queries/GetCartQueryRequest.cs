using MediatR;
using Shop.API.Core.Application.Dto;

namespace Shop.API.Core.Application.Features.CQRS.Queries
{
    public class GetCartQueryRequest : IRequest<CartListDto>
    {
        public int Id { get; set; }
        public GetCartQueryRequest(int id)
        {
            Id = id;
        }
    }
}
