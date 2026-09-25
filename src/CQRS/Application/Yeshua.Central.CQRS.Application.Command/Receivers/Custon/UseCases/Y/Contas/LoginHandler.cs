// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;

namespace Command.Receivers.UseCase
{
    public partial class LoginHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyUserReadRepository _repReadyUser = default!;
        private readonly IyUserWriteRepository _repWriteyUser = default!;
        private readonly ITenantCatalogoReadRepository _repReadTenantCatalogo = default!;
        private readonly IyTenantReadRepository _repReadTenant = default!;
        public LoginHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IyUserReadRepository repReadyUser, IyUserWriteRepository repWriteyUser,ITenantCatalogoReadRepository repReadTenantCatalogo,IyTenantReadRepository repReadTenant)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
           _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyUser = repReadyUser;
            _repWriteyUser = repWriteyUser;
            _repReadTenantCatalogo = repReadTenantCatalogo;
            _repReadTenant = repReadTenant;
        }
protected partial Task<State<LoginOutputCommand>> CustomActionHookAsync(State<LoginOutputCommand> state, LoginInputCommand comand, CancellationToken cancellationToken)
{
    var user = _repReadyUser.FirstByEmail(comand.email, true);
    if (user == null || user.senha != comand.password)
        throw new ReceiverException<LoginOutputCommand>(Error("Login invalido.", default));

    _executionContext.SetTenantId(user.tenantid);

    var now = DateTime.UtcNow;
    var catalogs = new[] { "Central" }
        .Concat(_repReadTenantCatalogo.GetAllByTenantID(user.tenantid)
            .Where(catalog => catalog.validuntil >= now)
            .Select(catalog => catalog.catalogo))
        .Where(catalog => !string.IsNullOrWhiteSpace(catalog))
        .Distinct(StringComparer.OrdinalIgnoreCase)
        .ToList();

    state = Success("Login valido", new LoginOutputCommand
    {
        modulos = new List<string>(),
        catalogos = catalogs,
        tenantId = user.tenantid,
        email = user.email,
        UserId = user.id
    });
    return Task.FromResult(state);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
