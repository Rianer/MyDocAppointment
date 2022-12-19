using MyDocAppointment.API.Dtos;
using System.Net.Http.Json;

namespace MyDocAppointment.IntegrationTests
{
    public class AppointmentsControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/appointment";

        [Fact]
        public async void WhenCreateAppointment_ThenShouldReturnCreated()
        {
        //Arange
        var AppointmentDto = GetAppointmentDto();

            //Act

            var AppointmentResponse = await HttpClient.PostAsJsonAsync(ApiUrl, AppointmentDto);
            var getAppointmentResult = await HttpClient.GetAsync(ApiUrl);
            var status = ((int)AppointmentResponse.StatusCode);

            //Assert
            AppointmentResponse.EnsureSuccessStatusCode();
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
            Assert.Contains("Iasi", responseString);
        }

        private CreateAppointmentDto GetAppointmentDto()
        {
            var AppointmentDto = new CreateAppointmentDto
            {
                Location = "Iasi",
                PatientID = "8a1dd56e-3714-47ff-74bb-08dad798785d",
                DoctorID = "b0d5bf1a-828d-4950-19cd-08dad7987905",
                Specialization = "Cardiology",
                AppointmentTime = "03 March 2016 06:30",
                Payment = new CreatePaymentDto()
                {
                    PaymentMethod = "Card",
                    Amount = 400
                }
            };

            return AppointmentDto;
        }
    }
}
