using Aplication.Interfaces.Services;
using Command.UseCase;
using Dominio.Commercial;
using IRepository.Read;
using Repositorio.Outputs;
using RepositoryInterfaces.Commercial.Central;

namespace Command.Authentication;

// The same resolver is used by conventional login and OAuth issuance/renewal.
// Profile tables do not currently participate in this login path. Do not invent
// a profile/grant resolver here or turn OAuth scopes into business permissions.
public sealed class CentralLoginSessionReader(IyUserReadRepository users, IyTenantReadRepository tenants,
    IyTenantApplicationReadRepository applications, IFinanceiroRepository finance, IExecutionContext context)
{
    public LoginOutputCommand? Resolve(int userId, int tenantId)
    {
        var user = users.FirstById(userId, true);
        return user is null || user.tenantid != tenantId ? null : Resolve(user);
    }
    public LoginOutputCommand? Resolve(yUserDTO user)
    {
        if (user.deleted || user.id <= 0 || user.tenantid <= 0) return null;
        context.SetTenantId(user.tenantid);
        var tenant = tenants.FirstById(user.tenantid, true);
        if (tenant is null || tenant.deleted) return null;
        var now = DateTime.UtcNow;
        return new LoginOutputCommand
        {
            modulos = [],
            catalogos = new[] { "Central" }.Concat(applications.GetAllByTenantID(user.tenantid)
                .Where(app => !app.deleted && app.validuntil >= now).Select(app => app.applicationkey))
                .Where(app => !string.IsNullOrWhiteSpace(app)).Distinct(StringComparer.OrdinalIgnoreCase).ToList(),
            UserId = user.id, tenantId = user.tenantid, email = user.email, userName = user.nome,
            tenantDocument = tenant.cnpjcpf, tenantName = tenant.nome,
            UsageRights = UsageRightClaims.Write(finance.ReadRights(user.tenantid))
        };
    }
}
