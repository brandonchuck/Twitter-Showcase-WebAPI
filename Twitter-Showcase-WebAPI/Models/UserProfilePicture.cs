using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Twitter_Showcase_WebAPI.Models
{
    public class UserProfilePicture
    {
        public Tweet[] data { get; set; }
        public IncludesKey includes { get; set; }
    }

    public class Tweet
    {
        public string text { get; set; }
        public string author_id { get; set; }
    }

    public class IncludesKey
    {
        public UserFields[] users { get; set; }
    }

    public class UserFields
    {
        public string id { get; set; }
        public string profile_image_url { get; set; }
        public string username { get; set; }
        public string name { get; set; }
    }

}
