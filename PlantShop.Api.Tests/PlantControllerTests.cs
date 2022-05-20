using System.Net;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using PlantShop.Api.Controllers;
using PlantShop.Service.Repository;
using Xunit;

namespace PlantShop.Api.Tests
{
    public class PlantControllerTests
    {
        private readonly IPlantRepository _plantRepository = Substitute.For<IPlantRepository>();
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
            result.Should().BeOfType<OkObjectResult>().Subject.StatusCode.Should().Be((int) HttpStatusCode.OK);
        }

        [Fact]
        public async Task PlantController_GetById_ShouldReturnOk()
        {
            // Arrange
            const int id = 1;

            // Act
            var result = await _sut.Get(id);

            // Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkObjectResult>().Subject.StatusCode.Should().Be((int)HttpStatusCode.OK);
        }
    }
}