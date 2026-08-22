// <yeshua>
// artifact: GENERATED_REGENERABLE
// createdBy: DSL
// ownership: ENGINE
// editable: false
// regeneration: REPLACE
// sourceOfTruth: DSL_OR_ENGINE_TEMPLATE
// generator: Dominio.Schemas.CQRS.SourceCodeInfrastructureRuntimeIdentityMigration
// </yeshua>

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
}//Dominio.Schemas.CQRS.SourceCodeInfrastructureRuntimeIdentityMigration