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

        FormatTweetService formatTweetService = new FormatTweetService();

        public List<TweetObject> GetRandomTweets(UserTimeline timeline)
        {
            List<TweetObject> randomTweets = new List<TweetObject>();

            List<TweetObject> tweets = formatTweetService.GetFormattedTweets(timeline);

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

        public async Task<UserProfilePicture> GetRandomUserProfilePicture(string username, string bearerToken)
        {
            var options = new RestClientOptions("https://api.twitter.com/2")
            {
                Timeout = 3000,
            };

            var client = new RestClient(options);

            var request = new RestRequest($"tweets/search/recent?query=from:{username}&user.fields=profile_image_url&expansions=author_id");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var profilePicture = await client.GetAsync<UserProfilePicture>(request);

            return profilePicture;
        }

    }
}
