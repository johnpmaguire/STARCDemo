using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace STARCDemo.Services;

public class DemoAuthService : AuthenticationStateProvider
{
    private static readonly Dictionary<string, (string Password, string Role, string DisplayName)> Users = new()
    {
        ["member"]    = ("demo", "Member",    "Alex Member"),
        ["leader"]    = ("demo", "Leader",    "Sarah Connor"),
        ["committee"] = ("demo", "Committee", "Priya Nair"),
        ["admin"]     = ("demo", "Admin",     "James Murphy"),
    };

    private ClaimsPrincipal _current = new(new ClaimsIdentity());

    public override Task<AuthenticationState> GetAuthenticationStateAsync()
        => Task.FromResult(new AuthenticationState(_current));

    public bool Login(string username, string password)
    {
        var key = username.Trim().ToLowerInvariant();
        if (!Users.TryGetValue(key, out var user) || user.Password != password)
            return false;

        var identity = new ClaimsIdentity(
        [
            new Claim(ClaimTypes.Name,        user.DisplayName),
            new Claim(ClaimTypes.NameIdentifier, key),
            new Claim(ClaimTypes.Role,        user.Role),
        ], "demo");

        _current = new ClaimsPrincipal(identity);
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        return true;
    }

    public void Logout()
    {
        _current = new ClaimsPrincipal(new ClaimsIdentity());
        NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
    }

    public static IReadOnlyList<(string Username, string Role)> DemoUsers =>
        Users.Select(kvp => (kvp.Key, kvp.Value.Role)).ToList();
}
