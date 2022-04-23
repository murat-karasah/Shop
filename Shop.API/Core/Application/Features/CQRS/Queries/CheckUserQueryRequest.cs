using MediatR;
using Shop.API.Core.Application.Dto;

namespace Shop.API.Core.Application.Features.CQRS.Queries
{
    public class CheckUserQueryRequest : IRequest<CheckUserResponseDto>
    {
        public CheckUserQueryRequest(string username, string password)
        {
            UserName = username;
            Password = password;
        }
        public string? UserName { get; set; }
        public string? Password { get; set; }

      
    }
}
