using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS;

public sealed class SourceCodeInfrastructureWorkerOperationalHealthMigration : SourceCodeBase
{
    protected override StringBuilder GenerateCode()
    {
        return new StringBuilder(
            """
            using Microsoft.AspNetCore.Builder;
            using Microsoft.AspNetCore.Hosting;
            using Microsoft.AspNetCore.Http;
            using Dominio.Interfaces;
            using Shared.Operational;

            namespace Yeshua.Generated.OperationalHealth;

            public sealed class WorkerOperationalHealthStartupFilter : IStartupFilter
            {
                public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
                {
                    return app =>
                    {
                        app.UseMiddleware<WorkerOperationalHealthMiddleware>();
                        next(app);
                    };
                }
            }

            public sealed class WorkerOperationalHealthMiddleware
            {
                private readonly RequestDelegate _next;

                public WorkerOperationalHealthMiddleware(RequestDelegate next)
                {
                    _next = next;
                }

                public async Task InvokeAsync(
                    HttpContext context,
                    IRuntimeIdentityProvider identityProvider,
                    Dominio.Interfaces.ILogger logger)
                {
                    if (context.Request.Path == "/yapi/health/live")
                    {
                        await WriteLivenessAsync(context, identityProvider.Current);
                        return;
                    }

                    if (context.Request.Path == "/yapi/health/ready")
                    {
                        await WriteReadinessAsync(context, identityProvider.Current);
                        return;
                    }

                    if (context.Request.Path == "/yapi/operational/telemetry")
                    {
                        await context.Response.WriteAsJsonAsync(new
                        {
                            Identity = identityProvider.Current,
                            Telemetry = logger.Snapshot(),
                            ObservedAtUtc = DateTimeOffset.UtcNow
                        });
                        return;
                    }

                    await _next(context);
                }

                private static Task WriteLivenessAsync(HttpContext context, RuntimeIdentity identity)
                {
                    return context.Response.WriteAsJsonAsync(new
                    {
                        Status = "Healthy",
                        Check = "Liveness",
                        Identity = identity,
                        ObservedAtUtc = DateTimeOffset.UtcNow
                    });
                }

                private static Task WriteReadinessAsync(
                    HttpContext context,
                    RuntimeIdentity identity)
                {
                    return context.Response.WriteAsJsonAsync(new
                    {
                        Status = "Ready",
                        Check = "Readiness",
                        Identity = identity,
                        ObservedAtUtc = DateTimeOffset.UtcNow
                    });
                }
            }
            """);
    }

    protected override StringBuilder GenerateCustonCode()
    {
        return new StringBuilder();
    }

    public void WriteGeneratedCode(string filePath)
    {
        WriteCode(GenerateCode(), filePath, false, false);
    }
}
