using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models
namespace Twitter_Showcase_WebAPI.Services
{
    public class GetUserDetailsService
    {
        private HttpClient _httpClient;

        public GetUserDetailsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        // uses username from url and bearerToken from api to get the UserDetails object
        public async int GetUserId(string username, string bearerToken)
        {
            // pass authorization headers
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", bearerToken);

            // make get request
            var response = await _httpClient.GetAsync($"users/by/username/{username}");

            response.EnsureSuccessStatusCode();

            // get the Content object from the response
            using var responseStream = await response.Content.ReadAsStreamAsync();

            // return UserDetails object with the UserId property 
            var userDetails = await JsonSerializer.Deserialize<UserDetails>(responseStream);

            // return the UserId from the UserDetails object
            return userDetails.UserId;
        }

    }
}
