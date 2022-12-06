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
    public class PatientsControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/patient";

        [Fact]
        public async void WhenCreatePatient_ThenShouldReturnCreated()
        {
        //Arange
        var patientDto = new CreatePatientDto
            {
                Name = "Ion",
                Surname = "Ion",
                Age = 30,
                Gender = "Male",
                EmailAddress = "ion@gmail.com",
                PhoneNumber = "0777777777",
                HomeAddress = "Iasi"

        };

            //Act

            var patientResponse = await HttpClient.PostAsJsonAsync(ApiUrl, patientDto);
            var getPatientResult = await HttpClient.GetAsync(ApiUrl);

            //Assert
            patientResponse.EnsureSuccessStatusCode();
            Assert.IsType<CreatedResult>(patientResponse);


            getPatientResult.EnsureSuccessStatusCode();
            var patients = await getPatientResult.Content.ReadFromJsonAsync<List<CreatePatientDto>>();
            Assert.IsType<NotNullAttribute>(patients);

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
