using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientsService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientsService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

        [MapToApiVersion("2.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _patientService.GetAll();
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var models = _mapper.Map<IEnumerable<PatientDto>>(response.Entity);
            return Ok(models);
        }

        [MapToApiVersion("2.0")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);

            await _patientService.Create(patient);

            return Created(nameof(Get), dto);
        }

        [MapToApiVersion("2.0")]
        [HttpGet("{patientId:guid}")]
        public async Task<IActionResult> GetById(Guid patientId)
        {
            var response = await _patientService.GetById(patientId);
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<PatientDto>(response.Entity);
            return Ok(model);

        }

        [MapToApiVersion("2.0")]
        [HttpDelete("{patientId:guid}")]
        public async Task<IActionResult> Delete(Guid patientId)
        {
            var response = await _patientService.Delete(patientId);
            if (response.IsSuccess)
            {
                return Ok();
            }

            return NotFound(response.Error);
        }

        [MapToApiVersion("2.0")]
        [HttpPut("{patientId:guid}")]
        public async Task<IActionResult> Update([FromBody] PatientDto dto, Guid patientId)
        {
            var patient = _mapper.Map<Patient>(dto);

            var response = await _patientService.Update(patient, patientId);

            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<PatientDto>(response.Entity);
            return Ok(model);
        }
    }
}