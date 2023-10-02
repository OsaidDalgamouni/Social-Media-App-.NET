using System.Security.Claims;

namespace Service.Extentions
{
    public static class CliamExtension
    {
        public static string GetUserName(this ClaimsPrincipal User)
        {
           return User.FindFirst(ClaimTypes.Name).Value;
        }
        public static string GetUserId(this ClaimsPrincipal User)
        {
            return User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
