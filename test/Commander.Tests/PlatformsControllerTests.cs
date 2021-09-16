using System;
using System.Threading.Tasks;
using System.Xml.XPath;
using Commander.Controllers;
using Commander.Models;
using Commander.Repositories;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
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
            _repositoryStub.Setup(repo => repo.GetPlatformByIdAsync(It.IsAny<int>())).ReturnsAsync((Platform)null);

            var controller = new PlatformsController(_repositoryStub.Object);

            // Act
            var result = await controller.GetPlatformByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
        // public async Task GetPlatformByIdAsync_IncorrectType_BadRequest()
        // {
        //     // Arrange
        //     var repositoryStub = new Mock<IPlatformsRepo>();
        //
        //     repositoryStub.Setup(repo => repo.GetPlatformByIdAsync(It.IsAny<string>())).ReturnsAsync((Platform)null);
        //
        //     var controller = new PlatformsController(repositoryStub.Object);
        //
        //     // Act
        //     var result = await controller.GetPlatformByIdAsync("hello");
        //
        //     // Assert
        //     Assert.IsType<BadRequestResult>(result.Result);
        // }

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
            result.Result.Should().BeEquivalentTo(expectedItem);
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