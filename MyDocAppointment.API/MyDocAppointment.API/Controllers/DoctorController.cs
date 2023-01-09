using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Queries;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IDoctorsService _doctorService;
        private readonly IMapper _mapper;
        public DoctorController(IDoctorsService doctorService, IMapper mapper, IMediator mediator)
        {
            _doctorService = doctorService;
            _mapper = mapper;
            _mediator = mediator;
        }
        [MapToApiVersion("1.0")]
        [HttpPost]
        public async Task<IActionResult>
           Create([FromBody] CreateDoctorCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<List<DoctorResponse>> Get()
        {
            return await _mediator.Send(new GetAllDoctorsQuery());
        }

        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
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

        [MapToApiVersion("1.0")]
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