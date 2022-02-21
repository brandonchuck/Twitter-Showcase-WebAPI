using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;
using RestSharp;

namespace Twitter_Showcase_WebAPI.Services
{
    public class UserTimelineService : IUserTimelineService
    {
        public async Task<UserTimeline> GetUserTimelineByUserId(string userId, string bearerToken)
        {
            const string expansions = "tweet.fields=created_at,public_metrics,attachments&user.fields=profile_image_url&media.fields=preview_image_url,url&expansions=author_id,attachments.media_keys&max_results=25";

            var options = new RestClientOptions("https://api.twitter.com/2")
            {
                Timeout = 3000,
            };

            var client = new RestClient(options);

            var request = new RestRequest($"users/{userId}/tweets?{expansions}");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var timeline = await client.GetAsync<UserTimeline>(request);

            return timeline;
        }

    }

}
