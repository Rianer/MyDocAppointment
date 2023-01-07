using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Queries;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DrugStockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DrugStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult>
           Create([FromBody] CreateDrugStockCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<List<DrugStockResponse>> Get()
        {
            return await _mediator.Send(new GetAllDrugStocksQuery());
        }
    }
}