using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class UserDetailsService : IUserDetailsService
    {

        public async Task<UserDetails> GetUserId(string searchTerm, string bearerToken)
        {
            var options = new RestClientOptions("https://api.twitter.com/2")
            {
                ThrowOnAnyError = true,
                Timeout = 1000,
            };

            var client = new RestClient(options);

            var request = new RestRequest($"users/by/username/{searchTerm}");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var response = await client.GetAsync<UserDetails>(request);

            if (response.data == null)
            {
                throw new Exception("User not found.");
            }

            return response;
            
        }
    }
}
