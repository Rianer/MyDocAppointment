using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Infrastructure.Repositories;

namespace MyDocAppointment.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastrutureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IDoctorsRepository, DoctorsRepository>();
            services.AddScoped<IDrugsRepository, DrugsRepository>();
            services.AddScoped<IDoctorsRepository, DoctorsRepository>();
            services.AddScoped<IPatientsRepository, PatientsRepository>();
            services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();
            services.AddScoped<IDrugStocksRepository, DrugStocksRepository>();
            services.
                AddDbContext<AppDbContext>
                (m => m.UseSqlServer(
                    configuration.GetConnectionString("MyDocAppointment")),
                    ServiceLifetime.Singleton);
            return services;
        }
    }
}
