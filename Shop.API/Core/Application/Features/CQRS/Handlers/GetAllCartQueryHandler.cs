using AutoMapper;
using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class GetAllCartQueryHandler : IRequestHandler<GetAllCartQueryRequest, List<CartListDto>>
    {
        private readonly IRepository<Cart> repository;
        private readonly IMapper mapper;

        public GetAllCartQueryHandler(IRepository<Cart> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        public async Task<List<CartListDto>> Handle(GetAllCartQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<CartListDto>>(data);
        }
    }
}
