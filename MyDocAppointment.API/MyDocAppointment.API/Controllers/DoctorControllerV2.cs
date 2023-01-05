using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Controllers
{
<<<<<<< Updated upstream
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    [ApiController]
=======
    [ApiController] 
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
>>>>>>> Stashed changes
    public class DoctorControllerV2 : ControllerBase
    {
        private readonly IDoctorsService _doctorService;
        private readonly IMapper _mapper;
        public DoctorControllerV2(IDoctorsService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _doctorService.GetAll();

            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

<<<<<<< Updated upstream
            var doctorsYoungerThan45 = _mapper.Map<IEnumerable<DoctorDto>>(response.Entity.Where(x => x.Age <= 45));
             
            return Ok(doctorsYoungerThan45);
=======
            var doctorsYoungerThan45 = response.Entity.Where(x => x.Age < 45);
            var models = _mapper.Map<IEnumerable<DoctorDto>>(doctorsYoungerThan45);

            
            return Ok(models);
>>>>>>> Stashed changes
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateDoctorDto dto)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            await _doctorService.Create(doctor);

            return Created(nameof(Get), dto);
        }

        [HttpGet("{doctorId:guid}")]
        public async Task<IActionResult> GetById(Guid doctorId)
        {
            var response = await _doctorService.GetById(doctorId);
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<DoctorDto>(response.Entity);
            return Ok(model);
        }

        [HttpDelete("{doctorId:guid}")]
        public async Task<IActionResult> Delete(Guid doctorId)
        {
            var response = await _doctorService.Delete(doctorId);
            if (response.IsSuccess)
            {
                return Ok();
            }

            return NotFound(response.Error);
        }

        [HttpPut("{doctorId:guid}")]
        public async Task<IActionResult> Update([FromBody] DoctorDto dto, Guid doctorId)
        {
            var doctor = _mapper.Map<Doctor>(dto);
            var response = await _doctorService.Update(doctor, doctorId);

            if (!response.IsSuccess)
            { 
                return NotFound(response.Error);
            }

            var model = _mapper.Map<DoctorDto>(response.Entity);
            return Ok(model);
        }
    }
}