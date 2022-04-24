using AutoMapper;
using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCartItemQueryHandler :IRequestHandler<GetAllCartItemQueryRequest, List<CartItemListDto>>
    {
        private readonly IRepository<CartItem> repository;
    private readonly IMapper mapper;

        public GetAllCartItemQueryHandler(IMapper mapper, IRepository<CartItem> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<List<CartItemListDto>> Handle(GetAllCartItemQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<CartItemListDto>>(data);
        }
    }
}
