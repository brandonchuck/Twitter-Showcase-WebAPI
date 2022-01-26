using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;
using RestSharp;
using System.Collections.Generic;

namespace Twitter_Showcase_WebAPI.Services
{
    public class UserTimelineService : IUserTimelineService
    {
        public async Task<UserTimeline> GetUserTimeline(string userId, string bearerToken)
        {
            var client = new RestClient("https://api.twitter.com/2");

            var request = new RestRequest($"users/{userId}/tweets?tweet.fields=created_at,public_metrics,attachments&user.fields=profile_image_url&media.fields=preview_image_url,url&expansions=author_id,attachments.media_keys&max_results=5");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var timeline = await client.GetAsync<UserTimeline>(request);

            return timeline;
        }
    }
}
