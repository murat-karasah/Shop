using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public CreateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateProductCommandRequest request, CancellationToken cancellationToken)
        {
          await  this.repository.CreateAsync(new Product
            {
                CategoryId=request.CategoryId,
                Name=request.Name,
                Price=request.Price,
                Stock=request.Stock,

            });
            return Unit.Value;  
        }
    }
}
