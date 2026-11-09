using Dominio.Operational;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OpenTelemetry;
using OpenTelemetry.Metrics;
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
        services.AddSingleton<OperationalEvidencePublisher>(sp =>
            new OperationalEvidencePublisher(
                sp.GetRequiredService<IOperationalLogSink>(),
                sp.GetRequiredService<IRuntimeIdentityProvider>().Current));
        services.AddTransient<OperationalHttpTelemetryHandler>();

        var openTelemetry = services
            .AddOpenTelemetry()
            .ConfigureResource(resource =>
            {
                resource.AddService(identity.Application, serviceVersion: identity.Version);
                resource.AddAttributes([
                    new KeyValuePair<string, object>("deployment.environment.name", identity.Environment),
                    new KeyValuePair<string, object>("service.commit.sha", identity.CommitSha)
                ]);
            });

        openTelemetry.WithTracing(tracing =>
        {
            tracing.AddSource(OperationalActivity.SourceName);
            tracing.AddProcessor(new OperationalActivitySanitizingProcessor());
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

        if (exportSettings.Mode == OperationalTelemetryExportMode.Otlp)
        {
            var metricExportIntervalMilliseconds = Math.Clamp(
                configuration.GetValue<int?>("OpenTelemetry:Metrics:ExportIntervalMilliseconds") ?? 15_000,
                5_000,
                300_000);
            openTelemetry.WithMetrics(metrics =>
            {
                metrics.AddMeter(OperationalMetrics.MeterName);
                metrics.AddOtlpExporter(
                    (exporterOptions, metricReaderOptions) =>
                    {
                        exporterOptions.Endpoint = exportSettings.OtlpEndpoint!;
                        metricReaderOptions.PeriodicExportingMetricReaderOptions.ExportIntervalMilliseconds =
                            metricExportIntervalMilliseconds;
                    });
            });
        }

        return services;
    }
}
