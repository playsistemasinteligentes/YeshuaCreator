using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using YourNamespace.Services;

namespace Yeshua.CQRS.Infrastructure.Shared.Tests;

[TestClass]
public sealed class JwtLifetimeTests
{
    [DataTestMethod]
    [DataRow(21600)]
    [DataRow(30)]
    public void SignedTokenUsesConfiguredMinutesAndExpiresAtTheBoundary(int minutes)
    {
        var settings = new JwtSettings { SecretKey = new string('x', 64) };
        Assert.AreEqual(15 * 24 * 60, settings.ExpirationMinutes);
        settings.ExpirationMinutes = minutes;
        var before = DateTime.UtcNow;
        var encoded = new JwtService(settings).GenerateToken("lifetime-test");
        var after = DateTime.UtcNow;
        var handler = new JwtSecurityTokenHandler();
        var token = handler.ReadJwtToken(encoded);

        // JWT NumericDate truncates fractional seconds.
        Assert.IsTrue(token.ValidTo >= before.AddMinutes(minutes).AddSeconds(-1));
        Assert.IsTrue(token.ValidTo <= after.AddMinutes(minutes));
        var validation = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey)),
            ValidateIssuerSigningKey = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            RequireExpirationTime = true,
            ClockSkew = TimeSpan.Zero,
            LifetimeValidator = (_, expires, _, _) => expires > token.ValidTo.AddSeconds(-1)
        };
        var principal = handler.ValidateToken(encoded, validation, out _);
        Assert.AreEqual("lifetime-test", principal.FindFirst(ClaimTypes.Name)?.Value);

        validation.LifetimeValidator = (_, expires, _, _) => expires > token.ValidTo;
        Assert.ThrowsException<SecurityTokenInvalidLifetimeException>(
            () => handler.ValidateToken(encoded, validation, out _));
    }
}
