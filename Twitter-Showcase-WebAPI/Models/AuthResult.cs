using System;
using System.Text.Json.Serialization;

namespace Twitter_Showcase_WebAPI.Models
{
    public class AuthResult
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
    }
}
