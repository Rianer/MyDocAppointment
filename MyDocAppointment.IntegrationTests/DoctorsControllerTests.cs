using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyDocAppointment.API.Controllers;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Infrastructure;
using System.Net.Http.Json;
using System.Diagnostics.CodeAnalysis;

using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace MyDocAppointment.IntegrationTests
{
    public class DoctorsControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/doctor";

        [Fact]
        public async void WhenCreateDoctor_ThenShouldReturnCreated()
        {
        //Arange
        var doctorDto = new CreateDoctorDto
            {
                Name = "Ion",
                Surname = "Ion",
                Age = 30,
                Gender = "Male",
                EmailAddress = "ion@gmail.com",
                PhoneNumber = "0777777777",
                HomeAddress = "Iasi",
                Speciality = "Cardiology"

        };

            //Act

            var doctorResponse = await HttpClient.PostAsJsonAsync(ApiUrl, doctorDto);
            var getDoctorgResult = await HttpClient.GetAsync(ApiUrl);

            //Assert
            doctorResponse.EnsureSuccessStatusCode();
            Assert.IsType<CreatedResult>(doctorResponse);


            getDoctorgResult.EnsureSuccessStatusCode();
            var doctors = await getDoctorgResult.Content.ReadFromJsonAsync<List<CreateDoctorDto>>();
            Assert.IsType<NotNullAttribute>(doctors);

        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsOk()
        {
            //Act
            var response = await HttpClient.GetAsync(ApiUrl);
            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}
