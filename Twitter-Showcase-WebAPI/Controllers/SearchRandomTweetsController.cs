using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
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
        private readonly IFormatTweetService _formatTweetService;
        private readonly IConfiguration _configuration;


        public SearchRandomTweetsController(ITwitterAuthorizationService twitterAuthorizationService, IUserDetailsService userDetailsService, IUserTimelineService userTimelineService, IFormatTweetService formatTweetService, IConfiguration configuration)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _userDetailsService = userDetailsService;
            _userTimelineService = userTimelineService;
            _formatTweetService = formatTweetService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<List<TweetObject>> GetRandomTweets([FromQuery] string user)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);
            UserDetails userDetails = await _userDetailsService.GetUserId(user, authToken);
            var userTimeline = await _userTimelineService.GetUserTimeline(userDetails.data.id, authToken);


            var randomTweets = _formatTweetService.GetRandomTweets(userTimeline);

            return JsonSerializer.Serialize(randomTweets);
        }
    }
}
