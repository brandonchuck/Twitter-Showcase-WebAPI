using System.Threading.Tasks;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IGetUserDetailsService
    {
        public Task<string> GetUserId(string searchTerm, string bearerToken);
    }
}
