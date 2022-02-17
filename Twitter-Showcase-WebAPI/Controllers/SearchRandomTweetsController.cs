using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twitter_Showcase_WebAPI.Models;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{
    [Route("api/tweets/search/random")]
    [ApiController]
    public class SearchRandomTweetsController : ControllerBase
    {
        private readonly ITwitterAuthorizationService _twitterAuthorizationService;
        private readonly IUserDetailsService _userDetailsService;
        private readonly IUserTimelineService _userTimelineService;
        private readonly IRandomTweetsService _randomTweetsService;
        private readonly IConfiguration _configuration;


        public SearchRandomTweetsController(ITwitterAuthorizationService twitterAuthorizationService, IUserDetailsService userDetailsService, IUserTimelineService userTimelineService, IRandomTweetsService randomTweetsService, IConfiguration configuration)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _userDetailsService = userDetailsService;
            _userTimelineService = userTimelineService;
            _randomTweetsService = randomTweetsService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<string> GetRandomTweets([FromQuery] string user)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);
            
            UserDetails userDetails = await _userDetailsService.GetUserId(user, authToken);
            
            var userTimeline = await _userTimelineService.GetUserTimeline(userDetails.data.id, authToken);

            var randomTweets = _randomTweetsService.GetRandomTweets(userTimeline);

            return JsonSerializer.Serialize(randomTweets);
        }

        [HttpGet]
        public async Task<string> GetRandomUserProfilePicture([FromQuery] string username)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);

            var profilePicture = await _randomTweetsService.GetRandomUserProfilePicture(username, authToken);

            return JsonSerializer.Serialize(profilePicture);
        }
    }
}
