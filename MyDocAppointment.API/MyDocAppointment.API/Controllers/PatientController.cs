using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Application;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Controllers
{   [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientsService patientService;

        public PatientController(IPatientsService patientService)
        {
            this.patientService = patientService;
        }

        
        [HttpGet]
        public IActionResult Get() 
        {
            return Ok(patientService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreatePatientDto dto)
        {
            var patient = new Patient(dto.Name, dto.Surname, dto.Age, dto.PersonGender, dto.EmailAddress,
                dto.FutureAppointments, dto.PastAppointments, dto.Diagnosis);
            patientService.Create(patient);
            patientService.SaveChanges();
            return Created(nameof(Get), patient);
        }

        [HttpGet("{patientId:guid}")]
        public IActionResult GetById(Guid doctorId)
        {
            return Ok(patientService.GetById(doctorId));
        }

        [HttpDelete("{doctorId:guid}")]
        public IActionResult Delete(Guid doctorId)
        {
            return Ok(patientService.Delete(doctorId));
        }



    }
}