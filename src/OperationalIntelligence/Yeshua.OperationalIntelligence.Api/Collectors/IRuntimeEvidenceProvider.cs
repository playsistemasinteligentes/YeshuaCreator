using Yeshua.OperationalIntelligence.Api.Contracts;

namespace Yeshua.OperationalIntelligence.Api.Collectors;

public interface IRuntimeEvidenceProvider
{
    Task<RuntimeEvidenceResponse> QueryAsync(
        RuntimeEvidenceQuery query,
        CancellationToken cancellationToken);
}
