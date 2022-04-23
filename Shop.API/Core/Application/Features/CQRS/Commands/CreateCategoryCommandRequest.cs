using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class CreateCategoryCommandRequest : IRequest
    {
        public string? Definition { get; set; }

    }
}
