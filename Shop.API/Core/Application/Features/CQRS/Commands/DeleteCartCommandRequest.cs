using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class DeleteCartCommandRequest : IRequest
    {
        public int Id { get; set; }
        public DeleteCartCommandRequest(int id)
        {
            Id = id;
        }
  
    }
}
