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
        private readonly IFormatTweetService _formatTweetService;
        private readonly IConfiguration _configuration;

        public SearchByContentController(ITwitterAuthorizationService twitterAuthorizationService, IContentSearchService contentSearchService, IConfiguration configuration, IFormatTweetService formatTweetService)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _contentSearchService = contentSearchService;
            _configuration = configuration;
            _formatTweetService = formatTweetService;
        }


        [HttpGet]
        public async Task<ActionResult> GetTweetsByContent([FromQuery] string searchTerm)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);
            
            var recentTweets = await _contentSearchService.GetTweetsByContent(searchTerm, authToken);
            
            if (recentTweets.data == null)
            {
                return NotFound("Content not found");
            }

            var tweets = _formatTweetService.GetFormattedTweets(recentTweets);

            return Ok(JsonSerializer.Serialize(tweets));
        }
    }
}
