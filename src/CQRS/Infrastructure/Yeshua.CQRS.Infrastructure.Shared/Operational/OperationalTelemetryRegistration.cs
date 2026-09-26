using Dominio.Operational;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace Shared.Operational;

public static class OperationalTelemetryRegistration
{
    public static IServiceCollection AddYeshuaOperationalTelemetry(
        this IServiceCollection services,
        IConfiguration configuration,
        RuntimeIdentity identity)
    {
        services
            .AddOpenTelemetry()
            .ConfigureResource(resource =>
            {
                resource.AddService(identity.Application, serviceVersion: identity.Version);
                resource.AddAttributes([
                    new KeyValuePair<string, object>("deployment.environment.name", identity.Environment),
                    new KeyValuePair<string, object>("service.commit.sha", identity.CommitSha)
                ]);
            })
            .WithTracing(tracing =>
            {
                tracing.AddSource(OperationalActivity.SourceName);
                tracing.AddProcessor(provider =>
                    new BatchActivityExportProcessor(
                        new YeshuaJsonlActivityExporter(
                            provider.GetRequiredService<IRuntimeIdentityProvider>())));

                var endpoint = configuration["OpenTelemetry:Otlp:Endpoint"];
                if (Uri.TryCreate(endpoint, UriKind.Absolute, out var uri))
                    tracing.AddOtlpExporter(options => options.Endpoint = uri);
            });

        return services;
    }
}
