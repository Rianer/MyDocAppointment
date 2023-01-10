using AutoMapper;

namespace MyDocAppointment.Application.Mappers
{
    public static class DrugEntryMapper
    {
        private static Lazy<IMapper> Lazy =
           new Lazy<IMapper>(() =>
           {
               var config = new MapperConfiguration(cfg =>
               {
                   cfg.ShouldMapProperty = p => {
                       System.Reflection.MethodInfo? getMethod = p.GetMethod;
                       return getMethod.IsPublic ||
                                          p.GetMethod.IsAssembly;
                   };
                   cfg.AddProfile<DrugEntryMappingProfile>();
               });
               var mapper = config.CreateMapper();
               return mapper;
           });
        public static IMapper Mapper => Lazy.Value;
    }
}
