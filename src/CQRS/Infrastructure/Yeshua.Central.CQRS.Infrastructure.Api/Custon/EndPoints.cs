namespace API.Migrations;

public static class EndpointsCuston
{
    public record UserLogin(string Login, string Password);

    public static void MapEndpoints(this WebApplication app)
    {
        var version = System.Reflection.CustomAttributeExtensions
            .GetCustomAttribute<System.Reflection.AssemblyInformationalVersionAttribute>(typeof(EndpointsCuston).Assembly)
            ?.InformationalVersion ?? throw new InvalidOperationException("Versao compilada ausente.");
        app.MapGet("/yapi/version", (HttpContext context) =>
        {
            context.Response.Headers.CacheControl = "no-store";
            return Results.Ok(new { version });
        }).AllowAnonymous();

        app.MapPost("/yapi/FileUpload/InfraSendFileUseCase2", async (
            HttpContext context,
            [Microsoft.AspNetCore.Mvc.FromServices] Command.Receivers.UseCase.SendFileHandler receiver) =>
        {
            if (!context.Request.HasFormContentType) return Results.BadRequest("Esperado multipart/form-data.");
            var form = await context.Request.ReadFormAsync(context.RequestAborted);
            if (!int.TryParse(form["chunkIndex"], out var index) || !bool.TryParse(form["isFinalChunk"], out var final))
                return Results.BadRequest("Parte de audio invalida.");
            var result = await receiver.ExecuteAsync(new Command.UseCase.SendFileInputCommand
            {
                token = form["token"], ChunkIndex = index, IsFinalChunk = final,
                FileName = form["fileName"], ContentType = form["contentType"], FileStream = form.Files["fileStream"]
            }, context.RequestAborted);
            return result.StatusCode == 200 ? Results.Ok(result.Data) : Results.BadRequest(result);
        }).RequireAuthorization();

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
                new("tenantDocument", authenticatedUser.tenantDocument),
                new("tenantName", authenticatedUser.tenantName),
                new("userName", authenticatedUser.userName)
            };
            var rights = Dominio.Commercial.UsageRightClaims.Read(authenticatedUser.UsageRights);
            Dominio.Commercial.UsageRightClaims.AddTo(claims, rights);
            var tokenDescriptor = new Microsoft.IdentityModel.Tokens.SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(rights.Count > 0 ? Math.Min(jwtSettings.ExpirationMinutes, 30) : jwtSettings.ExpirationMinutes),
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
