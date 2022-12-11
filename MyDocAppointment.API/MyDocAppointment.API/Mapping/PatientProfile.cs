using AutoMapper;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Users;

namespace MyDocAppointment.API.Mapping
{
    public class PatientProfile : Profile
    {
        public PatientProfile()
        {
            CreateMap<Patient, PatientDto>();
            CreateMap<CreatePatientDto, Patient>();
        }
    }
}
