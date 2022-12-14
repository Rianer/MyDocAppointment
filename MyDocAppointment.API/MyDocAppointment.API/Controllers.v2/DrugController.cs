using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class DrugController : ControllerBase
    {
        private readonly IDrugsService _drugService;
        private readonly IMapper _mapper;

        public DrugController(IDrugsService drugService, IMapper mapper)
        {
            _drugService = drugService;
            _mapper = mapper;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _drugService.GetAll();
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var models = _mapper.Map<IEnumerable<DrugDto>>(response.Entity);
            return Ok(models);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDrugDto dto)
        {
            var drug = _mapper.Map<Drug>(dto);

            await _drugService.Create(drug);

            return Created(nameof(Get), dto);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{drugId:guid}")]
        public async Task<IActionResult> GetById(Guid drugId)
        {
            var response = await _drugService.GetById(drugId);
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<DrugDto>(response.Entity);
            return Ok(model);
        }

        [MapToApiVersion("2.0")]
        [HttpDelete("{drugId:guid}")]
        public async Task<IActionResult> Delete(Guid drugId)
        {
            var response = await _drugService.Delete(drugId);
            if (response.IsSuccess)
            {
                return Ok();
            }

            return NotFound(response.Error);
        }

        [MapToApiVersion("2.0")]
        [HttpPut("{drugId:guid}")]
        public async Task<IActionResult> Update([FromBody] DrugDto dto, Guid drugId)
        {
            var drug = _mapper.Map<Drug>(dto);

            var response = await _drugService.Update(drug, drugId);

            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<DrugDto>(response.Entity);
            return Ok(model);
        }
    }
}