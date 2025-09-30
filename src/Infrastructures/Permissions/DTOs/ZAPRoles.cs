using System.Collections.ObjectModel;

namespace Infrastructures.Permissions.DTOs
{
    public static class ZAPRoles
    {
        public const string Admin = nameof(Admin);
        public const string Basic = nameof(Basic);

        public static IReadOnlyList<string> DefaultRoles { get; } = new ReadOnlyCollection<string>(new[]
        {
            Admin,
            Basic
        });

        public static bool IsDefault(string roleName) => DefaultRoles.Any(r => r == roleName);
    }

    public record ZAPRole(string Description, string Role, bool IsBasic = false, bool IsRoot = false)
    {
        public string Name => NameFor(Role);
        public static string NameFor(string role) => $"Role.{role}";
    }
}