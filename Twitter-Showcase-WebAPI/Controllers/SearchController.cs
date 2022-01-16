using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RestSharp;
using RestSharp.Authenticators;
using Twitter_Showcase_WebAPI.Models;
using Twitter_Showcase_WebAPI.Services;

namespace Twitter_Showcase_WebAPI.Controllers
{
    [Route("/user/search/")]
    [ApiController]
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

        // return list of Tweet objetcts
        [HttpGet("{username}")]
        public async Task<IEnumerable<TweetObject>> GetUserTweets([FromRoute] string username)
        {
            // get bearer token for api call authorization
            string bearerToken = await _twitterAuthorizationService.GetBearerToken(_configuration["ApiKey"], _configuration["SecretKey"]);

            // get id from api call; username parameter will come from the route
            string userId = await _getUserDetailsService.GetUserId(username, bearerToken);

            // if userId is null, meaning there is no user with the specified username, then treat it as content and return tweets

            // get the list of tweets from api call using the user_id
            IEnumerable<TweetObject> userTimeline = await _getUserTimelineService.GetUserTimeline(userId, bearerToken);

            return userTimeline; // The timeline should be returned as JSON
        }


    }
}
