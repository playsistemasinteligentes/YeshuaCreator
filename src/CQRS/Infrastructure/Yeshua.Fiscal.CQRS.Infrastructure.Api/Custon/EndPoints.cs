using Microsoft.AspNetCore.Mvc;

namespace API.Migrations;

public static class EndpointsCuston
{
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
        app.MapPost("/yapi/Fiscal/Inbox/YeshuaModuleEvent", async (
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
                ? Results.Accepted($"/yapi/Fiscal/Inbox/YeshuaModuleEvent/{command.MessageId}", new { command.MessageId, command.Type, Accepted = true })
                : Results.BadRequest(result);
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
