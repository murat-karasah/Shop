using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class CreateCartCommandHandler : IRequestHandler<CreateCartCommandRequest>
    {
        private readonly IRepository<Cart> repository;

        public CreateCartCommandHandler(IRepository<Cart> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateCartCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Cart
            {
                AppUserID=request.AppUserID,
                Status=false,
                OrderId=request.OrderId
               
            });
            return Unit.Value;
        }
    }
}
