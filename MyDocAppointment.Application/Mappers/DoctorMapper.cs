using AutoMapper;

namespace MyDocAppointment.Application.Mappers
{
    public class DoctorMapper
    {
        private static Lazy<IMapper> Lazy =
           new Lazy<IMapper>(() =>
           {
               var config = new MapperConfiguration(cfg =>
               {
                   cfg.ShouldMapProperty = p =>
                   p.GetMethod.IsPublic ||
                   p.GetMethod.IsAssembly;
                   cfg.AddProfile<DoctorMappingProfile>();
               });
               var mapper = config.CreateMapper();
               return mapper;
           });
        public static IMapper Mapper => Lazy.Value;
    }
}
