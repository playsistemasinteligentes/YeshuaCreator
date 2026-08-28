using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RepositoryInterfaces.Patterns.Command;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Migrations;

public static class EndpointsCuston
{
    public record UserLogin(string Login, string Password);
    public record Account(string idcompany, string email, string phone, string password, string confirmpassword);

    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/yapi/login", async (
            UserLogin user,
            JwtSettings jwtSettings,
            [FromServices] Command.Receivers.UseCase.LoginHandler receiver) =>
        {
            var command = new Command.UseCase.LoginInputCommand
            {
                email = user.Login,
                password = user.Password
            };
            var result = await receiver.ExecuteAsync(command);

            if (result.StatusCode is < 200 or >= 300 || result.Data is null)
                return Results.Unauthorized();

            var authenticatedUser = result.Data;
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, authenticatedUser.UserId.ToString()),
                new(ClaimTypes.Email, authenticatedUser.email),
                new(ClaimTypes.Role, "Admin"),
                new("tenantId", authenticatedUser.tenantId.ToString()),
                new("userModules", string.Join(",", authenticatedUser.modulos))
            };
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(jwtSettings.ExpirationMinutes),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Results.Ok(new { token = tokenHandler.WriteToken(token) });
        });

        app.MapPost("/CreateAccount", (Account company) => Results.NoContent());
        app.MapPost("/ForgotPassword", (string email) => Results.Unauthorized());

        app.MapPost("/yapi/FileUpload/InfraSendFileUseCase2", async (
            HttpContext context,
            [FromServices] Command.Receivers.UseCase.SendFileHandler receiver) =>
        {
            if (!context.Request.HasFormContentType)
                return Results.BadRequest("Esperado multipart/form-data");

            var form = await context.Request.ReadFormAsync();
            var command = new Command.UseCase.SendFileInputCommand
            {
                token = form["token"],
                ChunkIndex = int.Parse(form["chunkIndex"]),
                IsFinalChunk = bool.Parse(form["isFinalChunk"]),
                FileName = form["fileName"],
                ContentType = form["contentType"],
                FileStream = form.Files["fileStream"]
            };
            var result = await receiver.ExecuteAsync(command);
            return result.StatusCode == 200 ? Results.Ok(result.Data) : Results.BadRequest(result);
        }).RequireAuthorization();
    }
}
