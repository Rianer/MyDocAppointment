using AutoMapper;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Application.Response;

namespace MyDocAppointment.Application.Mappers
{
    public class DrugStockMappingProfile : Profile
    {
        public DrugStockMappingProfile()
        {
            CreateMap<DrugStock, DrugStockResponse>()
                .ForMember(dest => dest.DrugId,
                opt => opt.MapFrom(src => src.Item.Id))
                .ForMember(dest => dest.DrugName,
                opt => opt.MapFrom(src => src.Item.Name))
                .ReverseMap();
            CreateMap<DrugStock, CreateDrugStockCommand>()
                 .ForMember(dest => dest.DrugId,
                opt => opt.MapFrom(src => src.Item.Id))
                 .ForMember(dest => dest.DrugName,
                opt => opt.MapFrom(src => src.Item.Name))
                 .ReverseMap();
        }
    }
}
