using AutoMapper;
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
        private readonly IMapper _mapper;
        public DoctorController(IDoctorsService doctorService, IMapper mapper)
        {
            this.doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await doctorService.GetAll();

            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var models = _mapper.Map<IEnumerable<DoctorDto>>(response.Entity);

            return Ok(models);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            await doctorService.Create(doctor);

            return Created(nameof(Get), dto);
        }

        [HttpGet("{doctorId:guid}")]
        public async Task<IActionResult> GetById(Guid doctorId)
        {
            var response = await doctorService.GetById(doctorId);
            if (response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<DoctorDto>(response.Entity);
            return Ok(response);
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