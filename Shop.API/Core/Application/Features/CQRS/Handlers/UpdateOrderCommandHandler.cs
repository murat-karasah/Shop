using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommandRequest>
    {
        private readonly IRepository<Order> repository;

        public UpdateOrderCommandHandler(IRepository<Order> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateOrderCommandRequest request, CancellationToken cancellationToken)
        {
            var update = await this.repository.GetById(request.Id);
            if (update != null)
            {
                update.PaymentStatus = request.PaymentStatus;
                await this.repository.UpdateAsync(update);

            }
            return Unit.Value;
        }
    }
}
