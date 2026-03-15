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

        public record UserLogin(string Login, string Password);
        public record Account(string idcompany, string email, string phone, string password, string confirmpassword);

        public static void MapEndpoints(this WebApplication app)
        {

            app.MapPost("/yapi/login", async (UserLogin user,
                JwtSettings jwtSettings,
                [FromServices] Command.Receivers.UseCase.ContasLoginUseCaseReceiver receiver) =>
            {

                Console.WriteLine("Tentando login");

                var command = new Command.UseCase.ContasLoginUseCaseInputCommand();
                command.email = user.Login;
                command.password = user.Password;
                var result = StateResults.Try(() => receiver.Execute(command));

                if (result.Result is Ok<State<Command.UseCase.ContasLoginUseCaseOutputCommand>> okResult)
                {
                    Command.UseCase.ContasLoginUseCaseOutputCommand _user = okResult.Value.Data;
                    var modulesClaim = string.Join(",", _user.modulos);
                    var tokenHandler = new JwtSecurityTokenHandler();
                    var key = Encoding.UTF8.GetBytes(jwtSettings.SecretKey);

                    var claims = new List<Claim>{
                        new Claim(ClaimTypes.NameIdentifier, _user.UserId.ToString()),
                        new Claim(ClaimTypes.Email, _user.email),
                        new Claim(ClaimTypes.Role, "Admin"),
                        new Claim("tenantId", _user.tenantId.ToString()),
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
            });


            app.MapPost("/CreateAccount", (Account company) =>
            {
            });


            app.MapPost("/ForgotPassword", (string email) =>
            {
                return Results.Unauthorized();
            });



            app.MapPost("/yapi/FileUpload/InfraSendFileUseCase2", async (
    HttpContext context,
    [FromServices] Command.Receivers.UseCase.InfraSendFileUseCaseReceiver receiver
) =>
            {
                try
                {
                    var request = context.Request;

                    if (!request.HasFormContentType)
                        return Results.BadRequest("Esperado multipart/form-data");

                    var form = await request.ReadFormAsync();

                    var file = form.Files["fileStream"];

                    var command = new Command.UseCase.InfraSendFileUseCaseInputCommand
                    {
                        token = form["token"],
                        ChunkIndex = int.Parse(form["chunkIndex"]),
                        IsFinalChunk = bool.Parse(form["isFinalChunk"]),
                        FileName = form["fileName"],
                        ContentType = form["contentType"],
                        FileStream = file
                    };

                    var result = receiver.Execute(command);

                    if (result.StatusCode == 200)
                        return Results.Ok(result.Data);

                    return Results.BadRequest(result);
                }
                catch (Exception ex)
                {
                    return Results.Problem(ex.Message);
                }
            });



            app.MapPost("/upload", async (HttpContext context) =>
            {
                try
                {
                    var request = context.Request;
                    if (!request.HasFormContentType)
                        return Results.BadRequest("Requisição inválida. Esperado form-data.");

                    var form = await request.ReadFormAsync();
                    var file = form.Files["audio"];

                    if (file == null || file.Length == 0)
                        return Results.BadRequest("Nenhum arquivo foi enviado.");

                    // Define o caminho onde os áudios serão salvos
                    var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    Directory.CreateDirectory(uploadsFolder); // Garante que a pasta existe

                    var filePath = Path.Combine(uploadsFolder, file.FileName);

                    // Salva o arquivo no servidor
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    Console.WriteLine($"Arquivo salvo em: {filePath}");
                    return Results.Ok(new { message = "Arquivo recebido com sucesso!", filePath });
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Erro ao receber arquivo: {ex.Message}");
                    return Results.Problem("Erro ao processar o arquivo.");
                }
            });
        }
    }
}
