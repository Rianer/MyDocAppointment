using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorsService doctorService;

        public DoctorController(IDoctorsService doctorService)
        {
            this.doctorService = doctorService;
        }

         [HttpGet]
        public IActionResult Get() 
        {
            return Ok(doctorService.GetAll());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateDoctorDto dto)
        {
            var doctor = new Doctor(dto.Name, dto.Surname, dto.Age, dto.Gender,  dto.EmailAddress, dto.Speciality, dto.Appointments);
            doctorService.Create(doctor);
            doctorService.SaveChanges();
            return Created(nameof(Get), doctor);
        }

        [HttpGet("{doctorId:guid}")]
        public IActionResult GetById(Guid doctorId)
        {
            return Ok(doctorService.GetById(doctorId));
        }

        [HttpDelete("{doctorId:guid}")]
        public IActionResult Delete(Guid doctorId)
        {
            return Ok(doctorService.Delete(doctorId));
        }


    }
}