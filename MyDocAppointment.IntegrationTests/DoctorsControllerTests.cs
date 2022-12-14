using MyDocAppointment.API.Dtos;
using System.Net.Http.Json;

namespace MyDocAppointment.IntegrationTests
{
    public class DoctorsControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/v1/doctor";

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
            Assert.Equal(200, status);
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
            //Assert.Contains("Ion", responseString);
            Assert.Contains("Mark", responseString);
        }

        [Fact]
        public async Task Create_WhenCalled_ReturnsCreateForm()
        {
            var response = await HttpClient.GetAsync(ApiUrl);
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Contains("Stan", responseString);
        }

        /*[Fact]
        public async Task DefaultRoute_ReturnsNothing()
        {
            var response = await HttpClient.GetAsync("");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("", responseString);
        }*/

        private static CreateDoctorDto getDoctorDto()
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
