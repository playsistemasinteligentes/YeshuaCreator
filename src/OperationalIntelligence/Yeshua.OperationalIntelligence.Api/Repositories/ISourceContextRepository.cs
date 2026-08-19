using Yeshua.OperationalIntelligence.Api.Contracts;

namespace Yeshua.OperationalIntelligence.Api.Repositories;

public interface ISourceContextRepository
{
    Task<IReadOnlyList<ApplicationSummary>> GetApplicationsAsync(CancellationToken cancellationToken);
    Task<IReadOnlyList<BuildSummary>> GetBuildsAsync(string application, CancellationToken cancellationToken);
    Task<SourceContextResponse> SearchFieldAsync(FieldSearchRequest request, CancellationToken cancellationToken);
    Task<SourceContextResponse> SearchClassAsync(ClassSearchRequest request, CancellationToken cancellationToken);
    Task<SourceContextResponse> SearchFunctionAsync(FunctionSearchRequest request, CancellationToken cancellationToken);
}
