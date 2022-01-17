using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class GetUserTimelineService : IGetUserTimelineService
    {

        public async Task<UserTimeline> GetUserTimeline(string userId, string bearerToken)
        {
            var client = new RestClient("https://api.twitter.com/2");

            var request = new RestRequest($"users/{userId}/tweets?tweet.fields=created_at,public_metrics,attachments&user.fields=profile_image_url&media.fields=preview_image_url,url&expansions=author_id,attachments.media_keys");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            return await client.GetAsync<UserTimeline>(request);
        }
    }
}
