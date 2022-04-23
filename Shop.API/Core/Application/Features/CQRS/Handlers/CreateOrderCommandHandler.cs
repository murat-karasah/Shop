using MediatR;
using Shop.API.Core.Application.Dto;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommandRequest>
    {
        private readonly IRepository<Order> repository;

        public CreateOrderCommandHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            await this.repository.CreateAsync(new Order
            {
              AppUserID=request.AppUserID,
              PaymentStatus=false
            });
            return Unit.Value;
        }
    }
}
