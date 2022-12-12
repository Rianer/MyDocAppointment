using MyDocAppointment.Application;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Infrastructure.Configurations;
using MyDocAppointment.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("MyDocAppointment");
// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IDrugsRepository, DrugsRepository>();
builder.Services.AddScoped<IDoctorsRepository, DoctorsRepository>();
builder.Services.AddScoped<IPatientsRepository, PatientsRepository>();
builder.Services.AddScoped<IAppointmentsRepository, AppointmentsRepository>();


builder.Services.AddScoped<IDoctorsService, DoctorsService>();
builder.Services.AddScoped<IPatientsService, PatientsService>();
builder.Services.AddScoped<IDrugsService, DrugsService>();
builder.Services.AddScoped<IAppointmentsService, AppointmentsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDatabase(connectionString);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

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
