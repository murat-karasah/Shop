using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Core.Application.Features.CQRS.Commands;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Create(CreateOrderCommandRequest request,int id)
        {
            request.AppUserID= id;
            await this.mediator.Send(request);
            return Created("", request);
        }
    }
}
