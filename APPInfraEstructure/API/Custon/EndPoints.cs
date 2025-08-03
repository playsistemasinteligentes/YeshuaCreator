using Command.Patterns.Command;
using RepositoryInterfaces.Patterns.Command;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Command.Commands;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Authentication.Cookies;
namespace API.Migrations
{
    public static class EndpointsCuston
    {
        public static void MapEndpoints(this WebApplication app)
        {

            app.MapPost("/login", async (UserLogin user,
                JwtSettings jwtSettings,
                [FromServices] Command.Receivers.UseCase.ContasLoginUseCaseReceiver receiver) =>
            {

                var command = new Command.UseCase.ContasLoginUseCaseCommand();
                command.email = user.Login;
                command.password = user.Password;
                var result = StateResults.Try(() => receiver.Execute(command));

                if (result.Result is Ok<State<object>> okResult)
                {

                    var userModuleKeys = new List<string> { "ADM", "mod3", "mod7" };

                    // Junta os módulos em uma string única
                    var modulesClaim = string.Join(",", userModuleKeys);



                    var statObj = okResult.Value;

                    if (statObj.Data is Repositorio.Outputs.YuserDTO _user)
                    {

                        var tokenHandler = new JwtSecurityTokenHandler();
                        var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

                        var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, _user.id.ToString()),
                        new Claim(ClaimTypes.Email, _user.email),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim("tenantId", _user.tenantid.ToString()),
                        new Claim("userModules", modulesClaim)
                    };

                        var tokenDescriptor = new SecurityTokenDescriptor
                        {
                            Subject = new ClaimsIdentity(claims),
                            Expires = DateTime.UtcNow.AddSeconds(jwtSettings.ExpirationMinutes),
                            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                        };
                        var token = tokenHandler.CreateToken(tokenDescriptor);
                        return Results.Ok(new { token = tokenHandler.WriteToken(token) });
                    }
                    return Results.Unauthorized();
                }

                return Results.Unauthorized();
            });

        }
    }
}
