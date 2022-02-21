using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Twitter_Showcase_WebAPI.Models;

namespace Twitter_Showcase_WebAPI.Services
{
    public interface IUserDetailsService
    {
        public Task<UserDetails> GetUserDetails(string searchTerm, string bearerToken);

    }
}
