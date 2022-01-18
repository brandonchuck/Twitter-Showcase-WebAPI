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
        private IConfiguration _configuration;

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
            string apiKey = _configuration["Twitter:ApiKey"];
            string secretKey = _configuration["Twitter:SecretKey"];


            string authToken = await _twitterAuthorizationService.GetBearerToken(apiKey, secretKey);
            string id = await _getUserDetailsService.GetUserId(searchTerm, authToken);

            var userTimeline = await _getUserTimelineService.GetUserTimeline(id, authToken);
            //var recentTweets = await _getContentTweetsService.GetRecentTweets(searchTerm, authToken);

            return JsonSerializer.Serialize(userTimeline); // The timeline should be returned as JSON
            //return JsonSerializer.Serialize(recentTweets);

        }
    }
}
