using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class CreateOrderCommandRequest : IRequest
    {
        public int AppUserID { get; set; }
        public bool PaymentStatus { get; set; }
    }
}
