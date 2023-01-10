using AutoMapper;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Response;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.Application.Mappers
{
    public class DrugEntryMappingProfile : Profile
    {
        public DrugEntryMappingProfile()
        {
            CreateMap<DrugEntry, DrugEntryResponse>()
                .ForMember(dest => dest.DrugId,
                opt => opt.MapFrom(src => src.Drug.Id))
                .ForMember(dest => dest.DrugName,
                opt => opt.MapFrom(src => src.Drug.Name))
                .ReverseMap();
            CreateMap<DrugEntry, CreateDrugEntryCommand>()
                 .ForMember(dest => dest.DrugId,
                opt => opt.MapFrom(src => src.Drug.Id))
                 .ForMember(dest => dest.DrugName,
                opt => opt.MapFrom(src => src.Drug.Name))
                 .ReverseMap();
        }
    }
}
