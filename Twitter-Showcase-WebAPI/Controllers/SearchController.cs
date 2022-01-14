using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{
    [ApiController]
    [Route("/UserTweets/{username}")]
    public class SearchController : ControllerBase
    {
        private TwitterAuthorizationService _twitterAuthorizationService;
        private GetUserTimelineService _getUserTimelineService;
        private GetUserDetailsService _getUserDetailsService;
        private IConfiguration _configuration;

        public SearchController(TwitterAuthorizationService twitterAuthorizationService, GetUserTimelineService getUserTimelineService, IConfiguration configuration, GetUserDetailsService getUserDetailsService)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _getUserTimelineService = getUserTimelineService;
            _getUserDetailsService = getUserDetailsService;
        }

        // return list of Tweet objetcts to display on front end
        [HttpGet]
        public async void GetUserTweets()
        {
            // get bearer token for api call authorization
            var bearerToken = await _twitterAuthorizationService.GetBearerToken(_configuration["ApiKey"], _configuration["SecretKey"]);

            // HOW DO I GET username FROM THE URL TO PASS TO GetUserId() ???
            // get user_id from api call; username parameter will come from the url
            var userId = await _getUserDetailsService.GetUserId(username, bearerToken);

            // get the list of tweets from api call using the user_id
            var userTimeline = await _getUserTimelineService.GetUserTimeline(userId, bearerToken);

        }


    }
}
