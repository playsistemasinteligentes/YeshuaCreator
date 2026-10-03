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
        var exportSettings = OperationalTelemetryExportSettings.FromConfiguration(configuration);
        services.AddSingleton(exportSettings);
        services.AddSingleton<IOperationalLogSink>(sp =>
            OperationalLogSinkFactory.Create(
                exportSettings,
                sp.GetRequiredService<IRuntimeIdentityProvider>()));

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
                if (exportSettings.Mode == OperationalTelemetryExportMode.Otlp)
                {
                    var endpoint = exportSettings.OtlpEndpoint
                        ?? throw new InvalidOperationException(
                            "OpenTelemetry:Otlp:Endpoint deve estar configurado para o modo Otlp.");
                    tracing.AddOtlpExporter(options => options.Endpoint = endpoint);
                }
                else
                {
                    tracing.AddProcessor(provider =>
                        new BatchActivityExportProcessor(
                            new YeshuaJsonlActivityExporter(
                                provider.GetRequiredService<IRuntimeIdentityProvider>())));
                }
            });

        return services;
    }
}
