using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Twitter_Showcase_WebAPI.CustomActionResults;
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
        public async Task<ActionResult> GetUserTimeline([FromQuery] string searchTerm)
        {

            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);

            if (searchTerm.Length >= 15)
            {
                return BadRequest("Username must be 15 characters or less");
            }

            UserDetails userDetails = await _userDetailsService.GetUserId(searchTerm, authToken);

            if (userDetails.data == null)
            {
                return NotFound("User not found");
            }

            var userTimeline = await _userTimelineService.GetUserTimeline(userDetails.data.id, authToken);

            if (userTimeline.data == null) 
            {
                return NotFound("User does not have any tweets");
            }

            var tweets = _formatTweetService.GetFormattedTweets(userTimeline);

            return Ok(JsonSerializer.Serialize(tweets));

        }
    }
}

