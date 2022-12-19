using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Queries;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugStockController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DrugStockController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult>
           Create([FromBody] CreateDrugStockCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<List<DrugStockResponse>> Get()
        {
            return await _mediator.Send(new GetAllDrugStocksQuery());
        }

        /*[HttpGet("{drugStockId:guid}")]
        public async Task<IActionResult> GetById(Guid drugStockId)
        {
            var response = await _drugStockService.GetById(drugStockId);
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<drugStockDto>(response.Entity);
            return Ok(model);
        }

        [HttpDelete("{drugStockId:guid}")]
        public async Task<IActionResult> Delete(Guid drugStockId)
        {
            var response = await _drugStockService.Delete(drugStockId);
            if (response.IsSuccess)
            {
                return Ok();
            }

            return NotFound(response.Error);
        }

        [HttpPut("{drugStockId:guid}")]
        public async Task<IActionResult> Update([FromBody] drugStockDto dto, Guid drugStockId)
        {
            var drugStock = _mapper.Map<drugStock>(dto);

            var response = await _drugStockService.Update(drugStock, drugStockId);

            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<drugStockDto>(response.Entity);
            return Ok(model);
        }*/
    }
}