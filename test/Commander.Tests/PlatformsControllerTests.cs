using System;
using System.Threading.Tasks;
using System.Xml.XPath;
using Commander.Controllers;
using Commander.Models;
using Commander.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Moq;
using Xunit;

namespace Commander.Tests
{
    public class PlatformsControllerTests
    {
        private readonly Mock<IPlatformsRepo> _repositoryStub = new();
        private readonly Random _random = new();

        [Fact]
        // Naming convention for tests: UnitOfWork_StateUnderTest_ExpectedBehaviour
        public async Task GetPlatformByIdAsync_NonexistentItem_ReturnsNotFound()
        {
            // Arrange
            _repositoryStub.Setup(repo => repo.GetPlatformByIdAsync(999)).ReturnsAsync((Platform)null);

            var controller = new PlatformsController(_repositoryStub.Object);

            // Act
            var result = await controller.GetPlatformByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task GetPlatformByIdAsync_IncorrectType_BadRequest()
        {
            // Arrange
            _repositoryStub.Setup(repo => repo.GetPlatformByIdAsync(999)).ReturnsAsync((Platform)null);

            var controller = new PlatformsController(_repositoryStub.Object);

            // Act
            var result = await controller.GetPlatformByIdAsync("1");
            controller.ModelState.AddModelError("mock", "failed");

            // Assert
            result.Result.Should().BeOfType<BadRequestResult>();
        }

        [Fact]
        public async Task GetPlatformByIdAsync_WithExistingItem_ReturnExpectedItem()
        {
            // Arrange
            var expectedItem = CreateRandomPlatform();
            _repositoryStub.Setup(repo => repo.GetPlatformByIdAsync(999)).ReturnsAsync(expectedItem);

            var controller = new PlatformsController(_repositoryStub.Object);

            // Act
            var result = await controller.GetPlatformByIdAsync(999);

            // Assert
            result.Result.Should().BeOfType<OkObjectResult>();
        }

        private static Platform CreateRandomPlatform()
        {
            return new Platform
            {
                Id = 999,
                Name = "A new framework"
            };
        }
    }
}


// https://www.youtube.com/watch?v=dsD0CMgPjUk at 24'32"