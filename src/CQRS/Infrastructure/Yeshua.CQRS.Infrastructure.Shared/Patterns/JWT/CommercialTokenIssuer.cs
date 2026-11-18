using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dominio.Commercial;
using Microsoft.IdentityModel.Tokens;
using RepositoryInterfaces.Commercial;

namespace YourNamespace.Services;

public sealed class CommercialTokenIssuer(JwtSettings settings) : ICommercialTokenIssuer
{
    public string Issue(IReadOnlyList<Claim> identityClaims, IReadOnlyList<UsageRight> rights)
    {
        var claims = identityClaims.ToList();
        UsageRightClaims.AddTo(claims, rights);
        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddMinutes(Math.Min(settings.ExpirationMinutes, 30)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(settings.SecretKey)),
                SecurityAlgorithms.HmacSha256Signature)
        };
        var handler = new JwtSecurityTokenHandler();
        return handler.WriteToken(handler.CreateToken(descriptor));
    }
}
