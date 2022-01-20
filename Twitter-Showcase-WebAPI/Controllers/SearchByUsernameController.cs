using System.Collections.Generic;
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
    public class SearchController : ControllerBase
    {
        private readonly ITwitterAuthorizationService _twitterAuthorizationService;
        private readonly IUserDetailsService _userDetailsService;
        private readonly IUserTimelineService _userTimelineService;
        private IConfiguration _configuration;

        public SearchController(ITwitterAuthorizationService twitterAuthorizationService, IUserDetailsService userDetailsService, IUserTimelineService userTimelineService, IConfiguration configuration)
        {
            _twitterAuthorizationService = twitterAuthorizationService; 
            _userDetailsService = userDetailsService;
            _userTimelineService = userTimelineService;
            _configuration = configuration;
        }


        [HttpGet]
        public async Task<string> GetUserTimeline([FromQuery] string searchTerm)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);
            UserDetails userDetails = await _userDetailsService.GetUserId(searchTerm, authToken);

            var userTimeline = await _userTimelineService.GetUserTimeline(userDetails.data.id, authToken);

            return JsonSerializer.Serialize(userTimeline);
        }
    }
}
