using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Extensions
{
    public static class ControllerExtensions
    {
        public static Guid GetUserId(this ControllerBase controller)
        {
            var claimsIdentity = controller.User.Identity as ClaimsIdentity;
            if (claimsIdentity == null) return Guid.Empty;

            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            Guid.TryParse(userId, out Guid guid);;

            return guid;
        }
    }
}
