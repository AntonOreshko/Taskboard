using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Extensions
{
    public static class ControllerExtensions
    {
        public static long GetUserId(this ControllerBase controller)
        {
            var claimsIdentity = controller.User.Identity as ClaimsIdentity;
            if (claimsIdentity == null) return -1;

            string userId = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Convert.ToInt64(userId);
        }
    }
}
