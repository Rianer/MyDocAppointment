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
    public class DoctorControllerShould
    {
        DoctorController controller;
        Guid idOk;
        Guid idNotFound;
        public DoctorControllerShould()
        {
            // Arrange
            idOk = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            idNotFound = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
            var doctorsServiceMock = new Mock<IDoctorsService>();
            doctorsServiceMock.Setup(r => r.GetById(idOk))
                .ReturnsAsync(GetTestDoctors());
            doctorsServiceMock.Setup(r => r.GetById(idNotFound))
                .Returns(FailureResult(idNotFound));
            doctorsServiceMock.Setup(r => r.Create(It.IsAny<Doctor>()))
                .Returns(Task.CompletedTask);
            doctorsServiceMock.Setup(r => r.Delete(It.IsAny<Guid>()))
                 .Returns(SuccessResult());
            controller = new DoctorController(doctorsServiceMock.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenTheDoctorWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.GetById(idOk);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenTheDoctorWithSpecifiedIdIsNotFound()
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
            var response = await controller.Create(GetDoctorDto());

            // Assert
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenTheDoctorWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Delete(idOk);

            // Assert
            Assert.IsType<OkResult>(response);
        }

        private CreateDoctorDto GetDoctorDto()
        {

            var doctor = new CreateDoctorDto();
            return doctor;

        }
        private Result<Doctor> GetTestDoctors()
        {
            var doctor = new Doctor();
            return Result<Doctor>.Success(doctor);
        }
        private async Task<Result> SuccessResult()
        {
            return Result.Success();
        }
        private async Task<Result<Doctor>> FailureResult(Guid id)
        {
            return Result<Doctor>.Failure($"Patient with ID: {id} does not exist.");
        }
    }
}
