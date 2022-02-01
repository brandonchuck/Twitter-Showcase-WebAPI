using System;
using System.Collections.Generic;

namespace Twitter_Showcase_WebAPI.Models
{
    public class TweetObject
    {
        public TweetObject(string text, DateTime createdAt, int likeCount, int commentCount, int retweetCount, string profileImageUrl, string screenName, string username, List<string> imageUrls, List<string> videoPreviewImageUrls)
        {
            Text = text;
            CreatedAt = createdAt;
            LikeCount = likeCount;
            CommentCount = commentCount;
            RetweetCount = retweetCount;
            ProfileImageUrl = profileImageUrl;
            ScreenName = screenName;
            Username = username;
            VideoPreviewImageUrls = videoPreviewImageUrls;
            ImageUrls = imageUrls;
        }

        public string Text { get; set; }
        public DateTime CreatedAt { get; set; } // can this be type DateTime?
        public int LikeCount { get; set; }
        public int CommentCount { get; set; }
        public int RetweetCount { get; set; }

        public string ProfileImageUrl { get; set; }
        public string ScreenName { get; set; }
        public string Username { get; set; }

        public List<string> VideoPreviewImageUrls { get; set; }
        public List<string> ImageUrls { get; set; }


    }
}
