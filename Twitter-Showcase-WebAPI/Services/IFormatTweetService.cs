using System.Collections.Generic;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IFormatTweetService
    {
        public List<TweetObject> GetTweets(UserTimeline timeline);
    }
}
