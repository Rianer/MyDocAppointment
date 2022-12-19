using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyDocAppointment.API.Controllers;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.External;
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
            mapperMock.Setup(m => m.Map<Patient>(It.IsAny<CreatePatientDto>())).Returns(GetPatient());
            mapperMock.Setup(m => m.Map<Patient>(It.IsAny<PatientDto>())).Returns(GetPatient());
            Mock<IValidator<Patient>> validatorMock = new Mock<IValidator<Patient>>(MockBehavior.Strict);
            validatorMock.Setup(validator => validator.ValidateAsync(It.IsAny<Patient>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(new ValidationResult());
            patientsServiceMock.Setup(r => r.GetById(idOk))
                .ReturnsAsync(GetTestPatients());
            patientsServiceMock.Setup(r => r.GetById(idNotFound))
                .Returns(FailureResult(idNotFound));
            patientsServiceMock.Setup(r => r.Create(It.IsAny<Patient>()))
                .Returns(Task.CompletedTask);
            patientsServiceMock.Setup(r => r.Delete(idOk))
                 .Returns(SuccessResult());
            patientsServiceMock.Setup(r => r.Delete(idNotFound))
                 .Returns(FailResult(idNotFound));
            patientsServiceMock.Setup(r => r.Update(It.IsAny<Patient>(), idOk))
                .ReturnsAsync(GetTestPatient());
            patientsServiceMock.Setup(r => r.Update(It.IsAny<Patient>(), idNotFound))
                 .Returns(FailureResult(idNotFound));
            controller = new PatientController(patientsServiceMock.Object,mapperMock.Object, validatorMock.Object);
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
            var response = await controller.Create(GetCreatePatientDto());

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

        [Fact]
        public async Task Delete_ReturnsNotFound__WhenThePatientWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Delete(idNotFound);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        [Fact]
        public async Task Update_ReturnsOk_WhenThedrugWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Update(GetPatientDto(), idOk);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenThedrugWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Update(GetPatientDto(), idNotFound);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        private CreatePatientDto GetCreatePatientDto()
        {

            var dto = new CreatePatientDto()
            {
                Name = "Mark",
                Surname = "Mark",
                Age = 30,
                Gender = "Other",
                EmailAddress = "mark@gmail.com",
                PhoneNumber = "0777666655",
                HomeAddress = "Iasi",
            };
            return dto;
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

        private async Task<Result> FailResult(Guid id)
        {
            return Result.Failure($"Patient with ID: {id} does not exist.");
        }

        private async Task<Result<Patient>> FailureResult(Guid id)
        {
            return Result<Patient>.Failure($"Patient with ID: {id} does not exist.");
        }

        private PatientDto GetPatientDto()
        {
            var dto = new PatientDto()
            {
                Id = idOk,
                Name = "Mark",
                Surname = "Mark",
                Age = 30,
                Gender = "Other",
                EmailAddress = "mark@gmail.com",
                PhoneNumber = "0777666655",
                HomeAddress = "Iasi",
            };
            return dto;
        }

        private Patient GetPatient()
        {
            return new Patient()
            {
                Id = idOk,
                Name = "Mark",
                Surname = "Mark",
                Age = 30,
                Gender = PersonGender.Other,
                EmailAddress = "mark@gmail.com",
                PhoneNumber = "0777666655",
                HomeAddress = "Iasi",
            };
        }

        private Result<Patient> GetTestPatient()
        {
            var patient = GetPatient();
            return Result<Patient>.Success(patient);
        }
    }
}
