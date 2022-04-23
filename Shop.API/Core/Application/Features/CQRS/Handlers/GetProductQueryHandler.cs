using AutoMapper;
using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQueryRequest, ProductListDto>
    {
        private readonly IRepository<Product> repository;
        private readonly IMapper mapper;

        public GetProductQueryHandler(IRepository<Product> repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public async Task<ProductListDto> Handle(GetProductQueryRequest request, CancellationToken cancellationToken)
        {
           var data =  await this.repository.GetByFilter(x => x.Id == request.Id);
            return this.mapper.Map<ProductListDto>(data);
        }
    }
}
