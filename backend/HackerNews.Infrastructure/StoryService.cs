using System.Net.Http.Json;
using Microsoft.Extensions.Caching.Memory;
using HackerNews.Domain;
using HackerNews.Application;

namespace HackerNews.Infrastructure
{
    public class StoryService : IStoryService
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _cache;
        private const string NewStoriesUrl = "https://hacker-news.firebaseio.com/v0/newstories.json";
        private const string StoryUrl = "https://hacker-news.firebaseio.com/v0/item/{0}.json";
        private const string CacheKey = "newest_stories";
        private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(5);

        public StoryService(HttpClient httpClient, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _cache = cache;
        }

        public async Task<IEnumerable<Story>> GetNewestStoriesAsync(int page = 1, int pageSize = 20, string? search = null)
        {
            var stories = await GetCachedStoriesAsync();
            if (!string.IsNullOrWhiteSpace(search))
            {
                stories = stories.Where(s => s.Title.Contains(search, StringComparison.OrdinalIgnoreCase));
            }
            return stories.Skip((page - 1) * pageSize).Take(pageSize);
        }

        private async Task<IEnumerable<Story>> GetCachedStoriesAsync()
        {
            IEnumerable<Story>? stories;
            if (!_cache.TryGetValue(CacheKey, out stories))
            {
                var ids = await _httpClient.GetFromJsonAsync<List<int>>(NewStoriesUrl) ?? new List<int>();
                var tasks = ids.Take(200).Select(id => _httpClient.GetFromJsonAsync<Story>(string.Format(StoryUrl, id)));
                var storyArray = await Task.WhenAll(tasks);
                stories = storyArray
                    .Where(s => s != null && !string.IsNullOrWhiteSpace(s!.Url))
                    .Cast<Story>();
                _cache.Set(CacheKey, stories.ToList(), CacheDuration);
            }
            return stories!.ToList();
        }
    }
}
