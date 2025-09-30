using System.Security.Claims;

namespace Infrastructures.Permissions;

public interface ICurrentUser
{
    string? Name { get; }

    //string GetUserId();

    //string? GetUserEmail();

    //string? GetTenant();

    bool IsAuthenticated();

    bool IsInRole(string role);

    IEnumerable<Claim>? GetUserClaims();
}