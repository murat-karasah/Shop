using AutoMapper;
using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class GetOrderQueryHandler : IRequestHandler<GetOrderQueryRequest, OrderListDto>
    {
        private readonly IRepository<Order> repository;
        private readonly IMapper mapper;
        public GetOrderQueryHandler(IRepository<Order> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

       

        public async Task<OrderListDto> Handle(GetOrderQueryRequest request, CancellationToken cancellationToken)
        {
            var data = await this.repository.GetByFilter(x => x.Id == request.Id);
            return this.mapper.Map<OrderListDto>(data);
        }
    }
}
