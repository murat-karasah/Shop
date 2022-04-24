using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Application.Features.CQRS.Queries;

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
        [HttpPut]
        public async Task<IActionResult> Update(UpdateOrderCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var result = await this.mediator.Send(new GetAllOrderQueryRequest());
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.mediator.Send(new GetOrderQueryRequest(id));
            return result == null ? NotFound() : Ok(result);
        }
    }
}
