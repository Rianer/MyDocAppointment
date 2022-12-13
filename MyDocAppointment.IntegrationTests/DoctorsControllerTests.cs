﻿using System;
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
            var doctorDto = getDoctorDto();

            //Act
            var doctorResponse = await HttpClient.PostAsJsonAsync(ApiUrl, doctorDto);
            var getDoctorgResult = await HttpClient.GetAsync(ApiUrl);
            var status = ((int)doctorResponse.StatusCode);

            //Assert
            doctorResponse.EnsureSuccessStatusCode();
            Assert.Equal(201, status);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsOk()
        {
            //Act
            var response = await HttpClient.GetAsync(ApiUrl);
            //Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task Index_WhenCalled_ReturnsApplicationForm()
        {
            var response = await HttpClient.GetAsync(ApiUrl);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Ion", responseString);
            Assert.Contains("Mark", responseString);
        }

        [Fact]
        public async Task Create_WhenCalled_ReturnsCreateForm()
        {
            var response = await HttpClient.GetAsync(ApiUrl);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Please provide a new doctor data", responseString);
        }

        [Fact]
        public async Task DefaultRoute_ReturnsNothing()
        {
            var response = await HttpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("", responseString);
        }


        private CreateDoctorDto getDoctorDto()
        {
            var doctorDto = new CreateDoctorDto
            {
                Name = "Stan",
                Surname = "Mark",
                Age = 30,
                Gender = "Male",
                EmailAddress = "ion@gmail.com",
                PhoneNumber = "0777777777",
                HomeAddress = "Iasi",
                Speciality = "Cardiology"

            };

            return doctorDto;
        }
    }
}
