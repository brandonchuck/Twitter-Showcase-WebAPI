using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class GetUserTimelineService
    {

        private HttpClient _httpClient;

        public GetUserTimelineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        // grab user timeline using the user id and bearerToken
        public async Task<IEnumerable<TweetObject>> GetUserTimeline(string userId, string bearerToken)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);

            var response = await _httpClient.GetAsync($"users/{userId}/tweets?tweet.fields=created_at,public_metrics,attachments&user.fields=profile_image_url&media.fields=preview_image_url,url,media_key&expansions=author_id,attachments.media_keys");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            // deserialize Content from GET request
            var userTimeline = await JsonSerializer.Deserialize<UserTimeline>(responseStream);

            // how can I grab field from different parts of the JSON response?
            // once I can grb the correct field, then a TweetObject can be built from the fields and put in the list
        }
    }
}
