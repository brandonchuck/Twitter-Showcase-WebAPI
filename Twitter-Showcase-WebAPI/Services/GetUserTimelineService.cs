using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public class GetUserTimelineService
    {
        public GetUserTimelineService()
        {
        }

        // grab user timeline using the user id and bearerToken
        public Task<UserTimeline> GetUserTimeline(int userId, string bearerToken)
        {
            // make get request: pass bearer token and userId

            // return a UserTimeline Object
        }
    }
}
