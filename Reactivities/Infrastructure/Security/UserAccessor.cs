using System.Linq;
using System.Security.Claims;
using Application.interfaces;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetCurrentUsername()// THIS GRABS THE USERNAME FROM THE USER TOKEN
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x =>
            x.Type == ClaimTypes.NameIdentifier)?.Value;

            return username;
        }
    }
}