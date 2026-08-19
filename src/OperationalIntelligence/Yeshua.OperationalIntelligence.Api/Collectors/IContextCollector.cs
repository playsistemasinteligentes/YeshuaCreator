using Yeshua.OperationalIntelligence.Api.Contracts;

namespace Yeshua.OperationalIntelligence.Api.Collectors;

public interface IContextCollector
{
    string Name { get; }
    bool CanCollect(InvestigationRequest request);
    Task<CollectorResult> CollectAsync(
        InvestigationRequest request,
        CancellationToken cancellationToken);
}
