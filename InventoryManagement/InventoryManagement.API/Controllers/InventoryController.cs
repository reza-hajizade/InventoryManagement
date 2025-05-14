using InventoryManagement.Application.Commands;
using InventoryManagement.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {

        private readonly IMediator _mediator;
        public InventoryController(IMediator mediator)
        {
            _mediator=mediator;
        }

        [HttpPost("Create")]
        public async Task<IActionResult>  Create(CreateInventoryCommand createInventoryCommand)
        {
            await _mediator.Send(createInventoryCommand);
            return Ok();
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] string product)
        {
            var query = new GetInventoryQuery(product);
           var result= await _mediator.Send(query);
            return Ok(result);  
        }
    }
}
