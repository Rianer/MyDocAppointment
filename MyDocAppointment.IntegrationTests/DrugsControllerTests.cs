using MyDocAppointment.API.Dtos;
using System.Net.Http.Json;

namespace MyDocAppointment.IntegrationTests
{
    public class DrugsControllerTests : BaseIntegrationTests
    {
        private const string ApiUrl = "api/drug";

        [Fact]
        public async void WhenCreatedrug_ThenShouldReturnCreated()
        {
            //Arange
            var drugDto = GetDrugDto();

            //Act
            var drugResponse = await HttpClient.PostAsJsonAsync(ApiUrl, drugDto);
            var status = ((int)drugResponse.StatusCode);

            //Assert
            drugResponse.EnsureSuccessStatusCode();
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
            Assert.Contains("Name", responseString);
        }

        private CreateDrugDto GetDrugDto()
        {
            var drugDto = new CreateDrugDto
            {
                Name = "Name",
                Vendor = "Vendor",
                Category = "Category",
                Price = (decimal)12.4
            };

            return drugDto;
        }
    }
}
