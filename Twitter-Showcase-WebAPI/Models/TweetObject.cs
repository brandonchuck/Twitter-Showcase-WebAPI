using System.Collections.Generic;

namespace Twitter_Showcase_WebAPI.Models
{
    public class TweetObject
    {
        public string ProfileImageUrl { get; set; }
        public string ScreenName { get; set; }
        public string Username { get; set; }
        public string CreatedAt { get; set; } // can this be type DateTime?

        public string Text { get; set; }

        public List<string> VideoPreviewImageUrls { get; set; }
        public List<string> ImageUrls { get; set; }

        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int RetweetCount { get; set; }
    }
}
