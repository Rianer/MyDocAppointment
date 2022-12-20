using FluentValidation;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.External;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;
using System.Reflection;

namespace MyDocAppointment.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices
            (this IServiceCollection services)
        {
            services.AddScoped<IValidator<Drug>, DrugValidator>();
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<IDoctorsService, DoctorsService>();
            services.AddScoped<IPatientsService, PatientsService>();
            services.AddScoped<IDrugsService, DrugsService>();
            services.AddScoped<IAppointmentsService, AppointmentsService>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
