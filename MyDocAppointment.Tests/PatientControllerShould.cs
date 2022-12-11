using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyDocAppointment.API.Controllers;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;
using Xunit;

namespace MyDocAppointment.Tests
{
    public class PatientControllerShould
    {
        PatientController controller;
        Guid idOk;
        Guid idNotFound;
        public PatientControllerShould()
        {
            // Arrange
            idOk = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            idNotFound = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
            var patientsServiceMock = new Mock<IPatientsService>();
            var mapperMock = new Mock<IMapper>();
            patientsServiceMock.Setup(r => r.GetById(idOk))
                .ReturnsAsync(GetTestPatients());
            patientsServiceMock.Setup(r => r.GetById(idNotFound))
                .Returns(FailureResult(idNotFound));
            patientsServiceMock.Setup(r => r.Create(It.IsAny<Patient>()))
                .Returns(Task.CompletedTask);
            patientsServiceMock.Setup(r => r.Delete(It.IsAny<Guid>()))
                 .Returns(SuccessResult());
            controller = new PatientController(patientsServiceMock.Object,mapperMock.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenThePatientWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.GetById(idOk);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public async Task GetById_ReturnsNotFound_WhenThePatientWithSpecifiedIdIsNotFound()
        {
            //Act
            var response = await controller.GetById(idNotFound);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Create_ReturnsCreatedResult()
        {
            //Act
            var response = await controller.Create(GetPatientDto());

            // Assert
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenThePatientWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Delete(idOk);

            // Assert
            Assert.IsType<OkResult>(response);
        }

        private CreatePatientDto GetPatientDto()
        {

            var patient = new CreatePatientDto();
            return patient;

        }
        private Result<Patient> GetTestPatients()
        {
            var patient = new Patient();
            return Result<Patient>.Success(patient);
        }
        private async Task<Result> SuccessResult()
        {
            return Result.Success();
        }
        private async Task<Result<Patient>> FailureResult(Guid id)
        {
            return Result<Patient>.Failure($"Patient with ID: {id} does not exist.");
        }
    }
}
