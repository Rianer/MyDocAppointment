using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentService;
        private readonly IMapper _mapper;
        public AppointmentController(IAppointmentsService appointmentService, IMapper mapper)
        {
            _appointmentService = appointmentService;
            _mapper = mapper;
        }
        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _appointmentService.GetAll();

            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var models = _mapper.Map<IEnumerable<AppointmentDto>>(response.Entity);

            return Ok(models);
        }

        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateAppointmentDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);
            await _appointmentService.Create(appointment);

            return Created(nameof(Get), dto);
        }

        [MapToApiVersion("1.0")]
        [HttpGet("{appointmentId:guid}")]
        public async Task<IActionResult> GetById(Guid appointmentId)
        {
            var response = await _appointmentService.GetById(appointmentId);
            if (!response.IsSuccess)
            {
                return NotFound(response.Error);
            }

            var model = _mapper.Map<AppointmentDto>(response.Entity);
            return Ok(model);
        }

        [MapToApiVersion("1.0")]
        [HttpDelete("{appointmentId:guid}")]
        public async Task<IActionResult> Delete(Guid appointmentId)
        {
            var response = await _appointmentService.Delete(appointmentId);
            if (response.IsSuccess)
            {
                return Ok();
            }

            return NotFound(response.Error);
        }

        [MapToApiVersion("1.0")]
        [HttpPut("{appointmentId:guid}")]
        public async Task<IActionResult> Update([FromBody] AppointmentDto dto, Guid appointmentId)
        {
            var appointment = _mapper.Map<Appointment>(dto);

            var response = await _appointmentService.Update(appointment, appointmentId);

            if (!response.IsSuccess)
            { 
                return NotFound(response.Error);
            }

            var model = _mapper.Map<AppointmentDto>(response.Entity);
            return Ok(model);
        }
    }
}