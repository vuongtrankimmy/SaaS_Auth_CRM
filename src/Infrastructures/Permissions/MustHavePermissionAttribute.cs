using Infrastructures.Permissions.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace Infrastructures.Permissions;

public class MustHavePermissionAttribute : AuthorizeAttribute
{
    public MustHavePermissionAttribute(string role) =>
        Policy = ZAPRole.NameFor(role);
}