using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyDocAppointment.Business.Interfaces;
using System.Reflection;

namespace MyDocAppointment.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IDoctorsService, DoctorsService>();
            services.AddScoped<IPatientsService, PatientsService>();
            //services.AddScoped<IDrugsService, DrugsService>();
            services.AddScoped<IAppointmentsService, AppointmentsService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
