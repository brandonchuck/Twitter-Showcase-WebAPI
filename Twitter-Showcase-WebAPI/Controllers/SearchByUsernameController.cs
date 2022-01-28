using System;
using System.Collections.Generic;
using System.Linq;
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
        private IConfiguration _configuration;

        public SearchByUsernameController(ITwitterAuthorizationService twitterAuthorizationService, IUserDetailsService userDetailsService, IUserTimelineService userTimelineService, IConfiguration configuration, IFormatTweetService formatTweetService)
        {
            _twitterAuthorizationService = twitterAuthorizationService;
            _userDetailsService = userDetailsService;
            _userTimelineService = userTimelineService;
            _configuration = configuration;
            _formatTweetService = formatTweetService;
        }

        [HttpGet]
        public async Task<List<TweetObject>> GetUserTimeline([FromQuery] string searchTerm)
        {
            string authToken = await _twitterAuthorizationService.GetBearerToken(_configuration["Twitter:ApiKey"], _configuration["Twitter:SecretKey"]);
            UserDetails userDetails = await _userDetailsService.GetUserId(searchTerm, authToken);
            var userTimeline = await _userTimelineService.GetUserTimeline(userDetails.data.id, authToken);

            var tweets = _formatTweetService.GetTweets(userTimeline);

            return tweets;
        }
    }

// This method for creating a new TweetObject was not working; still want to find out why
//    TweetObject tweet = new TweetObject
//    {
//        Text = x.text,
//        CreatedAt = x.created_at,
//        LikeCount = x.public_metrics.like_count,
//        RetweetCount = x.public_metrics.retweet_count,
//        CommentCount = x.public_metrics.reply_count,
//    };

//    UserData currentUser = userTimeline.includes.users.First(user => user.id == x.author_id);

//    tweet.ScreenName = currentUser.name;
//                tweet.Username = currentUser.username;
//                tweet.ProfileImageUrl = currentUser.profile_image_url;

//                if (x.attachments != null)
//                {
//                    foreach (string key in x.attachments.media_keys)
//                    {
//                        foreach (MediaData m in userTimeline.includes.media)
//                        {
//                            if (m.media_key == key)
//                            {
//                                if (m.type == "photo")
//                                {
//                                    tweet.ImageUrls.Add(m.url);
//                                }

//if (m.type == "video")
//{
//    tweet.VideoPreviewImageUrls.Add(m.preview_image_url);
//}
//                            }
//                        }
//                    }
//                }
//                else
//{
//    tweet.ImageUrls.Add(string.Empty);
//    tweet.VideoPreviewImageUrls.Add(string.Empty);
}

