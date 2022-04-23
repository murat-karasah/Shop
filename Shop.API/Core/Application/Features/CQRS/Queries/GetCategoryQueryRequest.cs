using MediatR;
using Shop.API.Core.Application.Dto;

namespace Shop.API.Core.Application.Features.CQRS.Queries
{
    public class GetCategoryQueryRequest : IRequest<CategoryListDto>
    {
        public int Id { get; set; }
        public GetCategoryQueryRequest(int id)
        {
            Id = id;    
        }
    }
}
