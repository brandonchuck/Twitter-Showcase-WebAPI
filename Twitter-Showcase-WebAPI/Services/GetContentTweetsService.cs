using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;
using RestSharp;

namespace Twitter_Showcase_WebAPI.Services
{
    public class GetContentTweetsService : IGetContentTweetsService
    {

        public async Task<UserTimeline> GetRecentTweets(string searchTerm, string bearerToken)
        {
            var client = new RestClient("https://api.twitter.com/2");

            var request = new RestRequest($"tweets/search/recent/?user.fields=profile_image_url&media.fields=preview_image_url,url,media_key&tweet.fields=created_at,public_metrics,attachments&expansions=author_id,attachments.media_keys&query={searchTerm}");

            request.AddHeader("Authorization", $"Bearer AAAAAAAAAAAAAAAAAAAAANnhXwEAAAAAx5j0rzYCLTiRbRxSLp9l5kc3geM%3DwgVUDIsVd2Kph071Kp8duJ6ytXso3KG2ZHtC6WNDhHor9TRrJz");
            //request.AddHeader("Content-Type", "application/json");
            //request.AddHeader("Accept", "application/json");

            var recentTweets = await client.GetAsync<UserTimeline>(request);

            return recentTweets;
        }
    }
}
