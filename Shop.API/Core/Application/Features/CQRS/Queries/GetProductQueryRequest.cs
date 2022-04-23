using MediatR;
using Shop.API.Core.Application.Dto;

namespace Shop.API.Core.Application.Features.CQRS.Queries
{
    public class GetProductQueryRequest: IRequest<ProductListDto>
    {
        public int Id{ get; set; }

        public GetProductQueryRequest(int id)
        {
            Id=id;
        }
    }
}
