using Migration.Dominio;
using System.Text;

namespace Dominio.Schemas.CQRS;

public sealed class SourceCodeInfrastructureRuntimeIdentityMigration : SourceCodeBase
{
    protected override StringBuilder GenerateCode()
    {
        return new StringBuilder(
            """
            using Shared.Operational;
            using System.Globalization;
            using System.Reflection;

            namespace Yeshua.Generated.Operational;

            public sealed class RuntimeIdentityProvider : IRuntimeIdentityProvider
            {
                public RuntimeIdentityProvider(string environment)
                {
                    Current = ReadIdentity(environment);
                }

                public RuntimeIdentity Current { get; }

                private static RuntimeIdentity ReadIdentity(string environment)
                {
                    var assembly = Assembly.GetEntryAssembly() ?? typeof(RuntimeIdentityProvider).Assembly;
                    var metadata = assembly
                        .GetCustomAttributes<AssemblyMetadataAttribute>()
                        .GroupBy(attribute => attribute.Key, StringComparer.Ordinal)
                        .ToDictionary(
                            group => group.Key,
                            group => group.Last().Value,
                            StringComparer.Ordinal);

                    metadata.TryGetValue("YeshuaApplication", out var application);
                    metadata.TryGetValue("YeshuaVersion", out var version);
                    metadata.TryGetValue("YeshuaCommitSha", out var commitSha);
                    metadata.TryGetValue("YeshuaBuildTimestampUtc", out var buildTimestamp);

                    DateTimeOffset? builtAtUtc = null;
                    if (DateTimeOffset.TryParse(
                            buildTimestamp,
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.AssumeUniversal | DateTimeStyles.AdjustToUniversal,
                            out var parsedBuildTimestamp))
                    {
                        builtAtUtc = parsedBuildTimestamp;
                    }

                    return new RuntimeIdentity(
                        ValueOrUnset(application),
                        ValueOrUnset(environment),
                        ValueOrUnset(version),
                        ValueOrUnset(commitSha),
                        builtAtUtc);
                }

                private static string ValueOrUnset(string? value)
                {
                    return string.IsNullOrWhiteSpace(value) ? "UNSET" : value;
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

public sealed class SourceCodeInfrastructureWorkerRuntimeIdentityReporterMigration : SourceCodeBase
{
    protected override StringBuilder GenerateCode()
    {
        return new StringBuilder(
            """
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
