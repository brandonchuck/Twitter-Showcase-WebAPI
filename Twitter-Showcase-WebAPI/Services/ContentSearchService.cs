using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;
using RestSharp;
using System.Text.Json;

namespace Twitter_Showcase_WebAPI.Services
{
    public class ContentSearchService : IContentSearchService
    {
        public async Task<UserTimeline> GetTweetsByContent(string searchTerm, string bearerToken)
        {
            var options = new RestClientOptions("https://api.twitter.com/2")
            {
                Timeout = 3000,
            };

            var client = new RestClient(options);

            var request = new RestRequest($"tweets/search/recent?user.fields=profile_image_url&media.fields=preview_image_url,url,media_key&tweet.fields=created_at,public_metrics,attachments&expansions=author_id,attachments.media_keys&query={searchTerm}&max_results=25");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var recentTweets = await client.GetAsync<UserTimeline>(request);
            
            return recentTweets;

        }
    }
}
