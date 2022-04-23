using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommandRequest>
    {
        private readonly IRepository<Product> repository;

        public UpdateProductCommandHandler(IRepository<Product> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateProductCommandRequest request, CancellationToken cancellationToken)
        {
            var update = await this.repository.GetById(request.Id);
            if (update!=null)
            {
                update.CategoryId = request.CategoryId;
                update.Stock = request.Stock;
                update.Price = request.Price;
                update.Name=request.Name;
               await this.repository.UpdateAsync(update);

            }
            return Unit.Value;
         }
    }
}
