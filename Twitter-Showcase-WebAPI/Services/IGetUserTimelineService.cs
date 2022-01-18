using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IGetUserTimelineService
    {
        public Task<UserTimeline> GetUserTimeline(string userId, string bearerToken);
    }
}
