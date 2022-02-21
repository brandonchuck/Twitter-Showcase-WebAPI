using System.Collections.Generic;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IFormatTweetService
    {
        public List<TweetObject> GetFormattedTweets(UserTimeline timeline);
        public UserData GetCurrentUser(UserTimeline timeline, TweetData currentTweet);
        public void SetVideoAndImageUrls(UserTimeline timeline, TweetData data, List<string> images, List<string> videos);

    }
}
