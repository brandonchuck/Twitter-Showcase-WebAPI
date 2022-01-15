using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class TwitterAuthorizationService
    {
        private readonly HttpClient _httpClient;


        public TwitterAuthorizationService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> GetBearerToken(string apiKey, string apiSecret)
        {
            // Defining a POST request to the /token resource on https://api.twitter.com/oauth2/
            var request = new HttpRequestMessage(HttpMethod.Post, "token");

            // Define type of authorization and provide apiKey and apiSecret
            request.Headers.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes($"{apiKey}:{apiSecret}")));

            // Define credentials
            request.Content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
                { "grant_type", "client_credentials" }
            });

            // Execute POST request
            var response = await _httpClient.SendAsync(request);

            // Make sure request is successful
            response.EnsureSuccessStatusCode();

            // Get JSON response - response is part of IDisposable
            using var responseStream = await response.Content.ReadAsStreamAsync();

            // Directly deserialize JSON response into AuthResult C# object!
            var authorizationResult = await JsonSerializer.DeserializeAsync<AuthResult>(responseStream);

            // return the access_token provided by twitter api
            return authorizationResult.access_token;
        }

    }
}
