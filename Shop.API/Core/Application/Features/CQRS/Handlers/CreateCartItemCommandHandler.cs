using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class CreateCartItemCommandHandler : IRequestHandler<CreateCartItemCommandRequest>
    {
        private readonly IRepository<CartItem> repository;
    
        public CreateCartItemCommandHandler(IRepository<CartItem> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new CartItem
            {
                CartId = request.CartId,
                ProductId = request.ProductId,
                ProducAmount = request.ProducAmount,
                ProducPrice=request.ProducPrice

            });
            return Unit.Value;
        }
    }
}
