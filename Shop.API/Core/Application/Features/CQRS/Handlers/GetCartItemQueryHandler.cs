using AutoMapper;
using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class GetCartItemQueryHandler : IRequestHandler<GetCartItemQueryRequest, CartItemListDto>
    {
        private readonly IRepository<CartItem> repository;
        private readonly IMapper mapper;

        public GetCartItemQueryHandler(IMapper mapper, IRepository<CartItem> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<CartItemListDto> Handle(GetCartItemQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilter(x => x.Id == request.Id);
            return this.mapper.Map<CartItemListDto>(data);
        }
    }
}
