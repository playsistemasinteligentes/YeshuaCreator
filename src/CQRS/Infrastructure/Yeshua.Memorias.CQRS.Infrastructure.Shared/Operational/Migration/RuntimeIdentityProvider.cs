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
        var application = AppContext.GetData("Yeshua.Application") as string;
        var version = AppContext.GetData("Yeshua.Version") as string;
        var commitSha = AppContext.GetData("Yeshua.CommitSha") as string;
        var buildTimestamp = AppContext.GetData("Yeshua.BuildTimestampUtc") as string;

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