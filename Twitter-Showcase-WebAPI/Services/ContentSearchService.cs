using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;
using RestSharp;
using System.Text.Json;

namespace Twitter_Showcase_WebAPI.Services
{
    public class ContentSearchService : IContentSearchService
    {
        public async Task<string> GetTweetsByContent(string searchTerm, string bearerToken)
        {
            var client = new RestClient("https://api.twitter.com/2");

            var request = new RestRequest($"tweets/search/recent?user.fields=profile_image_url&media.fields=preview_image_url,url,media_key&tweet.fields=created_at,public_metrics,attachments&max_results=20&expansions=author_id,attachments.media_keys&query={searchTerm}");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var timeline = await client.GetAsync<UserTimeline>(request);

            return JsonSerializer.Serialize(timeline);

        }
    }
}
