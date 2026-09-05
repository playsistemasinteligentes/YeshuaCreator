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
    public sealed record YeshuaModuleEventIngress(
        string MessageId,
        string Type,
        string EntityType,
        string EntityId,
        string CorrelationId,
        string Payload,
        string Source,
        string Transport);

    public static void MapEndpoints(this WebApplication app)
    {
        app.MapPost("/yapi/APSADM/Inbox/YeshuaModuleEvent", async (
            [FromServices] Command.Receivers.Write.InsertyInboxReceiver receiver,
            [FromServices] RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork unitOfWork,
            [FromServices] Aplication.Interfaces.Services.IExecutionContext executionContext,
            [FromBody] YeshuaModuleEventIngress envelope) =>
        {
            PrepareSystemContext(unitOfWork, executionContext);

            var command = new Command.Write.yInboxCrudCommand
            {
                MessageId = string.IsNullOrWhiteSpace(envelope.MessageId) ? Guid.NewGuid().ToString() : envelope.MessageId,
                Type = envelope.Type,
                EntityType = envelope.EntityType,
                EntityId = envelope.EntityId,
                CorrelationId = envelope.CorrelationId,
                Payload = envelope.Payload,
                Status = 0,
                CreatedAt = DateTime.UtcNow,
                RetryCount = 0,
                LastError = null,
                ProcessingAt = null,
                NextAttemptAt = null,
                SagaId = null,
                SagaStepId = null
            };

            var result = await receiver.ExecuteAsync(command);
            return result.StatusCode is >= 200 and < 300
                ? Results.Accepted($"/yapi/APSADM/Inbox/YeshuaModuleEvent/{command.MessageId}", new { command.MessageId, command.Type, Accepted = true })
                : Results.BadRequest(result);
        });

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

        app.MapPost("/upload", async (HttpContext context) =>
        {
            if (!context.Request.HasFormContentType)
                return Results.BadRequest("Requisicao invalida. Esperado form-data.");

            var form = await context.Request.ReadFormAsync();
            var file = form.Files["audio"];
            if (file is null || file.Length == 0)
                return Results.BadRequest("Nenhum arquivo foi enviado.");

            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            Directory.CreateDirectory(uploadsFolder);
            var safeFileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(uploadsFolder, safeFileName);

            await using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);
            return Results.Ok(new { message = "Arquivo recebido com sucesso!", filePath });
        });
    }

    private static void PrepareSystemContext(
        RepositoryInterfaces.Patterns.UnitOfWork.IUnitOfWork unitOfWork,
        Aplication.Interfaces.Services.IExecutionContext executionContext)
    {
        const int tenantId = 1;
        const int userId = 1;

        executionContext.SetTenantId(tenantId);
        executionContext.SetUserId(userId);

        const string sql = @"
            IF NOT EXISTS (SELECT 1 FROM [yTenant] WHERE [Id] = @TenantId)
            BEGIN
                SET IDENTITY_INSERT [yTenant] ON;
                INSERT INTO [yTenant] ([Id], [CnpjCpf], [Nome], [UserId], [Deleted], [Changed])
                VALUES (@TenantId, @TenantDocument, @TenantName, NULL, 0, SYSDATETIME());
                SET IDENTITY_INSERT [yTenant] OFF;
            END;

            IF NOT EXISTS (SELECT 1 FROM [yUser] WHERE [Id] = @UserId)
            BEGIN
                SET IDENTITY_INSERT [yUser] ON;
                INSERT INTO [yUser] ([Id], [Nome], [Email], [Senha], [TenantID], [Deleted], [Changed])
                VALUES (@UserId, @UserName, @UserEmail, @UserPassword, @TenantId, 0, SYSDATETIME());
                SET IDENTITY_INSERT [yUser] OFF;
            END;";

        unitOfWork.Execute(sql, new
        {
            TenantId = tenantId,
            UserId = userId,
            TenantDocument = "00000000000000",
            TenantName = "Tenant tecnico Yeshua",
            UserName = "Integracao Yeshua",
            UserEmail = "integracao@yeshua.local",
            UserPassword = "system"
        });
    }
}
