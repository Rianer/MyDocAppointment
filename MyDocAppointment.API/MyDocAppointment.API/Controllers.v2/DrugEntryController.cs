using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Queries;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DrugEntryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DrugEntryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult>
           Create([FromBody] CreateDrugEntryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<List<DrugEntryResponse>> Get()
        {
            return await _mediator.Send(new GetAllDrugEntrysQuery());
        }
    }
}