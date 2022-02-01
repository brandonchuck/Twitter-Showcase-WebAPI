using System;
using System.Collections.Generic;

namespace Twitter_Showcase_WebAPI.Models
{
    public class UserTimeline
    {
        public TweetData[] data { get; set; }
        public Includes includes { get; set; }
        public Metadata meta { get; set; }
    }

    // data
    public class TweetData
    {
        public string id { get; set; }
        public string text { get; set; }
        public DateTime created_at { get; set; }
        public string author_id { get; set; }
        public Attachments? attachments { get; set; }
        public TweetPublicMetrics public_metrics { get; set; }
    }

    public class TweetPublicMetrics
    {
        public int retweet_count { get; set; }
        public int reply_count { get; set; }
        public int like_count { get; set; }
        public int quote_count { get; set; }
    }


    public class Attachments
    {
        public string[] media_keys { get; set; }
    }


    // includes
    public class Includes
    {
        public UserData[] users { get; set; }
        public MediaData[] media { get; set; }
    }

    public class MediaData
    {
        public string? preview_image_url { get; set; }
        public string? url { get; set; }
        public string media_key { get; set; }
        public string type { get; set; }
    }

    public class UserData
    {
        public string username { get; set; }
        public string profile_image_url { get; set; }
        public string id { get; set; }
        public string name { get; set; }
    }

    // metadata
    public class Metadata
    {
        public string oldest_id { get; set; }
        public string newest_id { get; set; }
        public int result_count { get; set; }
        public string? next_token { get; set; }
        public string? previous_token { get; set; }
    }
}