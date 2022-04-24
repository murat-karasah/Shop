using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class UpdateOrderCommandRequest: IRequest
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public bool PaymentStatus { get; set; } 

    }
}
