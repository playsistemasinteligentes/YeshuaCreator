// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfrastructureWorkerRuntimeIdentityReporterMigration
// </yeshua>

using Shared.Operational;

namespace Migrations.Operational;

public sealed class RuntimeIdentityReporter : BackgroundService
{
    private readonly IRuntimeIdentityProvider _identityProvider;
    private readonly ILogger<RuntimeIdentityReporter> _logger;

    public RuntimeIdentityReporter(
        IRuntimeIdentityProvider identityProvider,
        ILogger<RuntimeIdentityReporter> logger)
    {
        _identityProvider = identityProvider;
        _logger = logger;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var identity = _identityProvider.Current;
        _logger.LogInformation(
            "Runtime identity: Application={Application}, Environment={Environment}, Version={Version}, CommitSha={CommitSha}, BuiltAtUtc={BuiltAtUtc}",
            identity.Application,
            identity.Environment,
            identity.Version,
            identity.CommitSha,
            identity.BuiltAtUtc);

        return Task.CompletedTask;
    }
}//Dominio.Schemas.CQRS.SourceCodeInfrastructureWorkerRuntimeIdentityReporterMigration