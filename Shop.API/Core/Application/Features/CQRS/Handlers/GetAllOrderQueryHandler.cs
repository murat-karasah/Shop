using AutoMapper;
using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrderQueryRequest, List<OrderListDto>>
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;

        public GetAllOrderQueryHandler(IMapper mapper, IRepository<Order> repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public async Task<List<OrderListDto>> Handle(GetAllOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetAllAsync();
            return this.mapper.Map<List<OrderListDto>>(data);
        }
    }
}
