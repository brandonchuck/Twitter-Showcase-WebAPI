using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twitter_Showcase_WebAPI.Models;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{
    [Route("api/tweets/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ITwitterAuthorizationService _twitterAuthorizationService;
        private readonly IGetUserDetailsService _getUserDetailsService;
        private readonly IGetUserTimelineService _getUserTimelineService;
        private readonly IGetContentTweetsService _getContentTweetsService;
        private readonly IConfiguration _configuration;

        public SearchController(ITwitterAuthorizationService twitterAuthorizationService, IGetUserDetailsService getUserDetailsService, IGetUserTimelineService getUserTimelineService, IGetContentTweetsService getContentTweetsService, IConfiguration configuration)
        {
            _twitterAuthorizationService = twitterAuthorizationService; 
            _getUserDetailsService = getUserDetailsService;
            _getUserTimelineService = getUserTimelineService;
            _getContentTweetsService = getContentTweetsService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<string> GetUserTweets([FromQuery] string searchTerm)
        {
            string bearerToken = await _twitterAuthorizationService.GetBearerToken("jy6PWJ93pd2QmRgVgjB3RvfwY", "Bc6hD9xFaoQfsLvrNefZlMFRYvzl18AsRP0O0Fs5c7j6EAmH20");

            //string userId = await _getUserDetailsService.GetUserId(searchTerm, bearerToken);

            //var userTimeline = await _getUserTimelineService.GetUserTimeline(userId, bearerToken);
            var recentTweets = await _getContentTweetsService.GetRecentTweets(searchTerm, bearerToken);

            return JsonSerializer.Serialize(recentTweets); // The timeline should be returned as JSON
            //return JsonSerializer.Serialize(recentTweets);

        }
    }
}
