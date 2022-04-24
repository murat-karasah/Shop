using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class DeleteCartItemCommandRequest: IRequest
    {
        public int Id { get; set; }
    public DeleteCartItemCommandRequest(int id)
    {
        Id = id;
    }
    }
}
