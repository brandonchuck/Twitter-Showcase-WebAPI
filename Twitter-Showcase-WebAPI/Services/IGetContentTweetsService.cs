using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IGetContentTweetsService
    {
        public Task<UserTimeline> GetRecentTweets(string searchTerm, string bearerToken);
    }
}