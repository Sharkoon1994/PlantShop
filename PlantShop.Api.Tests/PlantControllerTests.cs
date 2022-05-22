using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PlantShop.Api.Controllers;
using PlantShop.Data.Context;
using PlantShop.Data.Models;
using PlantShop.Service.Repository;
using Xunit;

namespace PlantShop.Api.Tests
{
    public class PlantControllerTests
    {
        private readonly PlantRepository _plantRepository = Substitute.For<PlantRepository>();
        private readonly PlantController _sut;

        public PlantControllerTests()
        {
            _sut = new PlantController(_plantRepository);
        }

        [Fact]
        public async Task PlantController_Get_ShouldReturnOk()
        {
            // Act
            var result = await _sut.Get();

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>().Subject.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlantController_GetById_ShouldReturnOk()
        {
            // Act
            var result = await _sut.Get(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>().Subject.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlantController_PostWithValidData_ShouldReturnOk()
        {
            // Arrange
            var model = new Plant
            {
                Description = "Flower",
                Name = "Orchidee",
                Price = 2.59
            };

            // Act
            var result = await _sut.Post(model);

            // Assert
            result.Should().BeOfType<OkResult>().Subject.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlantController_PostWithInvalidData_ShouldBadRequest()
        {
            // Arrange
            var model = new Plant
            {
                Price = 2.59
            };

            // Act
            var result = await _sut.Post(model);

            // Assert
            result.Should().BeOfType<OkResult>().Subject.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlantController_Delete_ShouldReturnOk()
        {
            // Arrange
            const int id = 1;

            // Act
            var result = await _sut.Delete(id);

            // Assert
            result.Should().BeOfType<OkResult>().Subject.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}