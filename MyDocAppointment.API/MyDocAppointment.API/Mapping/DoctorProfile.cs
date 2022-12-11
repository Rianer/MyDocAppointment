using AutoMapper;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Mapping
{
    public class DoctorProfile : Profile
    {
        public DoctorProfile()
        {
            CreateMap<Doctor, DoctorDto>();
            CreateMap<CreateDoctorDto, Doctor>();
        }
    }
}
