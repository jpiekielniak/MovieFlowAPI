using System.IdentityModel.Tokens.Jwt;
using MovieFlow.Shared.Abstractions.Auth;

namespace MovieFlow.Modules.Users.Tests.Unit.Helpers;

public static class JwtHelper
{
    public static JsonWebToken CreateToken(string userId, string role = null)
    {
        var jwt = new JwtSecurityToken();

        var token = new JwtSecurityTokenHandler().WriteToken(jwt);

        return new JsonWebToken
        {
            AccessToken = token,
            RefreshToken = string.Empty,
            Expires = new DateTimeOffset().ToUnixTimeMilliseconds(),
            Id = userId,
            Role = role ?? string.Empty,
            Claims = new Dictionary<string, IEnumerable<string>>()
        };
    }
}