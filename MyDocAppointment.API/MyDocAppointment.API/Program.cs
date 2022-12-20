using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Application;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.External;
using MyDocAppointment.Business.Logistics.Internal;
using MyDocAppointment.Business.Users;
using MyDocAppointment.Infrastructure;
using MyDocAppointment.Infrastructure.Configurations;
using MyDocAppointment.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllerServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastrutureServices(builder.Configuration);

builder.Services.AddCors(options =>
{
    options.AddPolicy("sheltersCors", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("sheltersCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
