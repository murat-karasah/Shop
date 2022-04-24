using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Core.Application.Features.CQRS.Commands;
using Shop.API.Core.Application.Features.CQRS.Queries;

namespace Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly IMediator mediator;

        public CartController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateCartCommandRequest request)
        {
            await this.mediator.Send(request);
            return Created("", request);
        }

        [HttpGet]
        public async Task<IActionResult> List(int OrderId)
        {
            var result = await this.mediator.Send(new GetAllCartQueryRequest());
            return Ok(result);
        }
       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.mediator.Send(new DeleteCartCommandRequest(id));
            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCartCommandRequest request)
        {
            await this.mediator.Send(request);
            return NoContent();
        }
    }
}
