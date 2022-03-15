using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class RandomTweetsService : IRandomTweetsService
    {

        private readonly IFormatTweetService _formatTweetService;
        public RandomTweetsService(IFormatTweetService formatTweetService)
        {
            _formatTweetService = formatTweetService;
        }

        public List<TweetObject> GetRandomTweets(UserTimeline timeline)
        {
            List<TweetObject> randomTweets = new List<TweetObject>();

            List<TweetObject> tweets = _formatTweetService.GetFormattedTweets(timeline);

            while (randomTweets.Count != 15)
            {
                Random rand = new Random();
                int randomInt = rand.Next(0, tweets.Count);

                if (!randomTweets.Contains(tweets[randomInt]))
                {
                    randomTweets.Add(tweets[randomInt]);
                }
            }

            return randomTweets;
        }

    }
}
