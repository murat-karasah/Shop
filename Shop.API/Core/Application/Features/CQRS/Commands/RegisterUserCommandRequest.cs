using MediatR;

namespace Shop.API.Core.Application.Features.CQRS.Commands
{
    public class RegisterUserCommandRequest :IRequest
    {
        public string? UserName { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public int? AppRoleId { get; set; }

    }
}
