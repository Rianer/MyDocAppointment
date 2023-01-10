using MyDocAppointment.API.Dtos;
using System.Net.Http.Json;

namespace MyDocAppointment.IntegrationTests
{
    public class AppointmentsControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/v1/appointment";

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
                PatientID = "a252b780-9f6b-4cc6-21a8-08daf262db96",
                DoctorID = "b35abc1d-007f-4f7b-5aeb-08daf262ea7b",
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
