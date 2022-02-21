using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IUserTimelineService
    {
        public Task<UserTimeline> GetUserTimelineByUserId(string userId, string bearerToken);
    }
}
