using AutoMapper;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.API.Mapping
{
    public class ExternalProfile : Profile
    {
        public ExternalProfile()
        {
            CreateMap<Appointment, AppointmentDto>().ReverseMap();
        }
    }
}
