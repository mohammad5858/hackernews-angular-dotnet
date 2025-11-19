using Microsoft.AspNetCore.Mvc;
using HackerNews.Application;
using HackerNews.Domain;

namespace HackerNews.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StoriesController : ControllerBase
    {
        private readonly IStoryService _storyService;

        public StoriesController(IStoryService storyService)
        {
            _storyService = storyService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Story>>> Get([FromQuery] int page = 1, [FromQuery] int pageSize = 20, [FromQuery] string? search = null)
        {
            var stories = await _storyService.GetNewestStoriesAsync(page, pageSize, search);
            return Ok(stories);
        }
    }
}
