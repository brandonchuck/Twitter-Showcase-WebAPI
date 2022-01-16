using System;
using System.Net.Http;
using System.Threading.Tasks;
using RestSharp;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class GetUserDetailsService
    {

        public GetUserDetailsService()
        {
        }


        // uses username from url and bearerToken from api to get the UserDetails object
        public async Task<string> GetUserId(string username, string bearerToken)
        {

            var client = new RestClient("https://api.twitter.com/2");

            var request = new RestRequest($"users/by/username/{username}");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var response = await client.GetAsync<UserDetails>(request);

            return response.data.id;
        }

    }
}
