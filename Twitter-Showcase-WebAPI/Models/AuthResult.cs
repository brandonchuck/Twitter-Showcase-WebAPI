using System;
using System.Text.Json.Serialization;

namespace Twitter_Showcase_WebAPI.Models
{
    public class AuthResult
    {
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

    }
}
