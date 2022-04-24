using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Application.Features.CQRS.Queries;
using Shop.API.Infrastructure.Tools;
using System.Dynamic;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class AuthController : ControllerBase
    {
        private readonly IMediator mediator;

        public AuthController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterUserCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SignIn(CheckUserQueryRequest request)
        {
            var userdto =await this.mediator.Send(request);
            if (userdto.IsExist)
            {
                var token = JwtTokenGenerator.GenerateToken(userdto);
                return Created("", token);
            }
            return BadRequest("Username veya password hatalı");
        }
    }
}
