using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace TicketSystem.Common.Auth
{
    public class CurrentUser
    {
        public CurrentUser(int userId, string account, int roleId) :
            this(string.Empty, userId, account, roleId)
        {
        }

        [JsonConstructor]
        public CurrentUser(string jti, int userId, string account, int roleId)
        {
            Jti = jti ?? string.Empty;
            UserId = userId;
            Account = account;
            RoleId = roleId;
        }

        public CurrentUser(IHttpContextAccessor httpContextAccessor)
        {
            var claimsPrincipal = httpContextAccessor.HttpContext.User;
            Jti = claimsPrincipal.FindFirstValue("Jti");
            UserId = Convert.ToInt32(claimsPrincipal.FindFirstValue("UserId"));
            Account = claimsPrincipal.FindFirstValue("Account");
            RoleId = Convert.ToInt32(claimsPrincipal.FindFirstValue("RoleId"));
        }

        public string Jti { get; private set; } = string.Empty;

        public int UserId { get; private set; } = -1;

        public string Account { get; private set; }

        public int RoleId { get; private set; }
    }
}