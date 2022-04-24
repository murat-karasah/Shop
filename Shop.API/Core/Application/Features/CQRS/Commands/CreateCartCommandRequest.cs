using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class CreateCartCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
    }
}
