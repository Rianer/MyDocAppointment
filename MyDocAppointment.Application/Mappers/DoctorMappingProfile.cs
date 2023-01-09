using AutoMapper;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.Application.Mappers
{
    public class DoctorMappingProfile : Profile
    {
        public DoctorMappingProfile()
        {
            CreateMap<Doctor, DoctorResponse>().ReverseMap();
            CreateMap<Doctor, CreateDoctorCommand>().ReverseMap();
        }
    }
}
