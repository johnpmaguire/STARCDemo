using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace STARCDemo.Services;

public class DemoAuthService : AuthenticationStateProvider
{
    private static readonly Dictionary<string, (string Password, string Role, string DisplayName)> Users = new()
    {
        ["member1"]    = ("demo", "Member",    "Alex Member"),
        ["member2"]    = ("demo", "Member",    "Tom Briggs"),
        ["member3"]    = ("demo", "Member",    "Chloe Walsh"),
        ["member4"]    = ("demo", "Member",    "Ravi Patel"),
        ["member5"]    = ("demo", "Member",    "Niamh Kelly"),
        ["member6"]    = ("demo", "Member",    "Dan Foster"),
        ["member7"]    = ("demo", "Member",    "Lucia Ferreira"),
        ["member8"]    = ("demo", "Member",    "Owen Hughes"),
        ["member9"]    = ("demo", "Member",    "Amara Osei"),
        ["member10"]   = ("demo", "Member",    "Jack Tanner"),
        ["leader1"]    = ("demo", "Leader",    "Sarah Connor"),
        ["leader2"]    = ("demo", "Leader",    "Beth Cartwright"),
        ["leader3"]    = ("demo", "Leader",    "Marcus Webb"),
        ["committee1"] = ("demo", "Committee", "Priya Nair"),
        ["committee2"] = ("demo", "Committee", "Diane Hollis"),
        ["admin"]      = ("demo", "Admin",     "James Murphy"),
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

    public static IReadOnlyList<(string Username, string Role, string DisplayName)> DemoUsers =>
        Users.Select(kvp => (kvp.Key, kvp.Value.Role, kvp.Value.DisplayName)).ToList();
}
