using AutoMapper;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Logistics.Internal;

namespace MyDocAppointment.API.Mapping
{
    public class InternalProfile : Profile
    {
        public InternalProfile()
        {
            CreateMap<Drug, DrugDto>().ReverseMap();
            CreateMap<DrugStock, DrugStockDto>().ReverseMap();
        }
    }
}
