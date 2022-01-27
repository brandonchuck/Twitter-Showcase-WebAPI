using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
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
        private IConfiguration _configuration;

        public SearchByUsernameController(ITwitterAuthorizationService twitterAuthorizationService, IUserDetailsService userDetailsService, IUserTimelineService userTimelineService, IConfiguration configuration)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _userDetailsService = userDetailsService;
            _userTimelineService = userTimelineService;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<List<TweetObject>> GetUserTimeline([FromQuery] string searchTerm)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);
            UserDetails userDetails = await _userDetailsService.GetUserId(searchTerm, authToken);
            var userTimeline = await _userTimelineService.GetUserTimeline(userDetails.data.id, authToken);

            List<TweetObject> tweetList = new List<TweetObject>();

            var dataArray = userTimeline.data;
            var includes = userTimeline.includes;

            List<TweetObject> tweets = userTimeline.data.Select<TweetData>(x =>
            {
                TweetObject tweet = new TweetObject()
                {
                    Text = x.text,
                    CreatedAt = x.created_at,
                    LikeCount = x.public_metrics.like_count,
                    RetweetCount = x.public_metrics.retweet_count,
                    CommentCount = x.public_metrics.reply_count
                };

                // find username and name
                UserData currentUser = userTimeline.includes.users.First(user => {
                    return user.id == x.id;
                });

                // set ScreenName and Username for tweet object
                tweet.ScreenName = currentUser.name;
                tweet.Username = currentUser.username;
                tweet.ProfileImageUrl = currentUser.profile_image_url;

                // check if there are any media_keys
                if (x.attachments.media_keys != null)
                {
                    // loop through each media_key in the array
                    foreach(string key in x.attachments.media_keys)
                    {
                        // loop through each media_key in includes.media
                        foreach (MediaData m in userTimeline.includes.media)
                        {
                            // check if these keys match for the current tweet object
                            if (m.media_key == key)
                            { 
                                if (m.type == "photo")
                                {
                                    // set photo
                                    tweet.ImageUrl = m.url;
                                } 

                                if (m.type == "video")
                                {
                                    // set video preview image
                                    tweet.VideoPreviewImageUrl = m.preview_image_url;
                                }                                
                            }
                        }
                    }
                } else
                {
                    tweet.ImageUrl = null;
                    tweet.VideoPreviewImageUrl = null;
                }
            });

            return tweetList;

            //return JsonSerializer.Serialize(userTimeline);
        }

    }
}
