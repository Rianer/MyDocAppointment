using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : ControllerBase
    {
        private readonly IDrugsService _drugService;
        private readonly IMapper _mapper;
        private IValidator<Drug> _validator;

        public DrugController(IDrugsService drugService, IMapper mapper, IValidator<Drug> validator)
        {
            _drugService = drugService;
            _mapper = mapper;
            _validator = validator;
        }

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDrugDto dto)
        {
            var drug = _mapper.Map<Drug>(dto);

            ValidationResult result = await _validator.ValidateAsync(drug);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return BadRequest(drug);
            }

            await _drugService.Create(drug);

            return Created(nameof(Get), dto);
        }

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

        [HttpPut("{drugId:guid}")]
        public async Task<IActionResult> Update([FromBody] DrugDto dto, Guid drugId)
        {
            var drug = _mapper.Map<Drug>(dto);

            ValidationResult result = await _validator.ValidateAsync(drug);

            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);

                return BadRequest("All fields from drug are required" + drug);
            }
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