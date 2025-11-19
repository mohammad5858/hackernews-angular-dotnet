using Xunit;
using Moq;
using HackerNews.Application;
using HackerNews.Domain;
using HackerNews.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HackerNews.Application.Tests
{
    public class StoryServiceTests
    {
        [Fact]
        public async Task GetNewestStoriesAsync_ReturnsPagedStories()
        {
            // Arrange
            var mockHttp = new Mock<HttpClient>();
            var memoryCache = new MemoryCache(new MemoryCacheOptions());
            var service = new StoryService(new HttpClient(), memoryCache);
            // This test is a placeholder: in a real test, mock HttpClient and cache
            // For now, just check that it returns an IEnumerable
            var result = await service.GetNewestStoriesAsync(1, 20, null);
            Assert.NotNull(result);
        }
    }
}
