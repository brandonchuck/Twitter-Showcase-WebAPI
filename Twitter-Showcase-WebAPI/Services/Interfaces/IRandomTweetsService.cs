using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IRandomTweetsService
    {
        public List<TweetObject> GetRandomTweets(UserTimeline timeline);
    }
}
