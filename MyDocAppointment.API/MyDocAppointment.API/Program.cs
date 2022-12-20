<<<<<<< Updated upstream
using FluentValidation;
using FluentValidation.AspNetCore;
=======
>>>>>>> Stashed changes
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
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
<<<<<<< Updated upstream
=======
var connectionString = builder.Configuration.GetConnectionString("MyDocAppointment");
if (connectionString == null)
{
    throw new ArgumentNullException("Connection string null or empty!");
}
// Add services to the container.
>>>>>>> Stashed changes

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();
<<<<<<< Updated upstream

builder.Services.AddControllerServices();
builder.Services.AddApplicationServices();
builder.Services.AddInfrastrutureServices(builder.Configuration);

builder.Services.AddApiVersioning(opt =>
                                    {
                                        opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1,0);
                                        opt.AssumeDefaultVersionWhenUnspecified = true;
                                        opt.ReportApiVersions = true;
                                        opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                                        new HeaderApiVersionReader("x-api-version"),
                                                                                        new MediaTypeApiVersionReader("x-api-version"));
                                    });

// Add ApiExplorer to discover versions
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});
=======
builder.Services.AddDatabase(connectionString);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
>>>>>>> Stashed changes

builder.Services.AddApiVersioning(opt =>
                                    {
                                        opt.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
                                        opt.AssumeDefaultVersionWhenUnspecified = true;
                                        opt.ReportApiVersions = true;
                                        opt.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
                                                                                        new HeaderApiVersionReader("x-api-version"),
                                                                                        new MediaTypeApiVersionReader("x-api-version"));
                                    });

builder.Services.AddCors(options =>
{
    options.AddPolicy("sheltersCors", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
    });
});

builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "'v'VVV";
    setup.SubstituteApiVersionInUrl = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
<<<<<<< Updated upstream
    {
        foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
=======
   {
       foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
       {
           options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
               description.GroupName.ToUpperInvariant());
       }
   });
>>>>>>> Stashed changes
}

app.UseHttpsRedirection();
app.UseCors("sheltersCors");
app.UseAuthorization();

app.MapControllers();

app.Run();
