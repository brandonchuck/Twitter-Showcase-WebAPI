using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twitter_Showcase_WebAPI.Models;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{
    [Route("api/tweets/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private ITwitterAuthorizationService _twitterAuthorizationService;
        private IGetUserDetailsService _getUserDetailsService;
        private IGetUserTimelineService _getUserTimelineService;
        private IConfiguration _configuration;

        public SearchController(ITwitterAuthorizationService twitterAuthorizationService, IGetUserTimelineService getUserTimelineService, IGetUserDetailsService getUserDetailsService, IConfiguration configuration)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _getUserDetailsService = getUserDetailsService;
            _getUserTimelineService = getUserTimelineService;
            _configuration = configuration;
        }

        // return list of Tweet objects
        [HttpGet]
        public async Task<string> GetUserTweets([FromQuery] string username)
        {
            string bearerToken = await _twitterAuthorizationService.GetBearerToken(_configuration["ApiKey"], _configuration["SecretKey"]);

            string userId = await _getUserDetailsService.GetUserId(username, bearerToken);

            var userTimeline = await _getUserTimelineService.GetUserTimeline(userId, bearerToken);

            return JsonSerializer.Serialize(userTimeline); // The timeline should be returned as JSON
        }
    }
}
