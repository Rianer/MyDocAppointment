using AutoMapper;
using Microsoft.VisualBasic;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Logistics.External;

namespace MyDocAppointment.API.Mapping
{
    public class ExternalProfile : Profile
    {
        public ExternalProfile()
        {
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.AppointmentTime,
                opt => opt.MapFrom(src => src.AppointmentTime.ToString("dd MMMM yyyy HH:mm")))
                .ForMember(dest => dest.PaymentMethod,
                opt => opt.MapFrom(src => src.Payment.PaymentMethod.ToString()))
                .ForMember(dest => dest.PaymentDate,
                opt => opt.MapFrom(src => src.Payment.AcquittedDate.ToString("dd MMMM yyyy HH:mm")))
                .ForMember(dest => dest.Amount,
                opt => opt.MapFrom(src => src.Payment.Amount))
                .ReverseMap();
            CreateMap<CreateAppointmentDto, Appointment>();

            CreateMap<Payment, PaymentDto>()
                .ForMember(dest => dest.DueDate,
                opt => opt.MapFrom(src => src.DueDate.ToString("dd MMMM yyyy HH:mm")))
                .ForMember(dest => dest.EmissionDate,
                opt => opt.MapFrom(src => src.EmissionDate.ToString("dd MMMM yyyy HH:mm")))
                .ForMember(dest => dest.AcquittedDate,
                opt => opt.MapFrom(src => src.AcquittedDate.ToString("dd MMMM yyyy HH:mm")))
                .ReverseMap();
            CreateMap<CreatePaymentDto, Payment>();
        }
    }
}
