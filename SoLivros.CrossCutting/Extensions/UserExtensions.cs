using System.Security.Claims;

namespace SoLivros.CrossCutting.Extensions
{
    using SoLivros.Domain.Models;
    public static class UserExtensions
    {
        public static User User(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) { return new User(); }
            return new User()
            {
                Id = user.GetId(),
                UserName = user.GetName(),
                Email = user.GetEmail()
            };
        }
        public static string GetId(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) { return string.Empty; }
            return user.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        public static string GetName(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) { return string.Empty; }
            return user.FindFirst(ClaimTypes.Name)?.Value ?? string.Empty;
        }

        public static string GetEmail(this ClaimsPrincipal user)
        {
            if (!user.Identity.IsAuthenticated) { return string.Empty; }
            return user.FindFirst(ClaimTypes.Email)?.Value ?? string.Empty;
        }
    }
}
