using System.Collections.Generic;
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

        // username passed from client
        [HttpGet]
        public async Task<string> GetRandomTweets([FromQuery] string user)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);
            
            UserDetails userDetails = await _userDetailsService.GetUserDetails(user, authToken);
            
            var userTimeline = await _userTimelineService.GetUserTimelineByUserId(userDetails.data.id, authToken);

            var randomTweets = _randomTweetsService.GetRandomTweets(userTimeline);

            return JsonSerializer.Serialize(randomTweets);
        }

        [HttpGet]
        [Route("random-user-profiles")]
        public async Task<string> GetRandomUserProfiles()
        {
            List<UserDetails> randomUsers = new List<UserDetails>();

            List<string> usernames = new List<string>
            {
                "garyvee", "shanicucic96", "DystoApez", "PGodjira", "AbsoluteSaltETH"
            };

            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);

            foreach (string u in usernames)
            {
                var user = await _userDetailsService.GetUserDetails(u, authToken);
                randomUsers.Add(user);
            }

            return JsonSerializer.Serialize(randomUsers);
        }

    }
}
