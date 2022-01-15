using System;
using System.Text.Json.Serialization;

namespace Twitter_Showcase_WebAPI.Models
{
    public class UserDetails
    {
        public Data data { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string name { get; set; }
        public string username { get; set; }
    }
}
