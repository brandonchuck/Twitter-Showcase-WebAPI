using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twitter_Showcase_WebAPI.Models;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{
    [Route("api/tweets/search/username")]
    [ApiController]
    public class SearchByUsernameController : ControllerBase
    {
        private readonly ITwitterAuthorizationService _twitterAuthorizationService;
        private readonly IUserDetailsService _userDetailsService;
        private readonly IUserTimelineService _userTimelineService;
        private readonly IFormatTweetService _formatTweetService;
        private readonly IConfiguration _configuration;

        public SearchByUsernameController(ITwitterAuthorizationService twitterAuthorizationService, IUserDetailsService userDetailsService, IUserTimelineService userTimelineService, IConfiguration configuration, IFormatTweetService formatTweetService)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _userDetailsService = userDetailsService;
            _userTimelineService = userTimelineService;
            _formatTweetService = formatTweetService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserTimeline([FromQuery] string searchTerm)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);

            // username must be 15 or less characters
            //if (searchTerm.Length > 15)
            //{
            // custom exception?
            //}

            UserDetails userDetails = await _userDetailsService.GetUserId(searchTerm, authToken);

            if (userDetails.data == null)
            {
                return NotFound("User not found");
            }

            var userTimeline = await _userTimelineService.GetUserTimeline(userDetails.data.id, authToken);

            var tweets = _formatTweetService.GetTweets(userTimeline);

            return Ok(JsonSerializer.Serialize(tweets));            
        }
    }
}

