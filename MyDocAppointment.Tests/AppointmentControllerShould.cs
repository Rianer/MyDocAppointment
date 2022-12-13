using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyDocAppointment.API.Controllers;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.External;
using Xunit;

namespace MyDocAppointment.Tests
{
    public class AppointmentControllerShould
    {
        AppointmentController controller;
        Guid idOk;
        Guid idNotFound;
        public AppointmentControllerShould()
        {
            // Arrange
            idOk = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            idNotFound = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
            var appointmentsServiceMock = new Mock<IAppointmentsService>();
            var mapperMock = new Mock<IMapper>();
            appointmentsServiceMock.Setup(r => r.GetById(idOk))
                .ReturnsAsync(GetTestAppointments());
            appointmentsServiceMock.Setup(r => r.GetById(idNotFound))
                .Returns(FailureResult(idNotFound));
            appointmentsServiceMock.Setup(r => r.Create(It.IsAny<Appointment>()))
                .Returns(Task.CompletedTask);
            appointmentsServiceMock.Setup(r => r.Delete(idOk))
                 .Returns(SuccessResult());
            appointmentsServiceMock.Setup(r => r.Delete(idNotFound))
                 .Returns(FailResult(idNotFound));
            appointmentsServiceMock.Setup(r => r.Update(It.IsAny<Appointment>(), idOk))
                 .ReturnsAsync(GetTestAppointment());
            appointmentsServiceMock.Setup(r => r.Update(It.IsAny<Appointment>(), idNotFound))
                 .Returns(FailureResult(idNotFound));
            controller = new AppointmentController(appointmentsServiceMock.Object, mapperMock.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenTheAppointmentWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.GetById(idOk);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task GetById_ReturnsNotFound_WhenTheAppointmentWithSpecifiedIdIsNotFound()
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
            var response = await controller.Create(GetCreateAppointmentDto());

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
            var response = await controller.Update(GetAppointmentDto(), idOk);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenThedrugWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Update(GetAppointmentDto(), idNotFound);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        private CreateAppointmentDto GetCreateAppointmentDto()
        {

            var Appointment = new CreateAppointmentDto();
            return Appointment;

        }
        private Result<Appointment> GetTestAppointments()
        {
            var Appointment = new Appointment();
            return Result<Appointment>.Success(Appointment);
        }
        private async Task<Result> SuccessResult()
        {
            return Result.Success();
        }
        private async Task<Result> FailResult(Guid id)
        {
            return Result.Failure($"Appointment with ID: {id} does not exist.");
        }
        private async Task<Result<Appointment>> FailureResult(Guid id)
        {
            return Result<Appointment>.Failure($"Appointment with ID: {id} does not exist.");
        }

        private AppointmentDto GetAppointmentDto()
        {
            var dto = new AppointmentDto()
            {
                Id = idOk.ToString(),
                Location = "Iasi",
                PatientID = "8a1dd56e-3714-47ff-74bb-08dad798785d",
                DoctorID = "74a67233-cd3d-4b6a-3af0-08dad791cf86",
                Specialization = "Cardiology",
                AppointmentTime = "03 March 2016 06:30",
                PaymentMethod = "Card",
                PaymentDate = DateTime.Now.ToString(),
                Amount = 400
            };
            return dto;
        }

        private Appointment GetAppointment()
        {
            return new Appointment()
            {
                Id = idOk,
                Location = "Iasi",
                PatientID = new Guid("8a1dd56e-3714-47ff-74bb-08dad798785d"),
                DoctorID = new Guid("74a67233-cd3d-4b6a-3af0-08dad791cf86"),
                Specialization = Specialization.Cardiology,
                AppointmentTime = DateTime.Now,
                Payment = new Payment()
                {
                    Id= idOk,
                    PaymentMethod = PaymentMethod.Card,
                    EmissionDate = DateTime.Now,
                    AcquittedDate = DateTime.Now,
                    DueDate = DateTime.Now,
                    Amount = 400
                }
            };
        }

        private Result<Appointment> GetTestAppointment()
        {
            var Appointment = GetAppointment();
            return Result<Appointment>.Success(Appointment);
        }
    }
}
