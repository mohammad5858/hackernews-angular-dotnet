using Xunit;
using Moq;
using HackerNews.Api.Controllers;
using HackerNews.Application;
using HackerNews.Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackerNews.Api.Tests
{
    public class StoriesControllerTests
    {
        [Fact]
        public async Task Get_ReturnsStoriesList()
        {
            // Arrange
            var mockService = new Mock<IStoryService>();
            mockService.Setup(s => s.GetNewestStoriesAsync(1, 20, null))
                .ReturnsAsync(new List<Story> { new Story { Id = 1, Title = "Test Story", By = "user", Score = 10, Time = 123456 } });
            var controller = new StoriesController(mockService.Object);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var stories = Assert.IsAssignableFrom<IEnumerable<Story>>(okResult.Value);
            Assert.Single(stories);
        }
    }
}
