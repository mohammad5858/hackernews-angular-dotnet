using HackerNews.Domain;

namespace HackerNews.Application
{
    public interface IStoryService
    {
        Task<IEnumerable<Story>> GetNewestStoriesAsync(int page = 1, int pageSize = 20, string? search = null);
    }
}
