using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twitter_Showcase_WebAPI.Models;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{
    [Route("/user/search/")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private TwitterAuthorizationService _twitterAuthorizationService;
        private GetUserDetailsService _getUserDetailsService;
        private GetUserTimelineService _getUserTimelineService;
        private IConfiguration _configuration;

        public SearchController(TwitterAuthorizationService twitterAuthorizationService, GetUserTimelineService getUserTimelineService, IConfiguration configuration, GetUserDetailsService getUserDetailsService)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _getUserDetailsService = getUserDetailsService;
            _getUserTimelineService = getUserTimelineService;

        }

        // return list of Tweet objetcts
        [HttpGet("{username}")]
        public async Task<string> GetUserTweets([FromRoute] string username)
        {
            string bearerToken = await _twitterAuthorizationService.GetBearerToken(_configuration["ApiKey"], _configuration["SecretKey"]);

            string userId = await _getUserDetailsService.GetUserId(username, bearerToken);

            var userTimeline = await _getUserTimelineService.GetUserTimeline(userId, bearerToken);

            return JsonSerializer.Serialize(userTimeline); // The timeline should be returned as JSON
        }


    }
}
