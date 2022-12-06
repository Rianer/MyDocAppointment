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
        public async Task<IActionResult> Get()
        {
            var response = await doctorService.GetAll();
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response.Error);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDto dto)
        {
            var doctor = Doctor.Create(dto.Name, dto.Surname, dto.Age, dto.Gender, dto.EmailAddress, dto.PhoneNumber, dto.HomeAddress, dto.Speciality);
            await doctorService.Create(doctor.Entity);

            return Created(nameof(Get), doctor);
        }

        [HttpGet("{doctorId:guid}")]
        public async Task<IActionResult> GetById(Guid doctorId)
        {
            var response = await doctorService.GetById(doctorId);
            if (response.IsSuccess)
            {
                return Ok(response);
            }

            return NotFound(response.Error);
        }

        [HttpDelete("{doctorId:guid}")]
        public async Task<IActionResult> Delete(Guid doctorId)
        {
            var response = await doctorService.Delete(doctorId);
            if (response.IsSuccess)
            {
                return Ok();
            }

            return NotFound(response.Error);
        }
    }
}