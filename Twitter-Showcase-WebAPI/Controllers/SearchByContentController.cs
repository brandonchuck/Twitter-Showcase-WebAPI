using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{

    [Route("api/tweets/search/content")]
    [ApiController]
    public class SearchByContentController : ControllerBase
    {
        private readonly ITwitterAuthorizationService _twitterAuthorizationService;
        private readonly IContentSearchService _contentSearchService;
        private IConfiguration _configuration;


        public SearchByContentController(ITwitterAuthorizationService twitterAuthorizationService, IContentSearchService contentSearchService, IConfiguration configuration)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _contentSearchService = contentSearchService;
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<string> GetRecentTweets([FromQuery] string searchTerm)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);

            var recentTweets = await _contentSearchService.GetTweetsByContent(searchTerm, authToken);

            return JsonSerializer.Serialize(recentTweets);
        }
    }
}
