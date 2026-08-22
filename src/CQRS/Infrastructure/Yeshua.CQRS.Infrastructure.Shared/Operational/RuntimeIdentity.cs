namespace Shared.Operational;

public sealed record RuntimeIdentity(
    string Application,
    string Environment,
    string Version,
    string CommitSha,
    DateTimeOffset? BuiltAtUtc);

public interface IRuntimeIdentityProvider
{
    RuntimeIdentity Current { get; }
}
