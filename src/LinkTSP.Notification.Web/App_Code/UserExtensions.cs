
using System.Security.Claims;

namespace LinkTSP.Notification.Web.App_Code
{
    public static class UserExtensions
    {
        public static string GetUserId(this ClaimsPrincipal claims)
        {
            return claims.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
        }
    }
}
