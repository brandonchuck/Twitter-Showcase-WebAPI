using System.Threading.Tasks;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface ITwitterAuthorizationService
    {
        public Task<string> GetBearerToken(string apiKey, string secretKey);
    }
}
