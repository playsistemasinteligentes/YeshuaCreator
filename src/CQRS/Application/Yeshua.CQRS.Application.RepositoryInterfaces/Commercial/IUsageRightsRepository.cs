using Dominio.Commercial;

namespace RepositoryInterfaces.Commercial;

public interface IUsageRightsRepository
{
    void Synchronize(IReadOnlyList<UsageRight> rights);
    bool Reserve(string resource, string operationId, decimal units);
    void Confirm(string resource, string operationId);
    void Release(string resource, string operationId);
}
