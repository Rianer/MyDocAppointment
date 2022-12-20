using FluentValidation.AspNetCore;
using FluentValidation;
using MediatR;
using System.Reflection;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Users;

public static class ConfigureServices
{
    public static IServiceCollection AddControllerServices
        (this IServiceCollection services)
    {
        services.AddScoped<IValidator<CreateAppointmentDto>, CreateAppointmentDtoValidator>();
        services.AddScoped<IValidator<AppointmentDto>, AppointmentDtoValidator>();
        services.AddScoped<IValidator<PatientDto>, PatientDtoValidator>();
        services.AddScoped<IValidator<CreatePatientDto>, CreatePatientDtoValidator>();
        services.AddFluentValidationAutoValidation();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}