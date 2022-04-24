using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCartItemCommandHandler : IRequestHandler<DeleteCartItemCommandRequest>
    {
        private readonly IRepository<CartItem> repository;

        public DeleteCartItemCommandHandler(IRepository<CartItem> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCartItemCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteEntity = await this.repository.GetById(request.Id);
            if (deleteEntity != null)
            {
                await this.repository.RemoveAsync(deleteEntity);

            }
            return Unit.Value;
        }
    }
}
