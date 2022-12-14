using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyDocAppointment.API.Controllers;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Application.Commands;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Users;
using Xunit;

namespace MyDocAppointment.Tests
{
    public class DoctorControllerShould
    {
        DoctorController controller;
        static Guid idOk;  
        Guid idNotFound;
        public DoctorControllerShould()
        {
            // Arrange
            idOk = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            idNotFound = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
            var doctorsServiceMock = new Mock<IDoctorsService>();
            var mapperMock = new Mock<IMapper>();
            var mediatorMock = new Mock<IMediator>();
            doctorsServiceMock.Setup(r => r.GetById(idOk))
                .ReturnsAsync(GetTestDoctors());
            doctorsServiceMock.Setup(r => r.GetById(idNotFound))
                .Returns(FailureResult(idNotFound));
            doctorsServiceMock.Setup(r => r.Create(It.IsAny<Doctor>()))
                .Returns(Task.CompletedTask);
            doctorsServiceMock.Setup(r => r.Delete(idOk))
                 .Returns(SuccessResult());
            doctorsServiceMock.Setup(r => r.Delete(idNotFound))
                 .Returns(FailResult(idNotFound));
            doctorsServiceMock.Setup(r => r.Update(It.IsAny<Doctor>(), idOk))
                 .ReturnsAsync(GetTestDoctor());
            doctorsServiceMock.Setup(r => r.Update(It.IsAny<Doctor>(), idNotFound))
                 .Returns(FailureResult(idNotFound));
            controller = new DoctorController(doctorsServiceMock.Object, mapperMock.Object, mediatorMock.Object);
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
            var response = await controller.Create(GetCreateDoctorDto());

            // Assert
            Assert.IsType<OkObjectResult>(response);
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
            var response = await controller.Update(GetDoctorDto(), idOk);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenThedrugWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Update(GetDoctorDto(), idNotFound);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        private static CreateDoctorCommand GetCreateDoctorDto()
        {

            var doctor = new CreateDoctorCommand();
            return doctor;

        }
        private static Result<Doctor> GetTestDoctors()
        {
            var doctor = new Doctor();
            return Result<Doctor>.Success(doctor);
        }
        private static async Task<Result> SuccessResult()
        {
            return Result.Success();
        }
        private static async Task<Result> FailResult(Guid id)
        {
            return Result.Failure($"Doctor with ID: {id} does not exist.");
        }
        private static async Task<Result<Doctor>> FailureResult(Guid id)
        {
            return Result<Doctor>.Failure($"Patient with ID: {id} does not exist.");
        }

        private static DoctorDto GetDoctorDto()
        {
            var dto = new DoctorDto()
            {
                Id = idOk,
                Name = "Mark",
                Surname = "Mark",
                Age = 30,
                Gender = "Other",
                EmailAddress = "mark@gmail.com",
                PhoneNumber = "0777666655",
                HomeAddress = "Iasi",
                Speciality = "Cardiology"
            };
            return dto;
        }

        private static Doctor GetDoctor()
        {
            return new Doctor()
            {
                Id = idOk,
                Name = "Mark",
                Surname = "Mark",
                Age = 30,
                Gender = PersonGender.Other,
                EmailAddress = "mark@gmail.com",
                PhoneNumber = "0777666655",
                HomeAddress = "Iasi",
                Speciality = Specialization.Cardiology
            };
        }

        private static Result<Doctor> GetTestDoctor()
        {
            var doctor = GetDoctor();
            return Result<Doctor>.Success(doctor);
        }
    }
}
