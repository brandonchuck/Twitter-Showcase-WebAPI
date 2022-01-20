using System.Threading.Tasks;
using RestSharp;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class UserDetailsService : IUserDetailsService
    {

        public async Task<UserDetails> GetUserId(string searchTerm, string bearerToken)
        {
            var client = new RestClient("https://api.twitter.com/2");

            var request = new RestRequest($"users/by/username/{searchTerm}");

            request.AddHeader("Authorization", $"Bearer {bearerToken}");

            var response = await client.GetAsync<UserDetails>(request);

            return response;
        }
    }
}
