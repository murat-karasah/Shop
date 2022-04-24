using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class UpdateCartCommandHandler : IRequestHandler<UpdateCartCommandRequest>
    {
        private readonly IRepository<Cart> repository;

        public UpdateCartCommandHandler(IRepository<Cart> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(UpdateCartCommandRequest request, CancellationToken cancellationToken)
        {
            var update = await this.repository.GetById(request.Id);
            if (update != null)
            {
                update.Status = request.Status;
                await this.repository.UpdateAsync(update);

            }
            return Unit.Value;
        }
    }
}
