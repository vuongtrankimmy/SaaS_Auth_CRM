using System.Security.Claims;

namespace Infrastructures.Permissions.DTOs
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetEmail(this ClaimsPrincipal principal)
            => principal.FindFirst(ClaimTypes.Email)?.Value;

        public static string? GetTenant(this ClaimsPrincipal principal)
            => principal.FindFirst(ZAPClaims.Tenant)?.Value;

        public static string? GetFullName(this ClaimsPrincipal principal)
            => principal?.FindFirst(ZAPClaims.Fullname)?.Value;

        public static string? GetFirstName(this ClaimsPrincipal principal)
            => principal?.FindFirst(ClaimTypes.Name)?.Value;

        public static string? GetSurname(this ClaimsPrincipal principal)
            => principal?.FindFirst(ClaimTypes.Surname)?.Value;

        public static string? GetPhoneNumber(this ClaimsPrincipal principal)
            => principal.FindFirst(ClaimTypes.MobilePhone)?.Value;

        public static string? GetUserId(this ClaimsPrincipal principal)
           => principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        public static string? GetImageUrl(this ClaimsPrincipal principal)
           => principal.FindFirst(ZAPClaims.ImageUrl).Value;

        public static DateTimeOffset GetExpiration(this ClaimsPrincipal principal) =>
            DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(
                principal.FindFirst(ZAPClaims.Expiration)));
    }
}