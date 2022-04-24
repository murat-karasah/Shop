using MediatR;
using Shop.API.Core.Application.Dto;

namespace Shop.API.Core.Application.Features.CQRS.Queries
{
    public class GetOrderQueryRequest : IRequest<OrderListDto>
    {
        public int Id { get; set; }

        public GetOrderQueryRequest(int id)
        {
            Id = id;
        }
    }
}
