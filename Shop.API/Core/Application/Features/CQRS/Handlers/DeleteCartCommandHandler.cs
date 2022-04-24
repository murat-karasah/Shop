using MediatR;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Domain.Entity;
using Shop.API.Core.Interface;

namespace Shop.API.Core.Application.Features.CQRS.Handlers
{
    public class DeleteCartCommandHandler : IRequestHandler<DeleteCartCommandRequest>
    {
        private readonly IRepository<Cart> repository;

        public DeleteCartCommandHandler(IRepository<Cart> repository)
        {
            this.repository = repository;
        }

        public async Task<Unit> Handle(DeleteCartCommandRequest request, CancellationToken cancellationToken)
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
