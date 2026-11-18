using System.Security.Claims;

namespace RepositoryInterfaces.Commercial;

public interface ICommercialTokenIssuer
{
    string Issue(IReadOnlyList<Claim> identityClaims, IReadOnlyList<Dominio.Commercial.UsageRight> rights);
}
