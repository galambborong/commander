using System;
using System.Threading.Tasks;
using Commander.Controllers;
using Commander.Models;
using Commander.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Commander.Tests
{
    public class PlatformsControllerTests
    {
        [Fact]
        // Naming convention for tests:
            // UnitOfWork
            // StateUnderTest
            // ExpectedBehaviour
        public async Task GetPlatformByIdAsync_NonexistantItem_ReturnsNotFound()
        {
            // Arrange
            var repositoryStub = new Mock<IPlatformsRepo>();

            repositoryStub.Setup(repo => repo.GetPlatformByIdAsync(It.IsAny<Int16>())).ReturnsAsync((Platform)null);

            var controller = new PlatformsController(repositoryStub.Object);

            // Act
            var result = await controller.GetPlatformByIdAsync(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
}


// https://www.youtube.com/watch?v=dsD0CMgPjUk at 24'32"