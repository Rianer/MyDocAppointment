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

        public PatientController(IPatientsService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await patientService.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePatientDto dto)
        {
            var patient = Patient.Create(dto.Name, dto.Surname, dto.Age, dto.Gender, 
                dto.EmailAddress, dto.PhoneNumber, dto.HomeAddress);
            await patientService.Create(patient.Entity);

            return Created(nameof(Get), patient);
        }

        [HttpGet("{patientId:guid}")]
        public async Task<IActionResult> GetById(Guid doctorId)
        {
            var response = await patientService.GetById(doctorId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response.Error);
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