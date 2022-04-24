using AutoMapper;
using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class GetCartQueryHandler : IRequestHandler<GetCartQueryRequest, CartListDto>
    {
        private readonly IRepository<Cart> repository;
        private readonly IMapper mapper;

        public GetCartQueryHandler(IMapper mapper, IRepository<Cart> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<CartListDto> Handle(GetCartQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilter(x => x.Id == request.Id);
            return this.mapper.Map<CartListDto>(data);
        }
    }
}
