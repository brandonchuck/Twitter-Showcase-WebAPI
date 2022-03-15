using System;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class TwitterAuthorizationService : ITwitterAuthorizationService
    {

        public async Task<string> GetBearerToken(string apiKey, string secretKey)
        {

            var options = new RestClientOptions("https://api.twitter.com/oauth2")
            {
                Timeout = 3000,
            };

            var client = new RestClient(options)
            {
                Authenticator = new HttpBasicAuthenticator(apiKey, secretKey, Encoding.UTF8)
            };

            var request = new RestRequest("token", Method.Post);

            request.AddParameter("grant_type", "client_credentials");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Accept", "application/json");

            var response = await client.PostAsync<AuthResult>(request);

            Console.WriteLine(response);
            return response.access_token;
        }
    }
}