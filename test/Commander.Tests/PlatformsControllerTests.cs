using Commander.Repositories;
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
        public void GetPlatformByIdAsync_NonexistantItem_ReturnsNotFound()
        {
            // Arrange
            var repositoryStub = new Mock<IPlatformsRepo>();


            // Act

            // Assert
        }
    }
}


// https://www.youtube.com/watch?v=dsD0CMgPjUk at 24'32"