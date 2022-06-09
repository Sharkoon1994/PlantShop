using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PlantShop.Api.Controllers;
using PlantShop.Api.Models;
using PlantShop.Data.Entities;
using PlantShop.Service;
using Xunit;

namespace PlantShop.Api.Tests
{
    public class PlantControllerTests
    {
        private readonly IPlantService _plantService = Substitute.For<IPlantService>();
        private readonly PlantController _sut;

        public PlantControllerTests()
        {
            _sut = new PlantController(_plantService);
        }

        [Fact]
        public async Task GetById_WithValidEntity_ShouldReturnOk()
        {
            // Arrange
            _plantService.Get(Arg.Any<int>()).Returns(new Plant
            {
                Id = 1,
                Name = "test",
                Description = "test",
                Price = 5.0
            });

            // Act
            var result = await _sut.GetById(1);

            // Assert
            result.Should().NotBeNull(); 
            result.Should().BeOfType<OkObjectResult>();
        }

        [Fact]
        public async Task GetById_WithoutEntity_ShouldReturnNotFound()
        {
            // Act
            var result = await _sut.GetById(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NotFoundResult>();
        }

        [Fact]
        public async Task Post_WithValidRequest_ShouldReturnOk()
        {
            // Arrange
            var request = await CreateMockRequest();

            // Act
            var result = await _sut.Post(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<CreatedResult>();
        }

        [Fact]
        public async Task Post_WhereRequestIsNull_ShouldReturnBadRequest()
        {
            // Act
            var result = await _sut.Post(null);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task Post_WithInvalidRequest_ShouldReturnBadRequest()
        {
            // Arrange
            var request = new PlantModel
            {
                Price = 2.59
            };

            // Act
            var result = await _sut.Post(request);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task Delete_WithValidEntity_ShouldReturnOk()
        {
            // Arrange
            _plantService.Get(Arg.Any<int>()).Returns(new Plant
            {
                Id = 1,
                Name = "test",
                Description = "test",
                Price = 5.0
            });

            // Act
            var result = await _sut.Delete(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkResult>();
        }

        [Fact]
        public async Task Delete_ShouldReturnOk()
        {
            // Act
            var result = await _sut.Delete(1);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<NoContentResult>();
        }

        private static Task<PlantModel> CreateMockRequest()
        {
            return Task.FromResult(new PlantModel
            {
                Id = 1,
                Description = "Flower",
                Name = "Orchidee",
                Price = 2.59
            });
        }
    }
}