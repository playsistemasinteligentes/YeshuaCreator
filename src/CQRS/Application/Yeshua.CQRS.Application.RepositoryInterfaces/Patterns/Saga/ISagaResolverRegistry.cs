using Dominio.Patterns.Saga;

namespace RepositoryInterfaces.Patterns.Saga
{
    public interface ISagaResolverRegistry
    {
        ISagaHandlerResolver Resolve(SagaBase saga);
    }
}
