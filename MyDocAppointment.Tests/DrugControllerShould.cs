using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyDocAppointment.API.Controllers;
using MyDocAppointment.API.Dtos;
using MyDocAppointment.Business.Helpers;
using MyDocAppointment.Business.Interfaces;
using MyDocAppointment.Business.Logistics.Internal;
using Xunit;

namespace MyDocAppointment.Tests
{
    public class DrugControllerShould
    {
        DrugController controller;
        Guid idOk;
        Guid idNotFound;
        public DrugControllerShould()
        {
            // Arrange
            idOk = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            idNotFound = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa5");
            var drugsServiceMock = new Mock<IDrugsService>();
            var mapperMock = new Mock<IMapper>();
            drugsServiceMock.Setup(r => r.GetById(idOk))
                .ReturnsAsync(GetTestDrug());
            drugsServiceMock.Setup(r => r.GetById(idNotFound))
                .Returns(FailureResult(idNotFound));
            drugsServiceMock.Setup(r => r.Create(It.IsAny<Drug>()))
                .Returns(Task.CompletedTask);
            drugsServiceMock.Setup(r => r.Delete(idOk))
                 .Returns(SuccessResult());
            drugsServiceMock.Setup(r => r.Delete(idNotFound))
                 .Returns(FailResult(idNotFound));
            drugsServiceMock.Setup(r => r.Update(It.IsAny<Drug>(), idOk))
                 .ReturnsAsync(GetTestDrug());
            drugsServiceMock.Setup(r => r.Update(It.IsAny<Drug>(), idNotFound))
                 .Returns(FailureResult(idNotFound));
            controller = new DrugController(drugsServiceMock.Object, mapperMock.Object);
        }

        [Fact]
        public async Task GetById_ReturnsOk_WhenThedrugWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.GetById(idOk);

            // Assert       
            Assert.IsType<OkObjectResult>(response);
        }
        [Fact]
        public async Task GetById_ReturnsNotFound_WhenThedrugWithSpecifiedIdIsNotFound()
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
            var response = await controller.Create(GetCreateDrugDto());

            // Assert
            Assert.IsType<CreatedResult>(response);
        }

        [Fact]
        public async Task Delete_ReturnsOk_WhenThedrugWithSpecifiedIdIsFound()
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
            var response = await controller.Update(GetDrugDto(), idOk);

            // Assert
            Assert.IsType<OkObjectResult>(response);
        }

        [Fact]
        public async Task Update_ReturnsNotFound_WhenThedrugWithSpecifiedIdIsFound()
        {
            //Act
            var response = await controller.Update(GetDrugDto(), idNotFound);

            // Assert
            Assert.IsType<NotFoundObjectResult>(response);
        }

        private CreateDrugDto GetCreateDrugDto()
        {

            var drug = new CreateDrugDto();
            return drug;

        }
        private Result<Drug> GetTestDrugs()
        {
            var drug = new Drug();
            return Result<Drug>.Success(drug);
        }

        private Result<Drug> GetTestDrug()
        {
            var drug = GetDrug();
            return Result<Drug>.Success(drug);
        }
        private async Task<Result> SuccessResult()
        {
            return Result.Success();
        }
        private async Task<Result> FailResult(Guid id)
        {
            return Result.Failure($"Patient with ID: {id} does not exist.");
        }
        private async Task<Result<Drug>> FailureResult(Guid id)
        {
            return Result<Drug>.Failure($"Drug with ID: {id} does not exist.");
        }

        private Drug GetDrug()
        {
            return new Drug()
                { 
                Id = idOk,
                Vendor = "vendor",
                Name = "Name",
                Category = "Category",
                Price = (decimal)12.4
                };
        }

        private DrugDto GetDrugDto()
        {
            return new DrugDto()
            {
                Id = idOk,
                Name = "Name",
                Vendor = "vendor",
                Category = "Category",
                Price = (decimal)12.4
            };
        }
    }
}
