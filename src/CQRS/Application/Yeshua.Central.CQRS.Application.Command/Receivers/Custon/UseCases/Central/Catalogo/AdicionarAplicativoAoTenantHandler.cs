// <yeshua>
// artifact: DSL_SEEDED_CUSTOM_OWNED_BY_DEV
// createdBy: DSL
// ownership: IA_DEV
// editable: true
// regeneration: NEVER_OVERWRITE
// sourceOfTruth: THIS_FILE
// generator: Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
// </yeshua>

//scope;
using Dominio.Interfaces;
using Aplication.Interfaces.Services;
using RepositoryInterfaces.Patterns.Command;
using RepositoryInterfaces.Patterns.UnitOfWork;
using IRepository.Read;
using IRepository.Write;
using Command.UseCase;
using Dominio.Entitys;

namespace Command.Receivers.UseCase
{
    public partial class AdicionarAplicativoAoTenantHandler
    {
        private readonly IUnitOfWork _unitOfWork = default!;
        private readonly IDomainTrackingPolicy _domainTrackingPolicy = default!;
        private readonly IyTenantReadRepository _repReadyTenant = default!;
        private readonly ITenantCatalogoReadRepository _repReadTenantCatalogo = default!;
        private readonly ITenantCatalogoWriteRepository _repWriteTenantCatalogo = default!;
        public AdicionarAplicativoAoTenantHandler(IUnitOfWork unitOfWork,ILogger logger,IExecutionContext executionContext,IDomainTrackingPolicy domainTrackingPolicy,IyTenantReadRepository repReadyTenant,ITenantCatalogoReadRepository repReadTenantCatalogo,ITenantCatalogoWriteRepository repWriteTenantCatalogo)
            : base(logger, executionContext)
        {
           _unitOfWork = unitOfWork;
           _logger = logger;
           _executionContext = executionContext;
            _domainTrackingPolicy = domainTrackingPolicy;
            _repReadyTenant = repReadyTenant;
            _repReadTenantCatalogo = repReadTenantCatalogo;
            _repWriteTenantCatalogo = repWriteTenantCatalogo;
        }
protected partial Task<State<AdicionarAplicativoAoTenantOutputCommand>> CustomActionHookAsync(State<AdicionarAplicativoAoTenantOutputCommand> state, AdicionarAplicativoAoTenantInputCommand comand, CancellationToken cancellationToken)
{
    var application = comand.Aplicativo?.Trim() ?? string.Empty;
    if (string.IsNullOrWhiteSpace(application) || application.Length > 100 ||
        application.Equals("Central", StringComparison.OrdinalIgnoreCase))
        throw new ReceiverException<AdicionarAplicativoAoTenantOutputCommand>(
            Error("Catalogo invalido.", default));

    var tenant = _repReadyTenant.FirstById(_executionContext.TenantID);
    if (tenant is null || tenant.userid != _executionContext.UserId)
        throw new ReceiverException<AdicionarAplicativoAoTenantOutputCommand>(
            Error("Somente o proprietario do tenant pode adicionar aplicativos.", default));

    var tenantCatalogs = _repReadTenantCatalogo.GetAllByTenantID(_executionContext.TenantID)
        .Where(item => item.validuntil >= DateTime.UtcNow)
        .Select(item => item.catalogo)
        .Where(item => !string.IsNullOrWhiteSpace(item))
        .ToHashSet(StringComparer.OrdinalIgnoreCase);

    if (!tenantCatalogs.Contains(application))
    {
        try
        {
            _unitOfWork.BeginTran();
            var catalog = new TenantCatalogoFactory(_logger, _domainTrackingPolicy)
                .Create(null, application, DateTime.UtcNow.AddYears(100));
            catalog.TenantID = _executionContext.TenantID;
            catalog.UserId = _executionContext.UserId;
            _repWriteTenantCatalogo.Insert(catalog);
            _unitOfWork.Commit();
            tenantCatalogs.Add(application);
        }
        catch
        {
            _unitOfWork.Rollback();
            throw;
        }
    }

    state = Success("Aplicativo adicionado ao tenant.", new AdicionarAplicativoAoTenantOutputCommand
    {
        Adicionado = true,
        Aplicativo = application,
        Catalogos = new[] { "Central" }
            .Concat(tenantCatalogs)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList()
    });
    return Task.FromResult(state);
}
    }
}
//Dominio.Schemas.CQRS.SourceCodeAplicationHandlesAndResolvers
