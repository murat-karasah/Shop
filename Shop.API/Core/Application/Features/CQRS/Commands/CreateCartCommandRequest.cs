using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class CreateCartCommandRequest : IRequest
    {
        public int Id { get; set; }
        public int AppUserID { get; set; }
        public int? OrderId { get; set; }
        public bool Status { get; set; }
    }
}
