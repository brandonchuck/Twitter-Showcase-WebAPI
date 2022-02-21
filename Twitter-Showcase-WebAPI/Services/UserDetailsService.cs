using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class UserDetailsService : IUserDetailsService
    {
        public const string BASE_URL = "https://api.twitter.com/2";
        public async Task<UserDetails> GetUserDetails(string searchTerm, string bearerToken)
        {
            const string expansions = "user.fields=profile_image_url";

            var options = new RestClientOptions(BASE_URL)
            {
                Timeout = 3000,
            };

            var client = new RestClient(options);

            var request = new RestRequest($"users/by/username/{searchTerm}?{expansions}");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var response = await client.GetAsync<UserDetails>(request);

            return response;
        }

    }
}
