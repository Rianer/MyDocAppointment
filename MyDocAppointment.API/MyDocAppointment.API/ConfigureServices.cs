using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using System.Reflection;
using MyDocAppointment.API.Dtos;

namespace MyDocAppointment.API
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddControllerServices
            (this IServiceCollection services)
        {
            services.AddScoped<IValidator<CreateAppointmentDto>, CreateAppointmentDtoValidator>();
            services.AddScoped<IValidator<AppointmentDto>, AppointmentDtoValidator>();
            services.AddScoped<IValidator<CreatePatientDto>, CreatePatientDtoValidator>();
            services.AddScoped<IValidator<PatientDto>, PatientDtoValidator>();
            services.AddScoped<IValidator<CreateDrugDto>, CreateDrugDtoValidator>();
            services.AddScoped<IValidator<DrugDto>, DrugDtoValidator>();

            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}