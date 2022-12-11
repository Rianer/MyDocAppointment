using AutoMapper;
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
        private readonly IPatientsService patientService;
        private readonly IMapper _mapper;

        public PatientController(IPatientsService patientService, IMapper mapper)
        {
            this.patientService = patientService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await patientService.GetAll();
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
            await patientService.Create(patient);

            return Created(nameof(Get), dto);
        }

        [HttpGet("{patientId:guid}")]
        public async Task<IActionResult> GetById(Guid patientId)
        {
            var response = await patientService.GetById(patientId);
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<PatientDto>(response.Entity);
            return Ok(model);

        }

        [HttpDelete("{doctorId:guid}")]
        public async Task<IActionResult> Delete(Guid doctorId)
        {
            var response = await patientService.Delete(doctorId);
            if (response.IsSuccess)
            {
                return Ok();
            }

            return NotFound(response.Error);
        }
    }
}