using MyDocAppointment.API.Dtos;
using System.Net.Http.Json;

namespace MyDocAppointment.IntegrationTests
{
    public class PatientsControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/patient";

        [Fact]
        public async void WhenCreatePatient_ThenShouldReturnCreated()
        {
            //Arange
            var patientDto = GetPatientDto();

            //Act

            var patientResponse = await HttpClient.PostAsJsonAsync(ApiUrl, patientDto);
            var getPatientResult = await HttpClient.GetAsync(ApiUrl);
            var status = ((int)patientResponse.StatusCode);

            //Assert
            patientResponse.EnsureSuccessStatusCode();
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
            Assert.Contains("Evelin", responseString);
        }

        private CreatePatientDto GetPatientDto()
        {
            var patientDto = new CreatePatientDto
            {
                Name = "Evelin",
                Surname = "Evelin",
                Age = 30,
                Gender = "Female",
                EmailAddress = "evelin@gmail.com",
                PhoneNumber = "0777777777",
                HomeAddress = "Iasi"

            };

            return patientDto;
        }
    }
}
