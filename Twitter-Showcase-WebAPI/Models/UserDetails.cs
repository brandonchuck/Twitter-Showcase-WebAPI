using System;
using System.Text.Json.Serialization;

namespace Twitter_Showcase_WebAPI.Models
{
    public class UserDetails
    {
        [JsonPropertyName("id")]
        public int UserId { get; set; }

        [JsonPropertyName("name")]
        public string ScreenName { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }
    }
}
