namespace API.Migrations;

public static class EndpointsCuston
{
    public record UserLogin(string Login, string Password);

    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/yapi/login", async (
            UserLogin user,
            JwtSettings jwtSettings,
            [Microsoft.AspNetCore.Mvc.FromServices] Command.Receivers.UseCase.LoginHandler receiver) =>
        {
            var result = await receiver.ExecuteAsync(new Command.UseCase.LoginInputCommand
            {
                email = user.Login,
                password = user.Password
            });

            if (result.StatusCode is < 200 or >= 300 || result.Data is null)
                return Results.Unauthorized();

            var authenticatedUser = result.Data;
            var claims = new List<System.Security.Claims.Claim>
            {
                new(System.Security.Claims.ClaimTypes.NameIdentifier, authenticatedUser.UserId.ToString()),
                new(System.Security.Claims.ClaimTypes.Email, authenticatedUser.email),
                new(System.Security.Claims.ClaimTypes.Role, "Admin"),
                new("tenantId", authenticatedUser.tenantId.ToString()),
                new("userModules", string.Join(",", authenticatedUser.modulos)),
                new("userCatalogs", string.Join(",", authenticatedUser.catalogos)),
                new("tokenOrigin", "Central"),
                new("application", "Central"),
                new("centralTenantId", authenticatedUser.tenantId.ToString()),
                new("centralUserId", authenticatedUser.UserId.ToString()),
                new("tenantIdentity", authenticatedUser.tenantIdentity),
                new("tenantDocument", authenticatedUser.tenantDocument),
                new("tenantName", authenticatedUser.tenantName),
                new("userIdentity", authenticatedUser.userIdentity),
                new("userName", authenticatedUser.userName)
            };
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes),
                SigningCredentials = new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(
                        System.Text.Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            return Results.Ok(new { token = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)) });
        });
    }
}
