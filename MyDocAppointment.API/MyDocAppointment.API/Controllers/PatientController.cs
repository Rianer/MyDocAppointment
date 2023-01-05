using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientsService _patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientsService patientService, IMapper mapper)
        {
            _patientService = patientService;
            _mapper = mapper;
        }

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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto dto)
        {
            var patient = _mapper.Map<Patient>(dto);

            await _patientService.Create(patient);

            return Created(nameof(Get), dto);
        }

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